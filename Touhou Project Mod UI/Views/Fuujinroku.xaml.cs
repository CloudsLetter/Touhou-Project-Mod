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
    /// Fuujinroku.xaml 的交互逻辑
    /// </summary>
    public partial class Fuujinroku : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public bool IsGreenDotVisible
        {
            get => Globals.FuujinrokuStatus.IsRun;
            set
            {
                if (Globals.FuujinrokuStatus.IsRun != value)
                {
                    Globals.FuujinrokuStatus.IsRun = value;
                    OnPropertyChanged(nameof(IsGreenDotVisible));
                }
            }
        }
        public bool LockPlayer
        {
            get => Globals.FuujinrokuStatus.LockPlayer;
            set
            {
                if (Globals.FuujinrokuStatus.LockPlayer != value)
                {
                    Globals.FuujinrokuStatus.LockPlayer = value;
                    OnPropertyChanged(nameof(LockPlayer));
                }
            }
        }
        public bool LockBomb
        {
            get => Globals.FuujinrokuStatus.LockBomb;
            set
            {
                if (Globals.FuujinrokuStatus.LockBomb != value)
                {
                    Globals.FuujinrokuStatus.LockBomb = value;
                    OnPropertyChanged(nameof(LockBomb));
                }
            }
        }
        public bool MaxPower
        {
            get => Globals.FuujinrokuStatus.MaxPower;
            set
            {
                if (Globals.FuujinrokuStatus.MaxPower != value)
                {
                    Globals.FuujinrokuStatus.MaxPower = value;
                    OnPropertyChanged(nameof(MaxPower));
                }
            }
        }
        public bool Invincible
        {
            get => Globals.FuujinrokuStatus.Invincible;
            set
            {
                if (Globals.FuujinrokuStatus.Invincible != value)
                {
                    Globals.FuujinrokuStatus.Invincible = value;
                    OnPropertyChanged(nameof(Invincible));
                }
            }
        }


        public Fuujinroku()
        {
            InitializeComponent();
            DataContext = this;
            IsGreenDotVisible = Globals.FuujinrokuStatus.IsRun;
            LockPlayer = Globals.FuujinrokuStatus.LockPlayer;
            LockBomb = Globals.FuujinrokuStatus.LockBomb;
            MaxPower = Globals.FuujinrokuStatus.MaxPower;
            Invincible = Globals.FuujinrokuStatus.Invincible;

            Globals.FuujinrokuStatus.IsTouhouRunChanged += OnGlobalsIsFuujinrokuRunChanged;
            Globals.FuujinrokuStatus.LockPlayerChanged += OnGlobaLockPlayerChanged;
            Globals.FuujinrokuStatus.LockBombChanged += OnGlobalsLockBombChanged;
            Globals.FuujinrokuStatus.MaxPowerChanged += OnGlobalsMaxPowerChanged;
            Globals.FuujinrokuStatus.InvincibleChanged += OnGlobalsInvincibleChanged;
        }

        private void OnGlobalsIsFuujinrokuRunChanged(object sender, EventArgs e)
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
            if (Globals.FuujinrokuStatus.BaseAddress == IntPtr.Zero && Globals.FuujinrokuStatus.ProcessHandle == IntPtr.Zero)
            {
                if (Globals.FuujinrokuStatus.IsRunStatus)
                {
                    (Globals.FuujinrokuStatus.BaseAddress, Globals.FuujinrokuStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th10");
                    if (Globals.FuujinrokuStatus.BaseAddress == IntPtr.Zero && Globals.FuujinrokuStatus.ProcessHandle == IntPtr.Zero)
                    {
                        return false;
                    }
                }
                if (Globals.FuujinrokuStatus.IsRunStatusC)
                {
                    (Globals.FuujinrokuStatus.BaseAddress, Globals.FuujinrokuStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th10c");
                    if (Globals.FuujinrokuStatus.BaseAddress == IntPtr.Zero && Globals.FuujinrokuStatus.ProcessHandle == IntPtr.Zero)
                    {
                        return false;
                    }
                }
                if (Globals.FuujinrokuStatus.IsRunStatusE)
                {
                    (Globals.FuujinrokuStatus.BaseAddress, Globals.FuujinrokuStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th10e");
                    if (Globals.FuujinrokuStatus.BaseAddress == IntPtr.Zero && Globals.FuujinrokuStatus.ProcessHandle == IntPtr.Zero)
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
            if (Globals.FuujinrokuStatus.LockPlayer_Locker)
            {
                Globals.FuujinrokuStatus.LockPlayer_Locker = false;
                return;
            }
            if (!Globals.FuujinrokuStatus.IsRun)
            {
                Globals.FuujinrokuStatus.LockPlayer_Locker = true;

                LockPlayer = false;

                return;

            }

            if (!GetMemoryInfo())
            {
                return;
            }

            if (!LockPlayer)
            {
                if (!Memory.SetMemory(Globals.FuujinrokuStatus.ProcessHandle, Globals.FuujinrokuStatus.BaseAddress + Offset.Fuujinroku_Sub_Plyaer_Offset, Globals.FuujinrokuStatus.PlayersOriginalBytes, false, Globals.PLAYEROB, Globals.FuujinrokuStatus, 0x00))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.FuujinrokuStatus.ProcessHandle, Globals.FuujinrokuStatus.BaseAddress + Offset.Fuujinroku_Sub_Plyaer_Offset, Value.Fuujinroku_Sub_Plyaer_Value, true, Globals.PLAYEROB, Globals.FuujinrokuStatus, 0x00))
                {
                    Globals.FuujinrokuStatus.LockPlayer_Locker = true;
                    LockPlayer = false;
                    return;
                }
            }


        }
        private void LockeBombToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.FuujinrokuStatus.LockerBomb_Locker)
            {
                Globals.FuujinrokuStatus.LockerBomb_Locker = false;
                return;
            }
            if (!Globals.FuujinrokuStatus.IsRun)
            {
                Globals.FuujinrokuStatus.LockerBomb_Locker = true;
                LockBomb = false;

                return;

            }
            if (!GetMemoryInfo())
            {
                return;
            }

            if (!LockBomb)
            {
                if (!Memory.SetMemory(Globals.FuujinrokuStatus.ProcessHandle, Globals.FuujinrokuStatus.BaseAddress + Offset.Fuujinroku_Sub_Bomb_Offset, Globals.FuujinrokuStatus.BombOriginalBytes, false, Globals.BOMBOB, Globals.FuujinrokuStatus, 0x00))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.FuujinrokuStatus.ProcessHandle, Globals.FuujinrokuStatus.BaseAddress + Offset.Fuujinroku_Sub_Bomb_Offset, Value.Fuujinroku_Sub_Bomb_Value, true, Globals.BOMBOB, Globals.FuujinrokuStatus, 0x00))
                {
                    Globals.FuujinrokuStatus.LockerBomb_Locker = true;
                    LockBomb = false;

                    return;
                }
            }

        }
        private void MaxPowerToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.FuujinrokuStatus.MaxPower_Locker)
            {
                Globals.FuujinrokuStatus.MaxPower_Locker = false;
                return;
            }
            if (!Globals.FuujinrokuStatus.IsRun)
            {
                Globals.FuujinrokuStatus.MaxPower_Locker = true;
                MaxPower = false;

                return;

            }

            if (!GetMemoryInfo())
            {
                return;
            }
            if (!MaxPower)
            {
                if (!Memory.SetMemory(Globals.FuujinrokuStatus.ProcessHandle, Globals.FuujinrokuStatus.BaseAddress + Offset.Fuujinroku_Sub_Power_Offset, Globals.FuujinrokuStatus.PowerOriginalBytes, false, Globals.POWEROB, Globals.FuujinrokuStatus, 0x00))
                {
                    return;
                }


            }
            else
            {

                if (!Memory.SetMemory(Globals.FuujinrokuStatus.ProcessHandle, Globals.FuujinrokuStatus.BaseAddress + Offset.Fuujinroku_Power_Offset, Value.Fuujinroku_Power_Value, true, Globals.SETVALUE, Globals.FuujinrokuStatus, 0x00))
                {
                    Globals.FuujinrokuStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


                if (!Memory.SetMemory(Globals.FuujinrokuStatus.ProcessHandle, Globals.FuujinrokuStatus.BaseAddress + Offset.Fuujinroku_Sub_Power_Offset, Value.Fuujinroku_Sub_Power_Value, true, Globals.POWEROB, Globals.FuujinrokuStatus, 0x00))
                {
                    Globals.FuujinrokuStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


            }


            MaxPower = MaxPowerSwitch.IsOn;

        }
        private void InvincibleToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.FuujinrokuStatus.Invincible_Locker)
            {
                Globals.FuujinrokuStatus.Invincible_Locker = false;
                return;
            }

            if (!Globals.FuujinrokuStatus.IsRun)
            {
                Globals.FuujinrokuStatus.Invincible_Locker = true;

                Invincible = false;


                return;
            }
            if (!GetMemoryInfo())
            {
                return;
            }

            if (!Invincible)
            {
                if (!Memory.SetMemory(Globals.FuujinrokuStatus.ProcessHandle, Globals.FuujinrokuStatus.BaseAddress + Offset.Fuujinroku_Sub_Invincible_Offset, Globals.FuujinrokuStatus.InvincibleOriginalBytes, false, Globals.INVINCIBLEOB, Globals.FuujinrokuStatus, 0x00))
                {

                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.FuujinrokuStatus.ProcessHandle, Globals.FuujinrokuStatus.BaseAddress + Offset.Fuujinroku_Sub_Invincible_Offset, Value.Fuujinroku_Sub_Invincible_Value, true, Globals.INVINCIBLEOB, Globals.FuujinrokuStatus, 0x00))
                {
                    Globals.FuujinrokuStatus.Invincible_Locker = true;
                    Invincible = false;

                    return;
                }
            }


        }




    }
}
