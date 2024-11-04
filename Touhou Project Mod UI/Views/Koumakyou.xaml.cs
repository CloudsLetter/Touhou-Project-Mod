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
    /// Koumakyou.xaml 的交互逻辑
    /// </summary>
    public partial class Koumakyou : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public bool IsGreenDotVisible
        {
            get => Globals.KoumakyouStatus.IsRun;
            set
            {
                if (Globals.KoumakyouStatus.IsRun != value)
                {
                    Globals.KoumakyouStatus.IsRun = value;
                    OnPropertyChanged(nameof(IsGreenDotVisible));
                }
            }
        }
        public bool LockPlayer
        {
            get => Globals.KoumakyouStatus.LockPlayer;
            set
            {
                if (Globals.KoumakyouStatus.LockPlayer != value)
                {
                    Globals.KoumakyouStatus.LockPlayer = value;
                    OnPropertyChanged(nameof(LockPlayer));
                }
            }
        }
        public bool LockBomb
        {
            get => Globals.KoumakyouStatus.LockBomb;
            set
            {
                if (Globals.KoumakyouStatus.LockBomb != value)
                {
                    Globals.KoumakyouStatus.LockBomb = value;
                    OnPropertyChanged(nameof(LockBomb));
                }
            }
        }
        public bool MaxPower
        {
            get => Globals.KoumakyouStatus.MaxPower;
            set
            {
                if (Globals.KoumakyouStatus.MaxPower != value)
                {
                    Globals.KoumakyouStatus.MaxPower = value;
                    OnPropertyChanged(nameof(MaxPower));
                }
            }
        }
        public bool Invincible
        {
            get => Globals.KoumakyouStatus.Invincible;
            set
            {
                if (Globals.KoumakyouStatus.Invincible != value)
                {
                    Globals.KoumakyouStatus.Invincible = value;
                    OnPropertyChanged(nameof(Invincible));
                }
            }
        }


        public Koumakyou()
        {
            InitializeComponent();
            DataContext = this;
            IsGreenDotVisible = Globals.KoumakyouStatus.IsRun;
            LockPlayer = Globals.KoumakyouStatus.LockPlayer;
            LockBomb = Globals.KoumakyouStatus.LockBomb;
            MaxPower = Globals.KoumakyouStatus.MaxPower;
            Invincible= Globals.KoumakyouStatus.Invincible;

            Globals.KoumakyouStatus.IsTouhouRunChanged += OnGlobalsIsKoumakyouRunChanged;
            Globals.KoumakyouStatus.LockPlayerChanged += OnGlobaLockPlayerChanged;
            Globals.KoumakyouStatus.LockBombChanged += OnGlobalsLockBombChanged;
            Globals.KoumakyouStatus.MaxPowerChanged += OnGlobalsMaxPowerChanged;
            Globals.KoumakyouStatus.InvincibleChanged += OnGlobalsInvincibleChanged;
        }

        private void OnGlobalsIsKoumakyouRunChanged(object sender, EventArgs e)
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
            if (Globals.KoumakyouStatus.BaseAddress == IntPtr.Zero && Globals.KoumakyouStatus.ProcessHandle == IntPtr.Zero)
            {
                if (Globals.KoumakyouStatus.IsRunStatus)
                {
                    (Globals.KoumakyouStatus.BaseAddress, Globals.KoumakyouStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th06");
                    if (Globals.KoumakyouStatus.BaseAddress == IntPtr.Zero && Globals.KoumakyouStatus.ProcessHandle == IntPtr.Zero)
                    {
                        return false;
                    }
                }
                if (Globals.KoumakyouStatus.IsRunStatusC)
                { 
                    (Globals.KoumakyouStatus.BaseAddress, Globals.KoumakyouStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th06c");
                    if (Globals.KoumakyouStatus.BaseAddress == IntPtr.Zero && Globals.KoumakyouStatus.ProcessHandle == IntPtr.Zero)
                    {
                        return false;
                    }
                }
                if (Globals.KoumakyouStatus.IsRunStatusE)
                {
                    (Globals.KoumakyouStatus.BaseAddress, Globals.KoumakyouStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th06e");
                    if (Globals.KoumakyouStatus.BaseAddress == IntPtr.Zero && Globals.KoumakyouStatus.ProcessHandle == IntPtr.Zero)
                    {
                        return false;
                    }
                }
                if (Globals.KoumakyouStatus.IsRunStatusCC)
                {
                    (Globals.KoumakyouStatus.BaseAddress, Globals.KoumakyouStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("東方紅魔郷");
                    if (Globals.KoumakyouStatus.BaseAddress == IntPtr.Zero && Globals.KoumakyouStatus.ProcessHandle == IntPtr.Zero)
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
            if (Globals.KoumakyouStatus.LockPlayer_Locker)
            {
                Globals.KoumakyouStatus.LockPlayer_Locker = false;
                return;
            }
            if (!Globals.KoumakyouStatus.IsRun)
            {
                Globals.KoumakyouStatus.LockPlayer_Locker = true;

                LockPlayer = false;

                return;

            }

            if (!GetMemoryInfo())
            {
                return;
            }

            if (!LockPlayer)
            {
                if (!Memory.SetMemory(Globals.KoumakyouStatus.ProcessHandle, Globals.KoumakyouStatus.BaseAddress + Offset.Koumakyou_Sub_Plyaer_Offset, Globals.KoumakyouStatus.PlayersOriginalBytes, false, Globals.PLAYEROB, Globals.KoumakyouStatus, 0x00))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.KoumakyouStatus.ProcessHandle, Globals.KoumakyouStatus.BaseAddress + Offset.Koumakyou_Sub_Plyaer_Offset, Value.Koumakyou_Sub_Plyaer_Value, true, Globals.PLAYEROB, Globals.KoumakyouStatus, 0x00))
                {
                    Globals.KoumakyouStatus.LockPlayer_Locker = true;
                    LockPlayer = false;
                    return;
                }
            }


        }
        private void LockeBombToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.KoumakyouStatus.LockerBomb_Locker)
            {
                Globals.KoumakyouStatus.LockerBomb_Locker = false;
                return;
            }
            if (!Globals.KoumakyouStatus.IsRun)
            {
                Globals.KoumakyouStatus.LockerBomb_Locker = true;
                LockBomb = false;

                return;

            }
            if (!GetMemoryInfo())
            {
                return;
            }

            if (!LockBomb)
            {
                if (!Memory.SetMemory(Globals.KoumakyouStatus.ProcessHandle, Globals.KoumakyouStatus.BaseAddress + Offset.Koumakyou_Sub_Bomb_Offset, Globals.KoumakyouStatus.BombOriginalBytes, false, Globals.BOMBOB, Globals.KoumakyouStatus, 0x00))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.KoumakyouStatus.ProcessHandle, Globals.KoumakyouStatus.BaseAddress + Offset.Koumakyou_Sub_Bomb_Offset, Value.Koumakyou_Sub_Bomb_Value, true, Globals.BOMBOB, Globals.KoumakyouStatus, 0x00))
                {
                    Globals.KoumakyouStatus.LockerBomb_Locker = true;
                    LockBomb = false;

                    return;
                }
            }

        }
        private void MaxPowerToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.KoumakyouStatus.MaxPower_Locker)
            {
                Globals.KoumakyouStatus.MaxPower_Locker = false;
                return;
            }
            if (!Globals.KoumakyouStatus.IsRun)
            {
                Globals.KoumakyouStatus.MaxPower_Locker = true;
                MaxPower = false;

                return;

            }

            if (!GetMemoryInfo())
            {
                return;
            }
            if (!MaxPower)
            {
                if (!Memory.SetMemory(Globals.KoumakyouStatus.ProcessHandle, Globals.KoumakyouStatus.BaseAddress + Offset.Koumakyou_Sub_Power_2_Zero_Offset, Globals.KoumakyouStatus.PowerOriginalBytes, false, Globals.POWEROB, Globals.KoumakyouStatus, 0x00))
                {
                    return;
                }

                if (!Memory.SetMemory(Globals.KoumakyouStatus.ProcessHandle, Globals.KoumakyouStatus.BaseAddress + Offset.Koumakyou_Sub_Power_Offset, Globals.KoumakyouStatus.PowerOriginalBytes2, false, Globals.POWEROB, Globals.KoumakyouStatus, 0x01))
                {
                    return;
                }
            } 
            else
            {

                if (!Memory.SetMemory(Globals.KoumakyouStatus.ProcessHandle, Globals.KoumakyouStatus.BaseAddress + Offset.Koumakyou_Power_Offset, Value.Koumakyou_Power_Value, true, Globals.SETVALUE, Globals.KoumakyouStatus, 0x00))
                {
                    Globals.KoumakyouStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


                if (!Memory.SetMemory(Globals.KoumakyouStatus.ProcessHandle, Globals.KoumakyouStatus.BaseAddress + Offset.Koumakyou_Sub_Power_2_Zero_Offset, Value.Koumakyou_Sub_Power_Value, true, Globals.POWEROB, Globals.KoumakyouStatus, 0x00))
                {
                    Globals.KoumakyouStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }

                if (!Memory.SetMemory(Globals.KoumakyouStatus.ProcessHandle, Globals.KoumakyouStatus.BaseAddress + Offset.Koumakyou_Sub_Power_Offset, Value.Koumakyou_Sub_Power2_Value, true, Globals.POWEROB, Globals.KoumakyouStatus, 0x01))
                {
                    Globals.KoumakyouStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }
            }

            
            MaxPower = MaxPowerSwitch.IsOn;

        }
        private void InvincibleToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.KoumakyouStatus.Invincible_Locker)
            {
                Globals.KoumakyouStatus.Invincible_Locker = false;
                return;
            }

            if (!Globals.KoumakyouStatus.IsRun)
            {
                Globals.KoumakyouStatus.Invincible_Locker = true;

                Invincible = false;


                return;
            }
            if (!GetMemoryInfo())
            {
                return;
            }

            if (!Invincible)
            {
                if (!Memory.SetMemory(Globals.KoumakyouStatus.ProcessHandle, Globals.KoumakyouStatus.BaseAddress + Offset.Koumakyou_Sub_Invincible_Offset, Globals.KoumakyouStatus.InvincibleOriginalBytes, false, Globals.INVINCIBLEOB, Globals.KoumakyouStatus, 0x00))
                {

                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.KoumakyouStatus.ProcessHandle, Globals.KoumakyouStatus.BaseAddress + Offset.Koumakyou_Sub_Invincible_Offset, Value.Koumakyou_Sub_Invincible_Value, true, Globals.INVINCIBLEOB, Globals.KoumakyouStatus, 0x00))
                {
                    Globals.KoumakyouStatus.Invincible_Locker = true;
                    Invincible = false;

                    return;
                }
            }


        }




    }
}
