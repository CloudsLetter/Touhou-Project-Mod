using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touhou_Project_Mod_UI.Models
{
    public static class Value
    {
        // 东方红魔乡1 bit
        public static byte[] Koumakyou_Power_Value = [0x80];

        // sub al,01 -> nop 2bit
        public static byte[] Koumakyou_Sub_Plyaer_Value = [0x90, 0x90];

        // sub dl,01 -> nop 3bit 
        public static byte[] Koumakyou_Sub_Bomb_Value = [0x90, 0x90, 0x90];

        // mov word ptr [0069D4B0],0000 -> nop 9bit
        public static byte[] Koumakyou_Sub_Power_Value = [0x90, 0x90, 0x90, 0x90, 0x90, 0x90,0x90,0x90,0x90];
        // sub ecx,10 -> nop 3 bit
        public static byte[] Koumakyou_Sub_Power2_Value = [0x90, 0x90, 0x90];

        // cmp edx,03 -> cmp edx,02 relpace no bit change value != 3
        public static byte[] Koumakyou_Sub_Invincible_Value = [0x83, 0xFA, 0x02];

        //movsx edx,byte ptr [ecx+000009E0] -> nop 7 bit
        public static byte[] Koumakyou_No_Attac_Value = [0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90];

        // mov [ecx+000075C8],00000001 -> nop 10 bit
        public static byte[] Koumakyou_Make_Bomb_2_Hell = [];
        // wait to find Value with dev

        public static byte[] Koumakyou_Lock_Time = [];

        public static byte[] Seirensen_Humans_Value = [];


        //东方妖妖梦

        public static byte[] Youyoumu_Power_Value = [];

        // sub al,01 -> nop 2bit
        public static byte[] Youyoumu_Sub_Plyaer_Value = [];

        // sub dl,01 -> nop 3bit 
        public static byte[] Youyoumu_Sub_Bomb_Value = [];

        // mov word ptr [0069D4B0],0000 -> nop 9bit
        public static byte[] Youyoumu_Sub_Power_Value = [];
        // sub ecx,10 -> nop 3 bit
        public static byte[] Youyoumu_Sub_Power2_Value = [];

        // cmp edx,03 -> cmp edx,02 relpace no bit change value != 3
        public static byte[ ]Youyoumu_Sub_Invincible_Value = [];



        // 东方风神录
        public static byte[] Fuujinroku_Power_Value = [0x8F, 0x01];

        // 
        public static byte[] Fuujinroku_Sub_Plyaer_Value = [0x90, 0x90, 0x90, 0x90, 0x90, 0x90];

        // 
        public static byte[] Fuujinroku_Sub_Bomb_Value = [0x90, 0x90, 0x90];

        //
        public static byte[] Fuujinroku_Sub_Power_Value = [0x90, 0x90, 0x90, 0x90, 0x90];
        // 
        public static byte[] Fuujinroku_Sub_Power2_Value = [];

        // 
        public static byte[] Fuujinroku_Sub_Invincible_Value = [0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90];



        // 东方星莲船
        public static byte[] Seirensen_Power_Value = [0x8F,0x01];

        // sub al,01 -> nop 2bit
        public static byte[] Seirensen_Sub_Plyaer_Value = [0x90, 0x90, 0x90, 0x90, 0x90, 0x90];

        // sub dl,01 -> nop 3bit 
        public static byte[] Seirensen_Sub_Bomb_Value = [0x90, 0x90, 0x90];

        // mov word ptr [0069D4B0],0000 -> nop 9bit
        public static byte[] Seirensen_Sub_Power_Value = [0x90, 0x90, 0x90, 0x90, 0x90];
        // sub ecx,10 -> nop 3 bit
        public static byte[] Seirensen_Sub_Power2_Value = [];

        // cmp edx,03 -> cmp edx,02 relpace no bit change value != 3
        public static byte[] Seirensen_Sub_Invincible_Value = [0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90];

    }
}