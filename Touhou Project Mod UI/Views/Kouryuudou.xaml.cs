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
    /// Kouryuudou.xaml 的交互逻辑
    /// </summary>
    public partial class Kouryuudou : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public bool IsGreenDotVisible
        {
            get => Globals.KouryuudouStatus.IsRun;
            set
            {
                if (Globals.KouryuudouStatus.IsRun != value)
                {
                    Globals.KouryuudouStatus.IsRun = value;
                    OnPropertyChanged(nameof(IsGreenDotVisible));
                }
            }
        }
        public bool LockPlayer
        {
            get => Globals.KouryuudouStatus.LockPlayer;
            set
            {
                if (Globals.KouryuudouStatus.LockPlayer != value)
                {
                    Globals.KouryuudouStatus.LockPlayer = value;
                    OnPropertyChanged(nameof(LockPlayer));
                }
            }
        }
        public bool LockBomb
        {
            get => Globals.KouryuudouStatus.LockBomb;
            set
            {
                if (Globals.KouryuudouStatus.LockBomb != value)
                {
                    Globals.KouryuudouStatus.LockBomb = value;
                    OnPropertyChanged(nameof(LockBomb));
                }
            }
        }
        public bool MaxPower
        {
            get => Globals.KouryuudouStatus.MaxPower;
            set
            {
                if (Globals.KouryuudouStatus.MaxPower != value)
                {
                    Globals.KouryuudouStatus.MaxPower = value;
                    OnPropertyChanged(nameof(MaxPower));
                }
            }
        }
        public bool Invincible
        {
            get => Globals.KouryuudouStatus.Invincible;
            set
            {
                if (Globals.KouryuudouStatus.Invincible != value)
                {
                    Globals.KouryuudouStatus.Invincible = value;
                    OnPropertyChanged(nameof(Invincible));
                }
            }
        }


        public Kouryuudou()
        {
            InitializeComponent();
            DataContext = this;
            IsGreenDotVisible = Globals.KouryuudouStatus.IsRun;
            LockPlayer = Globals.KouryuudouStatus.LockPlayer;
            LockBomb = Globals.KouryuudouStatus.LockBomb;
            MaxPower = Globals.KouryuudouStatus.MaxPower;
            Invincible = Globals.KouryuudouStatus.Invincible;

            Globals.KouryuudouStatus.IsTouhouRunChanged += OnGlobalsIsKouryuudouRunChanged;
            Globals.KouryuudouStatus.LockPlayerChanged += OnGlobaLockPlayerChanged;
            Globals.KouryuudouStatus.LockBombChanged += OnGlobalsLockBombChanged;
            Globals.KouryuudouStatus.MaxPowerChanged += OnGlobalsMaxPowerChanged;
            Globals.KouryuudouStatus.InvincibleChanged += OnGlobalsInvincibleChanged;
        }

        private void OnGlobalsIsKouryuudouRunChanged(object sender, EventArgs e)
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
            if (Globals.KouryuudouStatus.BaseAddress == IntPtr.Zero && Globals.KouryuudouStatus.ProcessHandle == IntPtr.Zero)
            {
                if (Globals.KouryuudouStatus.IsRunStatus)
                {
                    (Globals.KouryuudouStatus.BaseAddress, Globals.KouryuudouStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th18");
                    if (Globals.KouryuudouStatus.BaseAddress == IntPtr.Zero && Globals.KouryuudouStatus.ProcessHandle == IntPtr.Zero)
                    {
                        return false;
                    }
                }
                if (Globals.KouryuudouStatus.IsRunStatusC)
                {
                    (Globals.KouryuudouStatus.BaseAddress, Globals.KouryuudouStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th18c");
                    if (Globals.KouryuudouStatus.BaseAddress == IntPtr.Zero && Globals.KouryuudouStatus.ProcessHandle == IntPtr.Zero)
                    {
                        return false;
                    }
                }
                if (Globals.KouryuudouStatus.IsRunStatusE)
                {
                    (Globals.KouryuudouStatus.BaseAddress, Globals.KouryuudouStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th18e");
                    if (Globals.KouryuudouStatus.BaseAddress == IntPtr.Zero && Globals.KouryuudouStatus.ProcessHandle == IntPtr.Zero)
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
            if (Globals.KouryuudouStatus.LockPlayer_Locker)
            {
                Globals.KouryuudouStatus.LockPlayer_Locker = false;
                return;
            }
            if (!Globals.KouryuudouStatus.IsRun)
            {
                Globals.KouryuudouStatus.LockPlayer_Locker = true;

                LockPlayer = false;

                return;

            }

            if (!GetMemoryInfo())
            {
                return;
            }

            if (!LockPlayer)
            {
                if (!Memory.SetMemory(Globals.KouryuudouStatus.ProcessHandle, Globals.KouryuudouStatus.BaseAddress + Offset.Kouryuudou_Sub_Plyaer_Offset, Globals.KouryuudouStatus.PlayersOriginalBytes, false, Globals.PLAYEROB, Globals.KouryuudouStatus, 0x00))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.KouryuudouStatus.ProcessHandle, Globals.KouryuudouStatus.BaseAddress + Offset.Kouryuudou_Sub_Plyaer_Offset, Value.Kouryuudou_Sub_Plyaer_Value, true, Globals.PLAYEROB, Globals.KouryuudouStatus, 0x00))
                {
                    Globals.KouryuudouStatus.LockPlayer_Locker = true;
                    LockPlayer = false;
                    return;
                }
            }


        }
        private void LockeBombToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.KouryuudouStatus.LockerBomb_Locker)
            {
                Globals.KouryuudouStatus.LockerBomb_Locker = false;
                return;
            }
            if (!Globals.KouryuudouStatus.IsRun)
            {
                Globals.KouryuudouStatus.LockerBomb_Locker = true;
                LockBomb = false;

                return;

            }
            if (!GetMemoryInfo())
            {
                return;
            }

            if (!LockBomb)
            {
                if (!Memory.SetMemory(Globals.KouryuudouStatus.ProcessHandle, Globals.KouryuudouStatus.BaseAddress + Offset.Kouryuudou_Sub_Bomb_Offset, Globals.KouryuudouStatus.BombOriginalBytes, false, Globals.BOMBOB, Globals.KouryuudouStatus, 0x00))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.KouryuudouStatus.ProcessHandle, Globals.KouryuudouStatus.BaseAddress + Offset.Kouryuudou_Sub_Bomb_Offset, Value.Kouryuudou_Sub_Bomb_Value, true, Globals.BOMBOB, Globals.KouryuudouStatus, 0x00))
                {
                    Globals.KouryuudouStatus.LockerBomb_Locker = true;
                    LockBomb = false;

                    return;
                }
            }

        }
        private void MaxPowerToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.KouryuudouStatus.MaxPower_Locker)
            {
                Globals.KouryuudouStatus.MaxPower_Locker = false;
                return;
            }
            if (!Globals.KouryuudouStatus.IsRun)
            {
                Globals.KouryuudouStatus.MaxPower_Locker = true;
                MaxPower = false;

                return;

            }

            if (!GetMemoryInfo())
            {
                return;
            }
            if (!MaxPower)
            {
                if (!Memory.SetMemory(Globals.KouryuudouStatus.ProcessHandle, Globals.KouryuudouStatus.BaseAddress + Offset.Kouryuudou_Sub_Power_Offset, Globals.KouryuudouStatus.PowerOriginalBytes, false, Globals.POWEROB, Globals.KouryuudouStatus, 0x00))
                {
                    return;
                }


            }
            else
            {

                if (!Memory.SetMemory(Globals.KouryuudouStatus.ProcessHandle, Globals.KouryuudouStatus.BaseAddress + Offset.Kouryuudou_Power_Offset, Value.Kouryuudou_Power_Value, true, Globals.SETVALUE, Globals.KouryuudouStatus, 0x00))
                {
                    Globals.KouryuudouStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


                if (!Memory.SetMemory(Globals.KouryuudouStatus.ProcessHandle, Globals.KouryuudouStatus.BaseAddress + Offset.Kouryuudou_Sub_Power_Offset, Value.Koumakyou_Sub_Power_Value, true, Globals.POWEROB, Globals.KouryuudouStatus, 0x00))
                {
                    Globals.KouryuudouStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


            }


            MaxPower = MaxPowerSwitch.IsOn;

        }
        private void InvincibleToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.KouryuudouStatus.Invincible_Locker)
            {
                Globals.KouryuudouStatus.Invincible_Locker = false;
                return;
            }

            if (!Globals.KouryuudouStatus.IsRun)
            {
                Globals.KouryuudouStatus.Invincible_Locker = true;

                Invincible = false;


                return;
            }
            if (!GetMemoryInfo())
            {
                return;
            }

            if (!Invincible)
            {
                if (!Memory.SetMemory(Globals.KouryuudouStatus.ProcessHandle, Globals.KouryuudouStatus.BaseAddress + Offset.Kouryuudou_Sub_Invincible_Offset, Globals.KouryuudouStatus.InvincibleOriginalBytes, false, Globals.INVINCIBLEOB, Globals.KouryuudouStatus, 0x00))
                {

                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.KouryuudouStatus.ProcessHandle, Globals.KouryuudouStatus.BaseAddress + Offset.Kouryuudou_Sub_Invincible_Offset, Value.Kouryuudou_Sub_Invincible_Value, true, Globals.INVINCIBLEOB, Globals.KouryuudouStatus, 0x00))
                {
                    Globals.KouryuudouStatus.Invincible_Locker = true;
                    Invincible = false;

                    return;
                }
            }


        }




    }
}
