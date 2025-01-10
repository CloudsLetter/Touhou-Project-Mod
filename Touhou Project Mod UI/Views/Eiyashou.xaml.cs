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
    /// Eiyashou.xaml 的交互逻辑
    /// </summary>
    /// <summary>
    /// Eiyashou.xaml 的交互逻辑
    /// </summary>
    public partial class Eiyashou : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public bool IsGreenDotVisible
        {
            get => Globals.EiyashouStatus.IsRun;
            set
            {
                if (Globals.EiyashouStatus.IsRun != value)
                {
                    Globals.EiyashouStatus.IsRun = value;
                    OnPropertyChanged(nameof(IsGreenDotVisible));
                }
            }
        }
        public bool LockPlayer
        {
            get => Globals.EiyashouStatus.LockPlayer;
            set
            {
                if (Globals.EiyashouStatus.LockPlayer != value)
                {
                    Globals.EiyashouStatus.LockPlayer = value;
                    OnPropertyChanged(nameof(LockPlayer));
                }
            }
        }
        public bool LockBomb
        {
            get => Globals.EiyashouStatus.LockBomb;
            set
            {
                if (Globals.EiyashouStatus.LockBomb != value)
                {
                    Globals.EiyashouStatus.LockBomb = value;
                    OnPropertyChanged(nameof(LockBomb));
                }
            }
        }
        public bool MaxPower
        {
            get => Globals.EiyashouStatus.MaxPower;
            set
            {
                if (Globals.EiyashouStatus.MaxPower != value)
                {
                    Globals.EiyashouStatus.MaxPower = value;
                    OnPropertyChanged(nameof(MaxPower));
                }
            }
        }
        public bool Invincible
        {
            get => Globals.EiyashouStatus.Invincible;
            set
            {
                if (Globals.EiyashouStatus.Invincible != value)
                {
                    Globals.EiyashouStatus.Invincible = value;
                    OnPropertyChanged(nameof(Invincible));
                }
            }
        }


        public Eiyashou()
        {
            InitializeComponent();
            DataContext = this;
            IsGreenDotVisible = Globals.EiyashouStatus.IsRun;
            LockPlayer = Globals.EiyashouStatus.LockPlayer;
            LockBomb = Globals.EiyashouStatus.LockBomb;
            MaxPower = Globals.EiyashouStatus.MaxPower;
            Invincible = Globals.EiyashouStatus.Invincible;

            Globals.EiyashouStatus.IsTouhouRunChanged += OnGlobalsIsEiyashouRunChanged;
            Globals.EiyashouStatus.LockPlayerChanged += OnGlobaLockPlayerChanged;
            Globals.EiyashouStatus.LockBombChanged += OnGlobalsLockBombChanged;
            Globals.EiyashouStatus.MaxPowerChanged += OnGlobalsMaxPowerChanged;
            Globals.EiyashouStatus.InvincibleChanged += OnGlobalsInvincibleChanged;
        }

        private void OnGlobalsIsEiyashouRunChanged(object sender, EventArgs e)
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
            if (Globals.EiyashouStatus.BaseAddress == IntPtr.Zero && Globals.EiyashouStatus.ProcessHandle == IntPtr.Zero)
            {
                if (Globals.EiyashouStatus.IsRunStatus)
                {
                    (Globals.EiyashouStatus.BaseAddress, Globals.EiyashouStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th08");
                    if (Globals.EiyashouStatus.BaseAddress == IntPtr.Zero && Globals.EiyashouStatus.ProcessHandle == IntPtr.Zero)
                    {
                        return false;
                    }
                }
                if (Globals.EiyashouStatus.IsRunStatusC)
                {
                    (Globals.EiyashouStatus.BaseAddress, Globals.EiyashouStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th08c");
                    if (Globals.EiyashouStatus.BaseAddress == IntPtr.Zero && Globals.EiyashouStatus.ProcessHandle == IntPtr.Zero)
                    {
                        return false;
                    }
                }
                if (Globals.EiyashouStatus.IsRunStatusE)
                {
                    (Globals.EiyashouStatus.BaseAddress, Globals.EiyashouStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th08e");
                    if (Globals.EiyashouStatus.BaseAddress == IntPtr.Zero && Globals.EiyashouStatus.ProcessHandle == IntPtr.Zero)
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
            if (Globals.EiyashouStatus.LockPlayer_Locker)
            {
                Globals.EiyashouStatus.LockPlayer_Locker = false;
                return;
            }
            if (!Globals.EiyashouStatus.IsRun)
            {
                Globals.EiyashouStatus.LockPlayer_Locker = true;

                LockPlayer = false;

                return;

            }

            if (Globals.EiyashouStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!LockPlayer)
            {
                if (!Memory.SetMemory(Globals.EiyashouStatus.ProcessHandle, Globals.EiyashouStatus.BaseAddress + Offset.Eiyashou_Sub_Plyaer_Offset, Value.Eiyashou_Sub_Plyaer_Value_Default))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.EiyashouStatus.ProcessHandle, Globals.EiyashouStatus.BaseAddress + Offset.Eiyashou_Sub_Plyaer_Offset, Value.Eiyashou_Sub_Plyaer_Value))
                {
                    Globals.EiyashouStatus.LockPlayer_Locker = true;
                    LockPlayer = false;
                    return;
                }
            }


        }
        private void LockeBombToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.EiyashouStatus.LockerBomb_Locker)
            {
                Globals.EiyashouStatus.LockerBomb_Locker = false;
                return;
            }
            if (!Globals.EiyashouStatus.IsRun)
            {
                Globals.EiyashouStatus.LockerBomb_Locker = true;
                LockBomb = false;

                return;

            }
            if (Globals.EiyashouStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!LockBomb)
            {
                if (!Memory.SetMemory(Globals.EiyashouStatus.ProcessHandle, Globals.EiyashouStatus.BaseAddress + Offset.Eiyashou_Sub_Bomb_Offset, Value.Eiyashou_Sub_Bomb_Value_Default))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.EiyashouStatus.ProcessHandle, Globals.EiyashouStatus.BaseAddress + Offset.Eiyashou_Sub_Bomb_Offset, Value.Eiyashou_Sub_Bomb_Value))
                {
                    Globals.EiyashouStatus.LockerBomb_Locker = true;
                    LockBomb = false;

                    return;
                }
            }

        }
        private void MaxPowerToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.EiyashouStatus.MaxPower_Locker)
            {
                Globals.EiyashouStatus.MaxPower_Locker = false;
                return;
            }
            if (!Globals.EiyashouStatus.IsRun)
            {
                Globals.EiyashouStatus.MaxPower_Locker = true;
                MaxPower = false;

                return;

            }

            if (Globals.EiyashouStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }
            if (!MaxPower)
            {
                Globals.EiyashouStatus.MaxPower_Locker = false;
                MaxPower = false;
                return;

            }
            else
            {

                Globals.EiyashouStatus.MaxPower_Locker = false;
                MaxPower = false;
                return;
            }


            MaxPower = MaxPowerSwitch.IsOn;

        }
        private void InvincibleToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.EiyashouStatus.Invincible_Locker)
            {
                Globals.EiyashouStatus.Invincible_Locker = false;
                return;
            }

            if (!Globals.EiyashouStatus.IsRun)
            {
                Globals.EiyashouStatus.Invincible_Locker = true;

                Invincible = false;


                return;
            }
            if (Globals.EiyashouStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!Invincible)
            {
                if (!Memory.SetMemory(Globals.EiyashouStatus.ProcessHandle, Globals.EiyashouStatus.BaseAddress + Offset.Eiyashou_Sub_Invincible1_Offset, Value.Eiyashou_Sub_Invincible1_Value_Default))
                {
                    Globals.EiyashouStatus.Invincible = false;
                    Invincible = false;

                    return;
                }
                if (!Memory.SetMemory(Globals.EiyashouStatus.ProcessHandle, Globals.EiyashouStatus.BaseAddress + Offset.Eiyashou_Sub_Invincible2_Offset, Value.Eiyashou_Sub_Invincible1_Value_Default))
                {
                    Globals.EiyashouStatus.Invincible = false;
                    Invincible = false;

                    return;
                }
                if (!Memory.SetMemory(Globals.EiyashouStatus.ProcessHandle, Globals.EiyashouStatus.BaseAddress + Offset.Eiyashou_Sub_Invincible3_Offset, Value.Eiyashou_Sub_Invincible1_Value_Default))
                {
                    Globals.EiyashouStatus.Invincible = false;
                    Invincible = false;

                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.EiyashouStatus.ProcessHandle, Globals.EiyashouStatus.BaseAddress + Offset.Eiyashou_Sub_Invincible1_Offset, Value.Eiyashou_Sub_Invincible1_Value))
                {
                    Globals.EiyashouStatus.Invincible = true;
                    Invincible = true;

                    return;
                }
                if (!Memory.SetMemory(Globals.EiyashouStatus.ProcessHandle, Globals.EiyashouStatus.BaseAddress + Offset.Eiyashou_Sub_Invincible2_Offset, Value.Eiyashou_Sub_Invincible2_Value))
                {
                    Globals.EiyashouStatus.Invincible = true;
                    Invincible = true;

                    return;
                }
                if (!Memory.SetMemory(Globals.EiyashouStatus.ProcessHandle, Globals.EiyashouStatus.BaseAddress + Offset.Eiyashou_Sub_Invincible3_Offset, Value.Eiyashou_Sub_Invincible3_Value))
                {
                    Globals.EiyashouStatus.Invincible = true;
                    Invincible = true;

                    return;
                }
            }


        }




    }
}
