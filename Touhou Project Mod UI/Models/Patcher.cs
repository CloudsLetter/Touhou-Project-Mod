using System;
using System.Diagnostics;
using Touhou_Project_Mod_UI.SDK.Native;

namespace Touhou_Project_Mod_UI.Models
{
    /// <summary>
    /// 把一组 <see cref="CodePatch"/> 应用/还原到目标进程。
    ///
    /// 启用流程：先把尚未捕获的原始字节逐个读回并缓存 → 再逐个写入补丁字节；
    ///           中途任一步失败，已写入的部分立刻还原，并返回 false。
    /// 关闭流程：逐个写回缓存的原始字节。
    ///
    /// 这样即使某个地址写失败，也不会让游戏停在「一半打补丁」的状态。
    /// </summary>
    public static class Patcher
    {
        public static bool Apply(IntPtr processHandle, IntPtr baseAddress, CodePatch[] patches, bool enable)
        {
            if (processHandle == IntPtr.Zero || baseAddress == IntPtr.Zero || patches == null || patches.Length == 0)
            {
                return false;
            }

            foreach (CodePatch patch in patches)
            {
                if (!patch.IsValid)
                {
                    Debug.WriteLine($"[Patcher] 补丁表含非法条目（偏移 0x{patch.Offset.ToInt64():X}），已整组拒绝。");
                    return false;
                }
            }

            return enable
                ? Enable(processHandle, baseAddress, patches)
                : Disable(processHandle, baseAddress, patches);
        }

        private static bool Enable(IntPtr processHandle, IntPtr baseAddress, CodePatch[] patches)
        {
            // 1) 捕获原始字节。必须在写补丁之前完成，否则读到的就是补丁本身。
            foreach (CodePatch patch in patches)
            {
                if (patch.Original != null)
                {
                    continue;
                }

                byte[] original = new byte[patch.Value.Length];
                if (!Memory.TryReadMemory(processHandle, Target(baseAddress, patch), original))
                {
                    Debug.WriteLine($"[Patcher] 读取原始字节失败（偏移 0x{patch.Offset.ToInt64():X}），本次启用取消。");
                    return false;
                }

                patch.Original = original;
            }

            // 2) 写入补丁字节，失败则回滚已写部分。
            for (int i = 0; i < patches.Length; i++)
            {
                if (!Memory.SetMemory(processHandle, Target(baseAddress, patches[i]), patches[i].Value))
                {
                    Debug.WriteLine($"[Patcher] 写入补丁失败（偏移 0x{patches[i].Offset.ToInt64():X}），正在回滚。");
                    for (int j = 0; j < i; j++)
                    {
                        Memory.SetMemory(processHandle, Target(baseAddress, patches[j]), patches[j].Original!);
                    }
                    return false;
                }
            }

            return true;
        }

        private static bool Disable(IntPtr processHandle, IntPtr baseAddress, CodePatch[] patches)
        {
            bool allOk = true;

            foreach (CodePatch patch in patches)
            {
                // 从未启用过就没有原始字节可还原，跳过即可。
                if (patch.Original == null)
                {
                    continue;
                }

                if (!Memory.SetMemory(processHandle, Target(baseAddress, patch), patch.Original))
                {
                    allOk = false;
                }
            }

            return allOk;
        }

        private static IntPtr Target(IntPtr baseAddress, CodePatch patch)
        {
            return new IntPtr(baseAddress.ToInt64() + patch.Offset.ToInt64());
        }

        /// <summary>
        /// 丢弃已缓存的原始字节，下次启用时重新从进程读回。
        ///
        /// 游戏退出时调用：同一个进程名下可能换成了另一个 exe 版本，
        /// 留着上一个版本读到的字节，关闭时就会把旧字节写进新版本，反而更危险。
        /// </summary>
        public static void InvalidateCachedOriginals(CodePatch[] patches)
        {
            if (patches == null)
            {
                return;
            }

            foreach (CodePatch patch in patches)
            {
                patch.Original = null;
            }
        }
    }
}
