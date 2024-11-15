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
    /// Tenkuushou.xaml 的交互逻辑
    /// </summary>
    public partial class Tenkuushou : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public bool IsGreenDotVisible
        {
            get => Globals.TenkuushouStatus.IsRun;
            set
            {
                if (Globals.TenkuushouStatus.IsRun != value)
                {
                    Globals.TenkuushouStatus.IsRun = value;
                    OnPropertyChanged(nameof(IsGreenDotVisible));
                }
            }
        }
        public bool LockPlayer
        {
            get => Globals.TenkuushouStatus.LockPlayer;
            set
            {
                if (Globals.TenkuushouStatus.LockPlayer != value)
                {
                    Globals.TenkuushouStatus.LockPlayer = value;
                    OnPropertyChanged(nameof(LockPlayer));
                }
            }
        }
        public bool LockBomb
        {
            get => Globals.TenkuushouStatus.LockBomb;
            set
            {
                if (Globals.TenkuushouStatus.LockBomb != value)
                {
                    Globals.TenkuushouStatus.LockBomb = value;
                    OnPropertyChanged(nameof(LockBomb));
                }
            }
        }
        public bool MaxPower
        {
            get => Globals.TenkuushouStatus.MaxPower;
            set
            {
                if (Globals.TenkuushouStatus.MaxPower != value)
                {
                    Globals.TenkuushouStatus.MaxPower = value;
                    OnPropertyChanged(nameof(MaxPower));
                }
            }
        }
        public bool Invincible
        {
            get => Globals.TenkuushouStatus.Invincible;
            set
            {
                if (Globals.TenkuushouStatus.Invincible != value)
                {
                    Globals.TenkuushouStatus.Invincible = value;
                    OnPropertyChanged(nameof(Invincible));
                }
            }
        }


        public Tenkuushou()
        {
            InitializeComponent();
            DataContext = this;
            IsGreenDotVisible = Globals.TenkuushouStatus.IsRun;
            LockPlayer = Globals.TenkuushouStatus.LockPlayer;
            LockBomb = Globals.TenkuushouStatus.LockBomb;
            MaxPower = Globals.TenkuushouStatus.MaxPower;
            Invincible = Globals.TenkuushouStatus.Invincible;

            Globals.TenkuushouStatus.IsTouhouRunChanged += OnGlobalsIsTenkuushouRunChanged;
            Globals.TenkuushouStatus.LockPlayerChanged += OnGlobaLockPlayerChanged;
            Globals.TenkuushouStatus.LockBombChanged += OnGlobalsLockBombChanged;
            Globals.TenkuushouStatus.MaxPowerChanged += OnGlobalsMaxPowerChanged;
            Globals.TenkuushouStatus.InvincibleChanged += OnGlobalsInvincibleChanged;
        }

        private void OnGlobalsIsTenkuushouRunChanged(object sender, EventArgs e)
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
            if (Globals.TenkuushouStatus.BaseAddress == IntPtr.Zero && Globals.TenkuushouStatus.ProcessHandle == IntPtr.Zero)
            {
                if (Globals.TenkuushouStatus.IsRunStatus)
                {
                    (Globals.TenkuushouStatus.BaseAddress, Globals.TenkuushouStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th16");
                    if (Globals.TenkuushouStatus.BaseAddress == IntPtr.Zero && Globals.TenkuushouStatus.ProcessHandle == IntPtr.Zero)
                    {
                        return false;
                    }
                }
                if (Globals.TenkuushouStatus.IsRunStatusC)
                {
                    (Globals.TenkuushouStatus.BaseAddress, Globals.TenkuushouStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th16c");
                    if (Globals.TenkuushouStatus.BaseAddress == IntPtr.Zero && Globals.TenkuushouStatus.ProcessHandle == IntPtr.Zero)
                    {
                        return false;
                    }
                }
                if (Globals.TenkuushouStatus.IsRunStatusE)
                {
                    (Globals.TenkuushouStatus.BaseAddress, Globals.TenkuushouStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th16e");
                    if (Globals.TenkuushouStatus.BaseAddress == IntPtr.Zero && Globals.TenkuushouStatus.ProcessHandle == IntPtr.Zero)
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
            if (Globals.TenkuushouStatus.LockPlayer_Locker)
            {
                Globals.TenkuushouStatus.LockPlayer_Locker = false;
                return;
            }
            if (!Globals.TenkuushouStatus.IsRun)
            {
                Globals.TenkuushouStatus.LockPlayer_Locker = true;

                LockPlayer = false;

                return;

            }
            if (Globals.TenkuushouStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }
            if (!LockPlayer)
            {
                if (!Memory.SetMemory(Globals.TenkuushouStatus.ProcessHandle, Globals.TenkuushouStatus.BaseAddress + Offset.Tenkuushou_Sub_Plyaer_Offset, Globals.TenkuushouStatus.PlayersOriginalBytes, false, Globals.PLAYEROB, Globals.TenkuushouStatus, 0x00))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.TenkuushouStatus.ProcessHandle, Globals.TenkuushouStatus.BaseAddress + Offset.Tenkuushou_Sub_Plyaer_Offset, Value.Tenkuushou_Sub_Plyaer_Value, true, Globals.PLAYEROB, Globals.TenkuushouStatus, 0x00))
                {
                    Globals.TenkuushouStatus.LockPlayer_Locker = true;
                    LockPlayer = false;
                    return;
                }
            }


        }
        private void LockeBombToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.TenkuushouStatus.LockerBomb_Locker)
            {
                Globals.TenkuushouStatus.LockerBomb_Locker = false;
                return;
            }
            if (!Globals.TenkuushouStatus.IsRun)
            {
                Globals.TenkuushouStatus.LockerBomb_Locker = true;
                LockBomb = false;

                return;

            }
            if (Globals.TenkuushouStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!LockBomb)
            {
                if (!Memory.SetMemory(Globals.TenkuushouStatus.ProcessHandle, Globals.TenkuushouStatus.BaseAddress + Offset.Tenkuushou_Sub_Bomb_Offset, Globals.TenkuushouStatus.BombOriginalBytes, false, Globals.BOMBOB, Globals.TenkuushouStatus, 0x00))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.TenkuushouStatus.ProcessHandle, Globals.TenkuushouStatus.BaseAddress + Offset.Tenkuushou_Sub_Bomb_Offset, Value.Tenkuushou_Sub_Bomb_Value, true, Globals.BOMBOB, Globals.TenkuushouStatus, 0x00))
                {
                    Globals.TenkuushouStatus.LockerBomb_Locker = true;
                    LockBomb = false;

                    return;
                }
            }

        }
        private void MaxPowerToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.TenkuushouStatus.MaxPower_Locker)
            {
                Globals.TenkuushouStatus.MaxPower_Locker = false;
                return;
            }
            if (!Globals.TenkuushouStatus.IsRun)
            {
                Globals.TenkuushouStatus.MaxPower_Locker = true;
                MaxPower = false;

                return;

            }

            if (Globals.TenkuushouStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }
            if (!MaxPower)
            {
                if (!Memory.SetMemory(Globals.TenkuushouStatus.ProcessHandle, Globals.TenkuushouStatus.BaseAddress + Offset.Tenkuushou_Sub_Power_Offset, Globals.TenkuushouStatus.PowerOriginalBytes, false, Globals.POWEROB, Globals.TenkuushouStatus, 0x00))
                {
                    return;
                }


            }
            else
            {

                if (!Memory.SetMemory(Globals.TenkuushouStatus.ProcessHandle, Globals.TenkuushouStatus.BaseAddress + Offset.Tenkuushou_Power_Offset, Value.Tenkuushou_Power_Value, true, Globals.SETVALUE, Globals.TenkuushouStatus, 0x00))
                {
                    Globals.TenkuushouStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


                if (!Memory.SetMemory(Globals.TenkuushouStatus.ProcessHandle, Globals.TenkuushouStatus.BaseAddress + Offset.Tenkuushou_Sub_Power_Offset, Value.Tenkuushou_Sub_Power_Value, true, Globals.POWEROB, Globals.TenkuushouStatus, 0x00))
                {
                    Globals.TenkuushouStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


            }


            MaxPower = MaxPowerSwitch.IsOn;

        }
        private void InvincibleToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.TenkuushouStatus.Invincible_Locker)
            {
                Globals.TenkuushouStatus.Invincible_Locker = false;
                return;
            }

            if (!Globals.TenkuushouStatus.IsRun)
            {
                Globals.TenkuushouStatus.Invincible_Locker = true;

                Invincible = false;


                return;
            }
            if (Globals.TenkuushouStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!Invincible)
            {
                if (!Memory.SetMemory(Globals.TenkuushouStatus.ProcessHandle, Globals.TenkuushouStatus.BaseAddress + Offset.Tenkuushou_Sub_Invincible_Offset, Globals.TenkuushouStatus.InvincibleOriginalBytes, false, Globals.INVINCIBLEOB, Globals.TenkuushouStatus, 0x00))
                {

                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.TenkuushouStatus.ProcessHandle, Globals.TenkuushouStatus.BaseAddress + Offset.Tenkuushou_Sub_Invincible_Offset, Value.Tenkuushou_Sub_Invincible_Value, true, Globals.INVINCIBLEOB, Globals.TenkuushouStatus, 0x00))
                {
                    Globals.TenkuushouStatus.Invincible_Locker = true;
                    Invincible = false;

                    return;
                }
            }


        }




    }
}
