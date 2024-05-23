using System;
using System.Drawing;
using System.Diagnostics;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using System.Reflection.Metadata;
using System.Xml.Linq;
// D:\HTL\~Software - Projekte\Visual Studio Code\[ C# ] - Projekte\
//
//          CABS-GINF\
//                         000 -- Opus\

namespace Ritt_4ACIFT_Abgabe.ConApp
{
  internal class MainProgram
  {
    // Constants:
    public const string PROGRAM_TITLE = "CABS GINF JAN",
                                TITLE = PROGRAM_TITLE;
    static Semaphore semaphore = new Semaphore(1, 1); // Nur ein Thread hat Zugriff

    static void Main()
    {
      /*
      TEST_CLASSES.ElementsDEMO();
      TEST_CLASSES.SettingsDEMO();
      */
      Console.OutputEncoding = Encoding.UTF8;
      Settings.SetConsoleSettings(-1);

      Null.PrintHeader(PROGRAM_TITLE);
      Color.ColorString("printRainbowLine", "", "=");

      Console.ReadLine();
      Draw.LogoPrinter();
      // ConsoleElements.DEMO();
      //Settings.InitConsole();
      // Settings.SetConsoleSettings();
      // Console.WriteLine("TEST");
      Console.Clear();
      Menus.Menu(1, 1, "Pause", "OutputMode", "logo", "owl", "Exit");
    }

  }
}
