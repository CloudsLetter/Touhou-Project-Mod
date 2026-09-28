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
    /// Hyouika.xaml 的交互逻辑
    /// 骨架页：Offset / Value 里的数值填好后即可直接生效，无需改动本文件。
    /// </summary>
    public partial class Hyouika : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public bool IsGreenDotVisible
        {
            get => Globals.HyouikaStatus.IsRun;
            set
            {
                if (Globals.HyouikaStatus.IsRun != value)
                {
                    Globals.HyouikaStatus.IsRun = value;
                    OnPropertyChanged(nameof(IsGreenDotVisible));
                }
            }
        }
        public bool LockPlayer
        {
            get => Globals.HyouikaStatus.LockPlayer;
            set
            {
                if (Globals.HyouikaStatus.LockPlayer != value)
                {
                    Globals.HyouikaStatus.LockPlayer = value;
                    OnPropertyChanged(nameof(LockPlayer));
                }
            }
        }
        public bool LockBomb
        {
            get => Globals.HyouikaStatus.LockBomb;
            set
            {
                if (Globals.HyouikaStatus.LockBomb != value)
                {
                    Globals.HyouikaStatus.LockBomb = value;
                    OnPropertyChanged(nameof(LockBomb));
                }
            }
        }
        public bool MaxPower
        {
            get => Globals.HyouikaStatus.MaxPower;
            set
            {
                if (Globals.HyouikaStatus.MaxPower != value)
                {
                    Globals.HyouikaStatus.MaxPower = value;
                    OnPropertyChanged(nameof(MaxPower));
                }
            }
        }
        public bool Invincible
        {
            get => Globals.HyouikaStatus.Invincible;
            set
            {
                if (Globals.HyouikaStatus.Invincible != value)
                {
                    Globals.HyouikaStatus.Invincible = value;
                    OnPropertyChanged(nameof(Invincible));
                }
            }
        }


        public Hyouika()
        {
            InitializeComponent();
            DataContext = this;
            IsGreenDotVisible = Globals.HyouikaStatus.IsRun;
            LockPlayer = Globals.HyouikaStatus.LockPlayer;
            LockBomb = Globals.HyouikaStatus.LockBomb;
            MaxPower = Globals.HyouikaStatus.MaxPower;
            Invincible = Globals.HyouikaStatus.Invincible;

            Globals.HyouikaStatus.IsTouhouRunChanged += OnGlobalsIsHyouikaRunChanged;
            Globals.HyouikaStatus.LockPlayerChanged += OnGlobaLockPlayerChanged;
            Globals.HyouikaStatus.LockBombChanged += OnGlobalsLockBombChanged;
            Globals.HyouikaStatus.MaxPowerChanged += OnGlobalsMaxPowerChanged;
            Globals.HyouikaStatus.InvincibleChanged += OnGlobalsInvincibleChanged;
        }

        private void OnGlobalsIsHyouikaRunChanged(object sender, EventArgs e)
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
            if (Globals.HyouikaStatus.BaseAddress == IntPtr.Zero && Globals.HyouikaStatus.ProcessHandle == IntPtr.Zero)
            {
                if (Globals.HyouikaStatus.IsRunStatus)
                {
                    (Globals.HyouikaStatus.BaseAddress, Globals.HyouikaStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th155");
                    if (Globals.HyouikaStatus.BaseAddress == IntPtr.Zero && Globals.HyouikaStatus.ProcessHandle == IntPtr.Zero)
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
            if (Globals.HyouikaStatus.LockPlayer_Locker)
            {
                Globals.HyouikaStatus.LockPlayer_Locker = false;
                return;
            }
            if (!Globals.HyouikaStatus.IsRun)
            {
                Globals.HyouikaStatus.LockPlayer_Locker = true;

                LockPlayer = false;

                return;

            }

            if (Globals.HyouikaStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!LockPlayer)
            {
                if (!Memory.SetMemory(Globals.HyouikaStatus.ProcessHandle, Globals.HyouikaStatus.BaseAddress + Offset.Hyouika_Sub_Plyaer_Offset, Value.Hyouika_Sub_Plyaer_Value_Default))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.HyouikaStatus.ProcessHandle, Globals.HyouikaStatus.BaseAddress + Offset.Hyouika_Sub_Plyaer_Offset, Value.Hyouika_Sub_Plyaer_Value))
                {
                    Globals.HyouikaStatus.LockPlayer_Locker = true;
                    LockPlayer = false;
                    return;
                }
            }


        }
        private void LockeBombToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.HyouikaStatus.LockerBomb_Locker)
            {
                Globals.HyouikaStatus.LockerBomb_Locker = false;
                return;
            }
            if (!Globals.HyouikaStatus.IsRun)
            {
                Globals.HyouikaStatus.LockerBomb_Locker = true;
                LockBomb = false;

                return;

            }
            if (Globals.HyouikaStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!LockBomb)
            {
                if (!Memory.SetMemory(Globals.HyouikaStatus.ProcessHandle, Globals.HyouikaStatus.BaseAddress + Offset.Hyouika_Sub_Bomb_Offset, Value.Hyouika_Sub_Bomb_Value_Default))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.HyouikaStatus.ProcessHandle, Globals.HyouikaStatus.BaseAddress + Offset.Hyouika_Sub_Bomb_Offset, Value.Hyouika_Sub_Bomb_Value))
                {
                    Globals.HyouikaStatus.LockerBomb_Locker = true;
                    LockBomb = false;

                    return;
                }
            }

        }
        private void MaxPowerToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.HyouikaStatus.MaxPower_Locker)
            {
                Globals.HyouikaStatus.MaxPower_Locker = false;
                return;
            }
            if (!Globals.HyouikaStatus.IsRun)
            {
                Globals.HyouikaStatus.MaxPower_Locker = true;
                MaxPower = false;

                return;

            }

            if (Globals.HyouikaStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }
            if (!MaxPower)
            {
                if (!Memory.SetMemory(Globals.HyouikaStatus.ProcessHandle, Globals.HyouikaStatus.BaseAddress + Offset.Hyouika_Sub_Power_Offset, Value.Hyouika_Sub_Power_Value_Default))
                {
                    return;
                }


            }
            else
            {

                if (!Memory.SetMemory(Globals.HyouikaStatus.ProcessHandle, Globals.HyouikaStatus.BaseAddress + Offset.Hyouika_Power_Offset, Value.Hyouika_Power_Value))
                {
                    Globals.HyouikaStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


                if (!Memory.SetMemory(Globals.HyouikaStatus.ProcessHandle, Globals.HyouikaStatus.BaseAddress + Offset.Hyouika_Sub_Power_Offset, Value.Hyouika_Sub_Power_Value))
                {
                    Globals.HyouikaStatus.MaxPower_Locker = true;
                    MaxPower = false;

                    return;
                }


            }


            MaxPower = MaxPowerSwitch.IsOn;

        }
        private void InvincibleToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.HyouikaStatus.Invincible_Locker)
            {
                Globals.HyouikaStatus.Invincible_Locker = false;
                return;
            }

            if (!Globals.HyouikaStatus.IsRun)
            {
                Globals.HyouikaStatus.Invincible_Locker = true;

                Invincible = false;


                return;
            }
            if (Globals.HyouikaStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!Invincible)
            {
                if (!Memory.SetMemory(Globals.HyouikaStatus.ProcessHandle, Globals.HyouikaStatus.BaseAddress + Offset.Hyouika_Sub_Invincible_Offset, Value.Hyouika_Sub_Invincible_Value_Default))
                {

                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.HyouikaStatus.ProcessHandle, Globals.HyouikaStatus.BaseAddress + Offset.Hyouika_Sub_Invincible_Offset, Value.Hyouika_Sub_Invincible_Value))
                {
                    Globals.HyouikaStatus.Invincible_Locker = true;
                    Invincible = false;

                    return;
                }
            }


        }




    }
}
