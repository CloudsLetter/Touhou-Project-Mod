using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touhou_Project_Mod_UI.Models
{
    public class Status
    {

        private  bool _isTouhouRun;
        private  bool _lockPlayer;
        private  bool _lockBomb;
        private  bool _maxPower;
        private  bool _invincible;
        public  event EventHandler IsTouhouRunChanged;
        public  event EventHandler LockPlayerChanged;
        public  event EventHandler LockBombChanged;
        public  event EventHandler MaxPowerChanged;
        public  event EventHandler InvincibleChanged;

        public bool IsRunStatus;
        public bool IsRunStatusC;
        public bool IsRunStatusE;
        public bool IsRunStatusCC;
        public bool IsRun
        {
            get => _isTouhouRun;
            set
            {
                if (_isTouhouRun != value)
                {
                    _isTouhouRun = value;
                    IsTouhouRunChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        public bool LockPlayer
        {
            get => _lockPlayer;
            set
            {
                if (_lockPlayer != value)
                {
                    _lockPlayer = value;
                    LockPlayerChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        public bool LockBomb
        {
            get => _lockBomb;
            set
            {
                if (_lockBomb != value)
                {
                    _lockBomb = value;
                    LockBombChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        public bool MaxPower
        {
            get => _maxPower;
            set
            {
                if (_maxPower != value)
                {
                    _maxPower = value;
                    MaxPowerChanged?.Invoke(null, EventArgs.Empty);
                }
            }
        }
        public bool Invincible
        {
            get => _invincible;
            set
            {
                if (_invincible != value)
                {
                    _invincible = value;
                    InvincibleChanged?.Invoke(null, EventArgs.Empty);
                }
            }
        }

        public bool LockPlayer_Locker = false;
        public bool LockerBomb_Locker = false;
        public bool MaxPower_Locker = false;
        public bool Invincible_Locker = false;


        // ── 通用功能开关 ────────────────────────────────────────────────
        // 整数作只用上面那 4 个属性；小数点作的功能项种类不同（锁时、无限装填率、
        // 暴力取材、无限道具、无限弹币、自动B），所以这里提供一套泛型存取，
        // 前四项直接转发到原有属性，保证老页面的绑定与事件不受影响。
        private readonly Dictionary<HackFeature, bool> _extraFeatures = new();
        private readonly HashSet<HackFeature> _lockers = new();

        /// <summary>小数点作页面订阅此事件刷新开关状态。</summary>
        public event EventHandler<HackFeature> FeatureChanged;

        public bool GetFeature(HackFeature feature)
        {
            switch (feature)
            {
                case HackFeature.LockPlayer: return LockPlayer;
                case HackFeature.LockBomb: return LockBomb;
                case HackFeature.MaxPower: return MaxPower;
                case HackFeature.Invincible: return Invincible;
                default: return _extraFeatures.TryGetValue(feature, out bool value) && value;
            }
        }

        public void SetFeature(HackFeature feature, bool value)
        {
            switch (feature)
            {
                case HackFeature.LockPlayer: LockPlayer = value; return;
                case HackFeature.LockBomb: LockBomb = value; return;
                case HackFeature.MaxPower: MaxPower = value; return;
                case HackFeature.Invincible: Invincible = value; return;
                default:
                    if (GetFeature(feature) != value)
                    {
                        _extraFeatures[feature] = value;
                        FeatureChanged?.Invoke(this, feature);
                    }
                    return;
            }
        }

        /// <summary>防重入标志：程序化改开关会再次触发 Toggled，用它把这次事件吞掉。</summary>
        public bool GetLocker(HackFeature feature) => _lockers.Contains(feature);

        public void SetLocker(HackFeature feature, bool value)
        {
            if (value)
            {
                _lockers.Add(feature);
            }
            else
            {
                _lockers.Remove(feature);
            }
        }

        /// <summary>游戏退出时把所有功能复位。取代逐个写 Xxx = false 的旧写法。</summary>
        public void ResetAllFeatures()
        {
            LockPlayer = false;
            LockBomb = false;
            MaxPower = false;
            Invincible = false;

            foreach (HackFeature feature in _extraFeatures.Where(pair => pair.Value).Select(pair => pair.Key).ToList())
            {
                _extraFeatures[feature] = false;
                FeatureChanged?.Invoke(this, feature);
            }
        }


        public IntPtr BaseAddress { get; set; }
        public IntPtr ProcessHandle { get; set; }


        public int Vsersion { get; set; }
    }
}
