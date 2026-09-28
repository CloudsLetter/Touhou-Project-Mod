namespace Touhou_Project_Mod_UI.Models
{
    /// <summary>
    /// 一个可开关的功能项。整数作只用前四项；小数点作按各作实际拥有的机制取用其余项。
    /// 每个枚举项对应一个可独立开关的机制。
    /// </summary>
    public enum HackFeature
    {
        /// <summary>锁残</summary>
        LockPlayer,

        /// <summary>锁雷 / 锁 Bomb</summary>
        LockBomb,

        /// <summary>满能量 / 火力不减</summary>
        MaxPower,

        /// <summary>无敌</summary>
        Invincible,

        /// <summary>锁时，剩余时间不减</summary>
        LockTime,

        /// <summary>无限装填率</summary>
        InfCharge,

        /// <summary>暴力取材 / 强制锁定拍摄目标</summary>
        FocusLockOn,

        /// <summary>无限道具</summary>
        InfItems,

        /// <summary>无限弹币</summary>
        InfBMoney,

        /// <summary>自动放 Bomb</summary>
        AutoBomb,

        LockRank,

        CpuChargeLock,

        MultiInstance,
    }
}
