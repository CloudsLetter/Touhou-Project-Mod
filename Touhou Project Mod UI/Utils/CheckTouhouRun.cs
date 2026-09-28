using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Touhou_Project_Mod_UI.Models;
using Touhou_Project_Mod_UI.SDK.Native;
using Touhou_Project_Mod_UI.Views;
namespace Touhou_Project_Mod_UI.Utils
{
    public static class Utils
    {
        public static  void CheckTouhouRun()
        {
            while (true) {

            foreach (var item in Globals.TouhouVersionList)
            {
                    bool tmpBool = Memory.IsTouhouRun(item);

                    if (tmpBool && item.Contains("th06") || tmpBool && item.Contains("東方紅魔郷"))
                    {
                        if (!Globals.KoumakyouStatus.IsRunStatus && !Globals.KoumakyouStatus.IsRun && item == "th06")
                        {
                            Globals.KoumakyouStatus.IsRunStatus = true;
                            Globals.KoumakyouStatus.IsRun = true;

                        }
                        if (!Globals.KoumakyouStatus.IsRunStatusC && !Globals.KoumakyouStatus.IsRun && item == "th06c")
                        {
                            Globals.KoumakyouStatus.IsRunStatusC = true;
                            Globals.KoumakyouStatus.IsRun = true;

                        }
                        if (!Globals.KoumakyouStatus.IsRunStatusE && !Globals.KoumakyouStatus.IsRun && item == "th06e")
                        {
                            Globals.KoumakyouStatus.IsRunStatusE = true;
                            Globals.KoumakyouStatus.IsRun = true;

                        }
                        if (!Globals.KoumakyouStatus.IsRunStatusCC && !Globals.KoumakyouStatus.IsRun && item == "東方紅魔郷")
                        {
                            Globals.KoumakyouStatus.IsRunStatusCC = true;
                            Globals.KoumakyouStatus.IsRun = true;

                        }
                    }
                    else if (!tmpBool && item.Contains("th06") || !tmpBool && item.Contains("東方紅魔郷"))
                    {

                        if (Globals.KoumakyouStatus.IsRunStatus && Globals.KoumakyouStatus.IsRun && item == "th06")
                        {
                            Globals.KoumakyouStatus.IsRunStatus = false;
                            Globals.KoumakyouStatus.IsRun = false;
                            Globals.KoumakyouStatus.BaseAddress = 0;
                            Globals.KoumakyouStatus.ProcessHandle = 0;
                            Globals.KoumakyouStatus.LockPlayer = false;
                            Globals.KoumakyouStatus.LockBomb = false;
                            Globals.KoumakyouStatus.MaxPower = false;
                            Globals.KoumakyouStatus.Invincible = false;


                        }
                        if (Globals.KoumakyouStatus.IsRunStatusC && Globals.KoumakyouStatus.IsRun && item == "th06c")
                        {
                            Globals.KoumakyouStatus.IsRunStatusC = false;
                            Globals.KoumakyouStatus.IsRun = false;
                            Globals.KoumakyouStatus.BaseAddress = 0;
                            Globals.KoumakyouStatus.ProcessHandle = 0;
                            Globals.KoumakyouStatus.LockPlayer = false;
                            Globals.KoumakyouStatus.LockBomb = false;
                            Globals.KoumakyouStatus.MaxPower = false;
                            Globals.KoumakyouStatus.Invincible = false;
                        }
                        if (Globals.KoumakyouStatus.IsRunStatusE && Globals.KoumakyouStatus.IsRun && item == "th06e")
                        {
                            Globals.KoumakyouStatus.IsRunStatusE = false;
                            Globals.KoumakyouStatus.IsRun = false;
                            Globals.KoumakyouStatus.BaseAddress = 0;
                            Globals.KoumakyouStatus.ProcessHandle = 0;
                            Globals.KoumakyouStatus.LockPlayer = false;
                            Globals.KoumakyouStatus.LockBomb = false;
                            Globals.KoumakyouStatus.MaxPower = false;
                            Globals.KoumakyouStatus.Invincible = false;
                        }
                        if (Globals.KoumakyouStatus.IsRunStatusCC && Globals.KoumakyouStatus.IsRun && item == "東方紅魔郷")
                        {
                            Globals.KoumakyouStatus.IsRunStatusCC = false;
                            Globals.KoumakyouStatus.IsRun = false;
                            Globals.KoumakyouStatus.BaseAddress = 0;
                            Globals.KoumakyouStatus.ProcessHandle = 0;
                            Globals.KoumakyouStatus.LockPlayer = false;
                            Globals.KoumakyouStatus.LockBomb = false;
                            Globals.KoumakyouStatus.MaxPower = false;
                            Globals.KoumakyouStatus.Invincible = false;
                        }
                    }

                    if (tmpBool && item == "th06nc")
                    {
                        if (!Globals.KoumakyouNcStatus.IsRunStatus && !Globals.KoumakyouNcStatus.IsRun)
                        {
                            Globals.KoumakyouNcStatus.IsRunStatus = true;
                            Globals.KoumakyouNcStatus.IsRun = true;

                        }

                    }
                    else if (!tmpBool && item == "th06nc")
                    {

                        if (Globals.KoumakyouNcStatus.IsRunStatus && Globals.KoumakyouNcStatus.IsRun)
                        {
                            Globals.KoumakyouNcStatus.IsRunStatus = false;
                            Globals.KoumakyouNcStatus.IsRun = false;
                            Globals.KoumakyouNcStatus.BaseAddress = 0;
                            Globals.KoumakyouNcStatus.ProcessHandle = 0;
                            TouhouHackProfiles.KoumakyouNc.ResetAll();
                        }

                    }
                    if (tmpBool && item.Contains("th07"))
                    {
                        if (!Globals.YouyoumuStatus.IsRunStatus && !Globals.YouyoumuStatus.IsRun && item == "th07")
                        {
                            Globals.YouyoumuStatus.IsRunStatus = true;
                            Globals.YouyoumuStatus.IsRun = true;
                        }
                        if (!Globals.YouyoumuStatus.IsRunStatusC && !Globals.YouyoumuStatus.IsRun && item == "th07c")
                        {
                            Globals.YouyoumuStatus.IsRunStatusC = true;
                            Globals.YouyoumuStatus.IsRun = true;

                        }
                        if (!Globals.YouyoumuStatus.IsRunStatusE && !Globals.YouyoumuStatus.IsRun && item == "th07e")
                        {
                            Globals.YouyoumuStatus.IsRunStatusE = true;
                            Globals.YouyoumuStatus.IsRun = true;

                        }

                    }
                    else if (!tmpBool && item.Contains("th07"))
                    {

                        if (Globals.YouyoumuStatus.IsRunStatus && Globals.YouyoumuStatus.IsRun && item == "th07")
                        {
                            Globals.YouyoumuStatus.IsRunStatus = false;
                            Globals.YouyoumuStatus.IsRun = false;
                            Globals.YouyoumuStatus.BaseAddress = 0;
                            Globals.YouyoumuStatus.ProcessHandle = 0;
                            Globals.YouyoumuStatus.LockPlayer = false;
                            Globals.YouyoumuStatus.LockBomb = false;
                            Globals.YouyoumuStatus.MaxPower = false;
                            Globals.YouyoumuStatus.Invincible = false;
                        }
                        if (Globals.YouyoumuStatus.IsRunStatusC && Globals.YouyoumuStatus.IsRun && item == "th07c")
                        {
                            Globals.YouyoumuStatus.IsRunStatusC = false;
                            Globals.YouyoumuStatus.IsRun = false;
                            Globals.YouyoumuStatus.BaseAddress = 0;
                            Globals.YouyoumuStatus.ProcessHandle = 0;
                            Globals.YouyoumuStatus.LockPlayer = false;
                            Globals.YouyoumuStatus.LockBomb = false;
                            Globals.YouyoumuStatus.MaxPower = false;
                            Globals.YouyoumuStatus.Invincible = false;
                        }
                        if (Globals.YouyoumuStatus.IsRunStatusE && Globals.YouyoumuStatus.IsRun && item == "th07e")
                        {
                            Globals.YouyoumuStatus.IsRunStatusE = false;
                            Globals.YouyoumuStatus.IsRun = false;
                            Globals.YouyoumuStatus.BaseAddress = 0;
                            Globals.YouyoumuStatus.ProcessHandle = 0;
                            Globals.YouyoumuStatus.LockPlayer = false;
                            Globals.YouyoumuStatus.LockBomb = false;
                            Globals.YouyoumuStatus.MaxPower = false;
                            Globals.YouyoumuStatus.Invincible = false;
                        }

                    }
                    if (tmpBool && item.Contains("th08"))
                    {
                        if (!Globals.EiyashouStatus.IsRunStatus && !Globals.EiyashouStatus.IsRun && item == "th08")
                        {
                            Globals.EiyashouStatus.IsRunStatus = true;
                            Globals.EiyashouStatus.IsRun = true;

                        }
                        if (!Globals.EiyashouStatus.IsRunStatusC && !Globals.EiyashouStatus.IsRun && item == "th08c")
                        {
                            Globals.EiyashouStatus.IsRunStatusC = true;
                            Globals.EiyashouStatus.IsRun = true;

                        }
                        if (!Globals.EiyashouStatus.IsRunStatusE && !Globals.EiyashouStatus.IsRun && item == "th08e")
                        {
                            Globals.EiyashouStatus.IsRunStatusE = true;
                            Globals.EiyashouStatus.IsRun = true;

                        }
                    }
                    else if (!tmpBool && item.Contains("th08"))
                    {

                        if (Globals.EiyashouStatus.IsRunStatus && Globals.EiyashouStatus.IsRun && item == "th08")
                        {
                            Globals.EiyashouStatus.IsRunStatus = false;
                            Globals.EiyashouStatus.IsRun = false;
                            Globals.EiyashouStatus.BaseAddress = 0;
                            Globals.EiyashouStatus.ProcessHandle = 0;
                            Globals.EiyashouStatus.LockPlayer = false;
                            Globals.EiyashouStatus.LockBomb = false;
                            Globals.EiyashouStatus.MaxPower = false;
                            Globals.EiyashouStatus.Invincible = false;
                            Offset.Eiyashou_ReLocate_Offet = 0x00;

                        }
                        if (Globals.EiyashouStatus.IsRunStatusC && Globals.EiyashouStatus.IsRun && item == "th08c")
                        {
                            Globals.EiyashouStatus.IsRunStatusC = false;
                            Globals.EiyashouStatus.IsRun = false;
                            Globals.EiyashouStatus.BaseAddress = 0;
                            Globals.EiyashouStatus.ProcessHandle = 0;
                            Globals.EiyashouStatus.LockPlayer = false;
                            Globals.EiyashouStatus.LockBomb = false;
                            Globals.EiyashouStatus.MaxPower = false;
                            Globals.EiyashouStatus.Invincible = false;
                            Offset.Eiyashou_ReLocate_Offet = 0x00;

                        }
                        if (Globals.EiyashouStatus.IsRunStatusE && Globals.EiyashouStatus.IsRun && item == "th08e")
                        {
                            Globals.EiyashouStatus.IsRunStatusE = false;
                            Globals.EiyashouStatus.IsRun = false;
                            Globals.EiyashouStatus.BaseAddress = 0;
                            Globals.EiyashouStatus.ProcessHandle = 0;
                            Globals.EiyashouStatus.LockPlayer = false;
                            Globals.EiyashouStatus.LockBomb = false;
                            Globals.EiyashouStatus.MaxPower = false;
                            Globals.EiyashouStatus.Invincible = false;
                            Offset.Eiyashou_ReLocate_Offet = 0x00;

                        }
                    }
                    if (tmpBool && item.Contains("th09"))
                    {
                        if (!Globals.KaeizukaStatus.IsRunStatus && !Globals.KaeizukaStatus.IsRun && item == "th09")
                        {
                            Globals.KaeizukaStatus.IsRunStatus = true;
                            Globals.KaeizukaStatus.IsRun = true;

                        }
                        if (!Globals.KaeizukaStatus.IsRunStatusC && !Globals.KaeizukaStatus.IsRun && item == "th09c")
                        {
                            Globals.KaeizukaStatus.IsRunStatusC = true;
                            Globals.KaeizukaStatus.IsRun = true;

                        }

                        if (!Globals.KaeizukaStatus.IsRunStatusE && !Globals.KaeizukaStatus.IsRun && item == "th09e")
                        {
                            Globals.KaeizukaStatus.IsRunStatusE = true;
                            Globals.KaeizukaStatus.IsRun = true;

                        }

                    }
                    else if (!tmpBool && item.Contains("th09"))
                    {

                        if (Globals.KaeizukaStatus.IsRunStatus && Globals.KaeizukaStatus.IsRun && item == "th09")
                        {
                            Globals.KaeizukaStatus.IsRunStatus = false;
                            Globals.KaeizukaStatus.IsRun = false;
                            Globals.KaeizukaStatus.BaseAddress = 0;
                            Globals.KaeizukaStatus.ProcessHandle = 0;
                            TouhouHackProfiles.Kaeizuka.ResetAll();
                        }
                        if (Globals.KaeizukaStatus.IsRunStatusC && Globals.KaeizukaStatus.IsRun && item == "th09c")
                        {
                            Globals.KaeizukaStatus.IsRunStatusC = false;
                            Globals.KaeizukaStatus.IsRun = false;
                            Globals.KaeizukaStatus.BaseAddress = 0;
                            Globals.KaeizukaStatus.ProcessHandle = 0;
                            TouhouHackProfiles.Kaeizuka.ResetAll();
                        }

                        if (Globals.KaeizukaStatus.IsRunStatusE && Globals.KaeizukaStatus.IsRun && item == "th09e")
                        {
                            Globals.KaeizukaStatus.IsRunStatusE = false;
                            Globals.KaeizukaStatus.IsRun = false;
                            Globals.KaeizukaStatus.BaseAddress = 0;
                            Globals.KaeizukaStatus.ProcessHandle = 0;
                            TouhouHackProfiles.Kaeizuka.ResetAll();
                        }

                    }
                    if (tmpBool && item.Contains("th10"))
                    {
                        if (!Globals.FuujinrokuStatus.IsRunStatus && !Globals.FuujinrokuStatus.IsRun && item == "th10")
                        {
                            Globals.FuujinrokuStatus.IsRunStatus = true;
                            Globals.FuujinrokuStatus.IsRun = true;

                        }
                        if (!Globals.FuujinrokuStatus.IsRunStatusC && !Globals.FuujinrokuStatus.IsRun && item == "th10c")
                        {
                            Globals.FuujinrokuStatus.IsRunStatusC = true;
                            Globals.FuujinrokuStatus.IsRun = true;

                        }
                        if (!Globals.FuujinrokuStatus.IsRunStatusE && !Globals.FuujinrokuStatus.IsRun && item == "th10e")
                        {
                            Globals.FuujinrokuStatus.IsRunStatusE = true;
                            Globals.FuujinrokuStatus.IsRun = true;

                        }
                    }
                    else if (!tmpBool && item.Contains("th10"))
                    {

                        if (Globals.FuujinrokuStatus.IsRunStatus && Globals.FuujinrokuStatus.IsRun && item == "th10")
                        {
                            Globals.FuujinrokuStatus.IsRunStatus = false;
                            Globals.FuujinrokuStatus.IsRun = false;
                            Globals.FuujinrokuStatus.BaseAddress = 0;
                            Globals.FuujinrokuStatus.ProcessHandle = 0;
                            Globals.FuujinrokuStatus.LockPlayer = false;
                            Globals.FuujinrokuStatus.LockBomb = false;
                            Globals.FuujinrokuStatus.MaxPower = false;
                            Globals.FuujinrokuStatus.Invincible = false;

                        }
                        if (Globals.FuujinrokuStatus.IsRunStatusC && Globals.FuujinrokuStatus.IsRun && item == "th10c")
                        {
                            Globals.FuujinrokuStatus.IsRunStatusC = false;
                            Globals.FuujinrokuStatus.IsRun = false;
                            Globals.FuujinrokuStatus.BaseAddress = 0;
                            Globals.FuujinrokuStatus.ProcessHandle = 0;
                            Globals.FuujinrokuStatus.LockPlayer = false;
                            Globals.FuujinrokuStatus.LockBomb = false;
                            Globals.FuujinrokuStatus.MaxPower = false;
                            Globals.FuujinrokuStatus.Invincible = false;
                        }

                        if (Globals.FuujinrokuStatus.IsRunStatusE && Globals.FuujinrokuStatus.IsRun && item == "th10e")
                        {
                            Globals.FuujinrokuStatus.IsRunStatusE = false;
                            Globals.FuujinrokuStatus.IsRun = false;
                            Globals.FuujinrokuStatus.BaseAddress = 0;
                            Globals.FuujinrokuStatus.ProcessHandle = 0;
                            Globals.FuujinrokuStatus.LockPlayer = false;
                            Globals.FuujinrokuStatus.LockBomb = false;
                            Globals.FuujinrokuStatus.MaxPower = false;
                            Globals.FuujinrokuStatus.Invincible = false;
                        }

                    }
                    if (tmpBool && item.Contains("th11"))
                    {
                        if (!Globals.ChireidenStatus.IsRunStatus && !Globals.ChireidenStatus.IsRun && item == "th11")
                        {
                            Globals.ChireidenStatus.IsRunStatus = true;
                            Globals.ChireidenStatus.IsRun = true;

                        }
                        if (!Globals.ChireidenStatus.IsRunStatusC && !Globals.ChireidenStatus.IsRun && item == "th11c")
                        {
                            Globals.ChireidenStatus.IsRunStatusC = true;
                            Globals.ChireidenStatus.IsRun = true;

                        }

                        if (!Globals.ChireidenStatus.IsRunStatusE && !Globals.ChireidenStatus.IsRun && item == "th11e")
                        {
                            Globals.ChireidenStatus.IsRunStatusE = true;
                            Globals.ChireidenStatus.IsRun = true;

                        }
                    }
                    else if (!tmpBool && item.Contains("th11"))
                    {

                        if (Globals.ChireidenStatus.IsRunStatus && Globals.ChireidenStatus.IsRun && item == "th11")
                        {
                            Globals.ChireidenStatus.IsRunStatus = false;
                            Globals.ChireidenStatus.IsRun = false;
                            Globals.ChireidenStatus.BaseAddress = 0;
                            Globals.ChireidenStatus.ProcessHandle = 0;
                            Globals.ChireidenStatus.LockPlayer = false;
                            Globals.ChireidenStatus.LockBomb = false;
                            Globals.ChireidenStatus.MaxPower = false;
                            Globals.ChireidenStatus.Invincible = false;
                        }
                        if (Globals.ChireidenStatus.IsRunStatusC && Globals.ChireidenStatus.IsRun && item == "th11c")
                        {
                            Globals.ChireidenStatus.IsRunStatusC = false;
                            Globals.ChireidenStatus.IsRun = false;
                            Globals.ChireidenStatus.BaseAddress = 0;
                            Globals.ChireidenStatus.ProcessHandle = 0;
                            Globals.ChireidenStatus.LockPlayer = false;
                            Globals.ChireidenStatus.LockBomb = false;
                            Globals.ChireidenStatus.MaxPower = false;
                            Globals.ChireidenStatus.Invincible = false;
                        }

                        if (Globals.ChireidenStatus.IsRunStatusE && Globals.ChireidenStatus.IsRun && item == "th11e")
                        {
                            Globals.ChireidenStatus.IsRunStatusE = false;
                            Globals.ChireidenStatus.IsRun = false;
                            Globals.ChireidenStatus.BaseAddress = 0;
                            Globals.ChireidenStatus.ProcessHandle = 0;
                            Globals.ChireidenStatus.LockPlayer = false;
                            Globals.ChireidenStatus.LockBomb = false;
                            Globals.ChireidenStatus.MaxPower = false;
                            Globals.ChireidenStatus.Invincible = false;
                        }

                    }
                    if (tmpBool && item.Contains("th12"))
                    {
                        if (!Globals.SeirensenStatus.IsRunStatus && !Globals.SeirensenStatus.IsRun && item == "th12")
                        {
                            Globals.SeirensenStatus.IsRunStatus = true;
                            Globals.SeirensenStatus.IsRun = true;

                        }
                        if (!Globals.SeirensenStatus.IsRunStatusC && !Globals.SeirensenStatus.IsRun && item == "th12c")
                        {
                            Globals.SeirensenStatus.IsRunStatusC = true;
                            Globals.SeirensenStatus.IsRun = true;

                        }
                        if (!Globals.SeirensenStatus.IsRunStatusE && !Globals.SeirensenStatus.IsRun && item == "th12e")
                        {
                            Globals.SeirensenStatus.IsRunStatusE = true;
                            Globals.SeirensenStatus.IsRun = true;

                        }
                    }
                    else if (!tmpBool && item.Contains("th12"))
                    {

                        if (Globals.SeirensenStatus.IsRunStatus && Globals.SeirensenStatus.IsRun && item == "th12")
                        {
                            Globals.SeirensenStatus.IsRunStatus = false;
                            Globals.SeirensenStatus.IsRun = false;
                            Globals.SeirensenStatus.BaseAddress = 0;
                            Globals.SeirensenStatus.ProcessHandle = 0;
                            Globals.SeirensenStatus.LockPlayer = false;
                            Globals.SeirensenStatus.LockBomb = false;
                            Globals.SeirensenStatus.MaxPower = false;
                            Globals.SeirensenStatus.Invincible = false;
                        }
                        if (Globals.SeirensenStatus.IsRunStatusC && Globals.SeirensenStatus.IsRun && item == "th12c")
                        {
                            Globals.SeirensenStatus.IsRunStatusC = false;
                            Globals.SeirensenStatus.IsRun = false;
                            Globals.SeirensenStatus.BaseAddress = 0;
                            Globals.SeirensenStatus.ProcessHandle = 0;
                            Globals.SeirensenStatus.LockPlayer = false;
                            Globals.SeirensenStatus.LockBomb = false;
                            Globals.SeirensenStatus.MaxPower = false;
                            Globals.SeirensenStatus.Invincible = false;
                        }

                        if (Globals.SeirensenStatus.IsRunStatusE && Globals.SeirensenStatus.IsRun && item == "th12e")
                        {
                            Globals.SeirensenStatus.IsRunStatusE = false;
                            Globals.SeirensenStatus.IsRun = false;
                            Globals.SeirensenStatus.BaseAddress = 0;
                            Globals.SeirensenStatus.ProcessHandle = 0;
                            Globals.SeirensenStatus.LockPlayer = false;
                            Globals.SeirensenStatus.LockBomb = false;
                            Globals.SeirensenStatus.MaxPower = false;
                            Globals.SeirensenStatus.Invincible = false;
                        }
                    }
                    if (tmpBool && item.Contains("th13"))
                    {
                        if (!Globals.ShinreibyouStatus.IsRunStatus && !Globals.ShinreibyouStatus.IsRun && item == "th13")
                        {
                            Globals.ShinreibyouStatus.IsRunStatus = true;
                            Globals.ShinreibyouStatus.IsRun = true;

                        }
                        if (!Globals.ShinreibyouStatus.IsRunStatusC && !Globals.ShinreibyouStatus.IsRun && item == "th13c")
                        {
                            Globals.ShinreibyouStatus.IsRunStatusC = true;
                            Globals.ShinreibyouStatus.IsRun = true;

                        }
                        if (!Globals.ShinreibyouStatus.IsRunStatusE && !Globals.ShinreibyouStatus.IsRun && item == "th13e")
                        {
                            Globals.ShinreibyouStatus.IsRunStatusE = true;
                            Globals.ShinreibyouStatus.IsRun = true;

                        }
                    }
                    else if (!tmpBool && item.Contains("th13"))
                    {

                        if (Globals.ShinreibyouStatus.IsRunStatus && Globals.ShinreibyouStatus.IsRun && item == "th13")
                        {
                            Globals.ShinreibyouStatus.IsRunStatus = false;
                            Globals.ShinreibyouStatus.IsRun = false;
                            Globals.ShinreibyouStatus.BaseAddress = 0;
                            Globals.ShinreibyouStatus.ProcessHandle = 0;
                            Globals.ShinreibyouStatus.LockPlayer = false;
                            Globals.ShinreibyouStatus.LockBomb = false;
                            Globals.ShinreibyouStatus.MaxPower = false;
                            Globals.ShinreibyouStatus.Invincible = false;
                        }
                        if (Globals.ShinreibyouStatus.IsRunStatusC && Globals.ShinreibyouStatus.IsRun && item == "th13c")
                        {
                            Globals.ShinreibyouStatus.IsRunStatusC = false;
                            Globals.ShinreibyouStatus.IsRun = false;
                            Globals.ShinreibyouStatus.BaseAddress = 0;
                            Globals.ShinreibyouStatus.ProcessHandle = 0;
                            Globals.ShinreibyouStatus.LockPlayer = false;
                            Globals.ShinreibyouStatus.LockBomb = false;
                            Globals.ShinreibyouStatus.MaxPower = false;
                            Globals.ShinreibyouStatus.Invincible = false;
                        }
                        if (Globals.ShinreibyouStatus.IsRunStatusE && Globals.ShinreibyouStatus.IsRun && item == "th13e")
                        {
                            Globals.ShinreibyouStatus.IsRunStatusE = false;
                            Globals.ShinreibyouStatus.IsRun = false;
                            Globals.ShinreibyouStatus.BaseAddress = 0;
                            Globals.ShinreibyouStatus.ProcessHandle = 0;
                            Globals.ShinreibyouStatus.LockPlayer = false;
                            Globals.ShinreibyouStatus.LockBomb = false;
                            Globals.ShinreibyouStatus.MaxPower = false;
                            Globals.ShinreibyouStatus.Invincible = false;
                        }

                    }
                    if (tmpBool && item.Contains("th14"))
                    {
                        if (!Globals.KishinjouStatus.IsRunStatus && !Globals.KishinjouStatus.IsRun && item == "th14")
                        {
                            Globals.KishinjouStatus.IsRunStatus = true;
                            Globals.KishinjouStatus.IsRun = true;

                        }
                        if (!Globals.KishinjouStatus.IsRunStatusC && !Globals.KishinjouStatus.IsRun && item == "th14c")
                        {
                            Globals.KishinjouStatus.IsRunStatusC = true;
                            Globals.KishinjouStatus.IsRun = true;

                        }
                        if (!Globals.KishinjouStatus.IsRunStatusE && !Globals.KishinjouStatus.IsRun && item == "th14e")
                        {
                            Globals.KishinjouStatus.IsRunStatusE = true;
                            Globals.KishinjouStatus.IsRun = true;

                        }
                    }
                    else if (!tmpBool && item.Contains("th14"))
                    {

                        if (Globals.KishinjouStatus.IsRunStatus && Globals.KishinjouStatus.IsRun && item == "th14")
                        {
                            Globals.KishinjouStatus.IsRunStatus = false;
                            Globals.KishinjouStatus.IsRun = false;
                            Globals.KishinjouStatus.BaseAddress = 0;
                            Globals.KishinjouStatus.ProcessHandle = 0;
                            Globals.KishinjouStatus.LockPlayer = false;
                            Globals.KishinjouStatus.LockBomb = false;
                            Globals.KishinjouStatus.MaxPower = false;
                            Globals.KishinjouStatus.Invincible = false;
                        }
                        if (Globals.KishinjouStatus.IsRunStatusC && Globals.KishinjouStatus.IsRun && item == "th14c")
                        {
                            Globals.KishinjouStatus.IsRunStatusC = false;
                            Globals.KishinjouStatus.IsRun = false;
                            Globals.KishinjouStatus.BaseAddress = 0;
                            Globals.KishinjouStatus.ProcessHandle = 0;
                            Globals.KishinjouStatus.LockPlayer = false;
                            Globals.KishinjouStatus.LockBomb = false;
                            Globals.KishinjouStatus.MaxPower = false;
                            Globals.KishinjouStatus.Invincible = false;
                        }
                        if (Globals.KishinjouStatus.IsRunStatusE && Globals.KishinjouStatus.IsRun && item == "th14e")
                        {
                            Globals.KishinjouStatus.IsRunStatusE = false;
                            Globals.KishinjouStatus.IsRun = false;
                            Globals.KishinjouStatus.BaseAddress = 0;
                            Globals.KishinjouStatus.ProcessHandle = 0;
                            Globals.KishinjouStatus.LockPlayer = false;
                            Globals.KishinjouStatus.LockBomb = false;
                            Globals.KishinjouStatus.MaxPower = false;
                            Globals.KishinjouStatus.Invincible = false;
                        }

                    }
                    if (tmpBool && item.Contains("th15"))
                    {
                        if (!Globals.KanjudenStatus.IsRunStatus && !Globals.KanjudenStatus.IsRun && item == "th15")
                        {
                            Globals.KanjudenStatus.IsRunStatus = true;
                            Globals.KanjudenStatus.IsRun = true;

                        }
                        if (!Globals.KanjudenStatus.IsRunStatusC && !Globals.KanjudenStatus.IsRun && item == "th15c")
                        {
                            Globals.KanjudenStatus.IsRunStatusC = true;
                            Globals.KanjudenStatus.IsRun = true;

                        }
                        if (!Globals.KanjudenStatus.IsRunStatusE && !Globals.KanjudenStatus.IsRun && item == "th15e")
                        {
                            Globals.KanjudenStatus.IsRunStatusE = true;
                            Globals.KanjudenStatus.IsRun = true;

                        }
                    }
                    else if (!tmpBool && item.Contains("th15"))
                    {

                        if (Globals.KanjudenStatus.IsRunStatus && Globals.KanjudenStatus.IsRun && item == "th15")
                        {
                            Globals.KanjudenStatus.IsRunStatus = false;
                            Globals.KanjudenStatus.IsRun = false;
                            Globals.KanjudenStatus.BaseAddress = 0;
                            Globals.KanjudenStatus.ProcessHandle = 0;
                            Globals.KanjudenStatus.LockPlayer = false;
                            Globals.KanjudenStatus.LockBomb = false;
                            Globals.KanjudenStatus.MaxPower = false;
                            Globals.KanjudenStatus.Invincible = false;
                        }
                        if (Globals.KanjudenStatus.IsRunStatusC && Globals.KanjudenStatus.IsRun && item == "th15c")
                        {
                            Globals.KanjudenStatus.IsRunStatusC = false;
                            Globals.KanjudenStatus.IsRun = false;
                            Globals.KanjudenStatus.BaseAddress = 0;
                            Globals.KanjudenStatus.ProcessHandle = 0;
                            Globals.KanjudenStatus.LockPlayer = false;
                            Globals.KanjudenStatus.LockBomb = false;
                            Globals.KanjudenStatus.MaxPower = false;
                            Globals.KanjudenStatus.Invincible = false;

                        }
                        if (Globals.KanjudenStatus.IsRunStatusE && Globals.KanjudenStatus.IsRun && item == "th15e")
                        {
                            Globals.KanjudenStatus.IsRunStatusE = false;
                            Globals.KanjudenStatus.IsRun = false;
                            Globals.KanjudenStatus.BaseAddress = 0;
                            Globals.KanjudenStatus.ProcessHandle = 0;
                            Globals.KanjudenStatus.LockPlayer = false;
                            Globals.KanjudenStatus.LockBomb = false;
                            Globals.KanjudenStatus.MaxPower = false;
                            Globals.KanjudenStatus.Invincible = false;

                        }

                    }
                    if (tmpBool && item.Contains("th16"))
                    {
                        if (!Globals.TenkuushouStatus.IsRunStatus && !Globals.TenkuushouStatus.IsRun && item == "th16")
                        {
                            Globals.TenkuushouStatus.IsRunStatus = true;
                            Globals.TenkuushouStatus.IsRun = true;

                        }
                        if (!Globals.TenkuushouStatus.IsRunStatusC && !Globals.TenkuushouStatus.IsRun && item == "th16c")
                        {
                            Globals.TenkuushouStatus.IsRunStatusC = true;
                            Globals.TenkuushouStatus.IsRun = true;

                        }
                        if (!Globals.TenkuushouStatus.IsRunStatusE && !Globals.TenkuushouStatus.IsRun && item == "th16e")
                        {
                            Globals.TenkuushouStatus.IsRunStatusE = true;
                            Globals.TenkuushouStatus.IsRun = true;

                        }
                    }
                    else if (!tmpBool && item.Contains("th16"))
                    {

                        if (Globals.TenkuushouStatus.IsRunStatus && Globals.TenkuushouStatus.IsRun && item == "th16")
                        {
                            Globals.TenkuushouStatus.IsRunStatus = false;
                            Globals.TenkuushouStatus.IsRun = false;
                            Globals.TenkuushouStatus.BaseAddress = 0;
                            Globals.TenkuushouStatus.ProcessHandle = 0;
                            Globals.TenkuushouStatus.LockPlayer = false;
                            Globals.TenkuushouStatus.LockBomb = false;
                            Globals.TenkuushouStatus.MaxPower = false;
                            Globals.TenkuushouStatus.Invincible = false;
                        }
                        if (Globals.TenkuushouStatus.IsRunStatusC && Globals.TenkuushouStatus.IsRun && item == "th16c")
                        {
                            Globals.TenkuushouStatus.IsRunStatusC = false;
                            Globals.TenkuushouStatus.IsRun = false;
                            Globals.TenkuushouStatus.BaseAddress = 0;
                            Globals.TenkuushouStatus.ProcessHandle = 0;
                            Globals.TenkuushouStatus.LockPlayer = false;
                            Globals.TenkuushouStatus.LockBomb = false;
                            Globals.TenkuushouStatus.MaxPower = false;
                            Globals.TenkuushouStatus.Invincible = false;
                        }
                        if (Globals.TenkuushouStatus.IsRunStatusE && Globals.TenkuushouStatus.IsRun && item == "th16e")
                        {
                            Globals.TenkuushouStatus.IsRunStatusE = false;
                            Globals.TenkuushouStatus.IsRun = false;
                            Globals.TenkuushouStatus.BaseAddress = 0;
                            Globals.TenkuushouStatus.ProcessHandle = 0;
                            Globals.TenkuushouStatus.LockPlayer = false;
                            Globals.TenkuushouStatus.LockBomb = false;
                            Globals.TenkuushouStatus.MaxPower = false;
                            Globals.TenkuushouStatus.Invincible = false;
                        }

                    }

                    if (tmpBool && item.Contains("th17"))
                    {
                        if (!Globals.KikeijuuStatus.IsRunStatus && !Globals.KikeijuuStatus.IsRun && item == "th17")
                        {
                            Globals.KikeijuuStatus.IsRunStatus = true;
                            Globals.KikeijuuStatus.IsRun = true;

                        }
                        if (!Globals.KikeijuuStatus.IsRunStatusC && !Globals.KikeijuuStatus.IsRun && item == "th17c")
                        {
                            Globals.KikeijuuStatus.IsRunStatusC = true;
                            Globals.KikeijuuStatus.IsRun = true;

                        }
                        if (!Globals.KikeijuuStatus.IsRunStatusE && !Globals.KikeijuuStatus.IsRun && item == "th17e")
                        {
                            Globals.KikeijuuStatus.IsRunStatusE = true;
                            Globals.KikeijuuStatus.IsRun = true;

                        }
                    }
                    else if (!tmpBool && item.Contains("th17"))
                    {

                        if (Globals.KikeijuuStatus.IsRunStatus && Globals.KikeijuuStatus.IsRun && item == "th17")
                        {
                            Globals.KikeijuuStatus.IsRunStatus = false;
                            Globals.KikeijuuStatus.IsRun = false;
                            Globals.KikeijuuStatus.BaseAddress = 0;
                            Globals.KikeijuuStatus.ProcessHandle = 0;
                            Globals.KikeijuuStatus.LockPlayer = false;
                            Globals.KikeijuuStatus.LockBomb = false;
                            Globals.KikeijuuStatus.MaxPower = false;
                            Globals.KikeijuuStatus.Invincible = false;
                        }
                        if (Globals.KikeijuuStatus.IsRunStatusC && Globals.KikeijuuStatus.IsRun && item == "th17c")
                        {
                            Globals.KikeijuuStatus.IsRunStatusC = false;
                            Globals.KikeijuuStatus.IsRun = false;
                            Globals.KikeijuuStatus.BaseAddress = 0;
                            Globals.KikeijuuStatus.ProcessHandle = 0;
                            Globals.KikeijuuStatus.LockPlayer = false;
                            Globals.KikeijuuStatus.LockBomb = false;
                            Globals.KikeijuuStatus.MaxPower = false;
                            Globals.KikeijuuStatus.Invincible = false;
                        }
                        if (Globals.KikeijuuStatus.IsRunStatusE && Globals.KikeijuuStatus.IsRun && item == "th17e")
                        {
                            Globals.KikeijuuStatus.IsRunStatusE = false;
                            Globals.KikeijuuStatus.IsRun = false;
                            Globals.KikeijuuStatus.BaseAddress = 0;
                            Globals.KikeijuuStatus.ProcessHandle = 0;
                            Globals.KikeijuuStatus.LockPlayer = false;
                            Globals.KikeijuuStatus.LockBomb = false;
                            Globals.KikeijuuStatus.MaxPower = false;
                            Globals.KikeijuuStatus.Invincible = false;
                        }

                    }
                    if (tmpBool && item.Contains("th18"))
                    {
                        if (!Globals.KouryuudouStatus.IsRunStatus && !Globals.KouryuudouStatus.IsRun && item == "th18")
                        {
                            Globals.KouryuudouStatus.IsRunStatus = true;
                            Globals.KouryuudouStatus.IsRun = true;

                        }
                        if (!Globals.KouryuudouStatus.IsRunStatusC && !Globals.KouryuudouStatus.IsRun && item == "th18c")
                        {
                            Globals.KouryuudouStatus.IsRunStatusC = true;
                            Globals.KouryuudouStatus.IsRun = true;

                        }
                        if (!Globals.KouryuudouStatus.IsRunStatusE && !Globals.KouryuudouStatus.IsRun && item == "th18e")
                        {
                            Globals.KouryuudouStatus.IsRunStatusE = true;
                            Globals.KouryuudouStatus.IsRun = true;

                        }
                    }
                    else if (!tmpBool && item.Contains("th18"))
                    {

                        if (Globals.KouryuudouStatus.IsRunStatus && Globals.KouryuudouStatus.IsRun && item == "th18")
                        {
                            Globals.KouryuudouStatus.IsRunStatus = false;
                            Globals.KouryuudouStatus.IsRun = false;
                            Globals.KouryuudouStatus.BaseAddress = 0;
                            Globals.KouryuudouStatus.ProcessHandle = 0;
                            Globals.KouryuudouStatus.LockPlayer = false;
                            Globals.KouryuudouStatus.LockBomb = false;
                            Globals.KouryuudouStatus.MaxPower = false;
                            Globals.KouryuudouStatus.Invincible = false;
                        }
                        if (Globals.KouryuudouStatus.IsRunStatusC && Globals.KouryuudouStatus.IsRun && item == "th18c")
                        {
                            Globals.KouryuudouStatus.IsRunStatusC = false;
                            Globals.KouryuudouStatus.IsRun = false;
                            Globals.KouryuudouStatus.BaseAddress = 0;
                            Globals.KouryuudouStatus.ProcessHandle = 0;
                            Globals.KouryuudouStatus.LockPlayer = false;
                            Globals.KouryuudouStatus.LockBomb = false;
                            Globals.KouryuudouStatus.MaxPower = false;
                            Globals.KouryuudouStatus.Invincible = false;
                        }
                        if (Globals.KouryuudouStatus.IsRunStatusE && Globals.KouryuudouStatus.IsRun && item == "th18e")
                        {
                            Globals.KouryuudouStatus.IsRunStatusE = false;
                            Globals.KouryuudouStatus.IsRun = false;
                            Globals.KouryuudouStatus.BaseAddress = 0;
                            Globals.KouryuudouStatus.ProcessHandle = 0;
                            Globals.KouryuudouStatus.LockPlayer = false;
                            Globals.KouryuudouStatus.LockBomb = false;
                            Globals.KouryuudouStatus.MaxPower = false;
                            Globals.KouryuudouStatus.Invincible = false;
                        }

                    }

                    if (tmpBool && item.Contains("th19"))
                    {
                        if (!Globals.JuuouenStatus.IsRunStatus && !Globals.JuuouenStatus.IsRun && item == "th19")
                        {
                            Globals.JuuouenStatus.IsRunStatus = true;
                            Globals.JuuouenStatus.IsRun = true;

                        }
                        if (!Globals.JuuouenStatus.IsRunStatusC && !Globals.JuuouenStatus.IsRun && item == "th19c")
                        {
                            Globals.JuuouenStatus.IsRunStatusC = true;
                            Globals.JuuouenStatus.IsRun = true;

                        }
                        if (!Globals.JuuouenStatus.IsRunStatusE && !Globals.JuuouenStatus.IsRun && item == "th19e")
                        {
                            Globals.JuuouenStatus.IsRunStatusE = true;
                            Globals.JuuouenStatus.IsRun = true;

                        }
                    }
                    else if (!tmpBool && item.Contains("th19"))
                    {

                        if (Globals.JuuouenStatus.IsRunStatus && Globals.JuuouenStatus.IsRun && item == "th19")
                        {
                            Globals.JuuouenStatus.IsRunStatus = false;
                            Globals.JuuouenStatus.IsRun = false;
                            Globals.JuuouenStatus.BaseAddress = 0;
                            Globals.JuuouenStatus.ProcessHandle = 0;
                            TouhouHackProfiles.JuuouenV100a.ResetAll();
                            TouhouHackProfiles.JuuouenV110c.ResetAll();
                        }
                        if (Globals.JuuouenStatus.IsRunStatusC && Globals.JuuouenStatus.IsRun && item == "th19c")
                        {
                            Globals.JuuouenStatus.IsRunStatusC = false;
                            Globals.JuuouenStatus.IsRun = false;
                            Globals.JuuouenStatus.BaseAddress = 0;
                            Globals.JuuouenStatus.ProcessHandle = 0;
                            TouhouHackProfiles.JuuouenV100a.ResetAll();
                            TouhouHackProfiles.JuuouenV110c.ResetAll();
                        }

                        if (Globals.JuuouenStatus.IsRunStatusE && Globals.JuuouenStatus.IsRun && item == "th19e")
                        {
                            Globals.JuuouenStatus.IsRunStatusE = false;
                            Globals.JuuouenStatus.IsRun = false;
                            Globals.JuuouenStatus.BaseAddress = 0;
                            Globals.JuuouenStatus.ProcessHandle = 0;
                            TouhouHackProfiles.JuuouenV100a.ResetAll();
                            TouhouHackProfiles.JuuouenV110c.ResetAll();
                        }

                    }
                    if (tmpBool && item.Contains("th20"))
                    {
                        if (!Globals.KinjoukyouStatus.IsRunStatus && !Globals.KinjoukyouStatus.IsRun && item == "th20")
                        {
                            Globals.KinjoukyouStatus.IsRunStatus = true;
                            Globals.KinjoukyouStatus.IsRun = true;

                        }
                        if (!Globals.KinjoukyouStatus.IsRunStatusC && !Globals.KinjoukyouStatus.IsRun && item == "th20c")
                        {
                            Globals.KinjoukyouStatus.IsRunStatusC = true;
                            Globals.KinjoukyouStatus.IsRun = true;

                        }
                        if (!Globals.KinjoukyouStatus.IsRunStatusE && !Globals.KinjoukyouStatus.IsRun && item == "th20e")
                        {
                            Globals.KinjoukyouStatus.IsRunStatusE = true;
                            Globals.KinjoukyouStatus.IsRun = true;

                        }
                    }
                    else if (!tmpBool && item.Contains("th20"))
                    {

                        if (Globals.KinjoukyouStatus.IsRunStatus && Globals.KinjoukyouStatus.IsRun && item == "th20")
                        {
                            Globals.KinjoukyouStatus.IsRunStatus = false;
                            Globals.KinjoukyouStatus.IsRun = false;
                            Globals.KinjoukyouStatus.BaseAddress = 0;
                            Globals.KinjoukyouStatus.ProcessHandle = 0;
                            Globals.KinjoukyouStatus.LockPlayer = false;
                            Globals.KinjoukyouStatus.LockBomb = false;
                            Globals.KinjoukyouStatus.MaxPower = false;
                            Globals.KinjoukyouStatus.Invincible = false;
                        }
                        if (Globals.KinjoukyouStatus.IsRunStatusC && Globals.KinjoukyouStatus.IsRun && item == "th20c")
                        {
                            Globals.KinjoukyouStatus.IsRunStatusC = false;
                            Globals.KinjoukyouStatus.IsRun = false;
                            Globals.KinjoukyouStatus.BaseAddress = 0;
                            Globals.KinjoukyouStatus.ProcessHandle = 0;
                            Globals.KinjoukyouStatus.LockPlayer = false;
                            Globals.KinjoukyouStatus.LockBomb = false;
                            Globals.KinjoukyouStatus.MaxPower = false;
                            Globals.KinjoukyouStatus.Invincible = false;
                        }

                        if (Globals.KinjoukyouStatus.IsRunStatusE && Globals.KinjoukyouStatus.IsRun && item == "th20e")
                        {
                            Globals.KinjoukyouStatus.IsRunStatusE = false;
                            Globals.KinjoukyouStatus.IsRun = false;
                            Globals.KinjoukyouStatus.BaseAddress = 0;
                            Globals.KinjoukyouStatus.ProcessHandle = 0;
                            Globals.KinjoukyouStatus.LockPlayer = false;
                            Globals.KinjoukyouStatus.LockBomb = false;
                            Globals.KinjoukyouStatus.MaxPower = false;
                            Globals.KinjoukyouStatus.Invincible = false;
                        }
                    }

                    // ===================== 小数点作（骨架，待逆向） =====================
                    // ---- 07.5东方萃梦想 (th075) ----
                    if (tmpBool && item.Contains("th075"))
                    {
                        if (!Globals.SuimusouStatus.IsRunStatus && !Globals.SuimusouStatus.IsRun && item == "th075")
                        {
                            Globals.SuimusouStatus.IsRunStatus = true;
                            Globals.SuimusouStatus.IsRun = true;

                        }

                    }
                    else if (!tmpBool && item.Contains("th075"))
                    {

                        if (Globals.SuimusouStatus.IsRunStatus && Globals.SuimusouStatus.IsRun && item == "th075")
                        {
                            Globals.SuimusouStatus.IsRunStatus = false;
                            Globals.SuimusouStatus.IsRun = false;
                            Globals.SuimusouStatus.BaseAddress = 0;
                            Globals.SuimusouStatus.ProcessHandle = 0;
                            Globals.SuimusouStatus.LockPlayer = false;
                            Globals.SuimusouStatus.LockBomb = false;
                            Globals.SuimusouStatus.MaxPower = false;
                            Globals.SuimusouStatus.Invincible = false;
                        }

                    }

                    // ---- 09.5东方文花帖 (th095) ----
                    if (tmpBool && item.Contains("th095"))
                    {
                        if (!Globals.BunkachouStatus.IsRunStatus && !Globals.BunkachouStatus.IsRun && item == "th095")
                        {
                            Globals.BunkachouStatus.IsRunStatus = true;
                            Globals.BunkachouStatus.IsRun = true;

                        }

                    }
                    else if (!tmpBool && item.Contains("th095"))
                    {

                        if (Globals.BunkachouStatus.IsRunStatus && Globals.BunkachouStatus.IsRun && item == "th095")
                        {
                            Globals.BunkachouStatus.IsRunStatus = false;
                            Globals.BunkachouStatus.IsRun = false;
                            Globals.BunkachouStatus.BaseAddress = 0;
                            Globals.BunkachouStatus.ProcessHandle = 0;
                            TouhouHackProfiles.Bunkachou.ResetAll();
                        }

                    }

                    // ---- 10.5东方绯想天 (th105) ----
                    if (tmpBool && item.Contains("th105"))
                    {
                        if (!Globals.HisoutenStatus.IsRunStatus && !Globals.HisoutenStatus.IsRun && item == "th105")
                        {
                            Globals.HisoutenStatus.IsRunStatus = true;
                            Globals.HisoutenStatus.IsRun = true;

                        }

                    }
                    else if (!tmpBool && item.Contains("th105"))
                    {

                        if (Globals.HisoutenStatus.IsRunStatus && Globals.HisoutenStatus.IsRun && item == "th105")
                        {
                            Globals.HisoutenStatus.IsRunStatus = false;
                            Globals.HisoutenStatus.IsRun = false;
                            Globals.HisoutenStatus.BaseAddress = 0;
                            Globals.HisoutenStatus.ProcessHandle = 0;
                            Globals.HisoutenStatus.LockPlayer = false;
                            Globals.HisoutenStatus.LockBomb = false;
                            Globals.HisoutenStatus.MaxPower = false;
                            Globals.HisoutenStatus.Invincible = false;
                        }

                    }

                    // ---- 12.3东方非想天则 (th123) ----
                    if (tmpBool && item.Contains("th123"))
                    {
                        if (!Globals.HisoutensokuStatus.IsRunStatus && !Globals.HisoutensokuStatus.IsRun && item == "th123")
                        {
                            Globals.HisoutensokuStatus.IsRunStatus = true;
                            Globals.HisoutensokuStatus.IsRun = true;

                        }

                    }
                    else if (!tmpBool && item.Contains("th123"))
                    {

                        if (Globals.HisoutensokuStatus.IsRunStatus && Globals.HisoutensokuStatus.IsRun && item == "th123")
                        {
                            Globals.HisoutensokuStatus.IsRunStatus = false;
                            Globals.HisoutensokuStatus.IsRun = false;
                            Globals.HisoutensokuStatus.BaseAddress = 0;
                            Globals.HisoutensokuStatus.ProcessHandle = 0;
                            Globals.HisoutensokuStatus.LockPlayer = false;
                            Globals.HisoutensokuStatus.LockBomb = false;
                            Globals.HisoutensokuStatus.MaxPower = false;
                            Globals.HisoutensokuStatus.Invincible = false;
                        }

                    }

                    // ---- 12.5东方文花帖DS (th125) ----
                    if (tmpBool && item.Contains("th125"))
                    {
                        if (!Globals.DoubleSpoilerStatus.IsRunStatus && !Globals.DoubleSpoilerStatus.IsRun && item == "th125")
                        {
                            Globals.DoubleSpoilerStatus.IsRunStatus = true;
                            Globals.DoubleSpoilerStatus.IsRun = true;

                        }

                    }
                    else if (!tmpBool && item.Contains("th125"))
                    {

                        if (Globals.DoubleSpoilerStatus.IsRunStatus && Globals.DoubleSpoilerStatus.IsRun && item == "th125")
                        {
                            Globals.DoubleSpoilerStatus.IsRunStatus = false;
                            Globals.DoubleSpoilerStatus.IsRun = false;
                            Globals.DoubleSpoilerStatus.BaseAddress = 0;
                            Globals.DoubleSpoilerStatus.ProcessHandle = 0;
                            TouhouHackProfiles.DoubleSpoiler.ResetAll();
                        }

                    }

                    // ---- 12.8妖精大战争 (th128) ----
                    if (tmpBool && item.Contains("th128"))
                    {
                        if (!Globals.YouseiDaisensouStatus.IsRunStatus && !Globals.YouseiDaisensouStatus.IsRun && item == "th128")
                        {
                            Globals.YouseiDaisensouStatus.IsRunStatus = true;
                            Globals.YouseiDaisensouStatus.IsRun = true;

                        }

                    }
                    else if (!tmpBool && item.Contains("th128"))
                    {

                        if (Globals.YouseiDaisensouStatus.IsRunStatus && Globals.YouseiDaisensouStatus.IsRun && item == "th128")
                        {
                            Globals.YouseiDaisensouStatus.IsRunStatus = false;
                            Globals.YouseiDaisensouStatus.IsRun = false;
                            Globals.YouseiDaisensouStatus.BaseAddress = 0;
                            Globals.YouseiDaisensouStatus.ProcessHandle = 0;
                            TouhouHackProfiles.YouseiDaisensou.ResetAll();
                        }

                    }

                    // ---- 13.5东方心绮楼 (th135) ----
                    if (tmpBool && item.Contains("th135"))
                    {
                        if (!Globals.ShinkirouStatus.IsRunStatus && !Globals.ShinkirouStatus.IsRun && item == "th135")
                        {
                            Globals.ShinkirouStatus.IsRunStatus = true;
                            Globals.ShinkirouStatus.IsRun = true;

                        }

                    }
                    else if (!tmpBool && item.Contains("th135"))
                    {

                        if (Globals.ShinkirouStatus.IsRunStatus && Globals.ShinkirouStatus.IsRun && item == "th135")
                        {
                            Globals.ShinkirouStatus.IsRunStatus = false;
                            Globals.ShinkirouStatus.IsRun = false;
                            Globals.ShinkirouStatus.BaseAddress = 0;
                            Globals.ShinkirouStatus.ProcessHandle = 0;
                            Globals.ShinkirouStatus.LockPlayer = false;
                            Globals.ShinkirouStatus.LockBomb = false;
                            Globals.ShinkirouStatus.MaxPower = false;
                            Globals.ShinkirouStatus.Invincible = false;
                        }

                    }

                    // ---- 14.3弹幕天邪鬼 (th143) ----
                    if (tmpBool && item.Contains("th143"))
                    {
                        if (!Globals.DanmakuAmanojakuStatus.IsRunStatus && !Globals.DanmakuAmanojakuStatus.IsRun && item == "th143")
                        {
                            Globals.DanmakuAmanojakuStatus.IsRunStatus = true;
                            Globals.DanmakuAmanojakuStatus.IsRun = true;

                        }

                    }
                    else if (!tmpBool && item.Contains("th143"))
                    {

                        if (Globals.DanmakuAmanojakuStatus.IsRunStatus && Globals.DanmakuAmanojakuStatus.IsRun && item == "th143")
                        {
                            Globals.DanmakuAmanojakuStatus.IsRunStatus = false;
                            Globals.DanmakuAmanojakuStatus.IsRun = false;
                            Globals.DanmakuAmanojakuStatus.BaseAddress = 0;
                            Globals.DanmakuAmanojakuStatus.ProcessHandle = 0;
                            TouhouHackProfiles.DanmakuAmanojaku.ResetAll();
                        }

                    }

                    // ---- 14.5东方深秘录 (th145) ----
                    if (tmpBool && item.Contains("th145"))
                    {
                        if (!Globals.ShinpirokuStatus.IsRunStatus && !Globals.ShinpirokuStatus.IsRun && item == "th145")
                        {
                            Globals.ShinpirokuStatus.IsRunStatus = true;
                            Globals.ShinpirokuStatus.IsRun = true;

                        }

                    }
                    else if (!tmpBool && item.Contains("th145"))
                    {

                        if (Globals.ShinpirokuStatus.IsRunStatus && Globals.ShinpirokuStatus.IsRun && item == "th145")
                        {
                            Globals.ShinpirokuStatus.IsRunStatus = false;
                            Globals.ShinpirokuStatus.IsRun = false;
                            Globals.ShinpirokuStatus.BaseAddress = 0;
                            Globals.ShinpirokuStatus.ProcessHandle = 0;
                            Globals.ShinpirokuStatus.LockPlayer = false;
                            Globals.ShinpirokuStatus.LockBomb = false;
                            Globals.ShinpirokuStatus.MaxPower = false;
                            Globals.ShinpirokuStatus.Invincible = false;
                        }

                    }

                    // ---- 15.5东方凭依华 (th155) ----
                    if (tmpBool && item.Contains("th155"))
                    {
                        if (!Globals.HyouikaStatus.IsRunStatus && !Globals.HyouikaStatus.IsRun && item == "th155")
                        {
                            Globals.HyouikaStatus.IsRunStatus = true;
                            Globals.HyouikaStatus.IsRun = true;

                        }

                    }
                    else if (!tmpBool && item.Contains("th155"))
                    {

                        if (Globals.HyouikaStatus.IsRunStatus && Globals.HyouikaStatus.IsRun && item == "th155")
                        {
                            Globals.HyouikaStatus.IsRunStatus = false;
                            Globals.HyouikaStatus.IsRun = false;
                            Globals.HyouikaStatus.BaseAddress = 0;
                            Globals.HyouikaStatus.ProcessHandle = 0;
                            Globals.HyouikaStatus.LockPlayer = false;
                            Globals.HyouikaStatus.LockBomb = false;
                            Globals.HyouikaStatus.MaxPower = false;
                            Globals.HyouikaStatus.Invincible = false;
                        }

                    }

                    // ---- 16.5秘封噩梦日记 (th165) ----
                    if (tmpBool && item.Contains("th165"))
                    {
                        if (!Globals.NightmareDiaryStatus.IsRunStatus && !Globals.NightmareDiaryStatus.IsRun && item == "th165")
                        {
                            Globals.NightmareDiaryStatus.IsRunStatus = true;
                            Globals.NightmareDiaryStatus.IsRun = true;

                        }

                    }
                    else if (!tmpBool && item.Contains("th165"))
                    {

                        if (Globals.NightmareDiaryStatus.IsRunStatus && Globals.NightmareDiaryStatus.IsRun && item == "th165")
                        {
                            Globals.NightmareDiaryStatus.IsRunStatus = false;
                            Globals.NightmareDiaryStatus.IsRun = false;
                            Globals.NightmareDiaryStatus.BaseAddress = 0;
                            Globals.NightmareDiaryStatus.ProcessHandle = 0;
                            TouhouHackProfiles.NightmareDiary.ResetAll();
                        }

                    }

                    // ---- 17.5东方刚欲异闻 (th175) ----
                    if (tmpBool && item.Contains("th175"))
                    {
                        if (!Globals.GouyokuIbunStatus.IsRunStatus && !Globals.GouyokuIbunStatus.IsRun && item == "th175")
                        {
                            Globals.GouyokuIbunStatus.IsRunStatus = true;
                            Globals.GouyokuIbunStatus.IsRun = true;

                        }

                    }
                    else if (!tmpBool && item.Contains("th175"))
                    {

                        if (Globals.GouyokuIbunStatus.IsRunStatus && Globals.GouyokuIbunStatus.IsRun && item == "th175")
                        {
                            Globals.GouyokuIbunStatus.IsRunStatus = false;
                            Globals.GouyokuIbunStatus.IsRun = false;
                            Globals.GouyokuIbunStatus.BaseAddress = 0;
                            Globals.GouyokuIbunStatus.ProcessHandle = 0;
                            Globals.GouyokuIbunStatus.LockPlayer = false;
                            Globals.GouyokuIbunStatus.LockBomb = false;
                            Globals.GouyokuIbunStatus.MaxPower = false;
                            Globals.GouyokuIbunStatus.Invincible = false;
                        }

                    }

                    // ---- 18.5弹幕狂们的黑市 (th185) ----
                    if (tmpBool && item.Contains("th185"))
                    {
                        if (!Globals.BlackMarketStatus.IsRunStatus && !Globals.BlackMarketStatus.IsRun && item == "th185")
                        {
                            Globals.BlackMarketStatus.IsRunStatus = true;
                            Globals.BlackMarketStatus.IsRun = true;

                        }

                    }
                    else if (!tmpBool && item.Contains("th185"))
                    {

                        if (Globals.BlackMarketStatus.IsRunStatus && Globals.BlackMarketStatus.IsRun && item == "th185")
                        {
                            Globals.BlackMarketStatus.IsRunStatus = false;
                            Globals.BlackMarketStatus.IsRun = false;
                            Globals.BlackMarketStatus.BaseAddress = 0;
                            Globals.BlackMarketStatus.ProcessHandle = 0;
                            TouhouHackProfiles.BlackMarket.ResetAll();
                        }

                    }
                }


                Thread.Sleep(5000);
            }
        }
    }
}
