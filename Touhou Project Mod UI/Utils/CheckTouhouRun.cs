using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

                    }
                    else if (!tmpBool && item.Contains("th09"))
                    {

                        if (Globals.KaeizukaStatus.IsRunStatus && Globals.KaeizukaStatus.IsRun && item == "th09")
                        {
                            Globals.KaeizukaStatus.IsRunStatus = false;
                            Globals.KaeizukaStatus.IsRun = false;
                            Globals.KaeizukaStatus.BaseAddress = 0;
                            Globals.KaeizukaStatus.ProcessHandle = 0;
                            Globals.KaeizukaStatus.LockPlayer = false;
                            Globals.KaeizukaStatus.LockBomb = false;
                            Globals.KaeizukaStatus.MaxPower = false;
                            Globals.KaeizukaStatus.Invincible = false;
                        }
                        if (Globals.KaeizukaStatus.IsRunStatusC && Globals.KaeizukaStatus.IsRun && item == "th09c")
                        {
                            Globals.KaeizukaStatus.IsRunStatusC = false;
                            Globals.KaeizukaStatus.IsRun = false;
                            Globals.KaeizukaStatus.BaseAddress = 0;
                            Globals.KaeizukaStatus.ProcessHandle = 0;
                            Globals.KaeizukaStatus.LockPlayer = false;
                            Globals.KaeizukaStatus.LockBomb = false;
                            Globals.KaeizukaStatus.MaxPower = false;
                            Globals.KaeizukaStatus.Invincible = false;
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
                    }
                    else if (!tmpBool && item.Contains("th19"))
                    {

                        if (Globals.JuuouenStatus.IsRunStatus && Globals.JuuouenStatus.IsRun && item == "th19")
                        {
                            Globals.JuuouenStatus.IsRunStatus = false;
                            Globals.JuuouenStatus.IsRun = false;
                            Globals.JuuouenStatus.BaseAddress = 0;
                            Globals.JuuouenStatus.ProcessHandle = 0;
                            Globals.JuuouenStatus.LockPlayer = false;
                            Globals.JuuouenStatus.LockBomb = false;
                            Globals.JuuouenStatus.MaxPower = false;
                            Globals.JuuouenStatus.Invincible = false;
                        }
                        if (Globals.JuuouenStatus.IsRunStatusC && Globals.JuuouenStatus.IsRun && item == "th19c")
                        {
                            Globals.JuuouenStatus.IsRunStatusC = false;
                            Globals.JuuouenStatus.IsRun = false;
                            Globals.JuuouenStatus.BaseAddress = 0;
                            Globals.JuuouenStatus.ProcessHandle = 0;
                            Globals.JuuouenStatus.LockPlayer = false;
                            Globals.JuuouenStatus.LockBomb = false;
                            Globals.JuuouenStatus.MaxPower = false;
                            Globals.JuuouenStatus.Invincible = false;
                        }


                    }
                }


                Thread.Sleep(5000);
            }
        }
    }
}
