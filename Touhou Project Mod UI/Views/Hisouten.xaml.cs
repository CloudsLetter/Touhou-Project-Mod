using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Touhou_Project_Mod_UI.Models;
using Touhou_Project_Mod_UI.SDK.Native;

namespace Touhou_Project_Mod_UI.Views
{
    /// <summary>
    /// Hisouten.xaml 的交互逻辑
    /// 骨架页：Offset / Value 里的数值填好后即可直接生效，无需改动本文件。
    /// </summary>
    public partial class Hisouten : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public bool IsGreenDotVisible
        {
            get => Globals.HisoutenStatus.IsRun;
            set
            {
                if (Globals.HisoutenStatus.IsRun != value)
                {
                    Globals.HisoutenStatus.IsRun = value;
                    OnPropertyChanged(nameof(IsGreenDotVisible));
                }
            }
        }
        public bool LockPlayer
        {
            get => Globals.HisoutenStatus.LockPlayer;
            set
            {
                if (Globals.HisoutenStatus.LockPlayer != value)
                {
                    Globals.HisoutenStatus.LockPlayer = value;
                    OnPropertyChanged(nameof(LockPlayer));
                }
            }
        }
        public bool LockBomb
        {
            get => Globals.HisoutenStatus.LockBomb;
            set
            {
                if (Globals.HisoutenStatus.LockBomb != value)
                {
                    Globals.HisoutenStatus.LockBomb = value;
                    OnPropertyChanged(nameof(LockBomb));
                }
            }
        }
        public bool MaxPower
        {
            get => Globals.HisoutenStatus.MaxPower;
            set
            {
                if (Globals.HisoutenStatus.MaxPower != value)
                {
                    Globals.HisoutenStatus.MaxPower = value;
                    OnPropertyChanged(nameof(MaxPower));
                }
            }
        }
        public bool Invincible
        {
            get => Globals.HisoutenStatus.Invincible;
            set
            {
                if (Globals.HisoutenStatus.Invincible != value)
                {
                    Globals.HisoutenStatus.Invincible = value;
                    OnPropertyChanged(nameof(Invincible));
                }
            }
        }


        public Hisouten()
        {
            InitializeComponent();
            DataContext = this;
            IsGreenDotVisible = Globals.HisoutenStatus.IsRun;
            LockPlayer = Globals.HisoutenStatus.LockPlayer;
            LockBomb = Globals.HisoutenStatus.LockBomb;
            MaxPower = Globals.HisoutenStatus.MaxPower;
            Invincible = Globals.HisoutenStatus.Invincible;

            Globals.HisoutenStatus.IsTouhouRunChanged += OnGlobalsIsHisoutenRunChanged;
            Globals.HisoutenStatus.LockPlayerChanged += OnGlobaLockPlayerChanged;
            Globals.HisoutenStatus.LockBombChanged += OnGlobalsLockBombChanged;
            Globals.HisoutenStatus.MaxPowerChanged += OnGlobalsMaxPowerChanged;
            Globals.HisoutenStatus.InvincibleChanged += OnGlobalsInvincibleChanged;
        }

        private void OnGlobalsIsHisoutenRunChanged(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(IsGreenDotVisible));
        }

        private void OnGlobaLockPlayerChanged(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(LockPlayer));
        }
        private void OnGlobalsLockBombChanged(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(LockBomb));
        }
        private void OnGlobalsMaxPowerChanged(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(MaxPower));
        }
        private void OnGlobalsInvincibleChanged(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(Invincible));
        }



        private bool GetMemoryInfo()
        {
            if (Globals.HisoutenStatus.BaseAddress == IntPtr.Zero && Globals.HisoutenStatus.ProcessHandle == IntPtr.Zero)
            {
                if (Globals.HisoutenStatus.IsRunStatus)
                {
                    (Globals.HisoutenStatus.BaseAddress, Globals.HisoutenStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th105");
                    if (Globals.HisoutenStatus.BaseAddress == IntPtr.Zero && Globals.HisoutenStatus.ProcessHandle == IntPtr.Zero)
                    {
                        return false;
                    }
                }
                return true;
            }
            return true;
        }

        private void LockePlayerToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.HisoutenStatus.LockPlayer_Locker)
            {
                Globals.HisoutenStatus.LockPlayer_Locker = false;
                return;
            }
            if (!Globals.HisoutenStatus.IsRun)
            {
                Globals.HisoutenStatus.LockPlayer_Locker = true;

                LockPlayer = false;

                return;

            }

            if (Globals.HisoutenStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!LockPlayer)
            {
                if (!Memory.SetMemory(Globals.HisoutenStatus.ProcessHandle, Globals.HisoutenStatus.BaseAddress + Offset.Hisouten_Sub_Plyaer_Offset, Value.Hisouten_Sub_Plyaer_Value_Default))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.HisoutenStatus.ProcessHandle, Globals.HisoutenStatus.BaseAddress + Offset.Hisouten_Sub_Plyaer_Offset, Value.Hisouten_Sub_Plyaer_Value))
                {
                    Globals.HisoutenStatus.LockPlayer_Locker = true;
                    LockPlayer = false;
                    return;
                }
            }


        }
        private void LockeBombToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.HisoutenStatus.LockerBomb_Locker)
            {
                Globals.HisoutenStatus.LockerBomb_Locker = false;
                return;
            }
            if (!Globals.HisoutenStatus.IsRun)
            {
                Globals.HisoutenStatus.LockerBomb_Locker = true;
                LockBomb = false;

                return;

            }
            if (Globals.HisoutenStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!LockBomb)
            {
                if (!Memory.SetMemory(Globals.HisoutenStatus.ProcessHandle, Globals.HisoutenStatus.BaseAddress + Offset.Hisouten_Sub_Bomb_Offset, Value.Hisouten_Sub_Bomb_Value_Default))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.HisoutenStatus.ProcessHandle, Globals.HisoutenStatus.BaseAddress + Offset.Hisouten_Sub_Bomb_Offset, Value.Hisouten_Sub_Bomb_Value))
                {
                    Globals.HisoutenStatus.LockerBomb_Locker = true;
                    LockBomb = false;

                    return;
                }
            }

        }
        private void MaxPowerToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.HisoutenStatus.MaxPower_Locker)
            {
                Globals.HisoutenStatus.MaxPower_Locker = false;
                return;
            }
            if (!Globals.HisoutenStatus.IsRun)
            {
                Globals.HisoutenStatus.MaxPower_Locker = true;
                MaxPower = false;

                return;

            }

            if (Globals.HisoutenStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }
            if (!MaxPower)
            {
                if (!Memory.SetMemory(Globals.HisoutenStatus.ProcessHandle, Globals.HisoutenStatus.BaseAddress + Offset.Hisouten_Sub_Power_Offset, Value.Hisouten_Sub_Power_Value_Default))
                {
                    return;
                }


            }
            else
            {

                if (!Memory.SetMemory(Globals.HisoutenStatus.ProcessHandle, Globals.HisoutenStatus.BaseAddress + Offset.Hisouten_Power_Offset, Value.Hisouten_Power_Value))
                {
                    Globals.HisoutenStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


                if (!Memory.SetMemory(Globals.HisoutenStatus.ProcessHandle, Globals.HisoutenStatus.BaseAddress + Offset.Hisouten_Sub_Power_Offset, Value.Hisouten_Sub_Power_Value))
                {
                    Globals.HisoutenStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


            }


            MaxPower = MaxPowerSwitch.IsOn;

        }
        private void InvincibleToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.HisoutenStatus.Invincible_Locker)
            {
                Globals.HisoutenStatus.Invincible_Locker = false;
                return;
            }

            if (!Globals.HisoutenStatus.IsRun)
            {
                Globals.HisoutenStatus.Invincible_Locker = true;

                Invincible = false;


                return;
            }
            if (Globals.HisoutenStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!Invincible)
            {
                if (!Memory.SetMemory(Globals.HisoutenStatus.ProcessHandle, Globals.HisoutenStatus.BaseAddress + Offset.Hisouten_Sub_Invincible_Offset, Value.Hisouten_Sub_Invincible_Value_Default))
                {

                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.HisoutenStatus.ProcessHandle, Globals.HisoutenStatus.BaseAddress + Offset.Hisouten_Sub_Invincible_Offset, Value.Hisouten_Sub_Invincible_Value))
                {
                    Globals.HisoutenStatus.Invincible_Locker = true;
                    Invincible = false;

                    return;
                }
            }


        }




    }
}
