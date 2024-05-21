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
  //*‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗ • DEBUGSCREEN  ‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗*//

  /// <summary>
  /// DE : Die DebugScreen-Klasse stellt Methoden zum Zeichnen und Löschen eines Debug-Bildschirms in der Konsole bereit.
  /// </summary>
  // <summary>
  // EN : DebugScreen class provides methods to draw and clear a debug screen on the console.
  // </summary>
  public class DebugScreen()
  {
    /// <summary>
    /// DE : ScreenDrawer(int cWidth) 
    /// ━━━━━▶ zeichnet den Debug-Bildschirm in der Konsole mit der angegebenen Breite.
    /// </summary>
    /// <param name="cWidth">
    /// Die Breite des Konsolenfensters.
    /// </param>
    // <summary>
    // EN : ScreenDrawer(int cWidth) draws the debug screen on the console with the specified width.
    // </summary>
    // <param name="cWidth">
    // The width of the console window.
    // </param>
    public void ScreenDrawer
      (int cWidth)
    {
      Colorizer Format = new Colorizer();
      Console.Write(DrawScreen(cWidth));
      Console.Clear();
    }

    /// <summary>
    /// DE : DrawScreen(int cWidth) 
    /// ━━━━━▶ generiert eine Zeichenkettenrepräsentation des Debug-Bildschirms mit einer angegebenen Breite.
    /// </summary>
    /// <param name="cWidth">
    /// Die Breite des Konsolenfensters.
    /// </param>
    /// <returns>
    /// Eine Zeichenkette, die die Repräsentation des Debug-Bildschirms enthält.
    /// </returns>
    // <summary>
    // EN : DrawScreen(int cWidth) generates a string representation of the debug screen with a specified width.
    // </summary>
    // <param name="cWidth">
    // The width of the console window.
    // </param>
    // <returns>
    // A string containing the debug screen representation.
    // </returns>
    public string DrawScreen
      (int cWidth)
    {
      Colorizer Format = new Colorizer();
      int cHeight = cWidth / 3;
      string debugScreen = "";
      /// 
      Box Set = new Box();
      // Thread.Sleep(1000);
      string colorMod = "ℝ0,200,0₲";
      Set.BoxDrawer(cWidth, cHeight, 0, 0, cWidth, cHeight, 2, colorMod);

      Console.SetCursorPosition(3, 0);
      Console.Write("DEBUG-SCREEN");
      Console.SetCursorPosition(5, 2);

      for (int j = 0; j < 2; j++)
      {
        for (int i = 0; i < 3; i++)
        {
          Thread.Sleep(150);
          Console.Write(".");
        }
        Console.Write((j == 0) ? "loading" : "");
      }
      Set.BoxDrawer(cWidth, cHeight, 0, 0, cWidth, cHeight, 2, colorMod);
      /*
            for (int j = 0; j < 2; j++)
            {
              Console.SetCursorPosition(0, 0);
              Console.Write(Format.ColorString($"ℝ{100 * j},0,0₲" + DEBUGSCREEN(j)));
              Console.SetCursorPosition(5, 2);
              Thread.Sleep(1500);
              Console.ReadLine();
            }
            Set.BoxDrawer(cWidth, cHeight, 0, 0, cWidth, cHeight, 2, colorMod);

            for (int j = 2; j < 3; j++)
            {
              Console.SetCursorPosition(1, 1);
              Console.Write(Format.ColorString($"ℝ0,{100 * j},0₲" + DEBUGSCREEN(j)));
              Console.SetCursorPosition(5, 2);
              Thread.Sleep(1500);
              Console.ReadLine();
            }
            Set.BoxDrawer(cWidth, cHeight, 0, 0, cWidth, cHeight, 2, colorMod);

            */

      int frame = 0;
      while (true)
      {
        Console.SetCursorPosition(0, 0);
        Console.Write(Format.ColorString(DEBUGSCREENMOVING(3, frame)));
        //   Thread.Sleep(00);

        frame = (frame + 1) % 60;
      }


      return debugScreen;
    }


    static public string DEBUGSCREENMOVING
      (int screenNr, int frame)
    {
      string[] DEBUGSCREENS = new string[5];
      string SCREEN1 = " ";
      string SCREEN2 = " ";
      string SCREEN3 = " ";
      string SCREEN4 = " ";
      SCREEN4 =
             "┌───────────────────────────────────────────────────────────────────▴ ▴ ▴ ▴ ▴ ↑─┐\n" +
             "⁰¹²³⁴⁵⁶⁷⁸⁹ABCDEFGHIJKLMNOPQRSTUVWXYZΩΦΔΓ.γδφωzyxwvutsrqponmlkjihgfedcba₉₈₇₆₅₄₃₂₁₀\n" +
             "│                                                                   │ │ │ │ 5 ↓ │\n" +
             "│                              ↳ COORDINATES cWidth                 │ │ │ 6 │ ↑ │\n" +
             "│                                                                   │ │ 9 │ ▾ 3 │\n" +
             "│                                                                   │13 │ ▾ 1 ↓ │\n" +
             "│                                                                  27 │ │ 1 ▴ ↑ │\n" +
             "│                           █████████ DEBUG █████████               │ │ │ ▴ │ 3 │\n" +
             "│                           ██▓▓▓▓▓▓ SCREEN: ▓▓▓▓▓▓██               │ │ ▾ │ │ ↓ │\n" +
             "│                           ██▓▓▒▒▒▒▒▒ 1/1 ▒▒▒▒▒▒▓▓██               │ │ ▴ │ │ ↑ │\n" +
             "│                           ██▓▓▒▒░░░░░░░░░░░░░▒▒▓▓██               │ │ │ │ ▾ 3 │\n" +
             "│ ▛ ▜                       ██▓▓▒▒░░▛▘  |  ▝▜░░▒▒▓▓██               │ │ │ │ ▴ ↓ │\n" +
             "│ ▙ ▟                       ██▓▓▒▒░░▘ ┌───┐ ▝░░▒▒▓▓██               │ ▾ │ ▾ │ ↑ │\n" +
             "─ ░▒▓█                      ██▓▓▒▒░░──│─┼─│──░░▒▒▓▓██               │ 1 │ 1 │ 3 ─\n" +
             "│                           ██▓▓▒▒░░▖ └───┘ ▗░░▒▒▓▓██               │ ▴ │ ▴ │ ↓ │\n" +
             "│                           ██▓▓▒▒░░▙▖  |  ▗▟░░▒▒▓▓██               │ │ │ │ ▾ ↑ │\n" +
             "│                           ██▓▓▒▒░░░░░░░░░░░░░▒▒▓▓██               │ │ ▾ │ │ ↓ │\n" +
             "◂───────────────────────────────────────81──────────────────────────────────────▸\n" +
             "◂──────────────────40──────────────────▸1◂─────────────────40───────────────────▸\n" +
             "◂──────────27─────────────▸◂────────────27───────────▸◂───────────27────────────▸\n" +
             "◂────13─────▸1◂────13─────▸◂────13─────▸1◂────13─────▸◂────13─────▸1◂────13─────▸\n" +
             "◂───9───▸◂───9───▸◂───9───▸◂───9───▸◂───9───▸◂───9───▸◂───9───▸◂───9───▸◂───9───▸\n" +
             "◂─6──▸1◂─6──▸1◂─6──▸1◂─6──▸1◂─6──▸◂──6─▸1◂─6──▸◂─6──▸1◂─6──▸1◂─6──▸1◂─6──▸1◂─6──▸\n" +
             "◂─5─▸◂─5─▸◂─5─▸◂─5─▸◂─5─▸◂─5─▸◂─5─▸◂─5─▸1◂─5─▸◂─5─▸◂─5─▸◂─5─▸◂─5─▸◂─5─▸◂─5─▸◂─5─▸\n" +
             "←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→\n" +
             "│                                                                   │ │ │ │ │ 3 │\n" +
             "└───────────────────────────────────────|───────────────────────────▾ ▾ ▾ ▾ ▾ ↓─┘";
      string cache = ""; int i = 0; int sign = 0;
      int red = 0, green = 0, blue = 0;
      foreach (char c in SCREEN4)
      {
        red = (sign == 0) ? red + i : red - i;
        green = (sign == 0) ? green + i : green - i;
        blue = (sign == 0) ? blue + i : blue - i;
        //        red = (red>=0)? + frame % 33: -frame % 33;
        //        green = (green>=0)? + frame% 13:-frame % 13;
        //        blue = (blue>=0)? + frame%11:-frame % 11;

        blue = (frame % 3 == 0) ? red + 33 : red;
        green = (frame % 4 == 0) ? blue + 44 : blue;
        green = (frame % 5 == 0) ? green + 55 : green;

        Math.Clamp(red, 0, 255);
        Math.Clamp(green, 0, 255);
        Math.Clamp(blue, 0, 255);



        cache = cache +
        "ℝ0,00,0₲" + $"rgbB[{red},{green},{blue}]" + c; i = (sign == 0) ? i + 1 : i - 1;
        Math.Clamp(i, 0, 41);
        if (i >= 41 ) { sign = 1; }
        if (i <= 0) { sign = 0; }
      }
      DEBUGSCREENS[3] = cache;


      return new string(DEBUGSCREENS[screenNr]);
    }

    /// <summary>
    /// DE : DEBUGSCREEN(int screenNr) 
    /// ━━━━━▶ generiert eine Zeichenkettenrepräsentation eines Debug-Bildschirms basierend auf der angegebenen Bildschirmnummer.
    /// </summary>
    /// <param name="screenNr">
    /// Die Nummer, die den gewünschten Debug-Bildschirm repräsentiert (1 oder 2).
    /// </param>
    /// <returns>
    /// Eine Zeichenkette, die die Repräsentation des angegebenen Debug-Bildschirms enthält.
    /// </returns>
    // <summary>
    // EN : DEBUGSCREEN(int screenNr) generates a string representation of a debug screen based on the specified screen number.
    // </summary>
    // <param name="screenNr">
    // The number representing the desired debug screen (1 or 2).
    // </param>
    // <returns>
    // A string containing the representation of the specified debug screen.
    // </returns>
    static public string DEBUGSCREEN
      (int screenNr)
    {
      string[] DEBUGSCREENS = new string[5];
      string SCREEN1 = " ";
      string SCREEN2 = " ";
      string SCREEN3 = " ";
      string SCREEN4 = " ";
      string SCREEN5 = " ";

      SCREEN1 =
                "┌───────────────────────────────────────────────────────────────────────────────┐\n" +
                "⁰¹²³⁴⁵⁶⁷⁸⁹ABCDEFGHIJKLMNOPQRSTUVWXYZΩΦΔΓ.γδφωzyxwvutsrqponmlkjihgfedcba₉₈₇₆₅₄₃₂₁₀\n" +
                "│                                                                │ │ │ │ 5 ↓    │\n" +
                "│                              ↳ COORDINATES cWidth              │ │ │ 6 │ ↑    │\n" +
                "│                                                                │ │ 9 │ ▾ 3    │\n" +
                "│                                                                │13 │ ▾ 1 ↓    │\n" +
                "│                                                               27 │ │ 1 ▴ ↑    │\n" +
                "│                                     DEBUG                      │ │ │ ▴ │ 3    │\n" +
                "│                                    SCREEN:                     │ │ ▾ │ │ ↓    │\n" +
                "│                                      1/n                       │ │ ▴ │ │ ↑    │\n" +
                "│                                                                │ │ │ │ ▾ 3    │\n" +
                "│                                       |                        │ │ │ │ ▴ ↓    │\n" +
                "│                                     ┌───┐                      │ ▾ │ ▾ │ ↑    │\n" +
                "─                                   ──│ ┼ │──                    │ 1 │ 1 │ 3    ─\n" +
                "│                                     └───┘                      │ ▴ │ ▴ │ ↓    │\n" +
                "│                                       |                        │ │ │ │ ▾ ↑    │\n" +
                "│                                                                               │\n" +
                "◂───────────────────────────────────────81──────────────────────────────────────▸\n" +
                "◂──────────────────40──────────────────▸1◂─────────────────40───────────────────▸\n" +
                "◂──────────27─────────────▸◂────────────27───────────▸◂───────────27────────────▸\n" +
                "◂────13─────▸1◂────13─────▸◂────13─────▸1◂────13─────▸◂────13─────▸1◂────13─────▸\n" +
                "◂───9───▸◂───9───▸◂───9───▸◂───9───▸◂───9───▸◂───9───▸◂───9───▸◂───9───▸◂───9───▸\n" +
                "◂─6──▸1◂─6──▸1◂─6──▸1◂─6──▸1◂─6──▸◂──6─▸1◂─6──▸◂─6──▸1◂─6──▸1◂─6──▸1◂─6──▸1◂─6──▸\n" +
                "◂─5─▸◂─5─▸◂─5─▸◂─5─▸◂─5─▸◂─5─▸◂─5─▸◂─5─▸1◂─5─▸◂─5─▸◂─5─▸◂─5─▸◂─5─▸◂─5─▸◂─5─▸◂─5─▸\n" +
                "←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→\n" +
                "│                                                                               │\n" +
                "└───────────────────────────────────────|───────────────────────────────────────┘";

      /*              ▲▴          */

      SCREEN2 =
                "┌ 0 ─────────────────────────────────────────────────────────────▴ ▴ ▴ ▴ ▴ ↑────┐\n" +
                "│ 1                                                              │ │ │ │ │ 3    │\n" +
                "│ 2                                                              │ │ │ │ 5 ↓    │\n" +
                "│ 3                                                              │ │ │ 6 │ ↑    │\n" +
                "│ 4                                                              │ │ 9 │ ▾ 3    │\n" +
                "│ 5                                                              │13 │ ▾ 1 ↓    │\n" +
                "│ 6                                                             27 │ │ 1 ▴ ↑    │\n" +
                "│ 7                                                              │ │ │ ▴ │ 3    │\n" +
                "│ 8                                                              │ │ ▾ │ │ ↓    │\n" +
                "│ 9                                                              │ │ ▴ │ │ ↑    │\n" +
                "│ A                                   DEBUG                      │ │ │ │ ▾ 3    │\n" +
                "│ B                                     |                        │ │ │ │ ▴ ↓    │\n" +
                "│ C                                   ┌───┐                      │ ▾ │ ▾ │ ↑    │\n" +
                "─ D  → COORDINATES cHeight          ──│ + │──                    │ 1 │ 1 │ 3    ─\n" +
                "│ E                                   └───┘                      │ ▴ │ ▴ │ ↓    │\n" +
                "│ F                                     |                        │ │ │ │ ▾ ↑    │\n" +
                "│ G                                  SCREEN:                     │ │ │ │ ▴ 3    │\n" +
                "│ H                                    2/n                       │ │ ▾ │ │ ↓    │\n" +
                "│ I                                                              │ │ ▴ │ │ ↑    │\n" +
                "│ J                                                              │ │ │ ▾ │ 3    │\n" +
                "│ K                                                              │ │ │ 1 ▾ ↓    │\n" +
                "│ L                                                              │ │ │ ▴ 1 ↑    │\n" +
                "│ M                                                              │ │ │ │ ▴ 3    │\n" +
                "│ N                                                              │ │ │ │ │ ↓    │\n" +
                "│ O                                                              │ │ │ │ │ ↑    │\n" +
                "│ P                                                              │ │ │ │ │ 3    │\n" +
                "└ Q ────────────────────────────────────|────────────────────────▾ ▾ ▾ ▾ ▾ ↓────┘";

      SCREEN3 =
                 "  -status/GUI           |   -status/GUI       \n" +
                 "   ✙ ✚                   |   ✙✚            \n" +
                 "   ■ ■ ■ ■ ■ ■ ■ ■ ■ ■   |   ■■■■■■■■■■\n" +
                 "   - - - - - - - - - -   |   ----------\n" +
                 "   ▮ ▮ ▮ ▮ ▮ ▮ ▮ ▮ ▮ ▮   |   ▮▮▮▮▮▮▮▮▮▮\n" +
                 "   ◼ ◼ ◼ ◼ ◼ ◼ ◼ ◼ ◼ ◼   |   ◼◼◼◼◼◼◼◼◼◼\n" +
                 "   ◾ ◾ ◾ ◾ ◾ ◾ ◾ ◾ ◾ ◾   |   ◾◾◾◾◾◾◾◾◾◾\n" +
                 "   ◽ ◽ ◽ ◽ ◽ ◽ ◽ ◽ ◽ ◽   |   ◽◽◽◽◽◽◽◽◽◽\n" +
                 "   ◻ ◻ ◻ ◻ ◻ ◻ ◻ ◻ ◻ ◻   |   ◻◻◻◻◻◻◻◻◻◻\n" +
                 "   ▯ ▯ ▯ ▯ ▯ ▯ ▯ ▯ ▯ ▯   |   ▯▯▯▯▯▯▯▯▯▯\n" +
                 "   - - - - - - - - - -   |   ----------\n" +
                 "   ◫ ◫ ◫ ◫ ◫ ◫ ◫ ◫ ◫ ◫   |   ◫◫◫◫◫◫◫◫◫◫";

      SCREEN4 =
      "┌───────────────────────────────────────────────────────────────────────────────┐\n" +
      "⁰¹²³⁴⁵⁶⁷⁸⁹ABCDEFGHIJKLMNOPQRSTUVWXYZΩΦΔΓ.γδφωzyxwvutsrqponmlkjihgfedcba₉₈₇₆₅₄₃₂₁₀\n" +
      "│                                                                               │\n" +
      "│                              ↳ COORDINATES cWidth                             │\n" +
      "│                                                                               │\n" +
      "│                                                                               │\n" +
      "│                                                                               │\n" +
      "│                                     DEBUG                                     │\n" +
      "│                                    SCREEN:                                    │\n" +
      "│                                      1/n                                      │\n" +
      "│                                                                               │\n" +
      "│                                       |                                       │\n" +
      "│                                     ┌───┐                                     │\n" +
      "─                                   ──│ ┼ │──                                   ─\n" +
      "│                                     └───┘                                     │\n" +
      "│                                       |                                       │\n" +
      "│                                                                               │\n" +
      "◂───────────────────────────────────────81──────────────────────────────────────▸\n" +
      "◂──────────────────40──────────────────▸1◂─────────────────40───────────────────▸\n" +
      "◂──────────27─────────────▸◂────────────27───────────▸◂───────────27────────────▸\n" +
      "◂────13─────▸1◂────13─────▸◂────13─────▸1◂────13─────▸◂────13─────▸1◂────13─────▸\n" +
      "◂───9───▸◂───9───▸◂───9───▸◂───9───▸◂───9───▸◂───9───▸◂───9───▸◂───9───▸◂───9───▸\n" +
      "◂─6──▸1◂─6──▸1◂─6──▸1◂─6──▸1◂─6──▸◂──6─▸1◂─6──▸◂─6──▸1◂─6──▸1◂─6──▸1◂─6──▸1◂─6──▸\n" +
      "◂─5─▸◂─5─▸◂─5─▸◂─5─▸◂─5─▸◂─5─▸◂─5─▸◂─5─▸1◂─5─▸◂─5─▸◂─5─▸◂─5─▸◂─5─▸◂─5─▸◂─5─▸◂─5─▸\n" +
      "←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→←3→\n" +
      "│                                                                               │\n" +
      "└───────────────────────────────────────|───────────────────────────────────────┘";


      int i = 0;
      string cache = "";
      foreach (char c in SCREEN1)
      {
        cache = cache +
        $"ℝ{3 * i},{2 * i},{2 * i}₲" + c; i++;
        if (3 * i > 255) { i = 0; }
      }
      DEBUGSCREENS[0] = cache;
      cache = ""; i = 0;
      foreach (char c in SCREEN2)
      {
        cache = cache +
        $"ℝ{0 * i},{1 * i},{3 * i}₲" + c; i++;
        if (3 * i > 255) { i = 0; }
      }
      DEBUGSCREENS[1] = cache;
      cache = ""; i = 0;
      foreach (char c in SCREEN3)
      {
        cache = cache +
        $"ℝ{2 * i},{1 * i},{3 * i}₲" + c; i++;
        if (3 * i > 255) { i = 0; }
      }
      DEBUGSCREENS[2] = cache;
      cache = ""; i = 0; int sign = 0;
      foreach (char c in SCREEN4)
      {
        cache = cache +
         $"rgbB[{5 * i / 4},{6 * i / 3},{3 * i / 2}]" + c; i = (sign == 0) ? i + 4 : i - 5;
        Math.Clamp(i, 0, 81);
        if (i >= 81) { sign = 1; }
        if (i <= 0) { sign = 0; }
      }
      DEBUGSCREENS[3] = cache;





      DEBUGSCREENS[4] = SCREEN5;
      return new string(DEBUGSCREENS[screenNr]);
    }
  }
}