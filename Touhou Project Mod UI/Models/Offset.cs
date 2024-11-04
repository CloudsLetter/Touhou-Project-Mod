using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touhou_Project_Mod_UI.Models
{
    public static class Offset
    {
        // 东方红魔乡1 bit
        public static IntPtr  Koumakyou_Power_Offset = 0x0029D4B0;

        // sub al,01 -> nop 2bit
        public static IntPtr  Koumakyou_Sub_Plyaer_Offset = 0x0028DEB;

        // sub dl,01 -> nop 3bit 
        public static IntPtr  Koumakyou_Sub_Bomb_Offset = 0x00289E1;

        // mov word ptr [0069D4B0],0000 -> nop 9bit
        public static IntPtr  Koumakyou_Sub_Power_2_Zero_Offset = 0x0028B67;

        // sub ecx,10 -> nop 3 bit
        public static IntPtr Koumakyou_Sub_Power_Offset = 0x0028B7B;

        // cmp edx,03 -> cmp edx,02 relpace no bit change value != 3
        public static IntPtr  Koumakyou_Sub_Invincible_Offset = 0x0028FDF;

        //movsx edx,byte ptr [ecx+000009E0] -> nop 7 bit
        public static IntPtr  Koumakyou_No_Attac_Offset = 0x0028FC3;

        // mov [ecx+000075C8],00000001 -> nop 10 bit
        public static IntPtr  Koumakyou_Make_Bomb_2_Hell = 0x00289FB;

        // wait to find offset with dev
        public static IntPtr  Koumakyou_Lock_Time = 0x00;

        public static IntPtr  Seirensen_Humans_Offset = 0x00B0C98;

        //东方妖妖梦
        // 
        public static IntPtr Youyoumu_Power_Offset = 0;

        // 
        public static IntPtr Youyoumu_Sub_Plyaer_Offset = 0;

        // 
        public static IntPtr Youyoumu_Sub_Bomb_Offset = 0;

        //
        public static IntPtr Youyoumu_Sub_Power_Offset = 0;


        // 
        public static IntPtr Youyoumu_Sub_Invincible_Offset = 0;




        //东方风神录

        public static IntPtr Fuujinroku_Power_Offset = 0x0074C48;

        // dec ecx -> nop 1 bit
        public static IntPtr Fuujinroku_Sub_Plyaer_Offset = 0x0026A15;

        // add word ptr [00474C48],-14 -> nop 8 bit
        public static IntPtr Fuujinroku_Sub_Bomb_Offset = 0x00;

        // add word ptr [00474C48],-40 -> nop 8 bit
        public static IntPtr Fuujinroku_Sub_Power_Offset = 0x00;


        //
        public static IntPtr Fuujinroku_Sub_Invincible_Offset = 0x00;



        //东方星莲船

        public static IntPtr Seirensen_Power_Offset = 0x00B0C48;

        // sub [004B0C98],ebx -> nop 6 bit
        public static IntPtr Seirensen_Sub_Plyaer_Offset = 0x00381E7;

        // sub eax,01 -> nop 3 bit
        public static IntPtr Seirensen_Sub_Bomb_Offset = 0x0022F25;

        // mov [004B0C48],eax -> nop 5 bit 
        public static IntPtr Seirensen_Sub_Power_Offset = 0x0039451;


       //mov [esi+00000A28],0000000 -> 10 bit
        public static IntPtr Seirensen_Sub_Invincible_Offset = 0x0038379;
    }
}
