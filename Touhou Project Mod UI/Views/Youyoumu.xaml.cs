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
    /// Youyoumu.xaml 的交互逻辑
    /// </summary>

    public partial class Youyoumu : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public bool IsGreenDotVisible
        {
            get => Globals.YouyoumuStatus.IsRun;
            set
            {
                if (Globals.YouyoumuStatus.IsRun != value)
                {
                    Globals.YouyoumuStatus.IsRun = value;
                    OnPropertyChanged(nameof(IsGreenDotVisible));
                }
            }
        }
        public bool LockPlayer
        {
            get => Globals.YouyoumuStatus.LockPlayer;
            set
            {
                if (Globals.YouyoumuStatus.LockPlayer != value)
                {
                    Globals.YouyoumuStatus.LockPlayer = value;
                    OnPropertyChanged(nameof(LockPlayer));
                }
            }
        }
        public bool LockBomb
        {
            get => Globals.YouyoumuStatus.LockBomb;
            set
            {
                if (Globals.YouyoumuStatus.LockBomb != value)
                {
                    Globals.YouyoumuStatus.LockBomb = value;
                    OnPropertyChanged(nameof(LockBomb));
                }
            }
        }
        public bool MaxPower
        {
            get => Globals.YouyoumuStatus.MaxPower;
            set
            {
                if (Globals.YouyoumuStatus.MaxPower != value)
                {
                    Globals.YouyoumuStatus.MaxPower = value;
                    OnPropertyChanged(nameof(MaxPower));
                }
            }
        }
        public bool Invincible
        {
            get => Globals.YouyoumuStatus.Invincible;
            set
            {
                if (Globals.YouyoumuStatus.Invincible != value)
                {
                    Globals.YouyoumuStatus.Invincible = value;
                    OnPropertyChanged(nameof(Invincible));
                }
            }
        }


        public Youyoumu()
        {
            InitializeComponent();
            DataContext = this;
            IsGreenDotVisible = Globals.YouyoumuStatus.IsRun;
            LockPlayer = Globals.YouyoumuStatus.LockPlayer;
            LockBomb = Globals.YouyoumuStatus.LockBomb;
            MaxPower = Globals.YouyoumuStatus.MaxPower;
            Invincible = Globals.YouyoumuStatus.Invincible;

            Globals.YouyoumuStatus.IsTouhouRunChanged += OnGlobalsIsYouyoumuRunChanged;
            Globals.YouyoumuStatus.LockPlayerChanged += OnGlobaLockPlayerChanged;
            Globals.YouyoumuStatus.LockBombChanged += OnGlobalsLockBombChanged;
            Globals.YouyoumuStatus.MaxPowerChanged += OnGlobalsMaxPowerChanged;
            Globals.YouyoumuStatus.InvincibleChanged += OnGlobalsInvincibleChanged;
        }

        private void OnGlobalsIsYouyoumuRunChanged(object sender, EventArgs e)
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
            if (Globals.YouyoumuStatus.BaseAddress == IntPtr.Zero && Globals.YouyoumuStatus.ProcessHandle == IntPtr.Zero)
            {
                if (Globals.YouyoumuStatus.IsRunStatus)
                {
                    (Globals.YouyoumuStatus.BaseAddress, Globals.YouyoumuStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th07");
                    if (Globals.YouyoumuStatus.BaseAddress == IntPtr.Zero && Globals.YouyoumuStatus.ProcessHandle == IntPtr.Zero)
                    {
                        return false;
                    }
                    Offset.Youyoumu_ReLocate_Offet = Memory.LocateRealPtr(Globals.YouyoumuStatus.ProcessHandle, Globals.YouyoumuStatus.BaseAddress, Offset.Youyoumu_Power_Offset, Offset.Youyoumu_Power_Ptr_Offset);
                    //if (Offset.Youyoumu_ReLocate_Offet == IntPtr.Zero)
                    //{
                    //    return false;
                    //}
                }
                if (Globals.YouyoumuStatus.IsRunStatusC)
                {
                    (Globals.YouyoumuStatus.BaseAddress, Globals.YouyoumuStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th07c");
                    if (Globals.YouyoumuStatus.BaseAddress == IntPtr.Zero && Globals.YouyoumuStatus.ProcessHandle == IntPtr.Zero)
                    {
                        return false;
                    }
                    Offset.Youyoumu_ReLocate_Offet = Memory.LocateRealPtr(Globals.YouyoumuStatus.ProcessHandle, Globals.YouyoumuStatus.BaseAddress, Offset.Youyoumu_Power_Offset, Offset.Youyoumu_Power_Ptr_Offset);
                    //if (Offset.Youyoumu_ReLocate_Offet == IntPtr.Zero)
                    //{
                    //    return false;
                    //}
                }
                if (Globals.YouyoumuStatus.IsRunStatusE)
                {
                    (Globals.YouyoumuStatus.BaseAddress, Globals.YouyoumuStatus.ProcessHandle) = Memory.GetBaseAddressWithProcvessHandle("th07e");
                    if (Globals.YouyoumuStatus.BaseAddress == IntPtr.Zero && Globals.YouyoumuStatus.ProcessHandle == IntPtr.Zero)
                    {
                        return false;
                    }
                    Offset.Youyoumu_ReLocate_Offet = Memory.LocateRealPtr(Globals.YouyoumuStatus.ProcessHandle, Globals.YouyoumuStatus.BaseAddress, Offset.Youyoumu_Power_Offset, Offset.Youyoumu_Power_Ptr_Offset);
                    //if (Offset.Youyoumu_ReLocate_Offet == IntPtr.Zero)
                    //{
                    //    return false;
                    //}
                }
                return true;
            }
            return true;
        }

        private void LockePlayerToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.YouyoumuStatus.LockPlayer_Locker)
            {
                Globals.YouyoumuStatus.LockPlayer_Locker = false;
                return;
            }
            if (!Globals.YouyoumuStatus.IsRun)
            {
                Globals.YouyoumuStatus.LockPlayer_Locker = true;

                LockPlayer = false;

                return;

            }

            if (Globals.YouyoumuStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }


            if (!LockPlayer)
            {
                if (!Memory.SetMemory(Globals.YouyoumuStatus.ProcessHandle, Globals.YouyoumuStatus.BaseAddress + Offset.Youyoumu_Sub_Plyaer_Offset, Value.Youyoumu_Sub_Plyaer_Value_Default))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.YouyoumuStatus.ProcessHandle, Globals.YouyoumuStatus.BaseAddress + Offset.Youyoumu_Sub_Plyaer_Offset, Value.Youyoumu_Sub_Plyaer_Value))
                {
                    Globals.YouyoumuStatus.LockPlayer_Locker = true;
                    LockPlayer = false;
                    return;
                }
            }


        }
        private void LockeBombToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.YouyoumuStatus.LockerBomb_Locker)
            {
                Globals.YouyoumuStatus.LockerBomb_Locker = false;
                return;
            }
            if (!Globals.YouyoumuStatus.IsRun)
            {
                Globals.YouyoumuStatus.LockerBomb_Locker = true;
                LockBomb = false;

                return;

            }
            if (Globals.YouyoumuStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!LockBomb)
            {
                if (!Memory.SetMemory(Globals.YouyoumuStatus.ProcessHandle, Globals.YouyoumuStatus.BaseAddress + Offset.Youyoumu_Sub_Bomb_Offset, Value.Youyoumu_Sub_Bomb_Value_Default))
                {
                    return;
                }
            }
            else
            {

                if (!Memory.SetMemory(Globals.YouyoumuStatus.ProcessHandle, Globals.YouyoumuStatus.BaseAddress + Offset.Youyoumu_Sub_Bomb_Offset, Value.Youyoumu_Sub_Bomb_Value))
                {
                    Globals.YouyoumuStatus.LockerBomb_Locker = true;
                    LockBomb = false;

                    return;
                }
            }

        }
        private void MaxPowerToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.YouyoumuStatus.MaxPower_Locker)
            {
                Globals.YouyoumuStatus.MaxPower_Locker = false;
                return;
            }
            if (!Globals.YouyoumuStatus.IsRun)
            {
                Globals.YouyoumuStatus.MaxPower_Locker = true;
                MaxPower = false;

                return;

            }

            if (Globals.YouyoumuStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }
            if (!MaxPower)
            {
                Globals.YouyoumuStatus.MaxPower_Locker = false;
                MaxPower = false;
                return;

            }
            else
            {

                Globals.YouyoumuStatus.MaxPower_Locker = false;
                MaxPower = false;
                return;


            }


            MaxPower = MaxPowerSwitch.IsOn;

        }
        private void InvincibleToggled(object sender, RoutedEventArgs e)
        {
            if (Globals.YouyoumuStatus.Invincible_Locker)
            {
                Globals.YouyoumuStatus.Invincible_Locker = false;
                return;
            }

            if (!Globals.YouyoumuStatus.IsRun)
            {
                Globals.YouyoumuStatus.Invincible_Locker = true;

                Invincible = false;


                return;
            }
            if (Globals.YouyoumuStatus.BaseAddress == IntPtr.Zero)
            {
                if (!GetMemoryInfo())
                {
                    return;
                }
            }

            if (!Invincible)
            {
                if (!Memory.SetMemory(Globals.YouyoumuStatus.ProcessHandle, Globals.YouyoumuStatus.BaseAddress + Offset.Youyoumu_Sub_Invincible1_Offset, Value.Youyoumu_Sub_Invincible1_Value_Default))
                {
                    Globals.YouyoumuStatus.Invincible = false;
                    Invincible = false;

                    return;
                }
                if (!Memory.SetMemory(Globals.YouyoumuStatus.ProcessHandle, Globals.YouyoumuStatus.BaseAddress + Offset.Youyoumu_Sub_Invincible2_Offset, Value.Youyoumu_Sub_Invincible2_Value_Default))
                {
                    Globals.YouyoumuStatus.Invincible = false;
                    Invincible = false;

                    return;
                }

            }
            else
            {

                if (!Memory.SetMemory(Globals.YouyoumuStatus.ProcessHandle, Globals.YouyoumuStatus.BaseAddress + Offset.Youyoumu_Sub_Invincible1_Offset, Value.Youyoumu_Sub_Invincible1_Value))
                {
                    Globals.YouyoumuStatus.Invincible = true;
                    Invincible = true;

                    return;
                }
                if (!Memory.SetMemory(Globals.YouyoumuStatus.ProcessHandle, Globals.YouyoumuStatus.BaseAddress + Offset.Youyoumu_Sub_Invincible2_Offset, Value.Youyoumu_Sub_Invincible2_Value))
                {
                    Globals.YouyoumuStatus.Invincible = true;
                    Invincible = true;

                    return;
                }

            }


        }




    }
}
