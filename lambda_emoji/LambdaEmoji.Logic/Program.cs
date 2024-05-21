#region header ( class: Program - general information )
// - This region stores info about the author and the program( version, features,.. )
/*
 *    ╔══════════════════════╦═══════════════════════════════════════════════════════════════════╗
 *    ║   HTBLA - Leonding   ║ ┏━━━━━━━━━━━━━━━┯━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓ ║█
 *    ╠═════════╤════════════╣ ┃▷ DESCRIPTION  │ Shows some uses of Lambda Expressions,        ┃ ║█
 *    ║  Name   │  Jan Ritt  ║ ┃               │ a simple Loop, some Ascii-Escape Sequences    ┃ ║█
 *    ╟─────────┼────────────╢ ┃               │ to color the output, and "fixed" Window-Size  ┃ ║█
 *    ║  Class  │  4 ACIFT   ║ ┠───────────────┼───────────────────────────────────────────────┨ ║█
 *    ╟─────────┼────────────╢ ┃▷ SYNTAX       │                                               ┃ ║█
 *    ║  Year   │  2024      ║ ┃               │                                               ┃ ║█
 *    ╟─────────┴────────────╢ ┃               │                                               ┃ ║█
 *    ║  Last edit:  4.2024  ║ ┃               │                                               ┃ ║█
 *    ╚══════════════════════╣ ┃  ╌╌╌╌╌╌╌╌╌╌╌╌╌┼╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌ ┃ ║█
 *      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀║ ┃ ► VERSION     │ 1.4                                           ┃ ║█
 *                           ║ ┗━━━━━━━━━━━━━━━┷━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛ ║█
 *    ┏━━━━━━━━━━━━━━━━━┓    ╚═══════════════════════════════════════════════════════════════════╝█
 *    ┃   Development   ┃      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀
 *    ┣━━━━━━━━━━━━━━━━━╇━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
 *    ┃ ▷ KNOWN ISSUES  │                                                                        ┃█
 *    ┗━━━━━━━━━━━━━━━━━┷━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛█
 *      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀
*/
#endregion

#region using
using System.Text;
#endregion using

namespace Emoji
{
  class Program
  {
    static void Main() => RunGame();

    #region methods
    static void RunGame()
    {
      Console.OutputEncoding = Encoding.UTF8;
      byte hp = 100;
      bool run = true;
      byte difference = 30;
      do
      {
        CalculateColors(out string rgbB, out string Reset, out string rgbF, difference++);
        Console.WriteLine(" " + rgbB + " Lambda " + Reset + "\n" + rgbF + "  anyone? \n " + Reset);
        Loop(Health(ref hp));
      } while (run && hp != 0);
    }

    #region color by using ANSI ESC SEQUENSES
    static void CalculateColors(out string rgbB, out string Reset, out string rgbF, byte difference)
    {
      /// The full syntax for coloring a string with ANSI is:
      /// 
      /// \u001b[   ... tells the program, that a color-specifier is next:
      /// 38;       ... is the number representing the foreground, and tells the program that an RGB-value follows (other examples: 48 does the same for the background)
      /// 2;        ... is the default value or "format-mod" (some terminals/consoles support underlined, or even blinking text) 
      /// x;x;x     ... R-G-B values from 0 to 255, separated by ';'
      /// m         ... indication of the End of this sequence.

      // Divide this Syntax into:
      string ESC = "\u001b[",
             Mod = ";2;",
             ColorForeground = "38" + Mod,
             ColorBackground = "48" + Mod;
      byte r = (byte)(difference * 2),
           g = (byte)(difference * 4),
           b = 0;                    
      string rgb = string.Join(';', r, g, b);

      // By using the following we can now set colors easy:
      rgbF = ESC + ColorForeground + rgb + "m";
      rgbB = ESC + ColorBackground + rgb + "m";
      
      // And resetting them by using:
      Reset = ESC + "0m";
    }
    #endregion color

    static void Loop(byte side = 0)
    {
      SetScreen();
      Console.WriteLine(side == 0 ? PointLeft : PointRight);
      Thread.Sleep(200);
    }

    static void SetScreen()
    {
      Console.CursorVisible = false;
      Console.SetWindowSize(10, 5);
    }

    static byte Health(ref byte hp) => (byte)(hp-- % 2);
    #endregion methods

    #region emoji
    static string PointRight => " (☞°ヮ°)☞ ";

    static string PointLeft => " ☜(°ヮ°☜) ";
    #endregion emoji
  }
}