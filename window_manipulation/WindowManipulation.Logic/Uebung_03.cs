using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// D:\HTL\~Software - Projekte\Visual Studio Code\[ C# ] - Projekte\
//
//          CABS-GINF\
//                         Uebung-03 -- Menu\
//                                            Menu       

namespace Ritt_4ACIFT_Abgabe.ConApp
{
  public class Menus
  {
    // Constants:
    public const string PROGRAM_TITLE = "Uebung_03 -- Menus",
                                TITLE = PROGRAM_TITLE;
    public static Semaphore semaphore = new Semaphore(1, 1); // Nur ein Thread hat Zugriff
    //  -  -  -


    // MENU: 
    public static void ClearMenu(int startPointWidth, int startPointHeight, string[] menuPoints)
    {
      string clearString = "",
             cursorWidth = "  ";
      clearString = cursorWidth + clearString + cursorWidth;

      for (int m = 0; m < menuPoints.Length; m++)
      {
        for (int l = 0; l < menuPoints[m].Length; l++)
        {
          clearString += " ";
        }
        Console.SetCursorPosition(startPointWidth, startPointHeight + m);
        Console.Write(clearString);
      }
    }
    public static void Menu(int startPointWidth, int startPointHeight, params string[] menuPoints)
    {
      int choice = 0;
      string actualPoints;
      string[] cursor = [Color.ColorString("red", "> "), Color.ColorString("red", " <")];
      do
      {
        Settings.MenuSetting();
        //ClearMenu(startPointWidth, startPointHeight, menuPoints);
        Thread thread = new Thread(() =>
        {
          semaphore.WaitOne(); // Warte auf Erlaubnis
          for (int m = 0; m < menuPoints.Length; m++)
          {
            if (choice == m)
              actualPoints = cursor[0] + Color.ColorString("white;blue", menuPoints[m]) + cursor[1];
            else
              actualPoints = "  " + menuPoints[m] + "  ";

            Console.SetCursorPosition(startPointWidth, startPointHeight + m);
            Console.Write(actualPoints);
          }
          semaphore.Release(); // Freigeben für den nächsten Thread
        });
        thread.Start();
        UserChoice(ref choice, menuPoints);

      } while (choice >= 0);
    }

    public static void UserChoice(ref int choice, params string[] menuPoints)
    {
      string pressedKey = "";
      ConsoleKeyInfo keyInfo = Console.ReadKey(true);

      switch (keyInfo.Key)
      {
        // ARROW UP
        case ConsoleKey.UpArrow:
        case ConsoleKey.W:
          choice--;
          choice = (choice < 0) ? menuPoints.Length - 1 : choice;
          pressedKey = Color.ColorString("black;yellow", "⬆");
          break;

        // ARROW DOWN
        case ConsoleKey.DownArrow:
        case ConsoleKey.S:
          choice++;
          choice = (choice > menuPoints.Length - 1) ? 0 : choice;
          pressedKey = Color.ColorString("black;yellow", "⬇");
          break;

        // ENTER
        case ConsoleKey.Enter:
        case ConsoleKey.E:
          // DoMenuPoint(choice, menuPoints[choice]);
          Choose(choice, menuPoints);
          pressedKey = Color.ColorString("black;green", "⏎");
          break;

        // ESCAPE
        case ConsoleKey.Escape:
        case ConsoleKey.Q:
          pressedKey = Color.ColorString("black;darkred", "ESC");
          Console.Clear();
          choice = -1;
          Null.ExitProgram();
          return;
      }
      Console.SetCursorPosition(0, 0);
      Color.ColorString("print", "yellow;black", pressedKey);
    }
    public static void Choose(int choice, string[] menuPoints)
    {
      DoMenuPoint(choice, menuPoints[choice]);
      Console.Clear();
    }
    public static void DoMenuPoint(int choice, string chosenPoint)
    {
      if (chosenPoint.Contains("Pause"))
        PrintPauseScreen();
      if (chosenPoint.Contains("Nothing"))
        PrintNothingness();
      //   if (chosenPoint.Contains("ThreeThree"))
      //     Illuminate_33();
      if (chosenPoint.Contains("logo"))
      {
        Draw.LogoPrinter();
      }
      if (chosenPoint.Contains("owl"))
      {
        Draw.OwlPrinter();
      }
      if (chosenPoint.Contains("OutputMode"))
      {
        Settings.PromptOutputMode(out int mode);
        Settings.OUTPUT_MODE = mode;
      }
      if (chosenPoint.Contains("Exit"))
      {
        Null.ExitProgram();
      }

    }

    public static void PrintNothingness()
    {
      int[] colorValues = null;
      string unformattedString;
      Console.Clear();
      Console.SetWindowSize(Settings.CONSOLE_COLUMNS, Settings.CONSOLE_ROWS);
      // TEST EXTRACT COLOR:
      string test01 = Color.ColorString("red;blue", "ROT + BLAU");
      Console.Write(test01 + "\n");
      colorValues = Color.ExtractExistingColor(test01, out unformattedString);
      for (int c = 0; c < colorValues.Length; c++) Console.Write($"Value{c}: {colorValues[c]}\n");
      Console.Write("\nRemaining Text: " + unformattedString);
      Console.ReadLine();


      Console.WriteLine("\n\nNur Textfarbe:");
      string test02 = Color.ColorString("199,240,87", "Irgrendwos");
      Console.Write(test02 + "\n");
      colorValues = Color.ExtractExistingColor(test02, out unformattedString);
      for (int c = 0; c < colorValues.Length; c++) Console.Write($"Value{c}: {colorValues[c]}\n");
      Console.Write("\nRemaining Text: " + unformattedString);
      Console.ReadLine();

    }
    public static void PrintPauseScreen()
    {
      Console.Clear();
      string[] pauseScreenLines = [
        //  ___  ____ _  _ ____ ____    ____ ____ ____ ____ ____ _  _
        //  |__] |__| |  | [__  |___ __ [__  |    |__/ |___ |___ |\ |
        //  |    |  | |__| ___] |___    ___] |___ |  \ |___ |___ | \| 

        "            ___  ____ _  _ ____ ____    ____ ____ ____ ____ ____ _  _              " + "\n",
        "            |__] |__| |  | [__  |___ __ [__  |    |__/ |___ |___ |\\ |              " + "\n",
        "            |    |  | |__| ___] |___    ___] |___ |  \\ |___ |___ | \\|              " + "\n",
        "                                                                                   "
      ];
      Settings.SetPauseScreen(pauseScreenLines[0].Length, pauseScreenLines.Length + 5);
      //  Settings.SetPauseScreen(91, 9);
      Stopwatch sw = new Stopwatch();
      sw.Start();
      byte t = 250;
      int countDown = 0;
      do
      {
        Settings.SetCONSOLE_TRSP(t);
        if (ESC_pressed()) break;
        Console.CursorVisible = false;
        PauseScreen(sw, pauseScreenLines);
        t = Math.Clamp(countDown < 25 ? (byte)(t - 5) : (byte)(t + 5), (byte)50, (byte)250);
        countDown = (countDown + 1) % 60;
      } while (true);
      sw.Stop();
    }
    public static void PauseScreen(Stopwatch sw, string[] screenLines)
    {

      Console.SetCursorPosition(0, 0);
      Color.ColorString("printGrayScaleLine", "", "⍊");  // ∸⍑⍊▒
      Console.SetCursorPosition(0, 5);
      Color.ColorString("printRainbowLine", "", "⍑");
      string escMsg = "  Escape  -  Pause beenden  ";
      //Settings.CONSOLE_COLUMNS = Settings.GetConstantINT(1);
      Console.SetCursorPosition((Settings.CONSOLE_COLUMNS - escMsg.Length) / 2, 6);

      if (Settings.OUTPUT_MODE == 2)
      {
        Console.Write(Color.ColorString("gray;12,12,12", escMsg) + Color.ColorString("114,0,43;22,22,22", ConcatTime(sw.ElapsedMilliseconds)));
        Color.AnimateStrings(0, 1, "fadeOut", 55, Color.ColorString("0,220,144;11,51,92", String.Concat(screenLines)));
      }
      else
      {
        Console.Write(escMsg + ConcatTime(sw.ElapsedMilliseconds));
        Console.SetCursorPosition(0, 1);
        Console.Write(String.Concat(screenLines));
      }
      Thread.Sleep(20);
    }
    public static string ConcatTime(long elapsedMilliseconds)
    {
      TimeSpan ts = TimeSpan.FromMilliseconds(elapsedMilliseconds);
      // Formatieren der Zeitangabe
      return $"{(int)ts.TotalHours:D2}h:{ts.Minutes:D2}m:{ts.Seconds:D2}s";
    }

    public static bool ESC_pressed()
    {
      if (Console.KeyAvailable)
      {
        ConsoleKeyInfo key = Console.ReadKey(true); // Benutzereingabe lesen
        if (key.Key == ConsoleKey.Escape)
        {
          Settings.MenuSetting();

          return true; // Schleife beenden, wenn die Escape-Taste gedrückt wurde
        }
      }
      return false;
    }
    public static bool F1_pressed()
    {
      if (Console.KeyAvailable)
      {
        ConsoleKeyInfo key = Console.ReadKey(true); // Benutzereingabe lesen
        if (key.Key == ConsoleKey.F1)
        {
          return true; // Schleife beenden, wenn die Escape-Taste gedrückt wurde
        }
      }
      return false;
    }

  }
}
