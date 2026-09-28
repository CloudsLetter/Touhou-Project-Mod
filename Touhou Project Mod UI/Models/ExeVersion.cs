using System;
using Touhou_Project_Mod_UI.SDK.Native;

namespace Touhou_Project_Mod_UI.Models
{
    public static class ExeVersion
    {
        private const int LfanewOffset = 0x3C;

        private const int FileHeaderSize = 20;

        private const int SectionHeaderSize = 40;

        private const uint PeSignature = 0x0000_4550;

        public static bool TryRead(IntPtr processHandle, IntPtr moduleBaseAddress,
            out uint timeStamp, out uint textSize)
        {
            timeStamp = 0;
            textSize = 0;

            if (processHandle == IntPtr.Zero || moduleBaseAddress == IntPtr.Zero)
            {
                return false;
            }

            if (!TryReadUInt32(processHandle, moduleBaseAddress + LfanewOffset, out uint ntHeaderOffset)
                || ntHeaderOffset == 0)
            {
                return false;
            }

            IntPtr ntHeader = moduleBaseAddress + (int)ntHeaderOffset;
            if (!TryReadUInt32(processHandle, ntHeader, out uint signature) || signature != PeSignature)
            {
                return false;
            }

            IntPtr fileHeader = ntHeader + 4;

            if (!TryReadUInt32(processHandle, fileHeader + 4, out timeStamp)
                || timeStamp == 0)
            {
                return false;
            }

            if (!TryReadUInt16(processHandle, fileHeader + 2, out ushort numberOfSections)
                || !TryReadUInt16(processHandle, fileHeader + 16, out ushort sizeOfOptionalHeader)
                || numberOfSections == 0)
            {
                return false;
            }

            IntPtr sectionTable = fileHeader + FileHeaderSize + sizeOfOptionalHeader;

            byte[] sectionName = new byte[8];
            for (int i = 0; i < numberOfSections; i++)
            {
                IntPtr section = sectionTable + i * SectionHeaderSize;
                if (!Memory.TryReadMemory(processHandle, section, sectionName))
                {
                    return false;
                }

                if (!IsTextSection(sectionName))
                {
                    continue;
                }

                return TryReadUInt32(processHandle, section + 16, out textSize) && textSize != 0;
            }

            return false;
        }

        private static bool IsTextSection(byte[] name)
        {
            return name[0] == (byte)'.'
                && name[1] == (byte)'t'
                && name[2] == (byte)'e'
                && name[3] == (byte)'x'
                && name[4] == (byte)'t'
                && name[5] == 0;
        }

        private static bool TryReadUInt32(IntPtr processHandle, IntPtr address, out uint value)
        {
            byte[] buffer = new byte[4];
            value = 0;

            if (!Memory.TryReadMemory(processHandle, address, buffer))
            {
                return false;
            }

            value = BitConverter.ToUInt32(buffer, 0);
            return true;
        }

        private static bool TryReadUInt16(IntPtr processHandle, IntPtr address, out ushort value)
        {
            byte[] buffer = new byte[2];
            value = 0;

            if (!Memory.TryReadMemory(processHandle, address, buffer))
            {
                return false;
            }

            value = BitConverter.ToUInt16(buffer, 0);
            return true;
        }
    }
}
