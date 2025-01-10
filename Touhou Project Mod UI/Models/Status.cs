using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touhou_Project_Mod_UI.Models
{
    public class Status
    {

        private  bool _isTouhouRun;
        private  bool _lockPlayer;
        private  bool _lockBomb;
        private  bool _maxPower;
        private  bool _invincible;
        public  event EventHandler IsTouhouRunChanged;
        public  event EventHandler LockPlayerChanged;
        public  event EventHandler LockBombChanged;
        public  event EventHandler MaxPowerChanged;
        public  event EventHandler InvincibleChanged;

        public bool IsRunStatus;
        public bool IsRunStatusC;
        public bool IsRunStatusE;
        public bool IsRunStatusCC;
        public bool IsRun
        {
            get => _isTouhouRun;
            set
            {
                if (_isTouhouRun != value)
                {
                    _isTouhouRun = value;
                    IsTouhouRunChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        public bool LockPlayer
        {
            get => _lockPlayer;
            set
            {
                if (_lockPlayer != value)
                {
                    _lockPlayer = value;
                    LockPlayerChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        public bool LockBomb
        {
            get => _lockBomb;
            set
            {
                if (_lockBomb != value)
                {
                    _lockBomb = value;
                    LockBombChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        public bool MaxPower
        {
            get => _maxPower;
            set
            {
                if (_maxPower != value)
                {
                    _maxPower = value;
                    MaxPowerChanged?.Invoke(null, EventArgs.Empty);
                }
            }
        }
        public bool Invincible
        {
            get => _invincible;
            set
            {
                if (_invincible != value)
                {
                    _invincible = value;
                    InvincibleChanged?.Invoke(null, EventArgs.Empty);
                }
            }
        }

        public bool LockPlayer_Locker = false;
        public bool LockerBomb_Locker = false;
        public bool MaxPower_Locker = false;
        public bool Invincible_Locker = false;


        public IntPtr BaseAddress { get; set; }
        public IntPtr ProcessHandle { get; set; }


        public int Vsersion { get; set; }
    }
}
