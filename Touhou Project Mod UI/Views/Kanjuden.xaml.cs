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
    /// Kanjuden.xaml 的交互逻辑
    /// </summary>
    public partial class Kanjuden : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public bool IsGreenDotVisible
        {
            get => Globals.KanjudenStatus.IsRun;
            set
            {
                if (Globals.KanjudenStatus.IsRun != value)
                {
                    Globals.KanjudenStatus.IsRun = value;
                    OnPropertyChanged(nameof(IsGreenDotVisible));
                }
            }
        }
        public bool LockPlayer
        {
            get => Globals.KanjudenStatus.LockPlayer;
            set
            {
                if (Globals.KanjudenStatus.LockPlayer != value)
                {
                    Globals.KanjudenStatus.LockPlayer = value;
                    OnPropertyChanged(nameof(LockPlayer));
                }
            }
        }
        public bool LockBomb
        {
            get => Globals.KanjudenStatus.LockBomb;
            set
            {
                if (Globals.KanjudenStatus.LockBomb != value)
                {
                    Globals.KanjudenStatus.LockBomb = value;
                    OnPropertyChanged(nameof(LockBomb));
                }
            }
        }
        public bool MaxPower
        {
            get => Globals.KanjudenStatus.MaxPower;
            set
            {
                if (Globals.KanjudenStatus.MaxPower != value)
                {
                    Globals.KanjudenStatus.MaxPower = value;
                    OnPropertyChanged(nameof(MaxPower));
                }
            }
        }
        public bool Invincible
        {
            get => Globals.KanjudenStatus.Invincible;
            set
            {
                if (Globals.KanjudenStatus.Invincible != value)
                {
                    Globals.KanjudenStatus.Invincible = value;
                    OnPropertyChanged(nameof(Invincible));
                }
            }
        }


        public Kanjuden()
        {
            InitializeComponent();
            DataContext = this;
            IsGreenDotVisible = Globals.KanjudenStatus.IsRun;
            LockPlayer = Globals.KanjudenStatus.LockPlayer;
            LockBomb = Globals.KanjudenStatus.LockBomb;
            MaxPower = Globals.KanjudenStatus.MaxPower;
            Invincible = Globals.KanjudenStatus.Invincible;

            Globals.KanjudenStatus.IsTouhouRunChanged += OnGlobalsIsKanjudenRunChanged;
            Globals.KanjudenStatus.LockPlayerChanged += OnGlobaLockPlayerChanged;
            Globals.KanjudenStatus.LockBombChanged += OnGlobalsLockBombChanged;
            Globals.KanjudenStatus.MaxPowerChanged += OnGlobalsMaxPowerChanged;
            Globals.KanjudenStatus.InvincibleChanged += OnGlobalsInvincibleChanged;
        }

        private void OnGlobalsIsKanjudenRunChanged(object sender, EventArgs e)
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
            if (Globals.KanjudenStatus.BaseAddress == IntPtr.Zero && Globals.KanjudenStatus.ProcessHandle == IntPtr.Zero)
            {
                if (Globals.KanjudenStatus.IsRunStatus)
                {
                    (Globals.KanjudenStatus.BaseAddress, Globals.KanjudenStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th15");
                    if (Globals.KanjudenStatus.BaseAddress == IntPtr.Zero && Globals.KanjudenStatus.ProcessHandle == IntPtr.Zero)
                    {
                        return false;
                    }
                }
                if (Globals.KanjudenStatus.IsRunStatusC)
                {
                    (Globals.KanjudenStatus.BaseAddress, Globals.KanjudenStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th15c");
                    if (Globals.KanjudenStatus.BaseAddress == IntPtr.Zero && Globals.KanjudenStatus.ProcessHandle == IntPtr.Zero)
                    {
                        return false;
                    }
                }
                if (Globals.KanjudenStatus.IsRunStatusE)
                {
                    (Globals.KanjudenStatus.BaseAddress, Globals.KanjudenStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th15e");
                    if (Globals.KanjudenStatus.BaseAddress == IntPtr.Zero && Globals.KanjudenStatus.ProcessHandle == IntPtr.Zero)
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
            if (Globals.KanjudenStatus.LockPlayer_Locker)
            {
                Globals.KanjudenStatus.LockPlayer_Locker = false;
                return;
            }
            if (!Globals.KanjudenStatus.IsRun)
            {
                Globals.KanjudenStatus.LockPlayer_Locker = true;

                LockPlayer = false;

                return;

            }

            if (!GetMemoryInfo())
            {
                return;
            }

            if (!LockPlayer)
            {
                if (!Memory.SetMemory(Globals.KanjudenStatus.ProcessHandle, Globals.KanjudenStatus.BaseAddress + Offset.Kanjuden_Sub_Plyaer_Offset, Globals.KanjudenStatus.PlayersOriginalBytes, false, Globals.PLAYEROB, Globals.KanjudenStatus, 0x00))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.KanjudenStatus.ProcessHandle, Globals.KanjudenStatus.BaseAddress + Offset.Kanjuden_Sub_Plyaer_Offset, Value.Kanjuden_Sub_Plyaer_Value, true, Globals.PLAYEROB, Globals.KanjudenStatus, 0x00))
                {
                    Globals.KanjudenStatus.LockPlayer_Locker = true;
                    LockPlayer = false;
                    return;
                }
            }


        }
        private void LockeBombToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.KanjudenStatus.LockerBomb_Locker)
            {
                Globals.KanjudenStatus.LockerBomb_Locker = false;
                return;
            }
            if (!Globals.KanjudenStatus.IsRun)
            {
                Globals.KanjudenStatus.LockerBomb_Locker = true;
                LockBomb = false;

                return;

            }
            if (!GetMemoryInfo())
            {
                return;
            }

            if (!LockBomb)
            {
                if (!Memory.SetMemory(Globals.KanjudenStatus.ProcessHandle, Globals.KanjudenStatus.BaseAddress + Offset.Kanjuden_Sub_Bomb_Offset, Globals.KanjudenStatus.BombOriginalBytes, false, Globals.BOMBOB, Globals.KanjudenStatus, 0x00))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.KanjudenStatus.ProcessHandle, Globals.KanjudenStatus.BaseAddress + Offset.Kanjuden_Sub_Bomb_Offset, Value.Kanjuden_Sub_Bomb_Value, true, Globals.BOMBOB, Globals.KanjudenStatus, 0x00))
                {
                    Globals.KanjudenStatus.LockerBomb_Locker = true;
                    LockBomb = false;

                    return;
                }
            }

        }
        private void MaxPowerToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.KanjudenStatus.MaxPower_Locker)
            {
                Globals.KanjudenStatus.MaxPower_Locker = false;
                return;
            }
            if (!Globals.KanjudenStatus.IsRun)
            {
                Globals.KanjudenStatus.MaxPower_Locker = true;
                MaxPower = false;

                return;

            }

            if (!GetMemoryInfo())
            {
                return;
            }
            if (!MaxPower)
            {
                if (!Memory.SetMemory(Globals.KanjudenStatus.ProcessHandle, Globals.KanjudenStatus.BaseAddress + Offset.Kanjuden_Sub_Power_Offset, Globals.KanjudenStatus.PowerOriginalBytes, false, Globals.POWEROB, Globals.KanjudenStatus, 0x00))
                {
                    return;
                }


            }
            else
            {

                if (!Memory.SetMemory(Globals.KanjudenStatus.ProcessHandle, Globals.KanjudenStatus.BaseAddress + Offset.Kanjuden_Power_Offset, Value.Kanjuden_Power_Value, true, Globals.SETVALUE, Globals.KanjudenStatus, 0x00))
                {
                    Globals.KanjudenStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


                if (!Memory.SetMemory(Globals.KanjudenStatus.ProcessHandle, Globals.KanjudenStatus.BaseAddress + Offset.Kanjuden_Sub_Power_Offset, Value.Kanjuden_Sub_Power_Value, true, Globals.POWEROB, Globals.KanjudenStatus, 0x00))
                {
                    Globals.KanjudenStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


            }


            MaxPower = MaxPowerSwitch.IsOn;

        }
        private void InvincibleToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.KanjudenStatus.Invincible_Locker)
            {
                Globals.KanjudenStatus.Invincible_Locker = false;
                return;
            }

            if (!Globals.KanjudenStatus.IsRun)
            {
                Globals.KanjudenStatus.Invincible_Locker = true;

                Invincible = false;


                return;
            }
            if (!GetMemoryInfo())
            {
                return;
            }

            if (!Invincible)
            {
                if (!Memory.SetMemory(Globals.KanjudenStatus.ProcessHandle, Globals.KanjudenStatus.BaseAddress + Offset.Kanjuden_Sub_Invincible_Offset, Globals.KanjudenStatus.InvincibleOriginalBytes, false, Globals.INVINCIBLEOB, Globals.KanjudenStatus, 0x00))
                {

                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.KanjudenStatus.ProcessHandle, Globals.KanjudenStatus.BaseAddress + Offset.Kanjuden_Sub_Invincible_Offset, Value.Kanjuden_Sub_Invincible_Value, true, Globals.INVINCIBLEOB, Globals.KanjudenStatus, 0x00))
                {
                    Globals.KanjudenStatus.Invincible_Locker = true;
                    Invincible = false;

                    return;
                }
            }


        }




    }
}
