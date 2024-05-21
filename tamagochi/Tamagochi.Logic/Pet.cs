using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using IxIGotchi;
using Gotchi;
using System.Linq;
using System.Net;

namespace Gotchi
{
  public class Pet

  {
    public void CallPet(int frame, string state)
    {
      Console.Write(ConjunctPartsHead(frame, state));

    }

    public string ConjunctPartsHead(int frame, string state)
    {
      string pet = "",
        spacingL = "", spacingR = "";
      int hL = 0, eL = 0, m = 0, eR = 0, hR = 0;

      /* PET: _______________________________________________________________________________________________*/
      /// handsLeftChars + "(" + spacingL + eyesLeftChars[eL] + mouthChars[m] + eyesRightChars[eR] + spacingR + ")" + handRightChars[hR]      
      /// handLeftChars, eyesLeftChars, mouthChars, eyesRightChars, handRightChars
      string[] handLeftChars = // ˓ᶜϲ⊂c
            [" ", "˓", "ᶜ", "ϲ", "⊂", "c"];

      string[] eyesLeftChars = // -≖⊙Ѳx
            [" ", "-", "≖", "⊙", "Ѳ", "x"];

      string[] mouthChars = // _ˍw˳‿˗
            ["_", "ˍ", "w", "˳", "‿", "˗"];

      string[] eyesRightChars = // -≖⊙Ѳx
            [" ", "-", "≖", "⊙", "Ѳ", "x"];

      string[] handRightChars = // ˒ᵓͻ⊃ɔ
            [" ", "˒", "ᵓ", "ͻ", "⊃", "ɔ"];

      bool isSleeping = true;
      bool isAwake;
      int wakingUp = frame % handRightChars.Length;

      /// (-_-)       
      if (state == "sleep")
      {
        wakingUp = 1;
        isAwake = false;
        isSleeping = true;
        hL = 0; hR = 0;
        eL = 1; eR = 1;
        m = 0;
        spacingL = ""; spacingR = spacingL;
        pet = handLeftChars[hR] + "(" + spacingL + eyesLeftChars[eL] + mouthChars[m] + eyesRightChars[eR] + spacingR + ")" + handRightChars[hR] + " ";
      }

      /// (x_x)
      if (state == "dead")
      {
        hL = 0;
        hR = 0;
        eL = 5;
        eR = 5;
        m = 0;
        spacingL = ""; spacingR = spacingL;
        pet = handLeftChars[hR] + "(" + spacingL + eyesLeftChars[eL] + mouthChars[m] + eyesRightChars[eR] + spacingR + ")" + handRightChars[hR] + " ";
      }

      /// ⊂( ⊙‿⊙)⊃
      if (state == "awake")
      {
        hL = 4;
        hR = 4;
        m = 4;
        eL = (frame <= 1) ? 1 : 3; eR = (frame <= 1) ? 1 : 3;
        m = (frame <= 50) ? 4 : 3;
        spacingL = (frame <= 29) ? " " : "";
        spacingR = (spacingL == " ") ? "" : " ";
        spacingL = (frame > 29) ? "" : " ";
        spacingR = (spacingL == "") ? " " : "";
        pet = handLeftChars[hL] + "(" + spacingL + eyesLeftChars[eL] + mouthChars[m] + eyesRightChars[eR] + spacingR + ")" + handRightChars[hR];
      }

      return pet;
    }

  }
}
