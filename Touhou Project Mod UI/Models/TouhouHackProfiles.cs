using System;
using System.Text.RegularExpressions;

namespace Touhou_Project_Mod_UI.Models
{
    /// <summary>一个功能项，以及打开它需要写入的一组补丁。</summary>
    public sealed class FeaturePatch
    {
        public readonly HackFeature Feature;
        public readonly CodePatch[] Patches;

        public FeaturePatch(HackFeature feature, params CodePatch[] patches)
        {
            Feature = feature;
            Patches = patches;
        }
    }

    /// <summary>
    /// 一个小数点作的完整描述：进程名、封面、状态对象，以及该作真正拥有的机制。
    /// 小数点作之间机制差异很大（拍照作没有残机，妖精大战争没有道具），
    /// 所以开关列表由数据决定，页面本身不含任何某作专属逻辑。
    /// </summary>
    public sealed class GameProfile
    {
        private static readonly Regex VersionIdentityPattern =
            new Regex(@"timeStamp\s+(\d+)\s*/\s*textSize\s+(\d+)", RegexOptions.Compiled);

        public readonly string Key;
        public readonly string[] ProcessNames;
        public readonly string CoverImage;
        public readonly string SourceNote;
        public readonly Status Status;
        public readonly FeaturePatch[] Features;

        public readonly uint TimeStamp;

        public readonly uint TextSize;

        public GameProfile(string key, string[] processNames, string coverImage, string sourceNote,
            Status status, params FeaturePatch[] features)
        {
            Key = key;
            ProcessNames = processNames;
            CoverImage = coverImage;
            SourceNote = sourceNote;
            Status = status;
            Features = features;

            Match identity = VersionIdentityPattern.Match(sourceNote ?? string.Empty);
            if (identity.Success)
            {
                uint.TryParse(identity.Groups[1].Value, out TimeStamp);
                uint.TryParse(identity.Groups[2].Value, out TextSize);
            }
        }

        public bool HasVersionIdentity => TimeStamp != 0 && TextSize != 0;

        public bool MatchesVersion(uint timeStamp, uint textSize)
        {
            return HasVersionIdentity && TimeStamp == timeStamp && TextSize == textSize;
        }

        /// <summary>
        /// 游戏退出时调用：复位全部开关，并丢弃缓存的原始字节
        /// （同一进程名下可能换了 exe 版本，旧字节不能留用）。
        /// </summary>
        public void ResetAll()
        {
            Status.ResetAllFeatures();

            foreach (FeaturePatch feature in Features)
            {
                Patcher.InvalidateCachedOriginals(feature.Patches);
            }
        }
    }

    /// <summary>
    /// 小数点作的补丁表。
    ///
    /// 偏移来自对下列各作 exe 的逆向，统一记成 RVA（相对模块基址），
    /// 运行时用 BaseAddress + Offset 定位，写法与 Offset.cs 一致。
    /// 原始字节不在此处硬编码 —— 由 Patcher 在首次启用前从目标进程读回并缓存。
    ///
    /// 注意：每个补丁表只对应一个确定的 exe 版本（见各条 SourceNote）。
    /// </summary>
    public static class TouhouHackProfiles
    {
        /// <summary>TH095 v1.02a（timeStamp 1137085759 / textSize 603136）</summary>
        public static readonly GameProfile Bunkachou = new(
            "th095", new[] { "th095" }, "/Img/Th095.png",
            "TH095 v1.02a（timeStamp 1137085759 / textSize 603136）",
            Globals.BunkachouStatus,
            new FeaturePatch(HackFeature.Invincible,
                new CodePatch(0x0306DE, "01"),
                new CodePatch(0x0307BB, "80"),
                new CodePatch(0x03070D, "83c40c9090")),
            new FeaturePatch(HackFeature.InfCharge,
                new CodePatch(0x033EE2, "00")),
            new FeaturePatch(HackFeature.FocusLockOn,
                new CodePatch(0x032EE4, "909090909090"),
                new CodePatch(0x031CF2, "909090909090"),
                new CodePatch(0x032F7E, "00")),
            new FeaturePatch(HackFeature.LockTime,
                new CodePatch(0x018317, "2EE9")));

        /// <summary>TH125 v1.00a（timeStamp 1267822137 / textSize 611328）</summary>
        public static readonly GameProfile DoubleSpoiler = new(
            "th125", new[] { "th125" }, "/Img/Th125.png",
            "TH125 v1.00a（timeStamp 1267822137 / textSize 611328）",
            Globals.DoubleSpoilerStatus,
            new FeaturePatch(HackFeature.Invincible,
                new CodePatch(0x036C2C, "01"),
                new CodePatch(0x036DF8, "eb19"),
                new CodePatch(0x036C76, "83c4109090")),
            new FeaturePatch(HackFeature.InfCharge,
                new CodePatch(0x03A0EA, "00")),
            new FeaturePatch(HackFeature.FocusLockOn,
                new CodePatch(0x038EB9, "909090909090"),
                new CodePatch(0x038EC9, "909090909090"),
                new CodePatch(0x0379C5, "909090909090"),
                new CodePatch(0x038F66, "00")),
            new FeaturePatch(HackFeature.LockTime,
                new CodePatch(0x01DEDA, "eb")));

        /// <summary>TH128 v1.00a（timeStamp 1280811414 / textSize 626176）</summary>
        public static readonly GameProfile YouseiDaisensou = new(
            "th128", new[] { "th128" }, "/Img/Th128.png",
            "TH128 v1.00a（timeStamp 1280811414 / textSize 626176）",
            Globals.YouseiDaisensouStatus,
            new FeaturePatch(HackFeature.Invincible,
                new CodePatch(0x03D0D5, "01"),
                new CodePatch(0x03B7FA, "eb"),
                new CodePatch(0x03D11B, "83c4109090"),
                new CodePatch(0x032735, "e99f00000090")),
            new FeaturePatch(HackFeature.LockPlayer,
                new CodePatch(0x03CDD9, "00000000")),
            new FeaturePatch(HackFeature.LockBomb,
                new CodePatch(0x03B7D7, "00000000"),
                new CodePatch(0x03B90D, "00000000")),
            new FeaturePatch(HackFeature.MaxPower,
                new CodePatch(0x01F429, "00")),
            new FeaturePatch(HackFeature.LockTime,
                new CodePatch(0x017307, "90")),
            new FeaturePatch(HackFeature.AutoBomb,
                new CodePatch(0x03B8E8, "c6"),
                new CodePatch(0x03B8F1, "00")));

        /// <summary>TH143 v1.00a（timeStamp 1398039605 / textSize 748032）</summary>
        public static readonly GameProfile DanmakuAmanojaku = new(
            "th143", new[] { "th143" }, "/Img/Th143.png",
            "TH143 v1.00a（timeStamp 1398039605 / textSize 748032）",
            Globals.DanmakuAmanojakuStatus,
            new FeaturePatch(HackFeature.Invincible,
                new CodePatch(0x04F272, "01")),
            new FeaturePatch(HackFeature.InfItems,
                new CodePatch(0x057860, "0F1F00"),
                new CodePatch(0x057F48, "0F1F00"),
                new CodePatch(0x058FCB, "0F1F00"),
                new CodePatch(0x05946A, "0F1F00"),
                new CodePatch(0x059608, "0F1F00"),
                new CodePatch(0x0597A6, "0F1F00"),
                new CodePatch(0x059950, "0F1F00"),
                new CodePatch(0x059EFF, "0F1F00"),
                new CodePatch(0x059F4A, "0F1F00"),
                new CodePatch(0x059F94, "0F1F00"),
                new CodePatch(0x059FF4, "0F1F00"),
                new CodePatch(0x05A5E3, "0F1F00"),
                new CodePatch(0x05B4EA, "0F1F00"),
                new CodePatch(0x05B9BC, "0F1F00"),
                new CodePatch(0x05BDE8, "0F1F00"),
                new CodePatch(0x05C1AD, "0F1F00"),
                new CodePatch(0x05C7FD, "0F1F00"),
                new CodePatch(0x05CE94, "0F1F00")),
            new FeaturePatch(HackFeature.LockTime,
                new CodePatch(0x01894D, "eb"),
                new CodePatch(0x0215C8, "90")));

        /// <summary>TH165 v1.00a（timeStamp 1532998383 / textSize 607232）</summary>
        public static readonly GameProfile NightmareDiary = new(
            "th165", new[] { "th165" }, "/Img/Th165.png",
            "TH165 v1.00a（timeStamp 1532998383 / textSize 607232）",
            Globals.NightmareDiaryStatus,
            new FeaturePatch(HackFeature.Invincible,
                new CodePatch(0x046A80, "01")),
            new FeaturePatch(HackFeature.InfCharge,
                new CodePatch(0x04C5F8, "9090")),
            new FeaturePatch(HackFeature.LockTime,
                new CodePatch(0x019A78, "eb63")));

        /// <summary>TH185 v1.00a（timeStamp 1659144319 / textSize 711168）</summary>
        public static readonly GameProfile BlackMarket = new(
            "th185", new[] { "th185" }, "/Img/Th185.png",
            "TH185 v1.00a（timeStamp 1659144319 / textSize 711168）",
            Globals.BlackMarketStatus,
            new FeaturePatch(HackFeature.Invincible,
                new CodePatch(0x0635A5, "01")),
            new FeaturePatch(HackFeature.LockPlayer,
                new CodePatch(0x00AEC3, "660f1f440000"),
                new CodePatch(0x063281, "00")),
            new FeaturePatch(HackFeature.InfBMoney,
                new CodePatch(0x00ED5F, "662e0f1f840000000000662e0f1f840000000000"),
                new CodePatch(0x01EE2D, "660f1f440000")),
            new FeaturePatch(HackFeature.LockTime,
                new CodePatch(0x034C85, "660f1f440000"),
                new CodePatch(0x036E38, "0f1f8400000000000f1f8400000000000f1f840000000000")));

        #region 整数作：花映塚 / 兽王园

        public static readonly GameProfile Kaeizuka = new(
            "th09", new[] { "th09" }, "/Img/Th09.png",
            "TH09 v1.50a（timeStamp 1128708539 / textSize 576512）",
            Globals.KaeizukaStatus,
            new FeaturePatch(HackFeature.Invincible,
                CodePatch.Nop(0x01E8EC, 5)),
            new FeaturePatch(HackFeature.LockRank,
                new CodePatch(0x01AC7F, "EB")),
            new FeaturePatch(HackFeature.MultiInstance,
                new CodePatch(0x02D928, "EB")));

        public static readonly GameProfile JuuouenV100a = new(
            "th19-v1.00a", new[] { "th19" }, "/Img/Th19.png",
            "TH19 v1.00a（timeStamp 1690598468 / textSize 1433600）",
            Globals.JuuouenStatus,
            new FeaturePatch(HackFeature.LockPlayer,
                CodePatch.Nop(0x0123EB5, 1)),
            new FeaturePatch(HackFeature.Invincible,
                CodePatch.Nop(0x0130ACC, 7)),
            new FeaturePatch(HackFeature.CpuChargeLock,
                CodePatch.Nop(0x00E9D33, 11)));

        public static readonly GameProfile JuuouenV110c = new(
            "th19-v1.10c", new[] { "th19" }, "/Img/Th19.png",
            "TH19 v1.10c（timeStamp 1720429610 / textSize 1544704）",
            Globals.JuuouenStatus,
            new FeaturePatch(HackFeature.LockPlayer,
                CodePatch.Nop(0x0137795, 1)),
            new FeaturePatch(HackFeature.Invincible,
                CodePatch.Nop(0x0145EE3, 13)),
            new FeaturePatch(HackFeature.CpuChargeLock,
                CodePatch.Nop(0x00FA722, 6)));

        #endregion

        #region 整数作：红魔乡 新典（New Classic）

        public static readonly GameProfile KoumakyouNc = new(
            "th06nc", new[] { "th06nc" }, "/Img/Th06nc.png",
            "TH06 新典 v1.03（timeStamp 1788754577 / textSize 2878464）",
            Globals.KoumakyouNcStatus,
            new FeaturePatch(HackFeature.Invincible,
                new CodePatch(0x06A981, "C3"),
                new CodePatch(0x06ABA7, "C3")),
            new FeaturePatch(HackFeature.LockPlayer,
                new CodePatch(0x068E86, "9090")),
            new FeaturePatch(HackFeature.LockBomb,
                new CodePatch(0x068A70, "9090")),
            new FeaturePatch(HackFeature.MaxPower,
                new CodePatch(0x04F1E88, "8000"),
                new CodePatch(0x068BAF, "90909090909090"),
                new CodePatch(0x068BBE, "9090909090909090")));

        #endregion
    }
}
