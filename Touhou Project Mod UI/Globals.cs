using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Touhou_Project_Mod_UI.Views;

namespace Touhou_Project_Mod_UI;

public static class Globals
{

    public static uint SETVALUE = 0x00;
    public static uint PLAYEROB = 0x01;
    public static uint BOMBOB = 0x02;
    public static uint POWEROB = 0x03;
    public static uint INVINCIBLEOB = 0x04;

    public static string[] TouhouVersionList = ["th06", "th06c", "th06e", "東方紅魔郷", "th07", "th07c", "th08", "th08c", "th09", "th09c", "th10", "th10c", "th11", "th11c", "th12", "th12c", "th13", "th13c", "th14", "th14c", "th15", "th15c", "th16", "th16c", "th17", "th17c", "th18", "th18c"];

    public static Models.Status KoumakyouStatus = new() { PlayersOriginalBytes = new byte[2], BombOriginalBytes = new byte[3], PowerOriginalBytes2 = new byte[3], PowerOriginalBytes = new byte[9], InvincibleOriginalBytes = new byte[3] };
    public static Models.Status YouyoumuStatus = new() { };
    public static Models.Status EiyashouStatus = new();
    public static Models.Status KaeizukaStatus = new();
    public static Models.Status FuujinrokuStatus = new() { PlayersOriginalBytes = new byte[1], BombOriginalBytes = new byte[8], PowerOriginalBytes = new byte[8], InvincibleOriginalBytes = new byte[10] };
    public static Models.Status ChireidenStatus = new() { PlayersOriginalBytes = new byte[6], BombOriginalBytes = new byte[6], PowerOriginalBytes = new byte[5], InvincibleOriginalBytes = new byte[10] };
    public static Models.Status SeirensenStatus = new() { PlayersOriginalBytes = new byte[6], BombOriginalBytes = new byte[3], PowerOriginalBytes = new byte[5], InvincibleOriginalBytes = new byte[10] };
    public static Models.Status ShinreibyouStatus = new() { PlayersOriginalBytes = new byte[6], BombOriginalBytes = new byte[2], PowerOriginalBytes = new byte[5], InvincibleOriginalBytes = new byte[10] };
    public static Models.Status KishinjouStatus = new() { PlayersOriginalBytes = new byte[5], BombOriginalBytes = new byte[5], PowerOriginalBytes = new byte[6], InvincibleOriginalBytes = new byte[10] };
    public static Models.Status KanjudenStatus = new() { PlayersOriginalBytes = new byte[5], BombOriginalBytes = new byte[5], PowerOriginalBytes = new byte[6], InvincibleOriginalBytes = new byte[10] };
    public static Models.Status TenkuushouStatus = new() { PlayersOriginalBytes = new byte[5], BombOriginalBytes = new byte[5], PowerOriginalBytes = new byte[6], InvincibleOriginalBytes = new byte[10] };
    public static Models.Status KikeijuuStatus = new() { PlayersOriginalBytes = new byte[6], BombOriginalBytes = new byte[6], PowerOriginalBytes = new byte[6], InvincibleOriginalBytes = new byte[10] };
    public static Models.Status KouryuudouStatus = new();
    public static Models.Status JuuouenStatus = new();

}
