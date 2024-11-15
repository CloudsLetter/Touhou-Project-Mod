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
    /// Chireiden.xaml 的交互逻辑
    /// </summary>
    public partial class Chireiden : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public bool IsGreenDotVisible
        {
            get => Globals.ChireidenStatus.IsRun;
            set
            {
                if (Globals.ChireidenStatus.IsRun != value)
                {
                    Globals.ChireidenStatus.IsRun = value;
                    OnPropertyChanged(nameof(IsGreenDotVisible));
                }
            }
        }
        public bool LockPlayer
        {
            get => Globals.ChireidenStatus.LockPlayer;
            set
            {
                if (Globals.ChireidenStatus.LockPlayer != value)
                {
                    Globals.ChireidenStatus.LockPlayer = value;
                    OnPropertyChanged(nameof(LockPlayer));
                }
            }
        }
        public bool LockBomb
        {
            get => Globals.ChireidenStatus.LockBomb;
            set
            {
                if (Globals.ChireidenStatus.LockBomb != value)
                {
                    Globals.ChireidenStatus.LockBomb = value;
                    OnPropertyChanged(nameof(LockBomb));
                }
            }
        }
        public bool MaxPower
        {
            get => Globals.ChireidenStatus.MaxPower;
            set
            {
                if (Globals.ChireidenStatus.MaxPower != value)
                {
                    Globals.ChireidenStatus.MaxPower = value;
                    OnPropertyChanged(nameof(MaxPower));
                }
            }
        }
        public bool Invincible
        {
            get => Globals.ChireidenStatus.Invincible;
            set
            {
                if (Globals.ChireidenStatus.Invincible != value)
                {
                    Globals.ChireidenStatus.Invincible = value;
                    OnPropertyChanged(nameof(Invincible));
                }
            }
        }


        public Chireiden()
        {
            InitializeComponent();
            DataContext = this;
            IsGreenDotVisible = Globals.ChireidenStatus.IsRun;
            LockPlayer = Globals.ChireidenStatus.LockPlayer;
            LockBomb = Globals.ChireidenStatus.LockBomb;
            MaxPower = Globals.ChireidenStatus.MaxPower;
            Invincible = Globals.ChireidenStatus.Invincible;

            Globals.ChireidenStatus.IsTouhouRunChanged += OnGlobalsIsChireidenRunChanged;
            Globals.ChireidenStatus.LockPlayerChanged += OnGlobaLockPlayerChanged;
            Globals.ChireidenStatus.LockBombChanged += OnGlobalsLockBombChanged;
            Globals.ChireidenStatus.MaxPowerChanged += OnGlobalsMaxPowerChanged;
            Globals.ChireidenStatus.InvincibleChanged += OnGlobalsInvincibleChanged;
        }

        private void OnGlobalsIsChireidenRunChanged(object sender, EventArgs e)
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
            if (Globals.ChireidenStatus.BaseAddress == IntPtr.Zero && Globals.ChireidenStatus.ProcessHandle == IntPtr.Zero)
            {
                if (Globals.ChireidenStatus.IsRunStatus)
                {
                    (Globals.ChireidenStatus.BaseAddress, Globals.ChireidenStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th11");
                    if (Globals.ChireidenStatus.BaseAddress == IntPtr.Zero && Globals.ChireidenStatus.ProcessHandle == IntPtr.Zero)
                    {
                        return false;
                    }
                }
                if (Globals.ChireidenStatus.IsRunStatusC)
                {
                    (Globals.ChireidenStatus.BaseAddress, Globals.ChireidenStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th11c");
                    if (Globals.ChireidenStatus.BaseAddress == IntPtr.Zero && Globals.ChireidenStatus.ProcessHandle == IntPtr.Zero)
                    {
                        return false;
                    }
                }
                if (Globals.ChireidenStatus.IsRunStatusE)
                {
                    (Globals.ChireidenStatus.BaseAddress, Globals.ChireidenStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th11e");
                    if (Globals.ChireidenStatus.BaseAddress == IntPtr.Zero && Globals.ChireidenStatus.ProcessHandle == IntPtr.Zero)
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
            if (Globals.ChireidenStatus.LockPlayer_Locker)
            {
                Globals.ChireidenStatus.LockPlayer_Locker = false;
                return;
            }
            if (!Globals.ChireidenStatus.IsRun)
            {
                Globals.ChireidenStatus.LockPlayer_Locker = true;

                LockPlayer = false;

                return;

            }

            if (Globals.ChireidenStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!LockPlayer)
            {
                if (!Memory.SetMemory(Globals.ChireidenStatus.ProcessHandle, Globals.ChireidenStatus.BaseAddress + Offset.Chireiden_Sub_Plyaer_Offset, Globals.ChireidenStatus.PlayersOriginalBytes, false, Globals.PLAYEROB, Globals.ChireidenStatus, 0x00))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.ChireidenStatus.ProcessHandle, Globals.ChireidenStatus.BaseAddress + Offset.Chireiden_Sub_Plyaer_Offset, Value.Chireiden_Sub_Plyaer_Value, true, Globals.PLAYEROB, Globals.ChireidenStatus, 0x00))
                {
                    Globals.ChireidenStatus.LockPlayer_Locker = true;
                    LockPlayer = false;
                    return;
                }
            }


        }
        private void LockeBombToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.ChireidenStatus.LockerBomb_Locker)
            {
                Globals.ChireidenStatus.LockerBomb_Locker = false;
                return;
            }
            if (!Globals.ChireidenStatus.IsRun)
            {
                Globals.ChireidenStatus.LockerBomb_Locker = true;
                LockBomb = false;

                return;

            }
            if (Globals.ChireidenStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!LockBomb)
            {
                if (!Memory.SetMemory(Globals.ChireidenStatus.ProcessHandle, Globals.ChireidenStatus.BaseAddress + Offset.Chireiden_Sub_Bomb_Offset, Globals.ChireidenStatus.BombOriginalBytes, false, Globals.BOMBOB, Globals.ChireidenStatus, 0x00))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.ChireidenStatus.ProcessHandle, Globals.ChireidenStatus.BaseAddress + Offset.Chireiden_Sub_Bomb_Offset, Value.Chireiden_Sub_Bomb_Value, true, Globals.BOMBOB, Globals.ChireidenStatus, 0x00))
                {
                    Globals.ChireidenStatus.LockerBomb_Locker = true;
                    LockBomb = false;

                    return;
                }
            }

        }
        private void MaxPowerToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.ChireidenStatus.MaxPower_Locker)
            {
                Globals.ChireidenStatus.MaxPower_Locker = false;
                return;
            }
            if (!Globals.ChireidenStatus.IsRun)
            {
                Globals.ChireidenStatus.MaxPower_Locker = true;
                MaxPower = false;

                return;

            }

            if (Globals.ChireidenStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }
            if (!MaxPower)
            {
                if (!Memory.SetMemory(Globals.ChireidenStatus.ProcessHandle, Globals.ChireidenStatus.BaseAddress + Offset.Chireiden_Sub_Power_Offset, Globals.ChireidenStatus.PowerOriginalBytes, false, Globals.POWEROB, Globals.ChireidenStatus, 0x00))
                {
                    return;
                }


            }
            else
            {

                if (!Memory.SetMemory(Globals.ChireidenStatus.ProcessHandle, Globals.ChireidenStatus.BaseAddress + Offset.Chireiden_Power_Offset, Value.Chireiden_Power_Value, true, Globals.SETVALUE, Globals.ChireidenStatus, 0x00))
                {
                    Globals.ChireidenStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


                if (!Memory.SetMemory(Globals.ChireidenStatus.ProcessHandle, Globals.ChireidenStatus.BaseAddress + Offset.Chireiden_Sub_Power_Offset, Value.Chireiden_Sub_Power_Value, true, Globals.POWEROB, Globals.ChireidenStatus, 0x00))
                {
                    Globals.ChireidenStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


            }


            MaxPower = MaxPowerSwitch.IsOn;

        }
        private void InvincibleToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.ChireidenStatus.Invincible_Locker)
            {
                Globals.ChireidenStatus.Invincible_Locker = false;
                return;
            }

            if (!Globals.ChireidenStatus.IsRun)
            {
                Globals.ChireidenStatus.Invincible_Locker = true;

                Invincible = false;


                return;
            }
            if (Globals.ChireidenStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!Invincible)
            {
                if (!Memory.SetMemory(Globals.ChireidenStatus.ProcessHandle, Globals.ChireidenStatus.BaseAddress + Offset.Chireiden_Sub_Invincible_Offset, Globals.ChireidenStatus.InvincibleOriginalBytes, false, Globals.INVINCIBLEOB, Globals.ChireidenStatus, 0x00))
                {

                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.ChireidenStatus.ProcessHandle, Globals.ChireidenStatus.BaseAddress + Offset.Chireiden_Sub_Invincible_Offset, Value.Chireiden_Sub_Invincible_Value, true, Globals.INVINCIBLEOB, Globals.ChireidenStatus, 0x00))
                {
                    Globals.ChireidenStatus.Invincible_Locker = true;
                    Invincible = false;

                    return;
                }
            }


        }




    }
}
