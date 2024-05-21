﻿#region header ( class:  - general information )
// - This region stores info about the author and the program( version, features,.. )
/*
 *    ╔══════════════════════╦═══════════════════════════════════════════════════════════════════╗
 *    ║   HTBLA - Leonding   ║ ┏━━━━━━━━━━━━━━━┯━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓ ║█
 *    ╠═════════╤════════════╣ ┃▷ DESCRIPTION  │ Shows some uses of Lambda Expressions,        ┃ ║█
 *    ║  Name   │  Jan Ritt  ║ ┃               │ a simple Loop, some Ascii-Escape Sequences    ┃ ║█
 *    ╟─────────┼────────────╢ ┃               │ to color the output, and "fixed" Window-Size  ┃ ║█
 *    ║  Class  │  4 ACIFT   ║ ┠───────────────┼───────────────────────────────────────────────┨ ║█
 *    ╟─────────┼────────────╢ ┃▷ SYNTAX       │ ESC terminates                                ┃ ║█
 *    ║  Year   │  2024      ║ ┃               │                                               ┃ ║█
 *    ╟─────────┴────────────╢ ┃               │                                               ┃ ║█
 *    ║  Last edit:  4.2024  ║ ┃               │                                               ┃ ║█
 *    ╚══════════════════════╣ ┃  ╌╌╌╌╌╌╌╌╌╌╌╌╌┼╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌ ┃ ║█
 *      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀║ ┃ ► VERSION     │ 1.0                                           ┃ ║█
 *                           ║ ┗━━━━━━━━━━━━━━━┷━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛ ║█
 *    ┏━━━━━━━━━━━━━━━━━┓    ╚═══════════════════════════════════════════════════════════════════╝█
 *    ┃   Development   ┃      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀
 *    ┣━━━━━━━━━━━━━━━━━╇━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
 *    ┃ ▷ KNOWN ISSUES  │                                                                        ┃█
 *    ┠─────────────────┼────────────────────────────────────────────────────────────────────────┨█
 *    ┃ ▷ NEXT UP       │                                                                        ┃█
 *    ┃    ► _here_     │                                                                        ┃█
 *    ┃  ╌╌╌╌╌╌╌╌╌╌╌╌╌  │ ╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌  ┃█
 *    ┃    ► _here_     │                                                                        ┃█
 *    ┗━━━━━━━━━━━━━━━━━┷━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛█
 *      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀
*/
#endregion

#region using
using System.Text;
#endregion using

namespace Tamagochi
{
  class Program
  {
    static void Main() => RunGame();

    #region methods
    static void RunGame()
    {
      Console.OutputEncoding = Encoding.UTF8;
      byte hp = 10;
      bool run = true;
      do
      {
        Console.WriteLine(" " + RedB + " Lambda " + Reset + "\n" + RedF + "  anyone? \n " + Reset);
        Loop((byte)(hp-- % 2));
      } while (run);
    }

    static void Loop(byte side = 0)
    {
      SetScreen();
      Console.WriteLine(side == 0 ? PointLeft : PointRight);
      Thread.Sleep(1000);
      Console.Clear();
    }

    static void SetScreen()
    {
      Console.CursorVisible = false;
      Console.SetWindowSize(10, 5);
    }

    static string Health(int hp) => new string('+', hp);

    #endregion methods

    #region emoji
    static string PointRight => " (☞°ヮ°)☞ ";
    /// DOES THE SAME AS:
    /*
    static string PointRight
    {
      get
      {
        string pointRight = " (☞°ヮ°)☞ ";
        return pointRight;
      }
    }
    */
    static string PointLeft => " ☜(°ヮ°☜) ";
    /// DOES THE SAME AS:
    /*
    static string PointLeft
    {
      get
      {
        string pointLeft = " ☜(°ヮ°☜) ";
        return pointLeft;
      }
    }
    */
    #endregion emoji

    #region color by using ANSI ESC SEQUENSES

    /// The full syntax for coloring a string with ANSI is:
    /// 
    /// \u001b[   ... tells the program, that a color-specifier is next:
    /// 38;       ... is the number representing the foreground, and tells the program that an RGB-value follows (other examples: 48 does the same for the background)
    /// 2;        ... is the default value or "format-mod" (some terminals/consoles support underlined, or even blinking text) 
    /// x;x;x     ... R-G-B values from 0 to 255, separated by ';'
    /// m         ... indication of the End of this sequence.

    // Divide this Syntax into:
    static string ESC => "\u001b[";
    static string ColorForeground => "38" + Mod;
    static string ColorBackground => "48" + Mod;
    static string Mod => ";2;";
    static string red => "255;0;0";
    // By using the following we can now set colors easy:
    static string RedF => ESC + ColorForeground + red + 'm';
    static string RedB => ESC + ColorBackground + red + 'm';
    // And resetting them by using:
    static string Reset => ESC + "0m";
    #endregion color
  }
}