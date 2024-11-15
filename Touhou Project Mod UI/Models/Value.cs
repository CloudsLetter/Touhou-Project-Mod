using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touhou_Project_Mod_UI.Models
{
    public static class Value
    {
        // 6东方红魔乡1 bit
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


        // 7东方妖妖梦

        public static byte[] Youyoumu_Power_Value = [];

        // sub al,01 -> nop 3 bit
        public static byte[] Youyoumu_Sub_Plyaer_Value = [0x90, 0x90, 0x90];

        // sub dl,01 -> nop 3bit 
        public static byte[] Youyoumu_Sub_Bomb_Value = [0x90, 0x90, 0x90];

        // mov word ptr [0069D4B0],0000 -> nop 9bit
        public static byte[] Youyoumu_Sub_Power_Value = [];


        public static byte[] Youyoumu_Sub_OriginPower1_Offset = [0x2D,0x74];
        public static byte[] Youyoumu_Sub_OriginPower2_Offset = [0xF0];

        public static byte[] Youyoumu_Sub_Power1_Value = [0xEB, 0x16];
        public static byte[] Youyoumu_Sub_Power2_Value = [0x00];

        public static byte[] Youyoumu_Sub_OriginInvincible1_Value = [0x07];
        public static byte[] Youyoumu_Sub_OriginInvincible2_Value = [0x04];

        public static byte[] Youyoumu_Sub_Invincible1_Value = [0x00];
        public static byte[] Youyoumu_Sub_Invincible2_Value = [0x00];



        // 08东方永夜抄
        // 
        public static byte[] Eiyashou_Power_Value = [0x98];

        public static byte[] Eiyashou_Sub_Plyaer_Value = [0x90, 0x90, 0x90];

        public static byte[] Eiyashou_Sub_Bomb_Value = [0x90, 0x90, 0x90, 0x90, 0x90, 0x90];
        // 
        public static byte[] Eiyashou_Sub_Power_Value = [];


        //
        public static byte[] Eiyashou_Sub_OriginInvincible1_Value = [0x07];
        public static byte[] Eiyashou_Sub_OriginInvincible2_Value = [0x07];
        public static byte[] Eiyashou_Sub_OriginInvincible3_Value = [0x04];

        public static byte[] Eiyashou_Sub_Invincible1_Value = [0x00];
        public static byte[] Eiyashou_Sub_Invincible2_Value = [0x00];
        public static byte[] Eiyashou_Sub_Invincible3_Value = [0x00];

        // 09东方花映塚 

        public static byte[] Kaeizuka_Power_Value = [];

        public static byte[] Kaeizuka_Sub_Plyaer_Value = [];

        public static byte[] Kaeizuka_Sub_Bomb_Value = [];

        public static byte[] Kaeizuka_Sub_Power_Value = [];


        public static byte[] Kaeizuka_Sub_Invincible_Value = [];

        // 10东方风神录
        public static byte[] Fuujinroku_Power_Value = [0x63];

        // 
        public static byte[] Fuujinroku_Sub_Plyaer_Value = [0x90];

        // 
        public static byte[] Fuujinroku_Sub_Bomb_Value = [0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90];

        //
        public static byte[] Fuujinroku_Sub_Power_Value = [0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90];
        // 
        public static byte[] Fuujinroku_Sub_Power2_Value = [];

        // 
        public static byte[] Fuujinroku_Sub_Invincible_Value = [0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90];


        //11东方地灵殿

        public static byte[] Chireiden_Power_Value = [0x4F];

        public static byte[] Chireiden_Sub_Plyaer_Value = [0x90, 0x90, 0x90, 0x90, 0x90, 0x90];

        public static byte[] Chireiden_Sub_Bomb_Value = [0x90, 0x90, 0x90, 0x90, 0x90, 0x90];

        public static byte[] Chireiden_Sub_Power_Value = [0x90, 0x90, 0x90, 0x90, 0x90];


        public static byte[] Chireiden_Sub_Invincible_Value = [0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90];


        // 12东方星莲船
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

        // 13东方神灵庙

        public static byte[] Shinreibyou_Power_Value = [0x8F, 0x01];

        public static byte[] Shinreibyou_Sub_Plyaer_Value = [0x90, 0x90, 0x90, 0x90, 0x90, 0x90];

        public static byte[] Shinreibyou_Sub_Bomb_Value = [0x90, 0x90];

        public static byte[] Shinreibyou_Sub_Power_Value = [0x90, 0x90, 0x90, 0x90, 0x90];


        public static byte[] Shinreibyou_Sub_Invincible_Value = [0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90];

        // 14东方辉针城

        public static byte[] Kishinjou_Power_Value = [0x8F, 0x01];

        public static byte[] Kishinjou_Sub_Plyaer_Value = [0x90, 0x90, 0x90, 0x90, 0x90];

        public static byte[] Kishinjou_Sub_Bomb_Value = [0x90, 0x90, 0x90, 0x90, 0x90];

        public static byte[] Kishinjou_Sub_Power_Value = [0x90, 0x90, 0x90, 0x90, 0x90, 0x90];


        public static byte[] Kishinjou_Sub_Invincible_Value = [0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90];

        // 15东方绀珠传

        public static byte[] Kanjuden_Power_Value = [0x8F, 0x01];

        public static byte[] Kanjuden_Sub_Plyaer_Value = [0x90, 0x90, 0x90, 0x90, 0x90];

        public static byte[] Kanjuden_Sub_Bomb_Value = [0x90, 0x90, 0x90, 0x90, 0x90];

        public static byte[] Kanjuden_Sub_Power_Value = [0x90, 0x90, 0x90, 0x90, 0x90, 0x90];


        public static byte[] Kanjuden_Sub_Invincible_Value = [0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90];

        // 16东方天空璋

        public static byte[] Tenkuushou_Power_Value = [0x8F, 0x01];

        public static byte[] Tenkuushou_Sub_Plyaer_Value = [0x90, 0x90, 0x90, 0x90, 0x90];

        public static byte[] Tenkuushou_Sub_Bomb_Value = [0x90, 0x90, 0x90, 0x90, 0x90];

        public static byte[] Tenkuushou_Sub_Power_Value = [0x90, 0x90, 0x90, 0x90, 0x90, 0x90];


        public static byte[] Tenkuushou_Sub_Invincible_Value = [0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90];


        // 17东方鬼形兽

        public static byte[] Kikeijuu_Power_Value = [0x8F, 0x01];

        public static byte[] Kikeijuu_Sub_Plyaer_Value = [0x90, 0x90, 0x90, 0x90, 0x90, 0x90];

        public static byte[] Kikeijuu_Sub_Bomb_Value = [0x90, 0x90, 0x90, 0x90, 0x90, 0x90];

        public static byte[] Kikeijuu_Sub_Power_Value = [0x90, 0x90, 0x90, 0x90, 0x90, 0x90];


        public static byte[] Kikeijuu_Sub_Invincible_Value = [0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90];

        // 18东方虹龙洞

        public static byte[] Kouryuudou_Power_Value = [0x8F, 0x01];

        public static byte[] Kouryuudou_Sub_Plyaer_Value = [0x90, 0x90, 0x90, 0x90, 0x90];

        public static byte[] Kouryuudou_Sub_Bomb_Value = [0x90, 0x90, 0x90, 0x90];

        public static byte[] Kouryuudou_Sub_Power_Value = [0x90, 0x90, 0x90];


        public static byte[] Kouryuudou_Sub_Invincible_Value = [0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90];

        // 19东方兽王国

        public static byte[] Juuouen_Power_Value = [];

        public static byte[] Juuouen_Sub_Plyaer_Value = [];

        public static byte[] Juuouen_Sub_Bomb_Value = [];

        public static byte[] Juuouen_Sub_Power_Value = [];


        public static byte[] Juuouen_Sub_Invincible_Value = [];


    }
}