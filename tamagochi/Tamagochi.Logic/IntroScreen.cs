using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using IxIGotchi;
using Gotchi;

namespace Gotchi
{
  /// <summary>
  /// DE : Die IntroScreen-Klasse bietet Methoden zum Anzeigen eines Einführungsbildschirms mit Ladeanimationen.
  /// </summary>
  // <summary>
  // EN : IntroScreen class provides methods to display an introductory screen with loading animations.
  // </summary>
  class IntroScreen
  {
    /// <summary>
    /// DE : PrintIntro(int cWidth) 
    /// ━━━━━▶ zeigt einen Einführungsbildschirm mit Ladeanimationen an.
    /// </summary>
    /// <param name="cWidth">
    /// Die Breite des Konsolenfensters.
    /// </param>
    // <summary>
    // EN : PrintIntro(int cWidth) displays an introductory screen with loading animations.
    // </summary>
    // <param name="cWidth">
    // The width of the console window.
    // </param>
    public void PrintIntro
      (int cWidth)
    {
      Colorizer Format = new Colorizer();
      int maxCounter = (cWidth / 3) - 9;
      for (int counter = 0; counter <= maxCounter; counter++)
      {
        if (counter < maxCounter)
        {
          Console.Clear();
          Console.Write(Format.ColorString(LoadingBar(cWidth, counter)));
          Thread.Sleep(100);
        }
        if (counter == maxCounter)
        {
          counter = -1;
          Console.Clear();
          Console.Write(Format.ColorString(LoadingBar(cWidth, counter)));
          Thread.Sleep(100);
          break;
        }
      }
      Console.Write(Format.ColorString(Intro(cWidth)));
      Thread.Sleep(700);
      Console.Write(Format.ColorString("rgbB[99,146,79]ℝ0,0,0₲ press Enter \u001b[?25l".PadLeft(88)));
      Thread.Sleep(300);
      Console.ReadLine();
    }
    /// <summary>
    /// DE : LoadingBar(int cWidth, int counter) 
    /// ━━━━━▶ generiert eine Zeichenkettenrepräsentation einer Ladeleiste mit dynamischen Farben basierend auf dem angegebenen Zähler.
    /// </summary>
    /// <param name="cWidth">
    /// Die Breite des Konsolenfensters.
    /// </param>
    /// <param name="counter">
    /// Der Zähler, der den Fortschritt der Ladeleiste bestimmt.
    /// </param>
    /// <returns>
    /// Eine Zeichenkette, die die Repräsentation der Ladeleiste enthält.
    /// </returns>
    // <summary>
    // EN : LoadingBar(int cWidth, int counter) generates a loading bar string with dynamic colors based on the specified counter.
    // </summary>
    // <param name="cWidth">
    // The width of the console window.
    // </param>
    // <param name="counter">
    // The counter used to determine the progress of the loading bar.
    // </param>
    // <returns>
    // A string containing the loading bar representation.
    // </returns>
    static string LoadingBar
      (
      int cWidth, 
      int counter
      )
    {
      string loadingBar = "\u001b[?25l";
      for (int h = 0; h < ((cWidth / 9) - 3); h++)
      {
        loadingBar += "\n";
      }
      for (int w = 0; w < cWidth / 3; w++)
      {
        loadingBar += " ";
      }
      if (counter != -1)
      {
        loadingBar += " ℝ60,60,60₲Loading..";
      }
      if (counter == -1)
      {
        loadingBar += " ℝ60,240,60₲Ready! ";
      }
      int red = 255, green = 30, blue = 30;

      for (int c = 0; c <= counter; c++)
      {
        red = red - 20;
        green = green + 30;

        red = Math.Clamp(red, 0, 255);
        green = Math.Clamp(green, 0, 255);

        if (c < (counter - 1))
        {
          loadingBar += $"ℝ{red},{green},{blue}₲" + "▣";
        }
        else if (c < counter)
        {
          loadingBar += $"ℝ{red},{green},{blue}₲" + "▢";
        }
      }
      //loadingBar = $"ℝ{red},{green},{blue})" + "ready";
      return new string(loadingBar);
    }

    /// <summary>
    /// DE : Intro(int cWidth) 
    /// ━━━━━▶ generiert eine Zeichenkettenrepräsentation des Einführungsbildschirms.
    /// </summary>
    /// <param name="cWidth">
    /// Die Breite des Konsolenfensters.
    /// </param>
    /// <returns>
    /// Eine Zeichenkette, die die Repräsentation des Einführungsbildschirms enthält.
    /// </returns>
    // <summary>
    // EN : Intro(int cWidth) generates a string representation of the introductory screen.
    // </summary>
    // <param name="cWidth">
    // The width of the console window.
    // </param>
    // <returns>
    // A string containing the representation of the introductory screen.
    // </returns>
    static string Intro
      (int cWidth)
    {
      string intro = ConcatIntro(cWidth);
      return new string(intro);
    }

    /// <summary>
    /// DE : ConcatIntro(int cWidth) 
    /// ━━━━━▶ generiert eine Zeichenkettenrepräsentation der verschiedenen Teile des Einführungsbildschirms.
    /// </summary>
    /// <param name="cWidth">
    /// Die Breite des Konsolenfensters.
    /// </param>
    /// <returns>
    /// Eine Zeichenkette, die die verkettete Repräsentation der Teile des Einführungsbildschirms enthält.
    /// </returns>
    // <summary>
    // EN : ConcatIntro(int cWidth) generates a string representation of the different parts of the introductory screen.
    // </summary>
    // <param name="cWidth">
    // The width of the console window.
    // </param>
    // <returns>
    // A string containing the concatenated representation of the introductory screen parts.
    // </returns>
    static string ConcatIntro
      (int cWidth)
    {
      string introParts = "";
      int widthPart = cWidth / 3;
      int heigthPart = cWidth / 9;

      introParts += "\n";
      introParts += " ℝ79,113, 46₲";
      for (int w = 0; w < (widthPart - 1); w++)
      {
        introParts += " ";
      }
      introParts += "╔";
      for (int w = 0; w < widthPart; w++)
      {
        introParts += "═";
      }
      introParts += "╗\n";
      for (int h = 0; h < (heigthPart - 1); h++)
      {
        for (int w = 0; w < widthPart; w++)
        {
          introParts += " ";
        }
        introParts += "║" + "rgbB[40,10,10]ℝ79,113, 46₲";
        /*  ,---.      .      .      0
         *  |  -'  ,-. |- ,-. |-. .  1 ╔═╗╔═╗╔╦╗╔═╗╦ ╦╦   
         *  |  ,-' | | |  |   | | |  2 ║ ╦║ ║ ║ ║  ╠═╣│
         *  `---| .`-' `' `-' ' ' '  3 ╚═╝╚═╝ ╩ ╚═╝╩ ╩o   
         *   ,-.| |-. . .   -,   ,-  4 ┬┐       ╦\\│//╦ 
         *   `-+' | | | |    |. .|   5 ├┴┐┬ ┬   ║ ─⨉─ ║ 
         *        `-' `-|     >X<    6 ┴─┘└┬┘   ╩//|\\╩ 
         *             /|    |´ `|   7     '            
         *            ´-'   -`   ´-  8    ℝ0,255,0)
        */
        switch (h)
        {
          case 0: introParts += "ℝ99,133,66₲   ╔═╗ ╔═╗ ╔╦╗ ╔═╗ ╦ ╦ ╦   "; break;
          case 1: introParts += "ℝ114,148,81₲   ║ ╦ ║ ║  ║  ║   ╠═╣ ║   "; break;
          case 2: introParts += "ℝ129,163,96₲   ║ ║ ║ ║  ║  ║   ║ ║ │   "; break;
          case 3: introParts += "ℝ144,178,111₲   ╚═╝ ╚═╝  ╩  ╚═╝ ╩ ╩ o   "; break;
          case 4: introParts += "ℝ159,193,126₲ -┬┐--─═══════════════─--  "; break;
          case 5: introParts += "ℝ174,208,141₲  ├┴┐┬ ┬  ╦\\v/╦ ┌─┐┌┐┌┬┌─┬ "; break;
          case 6: introParts += "ℝ189,223,156₲  ┴─┘└┬┘  ║ X ║-├┤ │││├┴┐│ "; break;
          case 7: introParts += "ℝ204,238,171₲      '   ╩/^\\╩ └─┘┘└┘┴ ┴┴ "; break;
        }
        introParts += "rgbB[12,12,12]ℝ79,113, 46₲║\n";
      }
      for (int w = 0; w < (widthPart); w++)
      {
        introParts += " ";
      }
      introParts += "rgbB[12,12,12]ℝ79, 113, 46₲" + "╚" + "rgbB[12,12,12]ℝ79, 113, 46₲";
      for (int w = 0; w < (widthPart); w++)
      {
        introParts += "═";
      }
      introParts += "rgbB[12,12,12]ℝ79, 113, 46₲" + "╝\n";

      return new string(introParts);
    }

  }
}