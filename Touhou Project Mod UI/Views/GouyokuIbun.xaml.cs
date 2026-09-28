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
    /// GouyokuIbun.xaml 的交互逻辑
    /// 骨架页：Offset / Value 里的数值填好后即可直接生效，无需改动本文件。
    /// </summary>
    public partial class GouyokuIbun : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public bool IsGreenDotVisible
        {
            get => Globals.GouyokuIbunStatus.IsRun;
            set
            {
                if (Globals.GouyokuIbunStatus.IsRun != value)
                {
                    Globals.GouyokuIbunStatus.IsRun = value;
                    OnPropertyChanged(nameof(IsGreenDotVisible));
                }
            }
        }
        public bool LockPlayer
        {
            get => Globals.GouyokuIbunStatus.LockPlayer;
            set
            {
                if (Globals.GouyokuIbunStatus.LockPlayer != value)
                {
                    Globals.GouyokuIbunStatus.LockPlayer = value;
                    OnPropertyChanged(nameof(LockPlayer));
                }
            }
        }
        public bool LockBomb
        {
            get => Globals.GouyokuIbunStatus.LockBomb;
            set
            {
                if (Globals.GouyokuIbunStatus.LockBomb != value)
                {
                    Globals.GouyokuIbunStatus.LockBomb = value;
                    OnPropertyChanged(nameof(LockBomb));
                }
            }
        }
        public bool MaxPower
        {
            get => Globals.GouyokuIbunStatus.MaxPower;
            set
            {
                if (Globals.GouyokuIbunStatus.MaxPower != value)
                {
                    Globals.GouyokuIbunStatus.MaxPower = value;
                    OnPropertyChanged(nameof(MaxPower));
                }
            }
        }
        public bool Invincible
        {
            get => Globals.GouyokuIbunStatus.Invincible;
            set
            {
                if (Globals.GouyokuIbunStatus.Invincible != value)
                {
                    Globals.GouyokuIbunStatus.Invincible = value;
                    OnPropertyChanged(nameof(Invincible));
                }
            }
        }


        public GouyokuIbun()
        {
            InitializeComponent();
            DataContext = this;
            IsGreenDotVisible = Globals.GouyokuIbunStatus.IsRun;
            LockPlayer = Globals.GouyokuIbunStatus.LockPlayer;
            LockBomb = Globals.GouyokuIbunStatus.LockBomb;
            MaxPower = Globals.GouyokuIbunStatus.MaxPower;
            Invincible = Globals.GouyokuIbunStatus.Invincible;

            Globals.GouyokuIbunStatus.IsTouhouRunChanged += OnGlobalsIsGouyokuIbunRunChanged;
            Globals.GouyokuIbunStatus.LockPlayerChanged += OnGlobaLockPlayerChanged;
            Globals.GouyokuIbunStatus.LockBombChanged += OnGlobalsLockBombChanged;
            Globals.GouyokuIbunStatus.MaxPowerChanged += OnGlobalsMaxPowerChanged;
            Globals.GouyokuIbunStatus.InvincibleChanged += OnGlobalsInvincibleChanged;
        }

        private void OnGlobalsIsGouyokuIbunRunChanged(object sender, EventArgs e)
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
            if (Globals.GouyokuIbunStatus.BaseAddress == IntPtr.Zero && Globals.GouyokuIbunStatus.ProcessHandle == IntPtr.Zero)
            {
                if (Globals.GouyokuIbunStatus.IsRunStatus)
                {
                    (Globals.GouyokuIbunStatus.BaseAddress, Globals.GouyokuIbunStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th175");
                    if (Globals.GouyokuIbunStatus.BaseAddress == IntPtr.Zero && Globals.GouyokuIbunStatus.ProcessHandle == IntPtr.Zero)
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
            if (Globals.GouyokuIbunStatus.LockPlayer_Locker)
            {
                Globals.GouyokuIbunStatus.LockPlayer_Locker = false;
                return;
            }
            if (!Globals.GouyokuIbunStatus.IsRun)
            {
                Globals.GouyokuIbunStatus.LockPlayer_Locker = true;

                LockPlayer = false;

                return;

            }

            if (Globals.GouyokuIbunStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!LockPlayer)
            {
                if (!Memory.SetMemory(Globals.GouyokuIbunStatus.ProcessHandle, Globals.GouyokuIbunStatus.BaseAddress + Offset.GouyokuIbun_Sub_Plyaer_Offset, Value.GouyokuIbun_Sub_Plyaer_Value_Default))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.GouyokuIbunStatus.ProcessHandle, Globals.GouyokuIbunStatus.BaseAddress + Offset.GouyokuIbun_Sub_Plyaer_Offset, Value.GouyokuIbun_Sub_Plyaer_Value))
                {
                    Globals.GouyokuIbunStatus.LockPlayer_Locker = true;
                    LockPlayer = false;
                    return;
                }
            }


        }
        private void LockeBombToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.GouyokuIbunStatus.LockerBomb_Locker)
            {
                Globals.GouyokuIbunStatus.LockerBomb_Locker = false;
                return;
            }
            if (!Globals.GouyokuIbunStatus.IsRun)
            {
                Globals.GouyokuIbunStatus.LockerBomb_Locker = true;
                LockBomb = false;

                return;

            }
            if (Globals.GouyokuIbunStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!LockBomb)
            {
                if (!Memory.SetMemory(Globals.GouyokuIbunStatus.ProcessHandle, Globals.GouyokuIbunStatus.BaseAddress + Offset.GouyokuIbun_Sub_Bomb_Offset, Value.GouyokuIbun_Sub_Bomb_Value_Default))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.GouyokuIbunStatus.ProcessHandle, Globals.GouyokuIbunStatus.BaseAddress + Offset.GouyokuIbun_Sub_Bomb_Offset, Value.GouyokuIbun_Sub_Bomb_Value))
                {
                    Globals.GouyokuIbunStatus.LockerBomb_Locker = true;
                    LockBomb = false;

                    return;
                }
            }

        }
        private void MaxPowerToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.GouyokuIbunStatus.MaxPower_Locker)
            {
                Globals.GouyokuIbunStatus.MaxPower_Locker = false;
                return;
            }
            if (!Globals.GouyokuIbunStatus.IsRun)
            {
                Globals.GouyokuIbunStatus.MaxPower_Locker = true;
                MaxPower = false;

                return;

            }

            if (Globals.GouyokuIbunStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }
            if (!MaxPower)
            {
                if (!Memory.SetMemory(Globals.GouyokuIbunStatus.ProcessHandle, Globals.GouyokuIbunStatus.BaseAddress + Offset.GouyokuIbun_Sub_Power_Offset, Value.GouyokuIbun_Sub_Power_Value_Default))
                {
                    return;
                }


            }
            else
            {

                if (!Memory.SetMemory(Globals.GouyokuIbunStatus.ProcessHandle, Globals.GouyokuIbunStatus.BaseAddress + Offset.GouyokuIbun_Power_Offset, Value.GouyokuIbun_Power_Value))
                {
                    Globals.GouyokuIbunStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


                if (!Memory.SetMemory(Globals.GouyokuIbunStatus.ProcessHandle, Globals.GouyokuIbunStatus.BaseAddress + Offset.GouyokuIbun_Sub_Power_Offset, Value.GouyokuIbun_Sub_Power_Value))
                {
                    Globals.GouyokuIbunStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


            }


            MaxPower = MaxPowerSwitch.IsOn;

        }
        private void InvincibleToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.GouyokuIbunStatus.Invincible_Locker)
            {
                Globals.GouyokuIbunStatus.Invincible_Locker = false;
                return;
            }

            if (!Globals.GouyokuIbunStatus.IsRun)
            {
                Globals.GouyokuIbunStatus.Invincible_Locker = true;

                Invincible = false;


                return;
            }
            if (Globals.GouyokuIbunStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!Invincible)
            {
                if (!Memory.SetMemory(Globals.GouyokuIbunStatus.ProcessHandle, Globals.GouyokuIbunStatus.BaseAddress + Offset.GouyokuIbun_Sub_Invincible_Offset, Value.GouyokuIbun_Sub_Invincible_Value_Default))
                {

                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.GouyokuIbunStatus.ProcessHandle, Globals.GouyokuIbunStatus.BaseAddress + Offset.GouyokuIbun_Sub_Invincible_Offset, Value.GouyokuIbun_Sub_Invincible_Value))
                {
                    Globals.GouyokuIbunStatus.Invincible_Locker = true;
                    Invincible = false;

                    return;
                }
            }


        }




    }
}
