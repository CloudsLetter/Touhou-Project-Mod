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
    /// Shinreibyou.xaml 的交互逻辑
    /// </summary>
    public partial class Shinreibyou : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public bool IsGreenDotVisible
        {
            get => Globals.ShinreibyouStatus.IsRun;
            set
            {
                if (Globals.ShinreibyouStatus.IsRun != value)
                {
                    Globals.ShinreibyouStatus.IsRun = value;
                    OnPropertyChanged(nameof(IsGreenDotVisible));
                }
            }
        }
        public bool LockPlayer
        {
            get => Globals.ShinreibyouStatus.LockPlayer;
            set
            {
                if (Globals.ShinreibyouStatus.LockPlayer != value)
                {
                    Globals.ShinreibyouStatus.LockPlayer = value;
                    OnPropertyChanged(nameof(LockPlayer));
                }
            }
        }
        public bool LockBomb
        {
            get => Globals.ShinreibyouStatus.LockBomb;
            set
            {
                if (Globals.ShinreibyouStatus.LockBomb != value)
                {
                    Globals.ShinreibyouStatus.LockBomb = value;
                    OnPropertyChanged(nameof(LockBomb));
                }
            }
        }
        public bool MaxPower
        {
            get => Globals.ShinreibyouStatus.MaxPower;
            set
            {
                if (Globals.ShinreibyouStatus.MaxPower != value)
                {
                    Globals.ShinreibyouStatus.MaxPower = value;
                    OnPropertyChanged(nameof(MaxPower));
                }
            }
        }
        public bool Invincible
        {
            get => Globals.ShinreibyouStatus.Invincible;
            set
            {
                if (Globals.ShinreibyouStatus.Invincible != value)
                {
                    Globals.ShinreibyouStatus.Invincible = value;
                    OnPropertyChanged(nameof(Invincible));
                }
            }
        }


        public Shinreibyou()
        {
            InitializeComponent();
            DataContext = this;
            IsGreenDotVisible = Globals.ShinreibyouStatus.IsRun;
            LockPlayer = Globals.ShinreibyouStatus.LockPlayer;
            LockBomb = Globals.ShinreibyouStatus.LockBomb;
            MaxPower = Globals.ShinreibyouStatus.MaxPower;
            Invincible = Globals.ShinreibyouStatus.Invincible;

            Globals.ShinreibyouStatus.IsTouhouRunChanged += OnGlobalsIsShinreibyouRunChanged;
            Globals.ShinreibyouStatus.LockPlayerChanged += OnGlobaLockPlayerChanged;
            Globals.ShinreibyouStatus.LockBombChanged += OnGlobalsLockBombChanged;
            Globals.ShinreibyouStatus.MaxPowerChanged += OnGlobalsMaxPowerChanged;
            Globals.ShinreibyouStatus.InvincibleChanged += OnGlobalsInvincibleChanged;
        }

        private void OnGlobalsIsShinreibyouRunChanged(object sender, EventArgs e)
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
            if (Globals.ShinreibyouStatus.BaseAddress == IntPtr.Zero && Globals.ShinreibyouStatus.ProcessHandle == IntPtr.Zero)
            {
                if (Globals.ShinreibyouStatus.IsRunStatus)
                {
                    (Globals.ShinreibyouStatus.BaseAddress, Globals.ShinreibyouStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th13");
                    if (Globals.ShinreibyouStatus.BaseAddress == IntPtr.Zero && Globals.ShinreibyouStatus.ProcessHandle == IntPtr.Zero)
                    {
                        return false;
                    }
                }
                if (Globals.ShinreibyouStatus.IsRunStatusC)
                {
                    (Globals.ShinreibyouStatus.BaseAddress, Globals.ShinreibyouStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th13c");
                    if (Globals.ShinreibyouStatus.BaseAddress == IntPtr.Zero && Globals.ShinreibyouStatus.ProcessHandle == IntPtr.Zero)
                    {
                        return false;
                    }
                }
                if (Globals.ShinreibyouStatus.IsRunStatusE)
                {
                    (Globals.ShinreibyouStatus.BaseAddress, Globals.ShinreibyouStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th13e");
                    if (Globals.ShinreibyouStatus.BaseAddress == IntPtr.Zero && Globals.ShinreibyouStatus.ProcessHandle == IntPtr.Zero)
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
            if (Globals.ShinreibyouStatus.LockPlayer_Locker)
            {
                Globals.ShinreibyouStatus.LockPlayer_Locker = false;
                return;
            }
            if (!Globals.ShinreibyouStatus.IsRun)
            {
                Globals.ShinreibyouStatus.LockPlayer_Locker = true;

                LockPlayer = false;

                return;

            }

            if (Globals.ShinreibyouStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!LockPlayer)
            {
                if (!Memory.SetMemory(Globals.ShinreibyouStatus.ProcessHandle, Globals.ShinreibyouStatus.BaseAddress + Offset.Shinreibyou_Sub_Plyaer_Offset, Value.Shinreibyou_Sub_Plyaer_Value_Default))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.ShinreibyouStatus.ProcessHandle, Globals.ShinreibyouStatus.BaseAddress + Offset.Shinreibyou_Sub_Plyaer_Offset, Value.Shinreibyou_Sub_Plyaer_Value))
                {
                    Globals.ShinreibyouStatus.LockPlayer_Locker = true;
                    LockPlayer = false;
                    return;
                }
            }


        }
        private void LockeBombToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.ShinreibyouStatus.LockerBomb_Locker)
            {
                Globals.ShinreibyouStatus.LockerBomb_Locker = false;
                return;
            }
            if (!Globals.ShinreibyouStatus.IsRun)
            {
                Globals.ShinreibyouStatus.LockerBomb_Locker = true;
                LockBomb = false;

                return;

            }
            if (Globals.ShinreibyouStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!LockBomb)
            {
                if (!Memory.SetMemory(Globals.ShinreibyouStatus.ProcessHandle, Globals.ShinreibyouStatus.BaseAddress + Offset.Shinreibyou_Sub_Bomb_Offset, Value.Shinreibyou_Sub_Plyaer_Value_Default))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.ShinreibyouStatus.ProcessHandle, Globals.ShinreibyouStatus.BaseAddress + Offset.Shinreibyou_Sub_Bomb_Offset, Value.Shinreibyou_Sub_Bomb_Value))
                {
                    Globals.ShinreibyouStatus.LockerBomb_Locker = true;
                    LockBomb = false;

                    return;
                }
            }

        }
        private void MaxPowerToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.ShinreibyouStatus.MaxPower_Locker)
            {
                Globals.ShinreibyouStatus.MaxPower_Locker = false;
                return;
            }
            if (!Globals.ShinreibyouStatus.IsRun)
            {
                Globals.ShinreibyouStatus.MaxPower_Locker = true;
                MaxPower = false;

                return;

            }

            if (Globals.ShinreibyouStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }
            if (!MaxPower)
            {
                if (!Memory.SetMemory(Globals.ShinreibyouStatus.ProcessHandle, Globals.ShinreibyouStatus.BaseAddress + Offset.Shinreibyou_Sub_Power_Offset, Value.Shinreibyou_Sub_Power_Value_Default))
                {
                    return;
                }


            }
            else
            {

                if (!Memory.SetMemory(Globals.ShinreibyouStatus.ProcessHandle, Globals.ShinreibyouStatus.BaseAddress + Offset.Shinreibyou_Power_Offset, Value.Shinreibyou_Power_Value))
                {
                    Globals.ShinreibyouStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


                if (!Memory.SetMemory(Globals.ShinreibyouStatus.ProcessHandle, Globals.ShinreibyouStatus.BaseAddress + Offset.Shinreibyou_Sub_Power_Offset, Value.Shinreibyou_Sub_Power_Value))
                {
                    Globals.ShinreibyouStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


            }


            MaxPower = MaxPowerSwitch.IsOn;

        }
        private void InvincibleToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.ShinreibyouStatus.Invincible_Locker)
            {
                Globals.ShinreibyouStatus.Invincible_Locker = false;
                return;
            }

            if (!Globals.ShinreibyouStatus.IsRun)
            {
                Globals.ShinreibyouStatus.Invincible_Locker = true;

                Invincible = false;


                return;
            }
            if (Globals.ShinreibyouStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!Invincible)
            {
                if (!Memory.SetMemory(Globals.ShinreibyouStatus.ProcessHandle, Globals.ShinreibyouStatus.BaseAddress + Offset.Shinreibyou_Sub_Invincible_Offset, Value.Shinreibyou_Sub_Invincible_Value_Default))
                {

                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.ShinreibyouStatus.ProcessHandle, Globals.ShinreibyouStatus.BaseAddress + Offset.Shinreibyou_Sub_Invincible_Offset, Value.Shinreibyou_Sub_Invincible_Value))
                {
                    Globals.ShinreibyouStatus.Invincible_Locker = true;
                    Invincible = false;

                    return;
                }
            }


        }




    }
}
