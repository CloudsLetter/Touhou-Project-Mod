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
    /// Shinpiroku.xaml 的交互逻辑
    /// 骨架页：Offset / Value 里的数值填好后即可直接生效，无需改动本文件。
    /// </summary>
    public partial class Shinpiroku : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public bool IsGreenDotVisible
        {
            get => Globals.ShinpirokuStatus.IsRun;
            set
            {
                if (Globals.ShinpirokuStatus.IsRun != value)
                {
                    Globals.ShinpirokuStatus.IsRun = value;
                    OnPropertyChanged(nameof(IsGreenDotVisible));
                }
            }
        }
        public bool LockPlayer
        {
            get => Globals.ShinpirokuStatus.LockPlayer;
            set
            {
                if (Globals.ShinpirokuStatus.LockPlayer != value)
                {
                    Globals.ShinpirokuStatus.LockPlayer = value;
                    OnPropertyChanged(nameof(LockPlayer));
                }
            }
        }
        public bool LockBomb
        {
            get => Globals.ShinpirokuStatus.LockBomb;
            set
            {
                if (Globals.ShinpirokuStatus.LockBomb != value)
                {
                    Globals.ShinpirokuStatus.LockBomb = value;
                    OnPropertyChanged(nameof(LockBomb));
                }
            }
        }
        public bool MaxPower
        {
            get => Globals.ShinpirokuStatus.MaxPower;
            set
            {
                if (Globals.ShinpirokuStatus.MaxPower != value)
                {
                    Globals.ShinpirokuStatus.MaxPower = value;
                    OnPropertyChanged(nameof(MaxPower));
                }
            }
        }
        public bool Invincible
        {
            get => Globals.ShinpirokuStatus.Invincible;
            set
            {
                if (Globals.ShinpirokuStatus.Invincible != value)
                {
                    Globals.ShinpirokuStatus.Invincible = value;
                    OnPropertyChanged(nameof(Invincible));
                }
            }
        }


        public Shinpiroku()
        {
            InitializeComponent();
            DataContext = this;
            IsGreenDotVisible = Globals.ShinpirokuStatus.IsRun;
            LockPlayer = Globals.ShinpirokuStatus.LockPlayer;
            LockBomb = Globals.ShinpirokuStatus.LockBomb;
            MaxPower = Globals.ShinpirokuStatus.MaxPower;
            Invincible = Globals.ShinpirokuStatus.Invincible;

            Globals.ShinpirokuStatus.IsTouhouRunChanged += OnGlobalsIsShinpirokuRunChanged;
            Globals.ShinpirokuStatus.LockPlayerChanged += OnGlobaLockPlayerChanged;
            Globals.ShinpirokuStatus.LockBombChanged += OnGlobalsLockBombChanged;
            Globals.ShinpirokuStatus.MaxPowerChanged += OnGlobalsMaxPowerChanged;
            Globals.ShinpirokuStatus.InvincibleChanged += OnGlobalsInvincibleChanged;
        }

        private void OnGlobalsIsShinpirokuRunChanged(object sender, EventArgs e)
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
            if (Globals.ShinpirokuStatus.BaseAddress == IntPtr.Zero && Globals.ShinpirokuStatus.ProcessHandle == IntPtr.Zero)
            {
                if (Globals.ShinpirokuStatus.IsRunStatus)
                {
                    (Globals.ShinpirokuStatus.BaseAddress, Globals.ShinpirokuStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th145");
                    if (Globals.ShinpirokuStatus.BaseAddress == IntPtr.Zero && Globals.ShinpirokuStatus.ProcessHandle == IntPtr.Zero)
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
            if (Globals.ShinpirokuStatus.LockPlayer_Locker)
            {
                Globals.ShinpirokuStatus.LockPlayer_Locker = false;
                return;
            }
            if (!Globals.ShinpirokuStatus.IsRun)
            {
                Globals.ShinpirokuStatus.LockPlayer_Locker = true;

                LockPlayer = false;

                return;

            }

            if (Globals.ShinpirokuStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!LockPlayer)
            {
                if (!Memory.SetMemory(Globals.ShinpirokuStatus.ProcessHandle, Globals.ShinpirokuStatus.BaseAddress + Offset.Shinpiroku_Sub_Plyaer_Offset, Value.Shinpiroku_Sub_Plyaer_Value_Default))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.ShinpirokuStatus.ProcessHandle, Globals.ShinpirokuStatus.BaseAddress + Offset.Shinpiroku_Sub_Plyaer_Offset, Value.Shinpiroku_Sub_Plyaer_Value))
                {
                    Globals.ShinpirokuStatus.LockPlayer_Locker = true;
                    LockPlayer = false;
                    return;
                }
            }


        }
        private void LockeBombToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.ShinpirokuStatus.LockerBomb_Locker)
            {
                Globals.ShinpirokuStatus.LockerBomb_Locker = false;
                return;
            }
            if (!Globals.ShinpirokuStatus.IsRun)
            {
                Globals.ShinpirokuStatus.LockerBomb_Locker = true;
                LockBomb = false;

                return;

            }
            if (Globals.ShinpirokuStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!LockBomb)
            {
                if (!Memory.SetMemory(Globals.ShinpirokuStatus.ProcessHandle, Globals.ShinpirokuStatus.BaseAddress + Offset.Shinpiroku_Sub_Bomb_Offset, Value.Shinpiroku_Sub_Bomb_Value_Default))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.ShinpirokuStatus.ProcessHandle, Globals.ShinpirokuStatus.BaseAddress + Offset.Shinpiroku_Sub_Bomb_Offset, Value.Shinpiroku_Sub_Bomb_Value))
                {
                    Globals.ShinpirokuStatus.LockerBomb_Locker = true;
                    LockBomb = false;

                    return;
                }
            }

        }
        private void MaxPowerToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.ShinpirokuStatus.MaxPower_Locker)
            {
                Globals.ShinpirokuStatus.MaxPower_Locker = false;
                return;
            }
            if (!Globals.ShinpirokuStatus.IsRun)
            {
                Globals.ShinpirokuStatus.MaxPower_Locker = true;
                MaxPower = false;

                return;

            }

            if (Globals.ShinpirokuStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }
            if (!MaxPower)
            {
                if (!Memory.SetMemory(Globals.ShinpirokuStatus.ProcessHandle, Globals.ShinpirokuStatus.BaseAddress + Offset.Shinpiroku_Sub_Power_Offset, Value.Shinpiroku_Sub_Power_Value_Default))
                {
                    return;
                }


            }
            else
            {

                if (!Memory.SetMemory(Globals.ShinpirokuStatus.ProcessHandle, Globals.ShinpirokuStatus.BaseAddress + Offset.Shinpiroku_Power_Offset, Value.Shinpiroku_Power_Value))
                {
                    Globals.ShinpirokuStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


                if (!Memory.SetMemory(Globals.ShinpirokuStatus.ProcessHandle, Globals.ShinpirokuStatus.BaseAddress + Offset.Shinpiroku_Sub_Power_Offset, Value.Shinpiroku_Sub_Power_Value))
                {
                    Globals.ShinpirokuStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


            }


            MaxPower = MaxPowerSwitch.IsOn;

        }
        private void InvincibleToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.ShinpirokuStatus.Invincible_Locker)
            {
                Globals.ShinpirokuStatus.Invincible_Locker = false;
                return;
            }

            if (!Globals.ShinpirokuStatus.IsRun)
            {
                Globals.ShinpirokuStatus.Invincible_Locker = true;

                Invincible = false;


                return;
            }
            if (Globals.ShinpirokuStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!Invincible)
            {
                if (!Memory.SetMemory(Globals.ShinpirokuStatus.ProcessHandle, Globals.ShinpirokuStatus.BaseAddress + Offset.Shinpiroku_Sub_Invincible_Offset, Value.Shinpiroku_Sub_Invincible_Value_Default))
                {

                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.ShinpirokuStatus.ProcessHandle, Globals.ShinpirokuStatus.BaseAddress + Offset.Shinpiroku_Sub_Invincible_Offset, Value.Shinpiroku_Sub_Invincible_Value))
                {
                    Globals.ShinpirokuStatus.Invincible_Locker = true;
                    Invincible = false;

                    return;
                }
            }


        }




    }
}
