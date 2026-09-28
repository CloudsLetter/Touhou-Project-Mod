using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Touhou_Project_Mod_UI.Models;

namespace Touhou_Project_Mod_UI.SDK.Native;

public static class Memory
{

    public static bool SetMemory(IntPtr processHandle, IntPtr targetAddress, byte[] value)
    {
        uint oldProtect;

        if (!Win32.VirtualProtectEx(processHandle,targetAddress, (uint)value.Length, Win32Offset.PAGE_EXECUTE_READWRITE, out oldProtect))
        {
/*            var e = Win32.GetLastError();*/
            return false;
        }


            if (!Win32.WriteProcessMemory(processHandle, targetAddress, value, (uint)value.Length, out _))
            {
                return false;
            }

        if (!Win32.VirtualProtectEx(processHandle,targetAddress, (uint)value.Length, oldProtect, out _))
        {
            return false;
        }

        return true;
    }




    /// <summary>
    /// 读取目标进程内存到调用方提供的缓冲区。用于在打补丁前捕获原始字节。
    /// </summary>
    public static bool TryReadMemory(IntPtr processHandle, IntPtr targetAddress, byte[] buffer)
    {
        if (processHandle == IntPtr.Zero || buffer.Length == 0)
        {
            return false;
        }

        if (!Win32.ReadProcessMemory(processHandle, targetAddress, buffer, (uint)buffer.Length, out uint bytesRead))
        {
            return false;
        }

        return bytesRead == buffer.Length;
    }




    public static bool IsTouhouRun(string processName)
    {
        Process[] processes = Process.GetProcessesByName(processName);
        if (processes.Length == 0)
        {
            return false;
        }
        return true;
    }

    public static (IntPtr, IntPtr) GetBaseAddressWithProcvessHandle(string processName)
    {
        Process[] processes = Process.GetProcessesByName(processName);
        if (processes.Length == 0)
        {
            Console.WriteLine("目标进程未找到。");
            return (IntPtr.Zero, IntPtr.Zero);
        }
        Process targetProcess = processes[0];

        IntPtr processHandle = Win32.OpenProcess(Win32Offset.PROCESS_ALL_ACCESS, false, targetProcess.Id);

        try
        {
            return (targetProcess.MainModule.BaseAddress, processHandle);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"读取 {processName} 模块基址失败：{ex.Message}");
            return (IntPtr.Zero, IntPtr.Zero);
        }
    }

    public static IntPtr LocateRealPtr(IntPtr handle, IntPtr baseAddress, IntPtr offset, IntPtr soffset)
    {
        byte[] buffer = new byte[4];

        IntPtr targetAddress = baseAddress + offset;

        // 从目标地址读取内存内容
        if (!Win32.ReadProcessMemory(handle, targetAddress, buffer, (uint)buffer.Length, out _))
        {
            return IntPtr.Zero;
        }

        IntPtr currentAddress = (IntPtr)(BitConverter.ToUInt32(buffer, 0) + soffset);

        return currentAddress;
    }

}

// 致敬传奇调试代码
//            if (status.Chireiden_Sub_Plyaer_Value_Default.Length != 0)
//            {
//                Debug.WriteLine("\nChireiden_Sub_Plyaer_Value_Default:");
//                Debug.WriteLine(BitConverter.ToString(status.Chireiden_Sub_Plyaer_Value_Default).Replace("-", ", 0x"));
//            }
//            if (status.BombOriginalBytes.Length != 0)
//{
//    Debug.WriteLine("\nBombOriginalBytes:");
//    Debug.WriteLine(BitConverter.ToString(status.BombOriginalBytes).Replace("-", ", 0x"));
//}
//if (status.PowerOriginalBytes.Length != 0)
//{
//    Debug.WriteLine("\nPowerOriginalBytes:");
//    Debug.WriteLine(BitConverter.ToString(status.PowerOriginalBytes).Replace("-", ", 0x"));
//}
////if (status.PowerOriginalBytes2.Length != 0)
////{
////    Debug.WriteLine("\nPowerOriginalBytes2:");
////    Debug.WriteLine(BitConverter.ToString(status.PowerOriginalBytes2).Replace("-", ", 0x"));
////}
////if (status.InvincibleOriginalBytes.Length != 0)
////{
////    Debug.WriteLine("\nInvincibleOriginalBytes:");
////    Debug.WriteLine(BitConverter.ToString(status.InvincibleOriginalBytes).Replace("-", ", 0x"));
////}