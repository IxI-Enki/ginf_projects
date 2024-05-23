using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// D:\HTL\~Software - Projekte\Visual Studio Code\[ C# ] - Projekte\
//
//          CABS-GINF\
//                         Uebung-00 -- null\
//                                           

namespace Ritt_4ACIFT_Abgabe.ConApp
{
  public class Null
  {
    // Constants:
    public const string PROGRAM_TITLE = "Uebung_00 -- Null",
                                TITLE = PROGRAM_TITLE;
    public static Semaphore semaphore = new Semaphore(1, 1); // Nur ein Thread hat Zugriff

    // SYSTEM:
    public static void PrintHeader()
    {
      PrintHeader("40,242,78;ixidarkgreen", TITLE);
    }
    public static void PrintHeader(string title)
    {
      PrintHeader("40,242,78;ixidarkgreen", title);
    }
    public static void PrintHeader(string colorInstruction, string title)
    {
      Console.Clear();
      Console.SetCursorPosition(0, 0);
      int spacing = (Settings.CONSOLE_COLUMNS - title.Length) / 2;
      string spacingLeft = "";

      for (int w = 0; w < spacing; w++)
      {
        spacingLeft += " ";
      }

      if (Settings.OUTPUT_MODE == 1) colorInstruction = "cyan;darkcyan";
      string coloredTITLE = Color.ColorString(colorInstruction, title);

      Console.Write(spacingLeft + coloredTITLE);
      Console.SetCursorPosition(0, 1);
      Color.ColorString("printLine", colorInstruction, "_");
    }

    public static void ExitProgram()
    {
      Console.Clear();
      Settings.OutroSetting();
      string escapeNotation = "Beendet";
      Color.AnimateStrings((Settings.GetCONSOLE_COLUMNS() / 2) - (escapeNotation.Length / 2), 1, "fadeOut", 60, Color.ColorString("red;darkred", escapeNotation));

      ExitProgram("outro");
      ExitProgram(0);
      ExitProgram("goodbye");
      ExitProgram(1);
    }
    public static void ExitProgram(string part)
    {
      switch (part)
      {
        case "outro":
          // Console.SetCursorPosition(0, Settings.GetCONSOLE_COLUMNS() - 3);
          // Color.ColorString("printLine", "", "̿");
          Console.SetCursorPosition(1, 4);
          Color.ColorString("print", "201,86,0", "Eingabetaste zum verlassen drücken..");
          Color.AnimateStrings(1, 1, "fadeOut", 50, Color.ColorString("46,201,86", "made by Jan Ritt"));
          break;
        case "goodbye":
          Console.Clear();
          Color.AnimateStrings(1, 4, "fadeOut", 15, Color.ColorString("red", "Eingabetaste"));
          Color.AnimateStrings((Settings.CONSOLE_COLUMNS - 4) / 2, 1, "fadeOut", 35, Color.ColorString("darkgreen", "verlassen"));
          return;
      }
    }
    public static void ExitProgram(int await)
    {
      if (await == 0)
      {
        bool abort = true;
        do
        {
          string color = "red;50,0,0";
          ConsoleKeyInfo keyInfo = Console.ReadKey(true);
          switch (keyInfo.Key)
          { case ConsoleKey.Enter: abort = false; break; default: break; }
          if (abort)
          {
            Color.AnimateStrings(1, 4, "fadeOut", 45, Color.ColorString("black;red", "Eingabetaste"));
            Color.AnimateStrings(14, 4, "fadeOut", 55, Color.ColorString(color, $"zum verlassen drücken.."));
            //            Thread.Sleep(200);
            Console.SetCursorPosition(1, 4);
            Color.ColorString("print", "red;12,12,12", "Eingabetaste");
          }
        } while (abort);
      }
      if (await == 1) Environment.Exit(0);
    }


  }
}
