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
    /// Seirensen.xaml 的交互逻辑
    /// </summary>
    public partial class Seirensen : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public bool IsGreenDotVisible
        {
            get => Globals.SeirensenStatus.IsRun;
            set
            {
                if (Globals.SeirensenStatus.IsRun != value)
                {
                    Globals.SeirensenStatus.IsRun = value;
                    OnPropertyChanged(nameof(IsGreenDotVisible));
                }
            }
        }
        public bool LockPlayer
        {
            get => Globals.SeirensenStatus.LockPlayer;
            set
            {
                if (Globals.SeirensenStatus.LockPlayer != value)
                {
                    Globals.SeirensenStatus.LockPlayer = value;
                    OnPropertyChanged(nameof(LockPlayer));
                }
            }
        }
        public bool LockBomb
        {
            get => Globals.SeirensenStatus.LockBomb;
            set
            {
                if (Globals.SeirensenStatus.LockBomb != value)
                {
                    Globals.SeirensenStatus.LockBomb = value;
                    OnPropertyChanged(nameof(LockBomb));
                }
            }
        }
        public bool MaxPower
        {
            get => Globals.SeirensenStatus.MaxPower;
            set
            {
                if (Globals.SeirensenStatus.MaxPower != value)
                {
                    Globals.SeirensenStatus.MaxPower = value;
                    OnPropertyChanged(nameof(MaxPower));
                }
            }
        }
        public bool Invincible
        {
            get => Globals.SeirensenStatus.Invincible;
            set
            {
                if (Globals.SeirensenStatus.Invincible != value)
                {
                    Globals.SeirensenStatus.Invincible = value;
                    OnPropertyChanged(nameof(Invincible));
                }
            }
        }


        public Seirensen()
        {
            InitializeComponent();
            DataContext = this;
            IsGreenDotVisible = Globals.SeirensenStatus.IsRun;
            LockPlayer = Globals.SeirensenStatus.LockPlayer;
            LockBomb = Globals.SeirensenStatus.LockBomb;
            MaxPower = Globals.SeirensenStatus.MaxPower;
            Invincible = Globals.SeirensenStatus.Invincible;

            Globals.SeirensenStatus.IsTouhouRunChanged += OnGlobalsIsSeirensenRunChanged;
            Globals.SeirensenStatus.LockPlayerChanged += OnGlobaLockPlayerChanged;
            Globals.SeirensenStatus.LockBombChanged += OnGlobalsLockBombChanged;
            Globals.SeirensenStatus.MaxPowerChanged += OnGlobalsMaxPowerChanged;
            Globals.SeirensenStatus.InvincibleChanged += OnGlobalsInvincibleChanged;
        }

        private void OnGlobalsIsSeirensenRunChanged(object sender, EventArgs e)
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
            if (Globals.SeirensenStatus.BaseAddress == IntPtr.Zero && Globals.SeirensenStatus.ProcessHandle == IntPtr.Zero)
            {
                if (Globals.SeirensenStatus.IsRunStatus)
                {
                    (Globals.SeirensenStatus.BaseAddress, Globals.SeirensenStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th12");
                    if (Globals.SeirensenStatus.BaseAddress == IntPtr.Zero && Globals.SeirensenStatus.ProcessHandle == IntPtr.Zero)
                    {
                        return false;
                    }
                }
                if (Globals.SeirensenStatus.IsRunStatusC)
                {
                    (Globals.SeirensenStatus.BaseAddress, Globals.SeirensenStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th12c");
                    if (Globals.SeirensenStatus.BaseAddress == IntPtr.Zero && Globals.SeirensenStatus.ProcessHandle == IntPtr.Zero)
                    {
                        return false;
                    }
                }
                if (Globals.SeirensenStatus.IsRunStatusE)
                {
                    (Globals.SeirensenStatus.BaseAddress, Globals.SeirensenStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th12e");
                    if (Globals.SeirensenStatus.BaseAddress == IntPtr.Zero && Globals.SeirensenStatus.ProcessHandle == IntPtr.Zero)
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
            if (Globals.SeirensenStatus.LockPlayer_Locker)
            {
                Globals.SeirensenStatus.LockPlayer_Locker = false;
                return;
            }
            if (!Globals.SeirensenStatus.IsRun)
            {
                Globals.SeirensenStatus.LockPlayer_Locker = true;

                LockPlayer = false;

                return;

            }

            if (Globals.SeirensenStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!LockPlayer)
            {
                if (!Memory.SetMemory(Globals.SeirensenStatus.ProcessHandle, Globals.SeirensenStatus.BaseAddress + Offset.Seirensen_Sub_Plyaer_Offset, Value.Seirensen_Sub_Plyaer_Value_Default))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.SeirensenStatus.ProcessHandle, Globals.SeirensenStatus.BaseAddress + Offset.Seirensen_Sub_Plyaer_Offset, Value.Seirensen_Sub_Plyaer_Value))
                {
                    Globals.SeirensenStatus.LockPlayer_Locker = true;
                    LockPlayer = false;
                    return;
                }
            }


        }
        private void LockeBombToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.SeirensenStatus.LockerBomb_Locker)
            {
                Globals.SeirensenStatus.LockerBomb_Locker = false;
                return;
            }
            if (!Globals.SeirensenStatus.IsRun)
            {
                Globals.SeirensenStatus.LockerBomb_Locker = true;
                LockBomb = false;

                return;

            }
            if (Globals.SeirensenStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!LockBomb)
            {
                if (!Memory.SetMemory(Globals.SeirensenStatus.ProcessHandle, Globals.SeirensenStatus.BaseAddress + Offset.Seirensen_Sub_Bomb_Offset, Value.Seirensen_Sub_Plyaer_Value_Default))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.SeirensenStatus.ProcessHandle, Globals.SeirensenStatus.BaseAddress + Offset.Seirensen_Sub_Bomb_Offset, Value.Seirensen_Sub_Bomb_Value))
                {
                    Globals.SeirensenStatus.LockerBomb_Locker = true;
                    LockBomb = false;

                    return;
                }
            }

        }
        private void MaxPowerToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.SeirensenStatus.MaxPower_Locker)
            {
                Globals.SeirensenStatus.MaxPower_Locker = false;
                return;
            }
            if (!Globals.SeirensenStatus.IsRun)
            {
                Globals.SeirensenStatus.MaxPower_Locker = true;
                MaxPower = false;

                return;

            }

            if (Globals.SeirensenStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }
            if (!MaxPower)
            {
                if (!Memory.SetMemory(Globals.SeirensenStatus.ProcessHandle, Globals.SeirensenStatus.BaseAddress + Offset.Seirensen_Sub_Power_Offset, Value.Seirensen_Sub_Power_Value_Default))
                {
                    return;
                }


            }
            else
            {

                if (!Memory.SetMemory(Globals.SeirensenStatus.ProcessHandle, Globals.SeirensenStatus.BaseAddress + Offset.Seirensen_Power_Offset, Value.Seirensen_Power_Value))
                {
                    Globals.SeirensenStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


                if (!Memory.SetMemory(Globals.SeirensenStatus.ProcessHandle, Globals.SeirensenStatus.BaseAddress + Offset.Seirensen_Sub_Power_Offset, Value.Seirensen_Sub_Power_Value))
                {
                    Globals.SeirensenStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


            }


            MaxPower = MaxPowerSwitch.IsOn;

        }
        private void InvincibleToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.SeirensenStatus.Invincible_Locker)
            {
                Globals.SeirensenStatus.Invincible_Locker = false;
                return;
            }

            if (!Globals.SeirensenStatus.IsRun)
            {
                Globals.SeirensenStatus.Invincible_Locker = true;

                Invincible = false;


                return;
            }
            if (Globals.SeirensenStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!Invincible)
            {
                if (!Memory.SetMemory(Globals.SeirensenStatus.ProcessHandle, Globals.SeirensenStatus.BaseAddress + Offset.Seirensen_Sub_Invincible_Offset, Value.Seirensen_Sub_Invincible_Value_Default))
                {

                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.SeirensenStatus.ProcessHandle, Globals.SeirensenStatus.BaseAddress + Offset.Seirensen_Sub_Invincible_Offset, Value.Seirensen_Sub_Invincible_Value))
                {
                    Globals.SeirensenStatus.Invincible_Locker = true;
                    Invincible = false;

                    return;
                }
            }


        }




    }
}
