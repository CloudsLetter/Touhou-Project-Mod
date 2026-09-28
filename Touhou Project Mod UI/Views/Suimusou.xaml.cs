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
    /// Suimusou.xaml 的交互逻辑
    /// 骨架页：Offset / Value 里的数值填好后即可直接生效，无需改动本文件。
    /// </summary>
    public partial class Suimusou : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public bool IsGreenDotVisible
        {
            get => Globals.SuimusouStatus.IsRun;
            set
            {
                if (Globals.SuimusouStatus.IsRun != value)
                {
                    Globals.SuimusouStatus.IsRun = value;
                    OnPropertyChanged(nameof(IsGreenDotVisible));
                }
            }
        }
        public bool LockPlayer
        {
            get => Globals.SuimusouStatus.LockPlayer;
            set
            {
                if (Globals.SuimusouStatus.LockPlayer != value)
                {
                    Globals.SuimusouStatus.LockPlayer = value;
                    OnPropertyChanged(nameof(LockPlayer));
                }
            }
        }
        public bool LockBomb
        {
            get => Globals.SuimusouStatus.LockBomb;
            set
            {
                if (Globals.SuimusouStatus.LockBomb != value)
                {
                    Globals.SuimusouStatus.LockBomb = value;
                    OnPropertyChanged(nameof(LockBomb));
                }
            }
        }
        public bool MaxPower
        {
            get => Globals.SuimusouStatus.MaxPower;
            set
            {
                if (Globals.SuimusouStatus.MaxPower != value)
                {
                    Globals.SuimusouStatus.MaxPower = value;
                    OnPropertyChanged(nameof(MaxPower));
                }
            }
        }
        public bool Invincible
        {
            get => Globals.SuimusouStatus.Invincible;
            set
            {
                if (Globals.SuimusouStatus.Invincible != value)
                {
                    Globals.SuimusouStatus.Invincible = value;
                    OnPropertyChanged(nameof(Invincible));
                }
            }
        }


        public Suimusou()
        {
            InitializeComponent();
            DataContext = this;
            IsGreenDotVisible = Globals.SuimusouStatus.IsRun;
            LockPlayer = Globals.SuimusouStatus.LockPlayer;
            LockBomb = Globals.SuimusouStatus.LockBomb;
            MaxPower = Globals.SuimusouStatus.MaxPower;
            Invincible = Globals.SuimusouStatus.Invincible;

            Globals.SuimusouStatus.IsTouhouRunChanged += OnGlobalsIsSuimusouRunChanged;
            Globals.SuimusouStatus.LockPlayerChanged += OnGlobaLockPlayerChanged;
            Globals.SuimusouStatus.LockBombChanged += OnGlobalsLockBombChanged;
            Globals.SuimusouStatus.MaxPowerChanged += OnGlobalsMaxPowerChanged;
            Globals.SuimusouStatus.InvincibleChanged += OnGlobalsInvincibleChanged;
        }

        private void OnGlobalsIsSuimusouRunChanged(object sender, EventArgs e)
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
            if (Globals.SuimusouStatus.BaseAddress == IntPtr.Zero && Globals.SuimusouStatus.ProcessHandle == IntPtr.Zero)
            {
                if (Globals.SuimusouStatus.IsRunStatus)
                {
                    (Globals.SuimusouStatus.BaseAddress, Globals.SuimusouStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th075");
                    if (Globals.SuimusouStatus.BaseAddress == IntPtr.Zero && Globals.SuimusouStatus.ProcessHandle == IntPtr.Zero)
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
            if (Globals.SuimusouStatus.LockPlayer_Locker)
            {
                Globals.SuimusouStatus.LockPlayer_Locker = false;
                return;
            }
            if (!Globals.SuimusouStatus.IsRun)
            {
                Globals.SuimusouStatus.LockPlayer_Locker = true;

                LockPlayer = false;

                return;

            }

            if (Globals.SuimusouStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!LockPlayer)
            {
                if (!Memory.SetMemory(Globals.SuimusouStatus.ProcessHandle, Globals.SuimusouStatus.BaseAddress + Offset.Suimusou_Sub_Plyaer_Offset, Value.Suimusou_Sub_Plyaer_Value_Default))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.SuimusouStatus.ProcessHandle, Globals.SuimusouStatus.BaseAddress + Offset.Suimusou_Sub_Plyaer_Offset, Value.Suimusou_Sub_Plyaer_Value))
                {
                    Globals.SuimusouStatus.LockPlayer_Locker = true;
                    LockPlayer = false;
                    return;
                }
            }


        }
        private void LockeBombToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.SuimusouStatus.LockerBomb_Locker)
            {
                Globals.SuimusouStatus.LockerBomb_Locker = false;
                return;
            }
            if (!Globals.SuimusouStatus.IsRun)
            {
                Globals.SuimusouStatus.LockerBomb_Locker = true;
                LockBomb = false;

                return;

            }
            if (Globals.SuimusouStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!LockBomb)
            {
                if (!Memory.SetMemory(Globals.SuimusouStatus.ProcessHandle, Globals.SuimusouStatus.BaseAddress + Offset.Suimusou_Sub_Bomb_Offset, Value.Suimusou_Sub_Bomb_Value_Default))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.SuimusouStatus.ProcessHandle, Globals.SuimusouStatus.BaseAddress + Offset.Suimusou_Sub_Bomb_Offset, Value.Suimusou_Sub_Bomb_Value))
                {
                    Globals.SuimusouStatus.LockerBomb_Locker = true;
                    LockBomb = false;

                    return;
                }
            }

        }
        private void MaxPowerToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.SuimusouStatus.MaxPower_Locker)
            {
                Globals.SuimusouStatus.MaxPower_Locker = false;
                return;
            }
            if (!Globals.SuimusouStatus.IsRun)
            {
                Globals.SuimusouStatus.MaxPower_Locker = true;
                MaxPower = false;

                return;

            }

            if (Globals.SuimusouStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }
            if (!MaxPower)
            {
                if (!Memory.SetMemory(Globals.SuimusouStatus.ProcessHandle, Globals.SuimusouStatus.BaseAddress + Offset.Suimusou_Sub_Power_Offset, Value.Suimusou_Sub_Power_Value_Default))
                {
                    return;
                }


            }
            else
            {

                if (!Memory.SetMemory(Globals.SuimusouStatus.ProcessHandle, Globals.SuimusouStatus.BaseAddress + Offset.Suimusou_Power_Offset, Value.Suimusou_Power_Value))
                {
                    Globals.SuimusouStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


                if (!Memory.SetMemory(Globals.SuimusouStatus.ProcessHandle, Globals.SuimusouStatus.BaseAddress + Offset.Suimusou_Sub_Power_Offset, Value.Suimusou_Sub_Power_Value))
                {
                    Globals.SuimusouStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


            }


            MaxPower = MaxPowerSwitch.IsOn;

        }
        private void InvincibleToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.SuimusouStatus.Invincible_Locker)
            {
                Globals.SuimusouStatus.Invincible_Locker = false;
                return;
            }

            if (!Globals.SuimusouStatus.IsRun)
            {
                Globals.SuimusouStatus.Invincible_Locker = true;

                Invincible = false;


                return;
            }
            if (Globals.SuimusouStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!Invincible)
            {
                if (!Memory.SetMemory(Globals.SuimusouStatus.ProcessHandle, Globals.SuimusouStatus.BaseAddress + Offset.Suimusou_Sub_Invincible_Offset, Value.Suimusou_Sub_Invincible_Value_Default))
                {

                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.SuimusouStatus.ProcessHandle, Globals.SuimusouStatus.BaseAddress + Offset.Suimusou_Sub_Invincible_Offset, Value.Suimusou_Sub_Invincible_Value))
                {
                    Globals.SuimusouStatus.Invincible_Locker = true;
                    Invincible = false;

                    return;
                }
            }


        }




    }
}
