using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using IxIGotchi;
using Gotchi;
using System.Linq;

namespace Gotchi
{
  internal class Animations
  {
    static void InitiateAnimation(string animation, int frame)
    {

    }

    public static string AnimateCurser(string animation, int frame)
    {
      string[] curserColorMod =   //  "ℝ"+{red}+","+{green}+","+{blue}+"₲"
            [];

      string[] curserAnimationL =
            [
              "▶",
              "►",
              "▶",
              "►",
              "▶",
              "▶"
             ];  //

      string[] curserAnimationR =
            [
              "◀",
              "◄",
              "◀",
              "◄",
              "◀",
              "◀"
             ];  // 

      string[] loading =
            [
              "◴",
              "◷",
              "◶",
              "◵"
             ];  // 

      string[] hpAnimation =
            [
              "✙",
              "✚"
             ];  // 

      string[] hydration =
        ["☕", "♨"];

      string[] sleeping =
            [
              "Z",
              "z",
              "ᶻ",

            ];


      int frameCounter;
      string animateCurser = "";
      switch (animation)
      {
        case "curserL":
          curserColorMod =   //  "ℝ"+{red}+","+{green}+","+{blue}+"₲"
           [
             "ℝ070,232,050₲",
             "ℝ050,212,070₲",
             "ℝ030,190,100₲",
             "ℝ010,170,140₲",
             "ℝ000,140,190₲",
             "ℝ000,100,250₲"
           ];
          animateCurser = curserColorMod[frame % curserColorMod.Length] + curserAnimationL[frame % curserAnimationL.Length];
          break;
        case "curserR":
          curserColorMod =   //  "ℝ"+{red}+","+{green}+","+{blue}+"₲"
           [
             "ℝ070,232,050₲",
             "ℝ050,212,070₲",
             "ℝ030,190,100₲",
             "ℝ010,170,140₲",
             "ℝ000,140,190₲",
             "ℝ000,100,250₲"
           ];
          animateCurser = curserColorMod[frame % curserColorMod.Length] + curserAnimationR[frame % curserAnimationR.Length];
          break;

        case "hpAnimation":
          curserColorMod =   //  "ℝ"+{red}+","+{green}+","+{blue}+"₲"
            [
              "ℝ255,012,070₲",
              "ℝ255,032,045₲",
              "ℝ255,042,045₲",
              "ℝ255,062,045₲",
            ];
          frameCounter = (frame <= 30 || frame >= 40) ? 1 : 0;
          animateCurser = curserColorMod[frame % curserColorMod.Length] + hpAnimation[frameCounter];
          break;

        case "hydration":
          curserColorMod =
            [
              "ℝ0,165,230₲",
              "ℝ0,150,200₲",
              "ℝ0,120,230₲",
              "ℝ0,180,255₲"
             ];
           frameCounter = (frame <= 59 || frame >= 61) ? 0 : 1;
          animateCurser = curserColorMod[frame % curserColorMod.Length] + hydration[frameCounter];
          break;

        case "sleepingDark":
          curserColorMod =
            [
              "ℝ0,0,0₲",
              "ℝ10,10,10₲",
              "ℝ20,20,20₲",
              "ℝ30,30,30₲",
              "ℝ40,40,40₲",
              "ℝ50,50,50₲",
            ];
          animateCurser = curserColorMod[frame % curserColorMod.Length] + sleeping[frame % sleeping.Length];
          break;
        case "sleepingMedium":
          curserColorMod =
            [
              "ℝ60,60,60₲",
              "ℝ70,70,70₲",
              "ℝ80,80,80₲",
              "ℝ90,90,90₲",
              "ℝ100,100,100₲",
              "ℝ110,110,110₲",
            ];
          animateCurser = curserColorMod[frame % curserColorMod.Length] + sleeping[frame % sleeping.Length];
          break;
        case "sleepingLight":
          curserColorMod =
            [
              "ℝ120,120,120₲",
              "ℝ130,130,130₲",
              "ℝ150,150,150₲",
              "ℝ170,170,170₲",
              "ℝ210,210,210₲",
              "ℝ255,255,255₲",
            ];
          animateCurser = curserColorMod[frame % curserColorMod.Length] + sleeping[frame % sleeping.Length];
          break;



        default:
          break;
      }


      return animateCurser;
    }

    static string AnimationFrames()
    {
      string animationFrame = "";

      return animationFrame;
    }


  }
}
