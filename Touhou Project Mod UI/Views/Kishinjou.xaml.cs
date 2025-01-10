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
    /// Kishinjou.xaml 的交互逻辑
    /// </summary>
    public partial class Kishinjou : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public bool IsGreenDotVisible
        {
            get => Globals.KishinjouStatus.IsRun;
            set
            {
                if (Globals.KishinjouStatus.IsRun != value)
                {
                    Globals.KishinjouStatus.IsRun = value;
                    OnPropertyChanged(nameof(IsGreenDotVisible));
                }
            }
        }
        public bool LockPlayer
        {
            get => Globals.KishinjouStatus.LockPlayer;
            set
            {
                if (Globals.KishinjouStatus.LockPlayer != value)
                {
                    Globals.KishinjouStatus.LockPlayer = value;
                    OnPropertyChanged(nameof(LockPlayer));
                }
            }
        }
        public bool LockBomb
        {
            get => Globals.KishinjouStatus.LockBomb;
            set
            {
                if (Globals.KishinjouStatus.LockBomb != value)
                {
                    Globals.KishinjouStatus.LockBomb = value;
                    OnPropertyChanged(nameof(LockBomb));
                }
            }
        }
        public bool MaxPower
        {
            get => Globals.KishinjouStatus.MaxPower;
            set
            {
                if (Globals.KishinjouStatus.MaxPower != value)
                {
                    Globals.KishinjouStatus.MaxPower = value;
                    OnPropertyChanged(nameof(MaxPower));
                }
            }
        }
        public bool Invincible
        {
            get => Globals.KishinjouStatus.Invincible;
            set
            {
                if (Globals.KishinjouStatus.Invincible != value)
                {
                    Globals.KishinjouStatus.Invincible = value;
                    OnPropertyChanged(nameof(Invincible));
                }
            }
        }


        public Kishinjou()
        {
            InitializeComponent();
            DataContext = this;
            IsGreenDotVisible = Globals.KishinjouStatus.IsRun;
            LockPlayer = Globals.KishinjouStatus.LockPlayer;
            LockBomb = Globals.KishinjouStatus.LockBomb;
            MaxPower = Globals.KishinjouStatus.MaxPower;
            Invincible = Globals.KishinjouStatus.Invincible;

            Globals.KishinjouStatus.IsTouhouRunChanged += OnGlobalsIsKishinjouRunChanged;
            Globals.KishinjouStatus.LockPlayerChanged += OnGlobaLockPlayerChanged;
            Globals.KishinjouStatus.LockBombChanged += OnGlobalsLockBombChanged;
            Globals.KishinjouStatus.MaxPowerChanged += OnGlobalsMaxPowerChanged;
            Globals.KishinjouStatus.InvincibleChanged += OnGlobalsInvincibleChanged;
        }

        private void OnGlobalsIsKishinjouRunChanged(object sender, EventArgs e)
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
            if (Globals.KishinjouStatus.BaseAddress == IntPtr.Zero && Globals.KishinjouStatus.ProcessHandle == IntPtr.Zero)
            {
                if (Globals.KishinjouStatus.IsRunStatus)
                {
                    (Globals.KishinjouStatus.BaseAddress, Globals.KishinjouStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th14");
                    if (Globals.KishinjouStatus.BaseAddress == IntPtr.Zero && Globals.KishinjouStatus.ProcessHandle == IntPtr.Zero)
                    {
                        return false;
                    }
                }
                if (Globals.KishinjouStatus.IsRunStatusC)
                {
                    (Globals.KishinjouStatus.BaseAddress, Globals.KishinjouStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th14c");
                    if (Globals.KishinjouStatus.BaseAddress == IntPtr.Zero && Globals.KishinjouStatus.ProcessHandle == IntPtr.Zero)
                    {
                        return false;
                    }
                }
                if (Globals.KishinjouStatus.IsRunStatusE)
                {
                    (Globals.KishinjouStatus.BaseAddress, Globals.KishinjouStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th14e");
                    if (Globals.KishinjouStatus.BaseAddress == IntPtr.Zero && Globals.KishinjouStatus.ProcessHandle == IntPtr.Zero)
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
            if (Globals.KishinjouStatus.LockPlayer_Locker)
            {
                Globals.KishinjouStatus.LockPlayer_Locker = false;
                return;
            }
            if (!Globals.KishinjouStatus.IsRun)
            {
                Globals.KishinjouStatus.LockPlayer_Locker = true;

                LockPlayer = false;

                return;

            }

            if (Globals.KishinjouStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!LockPlayer)
            {
                if (!Memory.SetMemory(Globals.KishinjouStatus.ProcessHandle, Globals.KishinjouStatus.BaseAddress + Offset.Kishinjou_Sub_Plyaer_Offset, Value.Kishinjou_Sub_Plyaer_Value_Default))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.KishinjouStatus.ProcessHandle, Globals.KishinjouStatus.BaseAddress + Offset.Kishinjou_Sub_Plyaer_Offset, Value.Kishinjou_Sub_Plyaer_Value))
                {
                    Globals.KishinjouStatus.LockPlayer_Locker = true;
                    LockPlayer = false;
                    return;
                }
            }


        }
        private void LockeBombToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.KishinjouStatus.LockerBomb_Locker)
            {
                Globals.KishinjouStatus.LockerBomb_Locker = false;
                return;
            }
            if (!Globals.KishinjouStatus.IsRun)
            {
                Globals.KishinjouStatus.LockerBomb_Locker = true;
                LockBomb = false;

                return;

            }
            if (Globals.KishinjouStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!LockBomb)
            {
                if (!Memory.SetMemory(Globals.KishinjouStatus.ProcessHandle, Globals.KishinjouStatus.BaseAddress + Offset.Kishinjou_Sub_Bomb_Offset, Value.Kishinjou_Sub_Plyaer_Value_Default))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.KishinjouStatus.ProcessHandle, Globals.KishinjouStatus.BaseAddress + Offset.Kishinjou_Sub_Bomb_Offset, Value.Kishinjou_Sub_Bomb_Value))
                {
                    Globals.KishinjouStatus.LockerBomb_Locker = true;
                    LockBomb = false;

                    return;
                }
            }

        }
        private void MaxPowerToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.KishinjouStatus.MaxPower_Locker)
            {
                Globals.KishinjouStatus.MaxPower_Locker = false;
                return;
            }
            if (!Globals.KishinjouStatus.IsRun)
            {
                Globals.KishinjouStatus.MaxPower_Locker = true;
                MaxPower = false;

                return;

            }

            if (Globals.KishinjouStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }
            if (!MaxPower)
            {
                if (!Memory.SetMemory(Globals.KishinjouStatus.ProcessHandle, Globals.KishinjouStatus.BaseAddress + Offset.Kishinjou_Sub_Power_Offset, Value.Kishinjou_Sub_Power_Value_Default))
                {
                    return;
                }


            }
            else
            {

                if (!Memory.SetMemory(Globals.KishinjouStatus.ProcessHandle, Globals.KishinjouStatus.BaseAddress + Offset.Kishinjou_Power_Offset, Value.Kishinjou_Power_Value))
                {
                    Globals.KishinjouStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


                if (!Memory.SetMemory(Globals.KishinjouStatus.ProcessHandle, Globals.KishinjouStatus.BaseAddress + Offset.Kishinjou_Sub_Power_Offset, Value.Kishinjou_Sub_Power_Value))
                {
                    Globals.KishinjouStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


            }


            MaxPower = MaxPowerSwitch.IsOn;

        }
        private void InvincibleToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.KishinjouStatus.Invincible_Locker)
            {
                Globals.KishinjouStatus.Invincible_Locker = false;
                return;
            }

            if (!Globals.KishinjouStatus.IsRun)
            {
                Globals.KishinjouStatus.Invincible_Locker = true;

                Invincible = false;


                return;
            }
            if (Globals.KishinjouStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!Invincible)
            {
                if (!Memory.SetMemory(Globals.KishinjouStatus.ProcessHandle, Globals.KishinjouStatus.BaseAddress + Offset.Kishinjou_Sub_Invincible_Offset, Value.Kishinjou_Sub_Invincible_Value_Default))
                {

                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.KishinjouStatus.ProcessHandle, Globals.KishinjouStatus.BaseAddress + Offset.Kishinjou_Sub_Invincible_Offset, Value.Kishinjou_Sub_Invincible_Value))
                {
                    Globals.KishinjouStatus.Invincible_Locker = true;
                    Invincible = false;

                    return;
                }
            }


        }




    }
}
