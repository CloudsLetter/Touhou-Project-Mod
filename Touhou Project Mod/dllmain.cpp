// dllmain.cpp : 定义 DLL 应用程序的入口点。
#include "pch.h"
#include"offset.h"
#include"define.h"
//


uintptr_t BaseAddress;
uintptr_t HumansAddress;
uintptr_t SpeelCardAddress;

PVOID ExceptionHandler;

bool Lock_Seirensen_SpeelCard = false;
bool Lock_Seirensen_Humans = false;
bool Func_InvincibleState = false;

bool Hook_Seirensen_SpeelCard = false;
bool Hook_Seirensen_Humans = false;

// ARR
uint8_t SeirensenHumans[6];
uint8_t SeirensenSpeelCard[5];



BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
        BaseAddress = reinterpret_cast<uintptr_t>(GetModuleHandle(NULL));
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}


int GetLength(int part, int method) {

    switch (part)
    {
    case TOUHOU_SEIRENSEN:
        if (method == FUNC_HUMANS) {
            return 0x06;
        }
        else if (method == FUNC_SPEELCARD) {
            return 0x05;
        }
    default:
        break;
    }

    return NULL;
}


uintptr_t GetOffset(int part,int method) {

    switch (part)
    {
     case TOUHOU_SEIRENSEN:
        if (method == HUMANS) {
            return Seirensen_Humans_Offset;
        }
        else if (method == SPEELCARD) {
            return Seirensen_SpeelCard_Offset;
        }
        else if (method == FUNC_HUMANS) {
            return Seirensen_Func_Sub_Humans_Offset;
        }
        else if (method == FUNC_SPEELCARD)
        {
            return Seirensen_Func_Sub_SpeelCard_Offset;
        }
    default:
        break;
    }

    return NULL;
}

void SaveOriginalBytes(uintptr_t targetAdress, int part,int method, int lenght) {
    switch (part) {
    case TOUHOUPROJECTMOD_EXPORTS:
        if (method == FUNC_HUMANS) {
            memcpy(SeirensenHumans, reinterpret_cast<void*>(targetAdress), lenght);

        }else 
        if (method == FUNC_SPEELCARD) {
            memcpy(SeirensenSpeelCard, reinterpret_cast<void*>(targetAdress), lenght);

        }
    default:
        break;
    }

}


bool SetMemoryHook(uintptr_t targetAdress) {
    DWORD oldProtect;
    if (!VirtualProtect((LPVOID)targetAdress, sizeof(BYTE), PAGE_NOACCESS, &oldProtect)) {
        return false;
    }
    return true;
}

bool RemoveMemoryHook(uintptr_t targetAdress) {
    DWORD oldProtect;
    if (!VirtualProtect((LPVOID)targetAdress, sizeof(BYTE), PAGE_EXECUTE_READWRITE, &oldProtect)) {
        return false;
    }
    return true;
}


LONG WINAPI VectoredHandler(PEXCEPTION_POINTERS pExceptionInfo) {
    if (pExceptionInfo->ExceptionRecord->ExceptionCode == EXCEPTION_ACCESS_VIOLATION) {
        DWORD_PTR address = pExceptionInfo->ExceptionRecord->ExceptionInformation[1];

        if (Hook_Seirensen_Humans) {
            if (address == HumansAddress) {
                DWORD oldProtect;
                //VirtualProtect((LPVOID)HumansAddress, sizeof(BYTE), PAGE_EXECUTE_READWRITE, &oldProtect);
                //*(BYTE*)HumansAddress = 0x0A;
                //SetMemoryHook(HumansAddress);
                pExceptionInfo->ContextRecord->Eip += 1;
                return EXCEPTION_CONTINUE_EXECUTION;
            }
        }

        if(Hook_Seirensen_SpeelCard){
        if (address == SpeelCardAddress) {
            DWORD oldProtect;
            //VirtualProtect((LPVOID)SpeelCardAddress, sizeof(BYTE), PAGE_EXECUTE_READWRITE, &oldProtect);
            //*(BYTE*)SpeelCardAddress = 0x0A;
            //SetMemoryHook(SpeelCardAddress); 
            pExceptionInfo->ContextRecord->Eip += 1;
            return EXCEPTION_CONTINUE_EXECUTION;
        }
        }
    }

    return EXCEPTION_CONTINUE_SEARCH;
}
bool SetMemoryValue(uintptr_t targetAdress, int value) {
    DWORD oldProtect;
    if (!VirtualProtect(reinterpret_cast<void*>(targetAdress), sizeof(int), PAGE_EXECUTE_READWRITE, &oldProtect)) {
        return false;
    }
    *reinterpret_cast<int*>(targetAdress) = value;
    if (!VirtualProtect(reinterpret_cast<void*>(targetAdress), sizeof(int), oldProtect, &oldProtect)) {
        return false;
    }
    return true;
}

extern "C" __declspec(dllexport) bool SetHumans(int part,int humans) {
    uintptr_t targetAdress = BaseAddress + GetOffset(part,HUMANS);
    if (!targetAdress) {
        return false;
    }
    if(!HumansAddress)
        HumansAddress = targetAdress;
    if (!SetMemoryValue(targetAdress,humans)) {
        return false;
    }
    return true;
}

extern "C" __declspec(dllexport) bool SetSpeelCard(int part, int speelcards) {

    uintptr_t targetAdress = BaseAddress + GetOffset(part, SPEELCARD);
    if (!targetAdress) {
        return false;
    }
    if(!SpeelCardAddress)
        SpeelCardAddress = targetAdress;

    if (!SetMemoryValue(targetAdress, speelcards)) {
        return false;
    }
    return true;
}

extern "C" __declspec(dllexport) bool LockHumans(int part) {
    if (Lock_Seirensen_Humans)
        return true;
    uintptr_t targetAdress = BaseAddress + GetOffset(part, FUNC_HUMANS);
    if (!targetAdress) {
        return false;
    }
    if (!HumansAddress)
        HumansAddress = targetAdress;


    DWORD oldProtect;
    if (!VirtualProtect(reinterpret_cast<void*>(targetAdress), GetLength(part, FUNC_HUMANS), PAGE_EXECUTE_READWRITE, &oldProtect)) {
        return false;
    }
    memset(reinterpret_cast<void*>(targetAdress), 0x90, GetLength(part, FUNC_HUMANS));

    if (!VirtualProtect(reinterpret_cast<void*>(targetAdress), GetLength(part, FUNC_HUMANS), oldProtect, &oldProtect)) {
        return false;
    }
    Lock_Seirensen_Humans = true;
    return true;
}

extern "C" __declspec(dllexport) bool LockSpeelCard(int part) {
    if (Lock_Seirensen_SpeelCard)
        return true;
    uintptr_t targetAdress = BaseAddress + GetOffset(part, FUNC_SPEELCARD);
    if (!targetAdress) {
        return false;
    }
    if (!SpeelCardAddress)
        SpeelCardAddress = targetAdress;
    SaveOriginalBytes(targetAdress, part, FUNC_SPEELCARD, GetLength(part, FUNC_SPEELCARD));


    DWORD oldProtect;
    if (!VirtualProtect(reinterpret_cast<void*>(targetAdress), GetLength(part, FUNC_SPEELCARD), PAGE_EXECUTE_READWRITE, &oldProtect)) {
        return false;
    }
    memset(reinterpret_cast<void*>(targetAdress), 0x90, GetLength(part, FUNC_SPEELCARD));

    if (!VirtualProtect(reinterpret_cast<void*>(targetAdress), GetLength(part, FUNC_SPEELCARD), oldProtect, &oldProtect)) {
        return false;
    }
    Lock_Seirensen_SpeelCard = true;
    return true;
}




extern "C" __declspec(dllexport) bool UnlockHumans(int part) {
    if (!Lock_Seirensen_Humans)
        return true;
    uintptr_t targetAdress = BaseAddress + GetOffset(part, FUNC_HUMANS);
    if (!targetAdress) {
        return false;
    }
    if (!HumansAddress)
        HumansAddress = targetAdress;
    DWORD oldProtect;
    if (!VirtualProtect(reinterpret_cast<void*>(targetAdress), GetLength(part, FUNC_HUMANS), PAGE_EXECUTE_READWRITE, &oldProtect)) {
        return false;
    }
    memcpy(reinterpret_cast<void*>(targetAdress), SeirensenHumans, GetLength(part, FUNC_HUMANS));

    if (!VirtualProtect(reinterpret_cast<void*>(targetAdress), GetLength(part, FUNC_HUMANS), oldProtect, &oldProtect)) {
        return false;
    }
    Lock_Seirensen_Humans = false;
    return true;
}

extern "C" __declspec(dllexport) bool UnlockSpeelCard(int part) {
    if (!Lock_Seirensen_SpeelCard)
        return true;
    uintptr_t targetAdress = BaseAddress + GetOffset(part, FUNC_SPEELCARD);

    if (!targetAdress) {
        return false;
    }
    if (!SpeelCardAddress)
        SpeelCardAddress = targetAdress;
    DWORD oldProtect;
    if (!VirtualProtect(reinterpret_cast<void*>(targetAdress), GetLength(part, FUNC_SPEELCARD), PAGE_EXECUTE_READWRITE, &oldProtect)) {
        return false;
    }
    memcpy(reinterpret_cast<void*>(targetAdress), SeirensenSpeelCard, GetLength(part, FUNC_SPEELCARD));

    if (!VirtualProtect(reinterpret_cast<void*>(targetAdress), GetLength(part, FUNC_SPEELCARD), oldProtect, &oldProtect)) {
        return false;
    }
    Lock_Seirensen_SpeelCard = false;
    return true;
}





extern "C" __declspec(dllexport) bool HookHumans(int part) {
    if (Hook_Seirensen_Humans)
        return true;
    uintptr_t targetAdress = BaseAddress + GetOffset(part, HUMANS);
    if (targetAdress)
        return false;
    if (!HumansAddress)
        HumansAddress = targetAdress;
    SetMemoryHook(targetAdress);
    if (!Hook_Seirensen_Humans && !Hook_Seirensen_SpeelCard) {
        ExceptionHandler =  AddVectoredExceptionHandler(1, VectoredHandler);
    }
    Hook_Seirensen_Humans = true;
    return true;
}


extern "C" __declspec(dllexport) bool HookSpeelCard(int part) {
    if (Hook_Seirensen_SpeelCard)
        return true;
    uintptr_t targetAdress = BaseAddress + GetOffset(part, SPEELCARD);
    if (targetAdress)
        return false;
    if (!SpeelCardAddress)
        SpeelCardAddress = targetAdress;
    SetMemoryHook(targetAdress);
    if (!Hook_Seirensen_Humans && !Hook_Seirensen_SpeelCard) {
        ExceptionHandler = AddVectoredExceptionHandler(1, VectoredHandler);
    }
    Hook_Seirensen_SpeelCard = true;
    return true;
}




extern "C" __declspec(dllexport) bool UninstallHookHumans(int part) {
    if (!Hook_Seirensen_Humans)
        return true;
    uintptr_t targetAdress = BaseAddress + GetOffset(part, HUMANS);
    if (!targetAdress) {
        return false;
    }

    RemoveMemoryHook(targetAdress);
    Hook_Seirensen_Humans = false;

    if (!Hook_Seirensen_Humans && !Hook_Seirensen_SpeelCard) {
        RemoveVectoredExceptionHandler(ExceptionHandler);
    }
    return true;
}


extern "C" __declspec(dllexport) bool UninstallHookSpeelCard(int part) {
    if (!Hook_Seirensen_SpeelCard)
        return true;

    uintptr_t targetAdress = BaseAddress + GetOffset(part, SPEELCARD);
    RemoveMemoryHook(targetAdress);
    Hook_Seirensen_SpeelCard = false;

    if (!Hook_Seirensen_Humans && !Hook_Seirensen_SpeelCard) {
        RemoveVectoredExceptionHandler(ExceptionHandler);
    }

    return true;
}



extern "C" _declspec(dllexport) bool EnableV(int part){
    uintptr_t targetAdress = BaseAddress + GetOffset(part, SPEELCARD);
    return true;
}