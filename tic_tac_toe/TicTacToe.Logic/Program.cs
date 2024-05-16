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

      byte[] playerScores
        = new byte[2];
      byte cursorPos = 5;
      // 1 2 3
      // 4 5 6
      // 7 8 9
      do
        CurserLogic
          (
          ref cursorPos,
          ref run,
          ref playerScores
          );
      while (run);
      // PrintResult();
    }
    static string Header
      =>
        ColoredString(" Tic", "40;40;255")
      + ColoredString(" Tac", "255;40;40")
      + ColoredString(" Toe", "40;255;40");

    #region cursor
    static void CurserLogic
      (
      ref byte cursorPos,
      ref bool run,
      ref byte[] playerScores
      )
    {
      if (Console.KeyAvailable)
      {
        ConsoleKeyInfo keyInfo
          = Console.ReadKey(true);

        PrintCursor(cursorPos, 1);

        switch (keyInfo.Key)
        {
          //  -  -  -  -  - ↑↑↑ -  -  -  -  -  
          case ConsoleKey.UpArrow:
            {
              cursorPos
                = cursorPos == 1 ? (byte)7
                : cursorPos == 2 ? (byte)8
                : cursorPos == 3 ? (byte)9
                : cursorPos == 4 ? (byte)1
                : cursorPos == 5 ? (byte)2
                : cursorPos == 6 ? (byte)3
                : cursorPos == 7 ? (byte)4
                : cursorPos == 8 ? (byte)5
                : (byte)6;
            }
            break;
          //  -  -  -  -  - ↓↓↓ -  -  -  -  -  
          case ConsoleKey.DownArrow:
            {
              cursorPos
                = cursorPos == 1 ? (byte)4
                : cursorPos == 2 ? (byte)5
                : cursorPos == 3 ? (byte)6
                : cursorPos == 4 ? (byte)7
                : cursorPos == 5 ? (byte)8
                : cursorPos == 6 ? (byte)9
                : cursorPos == 7 ? (byte)1
                : cursorPos == 8 ? (byte)2
                : (byte)3;
            }
            break;
          //  -  -  -  -  - <--- -  -  -  -  -  
          case ConsoleKey.LeftArrow:
            {
              cursorPos
                = cursorPos == 1 ? (byte)3
                : cursorPos == 2 ? (byte)1
                : cursorPos == 3 ? (byte)2
                : cursorPos == 4 ? (byte)6
                : cursorPos == 5 ? (byte)4
                : cursorPos == 6 ? (byte)5
                : cursorPos == 7 ? (byte)9
                : cursorPos == 8 ? (byte)7
                : (byte)8;
            }
            break;
          //  -  -  -  -  - --> -  -  -  -  -  
          case ConsoleKey.RightArrow:
            {
              cursorPos
                = cursorPos == 1 ? (byte)2
                : cursorPos == 2 ? (byte)3
                : cursorPos == 3 ? (byte)1
                : cursorPos == 4 ? (byte)5
                : cursorPos == 5 ? (byte)6
                : cursorPos == 6 ? (byte)4
                : cursorPos == 7 ? (byte)8
                : cursorPos == 8 ? (byte)9
                : (byte)7;
            }
            break;
          //  -  -  -  -  -ENTER-  -  -  -  - 
          case ConsoleKey.Enter:
            UpdateScore(ref playerScores);
            break;
          //  -  -  -  -  - ESC -  -  -  -  - 
          case ConsoleKey.Escape:
            run = false;
            return;
        }
      }
      PrintCursor(cursorPos);
    }

    private static void UpdateScore(ref byte[] playerScores)
    {
      throw new NotImplementedException();
    }

    private static void PrintCursor
      (
      byte cursorPos, 
      byte delete = 0
      )
    {
      int w = 0, h = 0;
      switch (cursorPos)
      {
        case 1: 
          w = 2; h = 3; break;
        case 2: 
          w = 6; h = 3; break;
        case 3: 
          w = 10; h = 3; break;
        case 4: 
          w = 2; h = 5; break;
        case 5: 
          w = 6; h = 5; break;
        case 6: 
          w = 10; h = 5; break;
        case 7: 
          w = 2; h = 7; break;
        case 8: 
          w = 6; h = 7; break;
        case 9: 
          w = 10; h = 7; break;
      }
      Console.SetCursorPosition
        (w, h);
      Console.Write
        (delete == 1 ? Del[0] : Cursor[0]);
      Console.SetCursorPosition
        (w + 2, h);
      Console.Write
        (delete == 1 ? Del[1] : Cursor[1]);
    }
    static char[] Cursor = ['▶', '◀'];  // ▶▷▸▹◀◁◂◃
    static char[] Del = [' ', ' '];
    #endregion cursor

    #region playfield
    static string ConcatField(string[] playfieldLines) 
      => string.Join("\n", Playfield());
    static string[] Playfield()
    {
      int width = 12,
          height = 6;

      string[] playfieldLines 
        = new string[height + 1];

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