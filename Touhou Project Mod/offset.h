#pragma once


// ������ħ�� Offset


// ���������� Offset, Touhou Seirensen Offset
// ����ƫ��
// const DWORD Graze_Offset = 0x00B0CDC;
const uintptr_t Seirensen_SpeelCard_Offset = 0x00B0CA0;
const uintptr_t Seirensen_Humans_Offset = 0x00B0C98;
// ʵ���õ���
// sub [0x00B0C98] -> nop 7 8 9 a b c  0x004381E7
const uintptr_t Seirensen_Func_Sub_Humans_Offset = 0x00381E7;
// mov [004B0CA0],eax -> nop 8 9 a b c
const uintptr_t Seirensen_Func_Sub_SpeelCard_Offset = 0x0022F28;

// ����ƫ��
//  mov ebx,00000001 -> mov ebx,0000000A
const uintptr_t Seirensen_Func_RePlay_SpeelCard_Humans_Offset = 0x0021D3C;
// mov [004B0C98],ebx -> nop 1 2 3 4 5 6
const uintptr_t Seirensen_Func_RePlay_Humans_Offset = 0x0021E81;
// mov [004B0CA0],ebx ->  nop f 0 1 2 3 4
const uintptr_t Seirensen_Func_RePlay_SpeelCard_Offset = 0x0021DEF;


// mov [eax+60],00000002 - > nop 0 1 2 3 4 5 6
const uintptr_t Seirensen_Func_Dead_SpeelCard_Offset = 0x0022F60;

// unknow
const uintptr_t Seirensen_Func_InvincibleState_Offset = 0x00;
// 0x0048B363
const uintptr_t Seirensen_Func_RefreshUI_Offset = 0x008B363;