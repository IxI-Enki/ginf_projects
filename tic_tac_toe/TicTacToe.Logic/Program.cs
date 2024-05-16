#region header ( class: TicTacToe - general information )
// - This region stores info about the author and the program( version, features,.. )
/*
 *    ╔══════════════════════╦═══════════════════════════════════════════════════════════════════╗
 *    ║   HTBLA - Leonding   ║ ┏━━━━━━━━━━━━━━━┯━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓ ║█
 *    ╠═════════╤════════════╣ ┃▷ DESCRIPTION: │                                               ┃ ║█
 *    ║  Name   │  Jan Ritt  ║ ┃               │                                               ┃ ║█
 *    ╟─────────┼────────────╢ ┃    GINF01     │                                               ┃ ║█
 *    ║  Class  │  4 ACIFT   ║ ┠───────────────┼───────────────────────────────────────────────┨ ║█
 *    ╟─────────┼────────────╢ ┃▷ SYNTAX:      │ TicTacToe                                     ┃ ║█
 *    ║  Year   │  2024      ║ ┃ ► _nameHere_  │                                               ┃ ║█
 *    ╟─────────┴────────────╢ ┃               │                                               ┃ ║█
 *    ║  Last edit:  5.2024  ║ ┃  ╌╌╌╌╌╌╌╌╌╌╌╌╌┼╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌ ┃ ║█
 *    ╚══════════════════════╣ ┃▷ VERSION:     │ 1.1                                           ┃ ║█
 *                           ║ ┗━━━━━━━━━━━━━━━┷━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛ ║█
 *    ┏━━━━━━━━━━━━━━━━━┓    ╚═══════════════════════════════════════════════════════════════════╝█
 *    ┃   Development   ┃      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀
 *    ┣━━━━━━━━━━━━━━━━━╇━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
 *    ┃ ▷ KNOWN ISSUES  │                                                                        ┃█
 *    ┠─────────────────┼────────────────────────────────────────────────────────────────────────┨█
 *    ┃ ▷ NEXT UP       │                                                                        ┃█
 *    ┃  ╌╌╌╌╌╌╌╌╌╌╌╌╌  │ ╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌  ┃█
 *    ┃    ► _here_     │                                                                        ┃█
 *    ┗━━━━━━━━━━━━━━━━━┷━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛█
 *      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀
*/
#endregion

#region using
// - imported Libraries

#endregion

using System.Text;

namespace Projects
{
  class Program
  {
    static void Main()
    {
      Console.OutputEncoding = Encoding.UTF8;

      Console.CursorVisible = false;

      Console.Write("\n " + Header);

      Console.Write("\n" + ColoredString(ConcatField(Playfield()), "55;255;66"));

      RunTicTacToe();
    }

    private static void RunTicTacToe()
    {
      bool run = true,
           togglePlayer;

      byte[] playerScores = new byte[2];
      byte cursorPos = 5;

      do
      {
        CurserLogic(cursorPos, ref run, ref playerScores);

      } while (run);
    }

    static void CurserLogic(int cursorPos, ref bool run, ref byte[] playerScores)
    {
      Console.SetCursorPosition(cursorPos == 5 ? 6 : 1, 5);
      Console.Write(Cursor[0]);
    }
    static char[] Cursor = ['▶', '◀'];  // ▶▷▸▹◀◁◂◃

    static string Header
      =>
        ColoredString(" Tic", "40;40;255")
      + ColoredString(" Tac", "255;40;40")
      + ColoredString(" Toe", "40;255;40");
    #region playfield
    static string ConcatField(string[] playfieldLines) => string.Join("\n", Playfield());
    static string[] Playfield()
    {
      int width = 12,
          height = 6;

      string[] playfieldLines = new string[height + 1];

      for (int h = 0; h <= height; h++)
      {
        string line = " ";
        for (int w = 0; w <= width; w++)
        {
          switch (h)
          {
            case 0:
              line += w == 0 ? pC[0]
                : w % 12 == 0 ? pC[3]
                : w % 4 == 0 ? pC[2]
                : pC[1];
              break;

            case 1:
            case 3:
            case 5:
              line += w == 0 || w % 12 == 0 ? pC[4]
                : w % 4 == 0 ? pC[8]
                : " ";
              break;

            case 2:
            case 4:
              line += w == 0 ? pC[5]
                : w % 12 == 0 ? pC[6]
                : w % 4 == 0 ? pC[9]
                : pC[7];
              break;

            case 6:
              line += w == 0 ? pC[10]
                : w % 12 == 0 ? pC[12]
                : w % 4 == 0 ? pC[11]
                : pC[1];
              break;
          }
        }
        playfieldLines[h] = line;
      }
      return playfieldLines;
    }
    // 0123456789012
    // ┌╌╌╌╥╌╌╌╥╌╌╌┐ 0
    // ╎   ║   ║   ╎ 1
    // ╞═══╬═══╬═══╡ 2
    // ╎   ║   ║   ╎ 3
    // ╞═══╬═══╬═══╡ 4
    // ╎   ║   ║   ╎ 5
    // └╌╌╌╨╌╌╌╨╌╌╌┘ 6
    static char[] PlayfieldChars
      = ['┌', '╌', '╥', '┐', '┊', '╞', '╡', '═', '║', '╬', '└', '╨', '┘'],
      pC = PlayfieldChars;
    #endregion playfield
    // (☞ﾟヮﾟ)☞   Easy setup for colored strings   ☜(ﾟヮﾟ☜)
    #region string coloring
    static string AnsiEsc = "\u001b[",
                  Foreground = "3",
                  Background = "4",
                  Modifier = "8;2;",
                  Reset = AnsiEsc + "0m";
    static byte Red = 255,
                Green = 255,
                Blue = 255;
    static byte[] RGBValues = [Red, Green, Blue];
    static string RGBString => string.Join(';', RGBValues);
    static string ColoredString(string toColor, string rgbString = "255;255;255", bool foreground = true)
          => AnsiEsc
          + (foreground ? Foreground : Background)
          + Modifier
          + (rgbString == RGBString ? RGBString : rgbString)
          + 'm'
          + toColor
          + Reset;
    #endregion string coloring
  }
}