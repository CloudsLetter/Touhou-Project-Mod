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


    public static bool SaveWithLoadOriginalBytes(IntPtr processHandle, IntPtr targetAddress, byte[] value, uint length ,uint func, bool set, Status status, uint powernums)
    {

        if (func == Globals.PLAYEROB && set)
        {
            if (!Win32.ReadProcessMemory(processHandle, targetAddress, status.PlayersOriginalBytes, length, out uint bytesRead) || bytesRead != (uint)length)
            {
                return false;
            }
            {
                if (!Win32.WriteProcessMemory(processHandle, targetAddress, value, (uint)status.PlayersOriginalBytes.Length, out _))
                {
                    return false;
                }
            }

            return true;
        } 
        else if(func == Globals.PLAYEROB && !set)
        {
            if (!Win32.WriteProcessMemory(processHandle, targetAddress, value, (uint)status.PlayersOriginalBytes.Length, out _))
            {
                return false;
            }
        }

        if (func == Globals.BOMBOB && set)
        {
            if (!Win32.ReadProcessMemory(processHandle, targetAddress, status.BombOriginalBytes, length, out uint bytesRead) || bytesRead != length)
            {
                return false;
            }

                if (!Win32.WriteProcessMemory(processHandle, targetAddress, value, (uint)status.BombOriginalBytes.Length, out _))
                {
                    return false;
                }


            return true;
        }
        else if (func == Globals.BOMBOB && !set)
        {
            if (!Win32.WriteProcessMemory(processHandle, targetAddress, value, (uint)status.BombOriginalBytes.Length, out _))
            {
                return false;
            }
        }


        if (func == Globals.POWEROB && set)
        {

            if (powernums == 0x00)
            {
                if (!Win32.ReadProcessMemory(processHandle, targetAddress, status.PowerOriginalBytes, length, out uint bytesRead) || bytesRead != length)
                {
                    return false;
                }
                if (!Win32.WriteProcessMemory(processHandle, targetAddress, value, (uint)status.PowerOriginalBytes.Length, out _))
                {
                    return false;
                }
            }


            if (powernums == 0x01)
            {
                if (!Win32.ReadProcessMemory(processHandle, targetAddress, status.PowerOriginalBytes2, length, out uint bytesRead) || bytesRead != length)
                {
                    return false;
                }
                if (!Win32.WriteProcessMemory(processHandle, targetAddress, value, (uint)status.PowerOriginalBytes2.Length, out _))
                {
                    return false;
                }
            }

            return true;
        }
        else if (func == Globals.POWEROB && !set)
        {
            if (powernums == 0x00)
            {
                if (!Win32.WriteProcessMemory(processHandle, targetAddress, value, (uint)status.PowerOriginalBytes.Length, out _))
                {
                    return false;
                }
            }

            if (powernums == 0x01)
            {
                if (!Win32.WriteProcessMemory(processHandle, targetAddress, value, (uint)status.PowerOriginalBytes2.Length, out _))
                {
                    return false;
                }
            }
        }

        if (func == Globals.INVINCIBLEOB && set)
        {
            if (!Win32.ReadProcessMemory(processHandle, targetAddress, status.InvincibleOriginalBytes, length, out uint bytesRead) || bytesRead != length)
            {
                return false;
            }

                if (!Win32.WriteProcessMemory(processHandle, targetAddress, value, (uint)status.InvincibleOriginalBytes.Length, out _))
                {
                    return false;
                }

            return true;
        }
        else if (func == Globals.INVINCIBLEOB && !set)
        {
            if (!Win32.WriteProcessMemory(processHandle, targetAddress, value, (uint)status.InvincibleOriginalBytes.Length, out _))
            {
                return false;
            }
        }


        return true;
    }


    public static bool SetMemory(IntPtr processHandle, IntPtr targetAddress, byte[] value, bool set, uint type, Status status, uint powernums)
    {
        uint oldProtect;

        if (!Win32.VirtualProtectEx(processHandle,targetAddress, (uint)value.Length, Win32Offset.PAGE_EXECUTE_READWRITE, out oldProtect))
        {
/*            var e = Win32.GetLastError();*/
            return false;
        }

        if (type != Globals.SETVALUE)
        {
            if (!SaveWithLoadOriginalBytes(processHandle, targetAddress, value,(uint)value.Length, type, set, status,powernums))
            {
                return false;
            }
        }

        if (type == Globals.SETVALUE)
        {
            if (!Win32.WriteProcessMemory(processHandle, targetAddress, value, (uint)value.Length, out _))
            {
                return false;
            }
        }

        if (!Win32.VirtualProtectEx(processHandle,targetAddress, (uint)value.Length, oldProtect, out _))
        {
            return false;
        }

        return true;
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

        return (targetProcess.MainModule.BaseAddress, processHandle);
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
