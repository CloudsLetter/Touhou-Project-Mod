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
    /// Shinkirou.xaml 的交互逻辑
    /// 骨架页：Offset / Value 里的数值填好后即可直接生效，无需改动本文件。
    /// </summary>
    public partial class Shinkirou : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public bool IsGreenDotVisible
        {
            get => Globals.ShinkirouStatus.IsRun;
            set
            {
                if (Globals.ShinkirouStatus.IsRun != value)
                {
                    Globals.ShinkirouStatus.IsRun = value;
                    OnPropertyChanged(nameof(IsGreenDotVisible));
                }
            }
        }
        public bool LockPlayer
        {
            get => Globals.ShinkirouStatus.LockPlayer;
            set
            {
                if (Globals.ShinkirouStatus.LockPlayer != value)
                {
                    Globals.ShinkirouStatus.LockPlayer = value;
                    OnPropertyChanged(nameof(LockPlayer));
                }
            }
        }
        public bool LockBomb
        {
            get => Globals.ShinkirouStatus.LockBomb;
            set
            {
                if (Globals.ShinkirouStatus.LockBomb != value)
                {
                    Globals.ShinkirouStatus.LockBomb = value;
                    OnPropertyChanged(nameof(LockBomb));
                }
            }
        }
        public bool MaxPower
        {
            get => Globals.ShinkirouStatus.MaxPower;
            set
            {
                if (Globals.ShinkirouStatus.MaxPower != value)
                {
                    Globals.ShinkirouStatus.MaxPower = value;
                    OnPropertyChanged(nameof(MaxPower));
                }
            }
        }
        public bool Invincible
        {
            get => Globals.ShinkirouStatus.Invincible;
            set
            {
                if (Globals.ShinkirouStatus.Invincible != value)
                {
                    Globals.ShinkirouStatus.Invincible = value;
                    OnPropertyChanged(nameof(Invincible));
                }
            }
        }


        public Shinkirou()
        {
            InitializeComponent();
            DataContext = this;
            IsGreenDotVisible = Globals.ShinkirouStatus.IsRun;
            LockPlayer = Globals.ShinkirouStatus.LockPlayer;
            LockBomb = Globals.ShinkirouStatus.LockBomb;
            MaxPower = Globals.ShinkirouStatus.MaxPower;
            Invincible = Globals.ShinkirouStatus.Invincible;

            Globals.ShinkirouStatus.IsTouhouRunChanged += OnGlobalsIsShinkirouRunChanged;
            Globals.ShinkirouStatus.LockPlayerChanged += OnGlobaLockPlayerChanged;
            Globals.ShinkirouStatus.LockBombChanged += OnGlobalsLockBombChanged;
            Globals.ShinkirouStatus.MaxPowerChanged += OnGlobalsMaxPowerChanged;
            Globals.ShinkirouStatus.InvincibleChanged += OnGlobalsInvincibleChanged;
        }

        private void OnGlobalsIsShinkirouRunChanged(object sender, EventArgs e)
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
            if (Globals.ShinkirouStatus.BaseAddress == IntPtr.Zero && Globals.ShinkirouStatus.ProcessHandle == IntPtr.Zero)
            {
                if (Globals.ShinkirouStatus.IsRunStatus)
                {
                    (Globals.ShinkirouStatus.BaseAddress, Globals.ShinkirouStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th135");
                    if (Globals.ShinkirouStatus.BaseAddress == IntPtr.Zero && Globals.ShinkirouStatus.ProcessHandle == IntPtr.Zero)
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
            if (Globals.ShinkirouStatus.LockPlayer_Locker)
            {
                Globals.ShinkirouStatus.LockPlayer_Locker = false;
                return;
            }
            if (!Globals.ShinkirouStatus.IsRun)
            {
                Globals.ShinkirouStatus.LockPlayer_Locker = true;

                LockPlayer = false;

                return;

            }

            if (Globals.ShinkirouStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!LockPlayer)
            {
                if (!Memory.SetMemory(Globals.ShinkirouStatus.ProcessHandle, Globals.ShinkirouStatus.BaseAddress + Offset.Shinkirou_Sub_Plyaer_Offset, Value.Shinkirou_Sub_Plyaer_Value_Default))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.ShinkirouStatus.ProcessHandle, Globals.ShinkirouStatus.BaseAddress + Offset.Shinkirou_Sub_Plyaer_Offset, Value.Shinkirou_Sub_Plyaer_Value))
                {
                    Globals.ShinkirouStatus.LockPlayer_Locker = true;
                    LockPlayer = false;
                    return;
                }
            }


        }
        private void LockeBombToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.ShinkirouStatus.LockerBomb_Locker)
            {
                Globals.ShinkirouStatus.LockerBomb_Locker = false;
                return;
            }
            if (!Globals.ShinkirouStatus.IsRun)
            {
                Globals.ShinkirouStatus.LockerBomb_Locker = true;
                LockBomb = false;

                return;

            }
            if (Globals.ShinkirouStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!LockBomb)
            {
                if (!Memory.SetMemory(Globals.ShinkirouStatus.ProcessHandle, Globals.ShinkirouStatus.BaseAddress + Offset.Shinkirou_Sub_Bomb_Offset, Value.Shinkirou_Sub_Bomb_Value_Default))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.ShinkirouStatus.ProcessHandle, Globals.ShinkirouStatus.BaseAddress + Offset.Shinkirou_Sub_Bomb_Offset, Value.Shinkirou_Sub_Bomb_Value))
                {
                    Globals.ShinkirouStatus.LockerBomb_Locker = true;
                    LockBomb = false;

                    return;
                }
            }

        }
        private void MaxPowerToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.ShinkirouStatus.MaxPower_Locker)
            {
                Globals.ShinkirouStatus.MaxPower_Locker = false;
                return;
            }
            if (!Globals.ShinkirouStatus.IsRun)
            {
                Globals.ShinkirouStatus.MaxPower_Locker = true;
                MaxPower = false;

                return;

            }

            if (Globals.ShinkirouStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }
            if (!MaxPower)
            {
                if (!Memory.SetMemory(Globals.ShinkirouStatus.ProcessHandle, Globals.ShinkirouStatus.BaseAddress + Offset.Shinkirou_Sub_Power_Offset, Value.Shinkirou_Sub_Power_Value_Default))
                {
                    return;
                }


            }
            else
            {

                if (!Memory.SetMemory(Globals.ShinkirouStatus.ProcessHandle, Globals.ShinkirouStatus.BaseAddress + Offset.Shinkirou_Power_Offset, Value.Shinkirou_Power_Value))
                {
                    Globals.ShinkirouStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


                if (!Memory.SetMemory(Globals.ShinkirouStatus.ProcessHandle, Globals.ShinkirouStatus.BaseAddress + Offset.Shinkirou_Sub_Power_Offset, Value.Shinkirou_Sub_Power_Value))
                {
                    Globals.ShinkirouStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


            }


            MaxPower = MaxPowerSwitch.IsOn;

        }
        private void InvincibleToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.ShinkirouStatus.Invincible_Locker)
            {
                Globals.ShinkirouStatus.Invincible_Locker = false;
                return;
            }

            if (!Globals.ShinkirouStatus.IsRun)
            {
                Globals.ShinkirouStatus.Invincible_Locker = true;

                Invincible = false;


                return;
            }
            if (Globals.ShinkirouStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!Invincible)
            {
                if (!Memory.SetMemory(Globals.ShinkirouStatus.ProcessHandle, Globals.ShinkirouStatus.BaseAddress + Offset.Shinkirou_Sub_Invincible_Offset, Value.Shinkirou_Sub_Invincible_Value_Default))
                {

                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.ShinkirouStatus.ProcessHandle, Globals.ShinkirouStatus.BaseAddress + Offset.Shinkirou_Sub_Invincible_Offset, Value.Shinkirou_Sub_Invincible_Value))
                {
                    Globals.ShinkirouStatus.Invincible_Locker = true;
                    Invincible = false;

                    return;
                }
            }


        }




    }
}
