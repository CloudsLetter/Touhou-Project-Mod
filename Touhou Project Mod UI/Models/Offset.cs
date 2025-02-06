using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touhou_Project_Mod_UI.Models
{
    public static class Offset
    {
        // 06东方红魔乡1 bit
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


        //07东方妖妖梦
        // th07.exe+226278 -> resulte + 7C
        public static IntPtr Youyoumu_Power_Offset = 0x00226278;

        public static IntPtr Youyoumu_Power_Ptr_Offset = 0x007C;

        public static IntPtr Youyoumu_ReLocate_Offet = 0x00;

        // fstp dword ptr [eax+5C] -> nop 3 bit
        public static IntPtr Youyoumu_Sub_Plyaer_Offset = 0x002D602;
        // fstp dword ptr [eax+68] -> nop 3 bit
        public static IntPtr Youyoumu_Sub_Bomb_Offset = 0x002D647;

        public static IntPtr Youyoumu_Sub_Power1_Offset = 0x002F02B;
        public static IntPtr Youyoumu_Sub_Power2_Offset = 0x0040DD3;

        // 
        public static IntPtr Youyoumu_Sub_Invincible1_Offset = 0x003E37F;
        public static IntPtr Youyoumu_Sub_Invincible2_Offset = 0x003EB6A;


        // 08东方永夜抄
        public static IntPtr Eiyashou_Power_Offset = 0x00120F510;

        public static IntPtr Eiyashou_Power_Ptr_Offset = 0x0098;

        public static IntPtr Eiyashou_ReLocate_Offet = 0x00;

        //fstp dword ptr [eax+74] -> nop 3 bit
        public static IntPtr Eiyashou_Sub_Plyaer_Offset = 0x003C676;
        // fstp dword ptr [eax+00000080] -> nop  6 bit 
        public static IntPtr Eiyashou_Sub_Bomb_Offset = 0x00398BB;

        // fstp dword ptr [ecx+00000098] -> 6 bit 复用
        public static IntPtr Eiyashou_Sub_Power_Offset = 0x006FB0;

        //
        public static IntPtr Eiyashou_Sub_Invincible1_Offset = 0x004A339;
        public static IntPtr Eiyashou_Sub_Invincible2_Offset = 0x004A44B;
        public static IntPtr Eiyashou_Sub_Invincible3_Offset = 0x004A906;


        // 09东方花映塚 

        public static IntPtr Kaeizuka_Power_Offset = 0x00;

        public static IntPtr Kaeizuka_Sub_Plyaer_Offset = 0x00;

        public static IntPtr Kaeizuka_Sub_Bomb_Offset = 0x00;

        public static IntPtr Kaeizuka_Sub_Power_Offset = 0x00;


        public static IntPtr Kaeizuka_Sub_Invincible_Offset = 0x00;

        //10东方风神录
        // 99
        public static IntPtr Fuujinroku_Power_Offset = 0x0074C48;

        // dec ecx -> nop 1 bit
        public static IntPtr Fuujinroku_Sub_Plyaer_Offset = 0x0026A15;

        // add word ptr [00474C48],-14 -> nop 8 bit
        public static IntPtr Fuujinroku_Sub_Bomb_Offset = 0x00259D4;

        // add word ptr [00474C48],-40 -> nop 8 bit 待定
        public static IntPtr Fuujinroku_Sub_Power_Offset = 0x0025AB6;


        // mov [ebp+00000458],00000004 -> 10 bit
        public static IntPtr Fuujinroku_Sub_Invincible_Offset = 0x0026CFF;


        //11东方地灵殿

        public static IntPtr Chireiden_Power_Offset = 0xA56E8;
        // mov [004A5718],edx -> nop 6 bit
        public static IntPtr Chireiden_Sub_Plyaer_Offset = 0x0327F0;
        // sub [004A56E8],edx -> nop 6 bit
        public static IntPtr Chireiden_Sub_Bomb_Offset = 0x00311F1;
        // mov [004A56E8],eax -> nop 5 bit
        public static IntPtr Chireiden_Sub_Power_Offset = 0x00312E0;

        // mov [edi+00000928],00000004 -> nop 10 bit
        public static IntPtr Chireiden_Sub_Invincible_Offset = 0x0032A9E;


        //12东方星莲船
        public static IntPtr Seirensen_Humans_Offset = 0x00B0C98;

        public static IntPtr Seirensen_Power_Offset = 0x00B0C48;

        // sub [004B0C98],ebx -> nop 6 bit
        public static IntPtr Seirensen_Sub_Plyaer_Offset = 0x00381E7;

        // sub eax,01 -> nop 3 bit
        public static IntPtr Seirensen_Sub_Bomb_Offset = 0x0022F25;

        // mov [004B0C48],eax -> nop 5 bit 
        public static IntPtr Seirensen_Sub_Power_Offset = 0x0039451;


       //mov [esi+00000A28],0000000 -> 10 bit
        public static IntPtr Seirensen_Sub_Invincible_Offset = 0x0038379;


        // 13东方神灵庙
        // 399 
        public static IntPtr Shinreibyou_Power_Offset = 0x00BE7E8;
        // dec [004BE7F4] -> nop 6 bit
        public static IntPtr Shinreibyou_Sub_Plyaer_Offset = 0x0044A52;
        // sub eax,edi -> nop 2 bit
        public static IntPtr Shinreibyou_Sub_Bomb_Offset = 0x000A402;
        // mov [004BE7E8],eax -> nop 5 bit
        public static IntPtr Shinreibyou_Sub_Power_Offset = 0x0045A31;

        // mov [edi+0000065C],00000004 -> nop 10 bit 
        public static IntPtr Shinreibyou_Sub_Invincible_Offset = 0x0044D75;

        // 14东方辉针城
        // 8F 01 399
        public static IntPtr Kishinjou_Power_Offset = 0x00F5858;
        // mov [004F5864],eax -> 5 bit
        public static IntPtr Kishinjou_Sub_Plyaer_Offset = 0x004F618;
        // mov [004F5870],eax -> nop 5 bit
        public static IntPtr Kishinjou_Sub_Bomb_Offset = 0x001218A;
        // mov [004F5858],ecx -> nop 6 bit
        public static IntPtr Kishinjou_Sub_Power_Offset = 0x004DDBF;
        // mov [edi+00000684],00000004 -> nop 10 bit
        public static IntPtr Kishinjou_Sub_Invincible_Offset = 0x004F871;

        // 15东方绀珠传
        // 399
        public static IntPtr Kanjuden_Power_Offset = 0x00E7440;
        // mov [004E7450],eax -> nop 5 bit 
        public static IntPtr Kanjuden_Sub_Plyaer_Offset = 0x0056398;
        // mov [004E745C],eax -> nop 5 bit
        public static IntPtr Kanjuden_Sub_Bomb_Offset = 0x001497A;
        //mov [004E7440],ecx -> nop 6 bit
        public static IntPtr Kanjuden_Sub_Power_Offset = 0x005830B;

        // mov [edi+00016220],00000004 -> nop 10 bit
        public static IntPtr Kanjuden_Sub_Invincible_Offset = 0x005669F;

        // 16东方天空璋
        // 399
        public static IntPtr Tenkuushou_Power_Offset = 0x00A57E4;
        // mov [004A57F4],eax -> 5 nop bit
        public static IntPtr Tenkuushou_Sub_Plyaer_Offset = 0x0043D3A;
        // mov [004A5800],eax -> nop 5 bit
        public static IntPtr Tenkuushou_Sub_Bomb_Offset = 0x00DB9C;
        // mov [004A57E4],ecx - > noop 6 bit
        public static IntPtr Tenkuushou_Sub_Power_Offset = 0x0042749;
        //  mov [edi+000165A8],00000004 -> nop 10 bit 
        public static IntPtr Tenkuushou_Sub_Invincible_Offset = 0x0043FDB;

        // 17东方鬼形兽
        // 399
        public static IntPtr Kikeijuu_Power_Offset = 0x00B5A30;
        // mov [004B5A40],ecx -> nop 6 bit
        public static IntPtr Kikeijuu_Sub_Plyaer_Offset = 0x004921B;
        // mov [004B5A4C],ecx -> nop 6 bit
        public static IntPtr Kikeijuu_Sub_Bomb_Offset = 0x0011CAB;
        // mov [004B5A30],ecx -> nop 6 bit
        public static IntPtr Kikeijuu_Sub_Power_Offset = 0x0047BA9;

        //mov [edi+00018DB0],00000004 -> nop 10 bit
        public static IntPtr Kikeijuu_Sub_Invincible_Offset = 0x0049564;

        // 18东方虹龙洞
        // 399
        public static IntPtr Kouryuudou_Power_Offset = 0x00CCD38;
        // mov [004CCD48],eax -> nop 5 bit
        public static IntPtr Kouryuudou_Sub_Plyaer_Offset = 0x005D1A3;
        //add dword ptr [edx+7C],-01 -> nop 4 bit
        public static IntPtr Kouryuudou_Sub_Bomb_Offset = 0x00574D3;
        // mov [eax+5C],edi -> nop 3 bit
        public static IntPtr Kouryuudou_Sub_Power_Offset = 0x005749C;
        //mov [edi+000476AC],00000004 -> nop 10 bit
        public static IntPtr Kouryuudou_Sub_Invincible_Offset = 0x005D4E4;

        // 19东方兽王国

        public static IntPtr Juuouen_Power_Offset = 0x00;

        public static IntPtr Juuouen_Sub_Plyaer_Offset = 0x00;

        public static IntPtr Juuouen_Sub_Bomb_Offset = 0x00;

        public static IntPtr Juuouen_Sub_Power_Offset = 0x00;


        public static IntPtr Juuouen_Sub_Invincible_Offset = 0x00;


    }
}
