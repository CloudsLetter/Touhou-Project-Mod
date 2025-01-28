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
    /// Kikeijuu.xaml 的交互逻辑
    /// </summary>
    public partial class Kikeijuu : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public bool IsGreenDotVisible
        {
            get => Globals.KikeijuuStatus.IsRun;
            set
            {
                if (Globals.KikeijuuStatus.IsRun != value)
                {
                    Globals.KikeijuuStatus.IsRun = value;
                    OnPropertyChanged(nameof(IsGreenDotVisible));
                }
            }
        }
        public bool LockPlayer
        {
            get => Globals.KikeijuuStatus.LockPlayer;
            set
            {
                if (Globals.KikeijuuStatus.LockPlayer != value)
                {
                    Globals.KikeijuuStatus.LockPlayer = value;
                    OnPropertyChanged(nameof(LockPlayer));
                }
            }
        }
        public bool LockBomb
        {
            get => Globals.KikeijuuStatus.LockBomb;
            set
            {
                if (Globals.KikeijuuStatus.LockBomb != value)
                {
                    Globals.KikeijuuStatus.LockBomb = value;
                    OnPropertyChanged(nameof(LockBomb));
                }
            }
        }
        public bool MaxPower
        {
            get => Globals.KikeijuuStatus.MaxPower;
            set
            {
                if (Globals.KikeijuuStatus.MaxPower != value)
                {
                    Globals.KikeijuuStatus.MaxPower = value;
                    OnPropertyChanged(nameof(MaxPower));
                }
            }
        }
        public bool Invincible
        {
            get => Globals.KikeijuuStatus.Invincible;
            set
            {
                if (Globals.KikeijuuStatus.Invincible != value)
                {
                    Globals.KikeijuuStatus.Invincible = value;
                    OnPropertyChanged(nameof(Invincible));
                }
            }
        }


        public Kikeijuu()
        {
            InitializeComponent();
            DataContext = this;
            IsGreenDotVisible = Globals.KikeijuuStatus.IsRun;
            LockPlayer = Globals.KikeijuuStatus.LockPlayer;
            LockBomb = Globals.KikeijuuStatus.LockBomb;
            MaxPower = Globals.KikeijuuStatus.MaxPower;
            Invincible = Globals.KikeijuuStatus.Invincible;

            Globals.KikeijuuStatus.IsTouhouRunChanged += OnGlobalsIsKikeijuuRunChanged;
            Globals.KikeijuuStatus.LockPlayerChanged += OnGlobaLockPlayerChanged;
            Globals.KikeijuuStatus.LockBombChanged += OnGlobalsLockBombChanged;
            Globals.KikeijuuStatus.MaxPowerChanged += OnGlobalsMaxPowerChanged;
            Globals.KikeijuuStatus.InvincibleChanged += OnGlobalsInvincibleChanged;
        }

        private void OnGlobalsIsKikeijuuRunChanged(object sender, EventArgs e)
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
            if (Globals.KikeijuuStatus.BaseAddress == IntPtr.Zero && Globals.KikeijuuStatus.ProcessHandle == IntPtr.Zero)
            {
                if (Globals.KikeijuuStatus.IsRunStatus)
                {
                    (Globals.KikeijuuStatus.BaseAddress, Globals.KikeijuuStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th17");
                    if (Globals.KikeijuuStatus.BaseAddress == IntPtr.Zero && Globals.KikeijuuStatus.ProcessHandle == IntPtr.Zero)
                    {
                        return false;
                    }
                }
                if (Globals.KikeijuuStatus.IsRunStatusC)
                {
                    (Globals.KikeijuuStatus.BaseAddress, Globals.KikeijuuStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th17c");
                    if (Globals.KikeijuuStatus.BaseAddress == IntPtr.Zero && Globals.KikeijuuStatus.ProcessHandle == IntPtr.Zero)
                    {
                        return false;
                    }
                }
                if (Globals.KikeijuuStatus.IsRunStatusE)
                {
                    (Globals.KikeijuuStatus.BaseAddress, Globals.KikeijuuStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th17e");
                    if (Globals.KikeijuuStatus.BaseAddress == IntPtr.Zero && Globals.KikeijuuStatus.ProcessHandle == IntPtr.Zero)
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
            if (Globals.KikeijuuStatus.LockPlayer_Locker)
            {
                Globals.KikeijuuStatus.LockPlayer_Locker = false;
                return;
            }
            if (!Globals.KikeijuuStatus.IsRun)
            {
                Globals.KikeijuuStatus.LockPlayer_Locker = true;

                LockPlayer = false;

                return;

            }

            if (Globals.KikeijuuStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!LockPlayer)
            {
                if (!Memory.SetMemory(Globals.KikeijuuStatus.ProcessHandle, Globals.KikeijuuStatus.BaseAddress + Offset.Kikeijuu_Sub_Plyaer_Offset, Value.Kikeijuu_Sub_Plyaer_Value_Default))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.KikeijuuStatus.ProcessHandle, Globals.KikeijuuStatus.BaseAddress + Offset.Kikeijuu_Sub_Plyaer_Offset, Value.Kikeijuu_Sub_Plyaer_Value))
                {
                    Globals.KikeijuuStatus.LockPlayer_Locker = true;
                    LockPlayer = false;
                    return;
                }
            }


        }
        private void LockeBombToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.KikeijuuStatus.LockerBomb_Locker)
            {
                Globals.KikeijuuStatus.LockerBomb_Locker = false;
                return;
            }
            if (!Globals.KikeijuuStatus.IsRun)
            {
                Globals.KikeijuuStatus.LockerBomb_Locker = true;
                LockBomb = false;

                return;

            }
            if (Globals.KikeijuuStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!LockBomb)
            {
                if (!Memory.SetMemory(Globals.KikeijuuStatus.ProcessHandle, Globals.KikeijuuStatus.BaseAddress + Offset.Kikeijuu_Sub_Bomb_Offset, Value.Kikeijuu_Sub_Bomb_Value_Default))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.KikeijuuStatus.ProcessHandle, Globals.KikeijuuStatus.BaseAddress + Offset.Kikeijuu_Sub_Bomb_Offset, Value.Kikeijuu_Sub_Bomb_Value))
                {
                    Globals.KikeijuuStatus.LockerBomb_Locker = true;
                    LockBomb = false;

                    return;
                }
            }

        }
        private void MaxPowerToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.KikeijuuStatus.MaxPower_Locker)
            {
                Globals.KikeijuuStatus.MaxPower_Locker = false;
                return;
            }
            if (!Globals.KikeijuuStatus.IsRun)
            {
                Globals.KikeijuuStatus.MaxPower_Locker = true;
                MaxPower = false;

                return;

            }

            if (Globals.KikeijuuStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }
            if (!MaxPower)
            {
                if (!Memory.SetMemory(Globals.KikeijuuStatus.ProcessHandle, Globals.KikeijuuStatus.BaseAddress + Offset.Kikeijuu_Sub_Power_Offset, Value.Kikeijuu_Sub_Power_Value_Default))
                {
                    return;
                }


            }
            else
            {

                if (!Memory.SetMemory(Globals.KikeijuuStatus.ProcessHandle, Globals.KikeijuuStatus.BaseAddress + Offset.Kikeijuu_Power_Offset, Value.Kikeijuu_Power_Value))
                {
                    Globals.KikeijuuStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


                if (!Memory.SetMemory(Globals.KikeijuuStatus.ProcessHandle, Globals.KikeijuuStatus.BaseAddress + Offset.Kikeijuu_Sub_Power_Offset, Value.Kikeijuu_Sub_Power_Value))
                {
                    Globals.KikeijuuStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


            }


            MaxPower = MaxPowerSwitch.IsOn;

        }
        private void InvincibleToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.KikeijuuStatus.Invincible_Locker)
            {
                Globals.KikeijuuStatus.Invincible_Locker = false;
                return;
            }

            if (!Globals.KikeijuuStatus.IsRun)
            {
                Globals.KikeijuuStatus.Invincible_Locker = true;

                Invincible = false;


                return;
            }
            if (Globals.KikeijuuStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!Invincible)
            {
                if (!Memory.SetMemory(Globals.KikeijuuStatus.ProcessHandle, Globals.KikeijuuStatus.BaseAddress + Offset.Kikeijuu_Sub_Invincible_Offset, Value.Kikeijuu_Sub_Invincible_Value_Default))
                {

                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.KikeijuuStatus.ProcessHandle, Globals.KikeijuuStatus.BaseAddress + Offset.Kikeijuu_Sub_Invincible_Offset, Value.Kikeijuu_Sub_Invincible_Value))
                {
                    Globals.KikeijuuStatus.Invincible_Locker = true;
                    Invincible = false;

                    return;
                }
            }


        }




    }
}
