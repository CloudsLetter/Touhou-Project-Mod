using System;
using System.Diagnostics;

namespace Touhou_Project_Mod_UI.Models
{
    /// <summary>
    /// 一条代码补丁：把「模块基址 + Offset」处的 Value.Length 个字节覆盖成 Value。
    ///
    /// Original 不硬编码，而是在首次启用前从目标进程读回并缓存，关闭时用它还原。
    /// 这样做的好处是：
    ///   - 不需要为每个版本事先准备好原始字节；
    ///   - 即使游戏版本与预期略有出入，关闭时也能原样还原，不会写坏代码段。
    /// </summary>
    public sealed class CodePatch
    {
        /// <summary>相对模块基址的偏移（运行时用模块基址 + 该值定位）。</summary>
        public readonly IntPtr Offset;

        /// <summary>启用时写入的字节。</summary>
        public readonly byte[] Value;

        /// <summary>首次启用前读回的原始字节；为 null 表示尚未捕获。</summary>
        public byte[] Original;

        /// <summary>字面量校验结果。false 的补丁会被 Patcher 拒绝执行，不会写内存。</summary>
        public readonly bool IsValid;

        public CodePatch(int offset, byte[] value)
        {
            Offset = new IntPtr(offset);
            Value = value ?? Array.Empty<byte>();

            if (offset <= 0)
            {
                Debug.WriteLine($"[CodePatch] 非法偏移 0x{offset:X}：0 或负数会落到 PE 头，已拒绝。");
            }
            else if (Value.Length == 0)
            {
                Debug.WriteLine($"[CodePatch] 0x{offset:X} 的补丁字节为空，已拒绝。");
            }
            else
            {
                IsValid = true;
            }
        }

        /// <summary>
        /// 以十六进制字符串书写补丁字节，便于与反汇编结果逐字节对照。
        /// </summary>
        public CodePatch(int offset, string hex) : this(offset, HexToBytes(hex))
        {
        }

        public static CodePatch Nop(int offset, int count)
        {
            if (count <= 0)
            {
                Debug.WriteLine($"[CodePatch] NOP 长度非法：{count}");
                return new CodePatch(offset, Array.Empty<byte>());
            }

            byte[] value = new byte[count];
            for (int i = 0; i < count; i++)
            {
                value[i] = 0x90;
            }

            return new CodePatch(offset, value);
        }

        private static byte[] HexToBytes(string hex)
        {
            if (string.IsNullOrEmpty(hex) || (hex.Length & 1) != 0)
            {
                Debug.WriteLine($"[CodePatch] 十六进制串长度非法：\"{hex}\"");
                return Array.Empty<byte>();
            }

            byte[] result = new byte[hex.Length / 2];
            for (int i = 0; i < result.Length; i++)
            {
                if (!byte.TryParse(hex.AsSpan(i * 2, 2), System.Globalization.NumberStyles.HexNumber,
                        System.Globalization.CultureInfo.InvariantCulture, out result[i]))
                {
                    Debug.WriteLine($"[CodePatch] 十六进制串含非法字符：\"{hex}\"");
                    return Array.Empty<byte>();
                }
            }
            return result;
        }
    }
}
