using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using IxIGotchi;
using Gotchi;


namespace Gotchi
{
  class Menu
  {
    public string GenerateMenu(int cWidth, int choice, int frame, string petState)
    { // 
      Colorizer Format = new Colorizer();
      Animations Animate = new Animations();

      string[] menuChoices = new string[10];


      menuChoices[0] = (petState == "awake") ? "ℝ180,255,180₲   Schlafen legen ℝ100,100,100₲  " : "ℝ180,255,180₲ Haustier ℝ200,255,255₲aufwecken ℝ100,100,100₲";

      menuChoices[1] = "ℝ205,35,55₲      Test ℝ205,135,155₲HP       ℝ100,100,100₲";
      menuChoices[2] = "ℝ05,85,225₲   Test ℝ105,185,225₲Hydration   ℝ100,100,100₲";
      menuChoices[3] = "ℝ250,205,225₲    4 ℝ200,200,200₲auswählen     ℝ100,100,100₲";
      menuChoices[4] = "ℝ95,255,45₲     Speichern ℝ200,200,200₲     ℝ100,100,100₲";

      menuChoices[5] = "ℝ255,180,180₲      Beenden ℝ255,150,150₲!     ";
      // 
      int tab = 24;
      string spacing;
      string menu = "";





      for (int c = 0; c < 6; c++)
      {
        Console.SetCursorPosition(28, 18 + c);

        if (c == choice)
        {
          Console.Write(Format.ColorString(" " + Animations.AnimateCurser("curserL", frame) + menuChoices[c] + Animations.AnimateCurser("curserR", frame)));
        }
        else
        {
          Console.Write(Format.ColorString("  " + menuChoices[c] + "  "));
        }
      }

        


      // 
      /*
      for (int c = 0; c < menuChoices.Length; c++)
      { // 
        spacing = "";
        for (int w = 0; w < ((cWidth - tab) / 2); w++)
        { // 
          spacing += " ";
        }
        // 
        if (c == choice)
        {// pointer choices:  →←  ►◄
          menu = menu + spacing + "ℝ70,232, 50₲► " + menuChoices[c] + "ℝ70,232, 50₲ ◄";
        }
        else
        { // 
          menu = menu + spacing + "  " + menuChoices[c];
        }
        menu = menu + "\n";
      }
      */
      //

      return new string(menu);
    }

  }
}
