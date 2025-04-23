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
    /// Kinjoukyou.xaml 的交互逻辑
    /// </summary>
    public partial class Kinjoukyou : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public bool IsGreenDotVisible
        {
            get => Globals.KinjoukyouStatus.IsRun;
            set
            {
                if (Globals.KinjoukyouStatus.IsRun != value)
                {
                    Globals.KinjoukyouStatus.IsRun = value;
                    OnPropertyChanged(nameof(IsGreenDotVisible));
                }
            }
        }
        public bool LockPlayer
        {
            get => Globals.KinjoukyouStatus.LockPlayer;
            set
            {
                if (Globals.KinjoukyouStatus.LockPlayer != value)
                {
                    Globals.KinjoukyouStatus.LockPlayer = value;
                    OnPropertyChanged(nameof(LockPlayer));
                }
            }
        }
        public bool LockBomb
        {
            get => Globals.KinjoukyouStatus.LockBomb;
            set
            {
                if (Globals.KinjoukyouStatus.LockBomb != value)
                {
                    Globals.KinjoukyouStatus.LockBomb = value;
                    OnPropertyChanged(nameof(LockBomb));
                }
            }
        }
        public bool MaxPower
        {
            get => Globals.KinjoukyouStatus.MaxPower;
            set
            {
                if (Globals.KinjoukyouStatus.MaxPower != value)
                {
                    Globals.KinjoukyouStatus.MaxPower = value;
                    OnPropertyChanged(nameof(MaxPower));
                }
            }
        }
        public bool Invincible
        {
            get => Globals.KinjoukyouStatus.Invincible;
            set
            {
                if (Globals.KinjoukyouStatus.Invincible != value)
                {
                    Globals.KinjoukyouStatus.Invincible = value;
                    OnPropertyChanged(nameof(Invincible));
                }
            }
        }


        public Kinjoukyou()
        {
            InitializeComponent();
            DataContext = this;
            IsGreenDotVisible = Globals.KinjoukyouStatus.IsRun;
            LockPlayer = Globals.KinjoukyouStatus.LockPlayer;
            LockBomb = Globals.KinjoukyouStatus.LockBomb;
            MaxPower = Globals.KinjoukyouStatus.MaxPower;
            Invincible = Globals.KinjoukyouStatus.Invincible;

            Globals.KinjoukyouStatus.IsTouhouRunChanged += OnGlobalsIsKinjoukyouRunChanged;
            Globals.KinjoukyouStatus.LockPlayerChanged += OnGlobaLockPlayerChanged;
            Globals.KinjoukyouStatus.LockBombChanged += OnGlobalsLockBombChanged;
            Globals.KinjoukyouStatus.MaxPowerChanged += OnGlobalsMaxPowerChanged;
            Globals.KinjoukyouStatus.InvincibleChanged += OnGlobalsInvincibleChanged;
        }

        private void OnGlobalsIsKinjoukyouRunChanged(object sender, EventArgs e)
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
            if (Globals.KinjoukyouStatus.BaseAddress == IntPtr.Zero && Globals.KinjoukyouStatus.ProcessHandle == IntPtr.Zero)
            {
                if (Globals.KinjoukyouStatus.IsRunStatus)
                {
                    (Globals.KinjoukyouStatus.BaseAddress, Globals.KinjoukyouStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th20");
                    if (Globals.KinjoukyouStatus.BaseAddress == IntPtr.Zero && Globals.KinjoukyouStatus.ProcessHandle == IntPtr.Zero)
                    {
                        return false;
                    }
                }
                if (Globals.KinjoukyouStatus.IsRunStatusC)
                {
                    (Globals.KinjoukyouStatus.BaseAddress, Globals.KinjoukyouStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th20c");
                    if (Globals.KinjoukyouStatus.BaseAddress == IntPtr.Zero && Globals.KinjoukyouStatus.ProcessHandle == IntPtr.Zero)
                    {
                        return false;
                    }
                }
                if (Globals.KinjoukyouStatus.IsRunStatusE)
                {
                    (Globals.KinjoukyouStatus.BaseAddress, Globals.KinjoukyouStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th20e");
                    if (Globals.KinjoukyouStatus.BaseAddress == IntPtr.Zero && Globals.KinjoukyouStatus.ProcessHandle == IntPtr.Zero)
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
            if (Globals.KinjoukyouStatus.LockPlayer_Locker)
            {
                Globals.KinjoukyouStatus.LockPlayer_Locker = false;
                return;
            }
            if (!Globals.KinjoukyouStatus.IsRun)
            {
                Globals.KinjoukyouStatus.LockPlayer_Locker = true;

                LockPlayer = false;

                return;

            }

            if (Globals.KinjoukyouStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!LockPlayer)
            {
                if (!Memory.SetMemory(Globals.KinjoukyouStatus.ProcessHandle, Globals.KinjoukyouStatus.BaseAddress + Offset.Kinjoukyou_Sub_Plyaer_Offset, Value.Kinjoukyou_Sub_Plyaer_Value_Default))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.KinjoukyouStatus.ProcessHandle, Globals.KinjoukyouStatus.BaseAddress + Offset.Kinjoukyou_Sub_Plyaer_Offset, Value.Kinjoukyou_Sub_Plyaer_Value))
                {
                    Globals.KinjoukyouStatus.LockPlayer_Locker = true;
                    LockPlayer = false;
                    return;
                }
            }


        }
        private void LockeBombToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.KinjoukyouStatus.LockerBomb_Locker)
            {
                Globals.KinjoukyouStatus.LockerBomb_Locker = false;
                return;
            }
            if (!Globals.KinjoukyouStatus.IsRun)
            {
                Globals.KinjoukyouStatus.LockerBomb_Locker = true;
                LockBomb = false;

                return;

            }
            if (Globals.KinjoukyouStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!LockBomb)
            {
                if (!Memory.SetMemory(Globals.KinjoukyouStatus.ProcessHandle, Globals.KinjoukyouStatus.BaseAddress + Offset.Kinjoukyou_Sub_Bomb_Offset, Value.Kinjoukyou_Sub_Bomb_Value_Default))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.KinjoukyouStatus.ProcessHandle, Globals.KinjoukyouStatus.BaseAddress + Offset.Kinjoukyou_Sub_Bomb_Offset, Value.Kinjoukyou_Sub_Bomb_Value))
                {
                    Globals.KinjoukyouStatus.LockerBomb_Locker = true;
                    LockBomb = false;

                    return;
                }
            }

        }
        private void MaxPowerToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.KinjoukyouStatus.MaxPower_Locker)
            {
                Globals.KinjoukyouStatus.MaxPower_Locker = false;
                return;
            }
            if (!Globals.KinjoukyouStatus.IsRun)
            {
                Globals.KinjoukyouStatus.MaxPower_Locker = true;
                MaxPower = false;

                return;

            }

            if (Globals.KinjoukyouStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }
            if (!MaxPower)
            {
                if (!Memory.SetMemory(Globals.KinjoukyouStatus.ProcessHandle, Globals.KinjoukyouStatus.BaseAddress + Offset.Kinjoukyou_Sub_Power_Offset, Value.Kinjoukyou_Sub_Power_Value_Default))
                {
                    return;
                }


            }
            else
            {

                if (!Memory.SetMemory(Globals.KinjoukyouStatus.ProcessHandle, Globals.KinjoukyouStatus.BaseAddress + Offset.Kinjoukyou_Power_Offset, Value.Kinjoukyou_Power_Value))
                {
                    Globals.KinjoukyouStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


                if (!Memory.SetMemory(Globals.KinjoukyouStatus.ProcessHandle, Globals.KinjoukyouStatus.BaseAddress + Offset.Kinjoukyou_Sub_Power_Offset, Value.Kinjoukyou_Sub_Power_Value))
                {
                    Globals.KinjoukyouStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


            }


            MaxPower = MaxPowerSwitch.IsOn;

        }
        private void InvincibleToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.KinjoukyouStatus.Invincible_Locker)
            {
                Globals.KinjoukyouStatus.Invincible_Locker = false;
                return;
            }

            if (!Globals.KinjoukyouStatus.IsRun)
            {
                Globals.KinjoukyouStatus.Invincible_Locker = true;

                Invincible = false;


                return;
            }
            if (Globals.KinjoukyouStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!Invincible)
            {
                if (!Memory.SetMemory(Globals.KinjoukyouStatus.ProcessHandle, Globals.KinjoukyouStatus.BaseAddress + Offset.Kinjoukyou_Sub_Invincible_Offset, Value.Kinjoukyou_Sub_Invincible_Value_Default))
                {

                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.KinjoukyouStatus.ProcessHandle, Globals.KinjoukyouStatus.BaseAddress + Offset.Kinjoukyou_Sub_Invincible_Offset, Value.Kinjoukyou_Sub_Invincible_Value))
                {
                    Globals.KinjoukyouStatus.Invincible_Locker = true;
                    Invincible = false;

                    return;
                }
            }


        }




    }
}
