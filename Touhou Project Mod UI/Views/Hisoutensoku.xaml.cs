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
    /// Hisoutensoku.xaml 的交互逻辑
    /// 骨架页：Offset / Value 里的数值填好后即可直接生效，无需改动本文件。
    /// </summary>
    public partial class Hisoutensoku : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public bool IsGreenDotVisible
        {
            get => Globals.HisoutensokuStatus.IsRun;
            set
            {
                if (Globals.HisoutensokuStatus.IsRun != value)
                {
                    Globals.HisoutensokuStatus.IsRun = value;
                    OnPropertyChanged(nameof(IsGreenDotVisible));
                }
            }
        }
        public bool LockPlayer
        {
            get => Globals.HisoutensokuStatus.LockPlayer;
            set
            {
                if (Globals.HisoutensokuStatus.LockPlayer != value)
                {
                    Globals.HisoutensokuStatus.LockPlayer = value;
                    OnPropertyChanged(nameof(LockPlayer));
                }
            }
        }
        public bool LockBomb
        {
            get => Globals.HisoutensokuStatus.LockBomb;
            set
            {
                if (Globals.HisoutensokuStatus.LockBomb != value)
                {
                    Globals.HisoutensokuStatus.LockBomb = value;
                    OnPropertyChanged(nameof(LockBomb));
                }
            }
        }
        public bool MaxPower
        {
            get => Globals.HisoutensokuStatus.MaxPower;
            set
            {
                if (Globals.HisoutensokuStatus.MaxPower != value)
                {
                    Globals.HisoutensokuStatus.MaxPower = value;
                    OnPropertyChanged(nameof(MaxPower));
                }
            }
        }
        public bool Invincible
        {
            get => Globals.HisoutensokuStatus.Invincible;
            set
            {
                if (Globals.HisoutensokuStatus.Invincible != value)
                {
                    Globals.HisoutensokuStatus.Invincible = value;
                    OnPropertyChanged(nameof(Invincible));
                }
            }
        }


        public Hisoutensoku()
        {
            InitializeComponent();
            DataContext = this;
            IsGreenDotVisible = Globals.HisoutensokuStatus.IsRun;
            LockPlayer = Globals.HisoutensokuStatus.LockPlayer;
            LockBomb = Globals.HisoutensokuStatus.LockBomb;
            MaxPower = Globals.HisoutensokuStatus.MaxPower;
            Invincible = Globals.HisoutensokuStatus.Invincible;

            Globals.HisoutensokuStatus.IsTouhouRunChanged += OnGlobalsIsHisoutensokuRunChanged;
            Globals.HisoutensokuStatus.LockPlayerChanged += OnGlobaLockPlayerChanged;
            Globals.HisoutensokuStatus.LockBombChanged += OnGlobalsLockBombChanged;
            Globals.HisoutensokuStatus.MaxPowerChanged += OnGlobalsMaxPowerChanged;
            Globals.HisoutensokuStatus.InvincibleChanged += OnGlobalsInvincibleChanged;
        }

        private void OnGlobalsIsHisoutensokuRunChanged(object sender, EventArgs e)
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
            if (Globals.HisoutensokuStatus.BaseAddress == IntPtr.Zero && Globals.HisoutensokuStatus.ProcessHandle == IntPtr.Zero)
            {
                if (Globals.HisoutensokuStatus.IsRunStatus)
                {
                    (Globals.HisoutensokuStatus.BaseAddress, Globals.HisoutensokuStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th123");
                    if (Globals.HisoutensokuStatus.BaseAddress == IntPtr.Zero && Globals.HisoutensokuStatus.ProcessHandle == IntPtr.Zero)
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
            if (Globals.HisoutensokuStatus.LockPlayer_Locker)
            {
                Globals.HisoutensokuStatus.LockPlayer_Locker = false;
                return;
            }
            if (!Globals.HisoutensokuStatus.IsRun)
            {
                Globals.HisoutensokuStatus.LockPlayer_Locker = true;

                LockPlayer = false;

                return;

            }

            if (Globals.HisoutensokuStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!LockPlayer)
            {
                if (!Memory.SetMemory(Globals.HisoutensokuStatus.ProcessHandle, Globals.HisoutensokuStatus.BaseAddress + Offset.Hisoutensoku_Sub_Plyaer_Offset, Value.Hisoutensoku_Sub_Plyaer_Value_Default))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.HisoutensokuStatus.ProcessHandle, Globals.HisoutensokuStatus.BaseAddress + Offset.Hisoutensoku_Sub_Plyaer_Offset, Value.Hisoutensoku_Sub_Plyaer_Value))
                {
                    Globals.HisoutensokuStatus.LockPlayer_Locker = true;
                    LockPlayer = false;
                    return;
                }
            }


        }
        private void LockeBombToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.HisoutensokuStatus.LockerBomb_Locker)
            {
                Globals.HisoutensokuStatus.LockerBomb_Locker = false;
                return;
            }
            if (!Globals.HisoutensokuStatus.IsRun)
            {
                Globals.HisoutensokuStatus.LockerBomb_Locker = true;
                LockBomb = false;

                return;

            }
            if (Globals.HisoutensokuStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!LockBomb)
            {
                if (!Memory.SetMemory(Globals.HisoutensokuStatus.ProcessHandle, Globals.HisoutensokuStatus.BaseAddress + Offset.Hisoutensoku_Sub_Bomb_Offset, Value.Hisoutensoku_Sub_Bomb_Value_Default))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.HisoutensokuStatus.ProcessHandle, Globals.HisoutensokuStatus.BaseAddress + Offset.Hisoutensoku_Sub_Bomb_Offset, Value.Hisoutensoku_Sub_Bomb_Value))
                {
                    Globals.HisoutensokuStatus.LockerBomb_Locker = true;
                    LockBomb = false;

                    return;
                }
            }

        }
        private void MaxPowerToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.HisoutensokuStatus.MaxPower_Locker)
            {
                Globals.HisoutensokuStatus.MaxPower_Locker = false;
                return;
            }
            if (!Globals.HisoutensokuStatus.IsRun)
            {
                Globals.HisoutensokuStatus.MaxPower_Locker = true;
                MaxPower = false;

                return;

            }

            if (Globals.HisoutensokuStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }
            if (!MaxPower)
            {
                if (!Memory.SetMemory(Globals.HisoutensokuStatus.ProcessHandle, Globals.HisoutensokuStatus.BaseAddress + Offset.Hisoutensoku_Sub_Power_Offset, Value.Hisoutensoku_Sub_Power_Value_Default))
                {
                    return;
                }


            }
            else
            {

                if (!Memory.SetMemory(Globals.HisoutensokuStatus.ProcessHandle, Globals.HisoutensokuStatus.BaseAddress + Offset.Hisoutensoku_Power_Offset, Value.Hisoutensoku_Power_Value))
                {
                    Globals.HisoutensokuStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


                if (!Memory.SetMemory(Globals.HisoutensokuStatus.ProcessHandle, Globals.HisoutensokuStatus.BaseAddress + Offset.Hisoutensoku_Sub_Power_Offset, Value.Hisoutensoku_Sub_Power_Value))
                {
                    Globals.HisoutensokuStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


            }


            MaxPower = MaxPowerSwitch.IsOn;

        }
        private void InvincibleToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.HisoutensokuStatus.Invincible_Locker)
            {
                Globals.HisoutensokuStatus.Invincible_Locker = false;
                return;
            }

            if (!Globals.HisoutensokuStatus.IsRun)
            {
                Globals.HisoutensokuStatus.Invincible_Locker = true;

                Invincible = false;


                return;
            }
            if (Globals.HisoutensokuStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!Invincible)
            {
                if (!Memory.SetMemory(Globals.HisoutensokuStatus.ProcessHandle, Globals.HisoutensokuStatus.BaseAddress + Offset.Hisoutensoku_Sub_Invincible_Offset, Value.Hisoutensoku_Sub_Invincible_Value_Default))
                {

                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.HisoutensokuStatus.ProcessHandle, Globals.HisoutensokuStatus.BaseAddress + Offset.Hisoutensoku_Sub_Invincible_Offset, Value.Hisoutensoku_Sub_Invincible_Value))
                {
                    Globals.HisoutensokuStatus.Invincible_Locker = true;
                    Invincible = false;

                    return;
                }
            }


        }




    }
}
