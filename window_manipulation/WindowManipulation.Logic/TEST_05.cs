using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Ritt_4ACIFT_Abgabe.ConApp
{
  public class TEST_05_ConsoleElements
  {
    public static void TESTelements()
    {
      Settings.OUTPUT_MODE = 2;
      bool testPASSED;
      TESTattributes(out testPASSED);
      TESTelementIndexLength(out testPASSED);
      TESTlambdaGetConsoleSizeInChars(out testPASSED);
      TESTsetConsoleELEMENTS(out testPASSED);

    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
    public static void TESTsetConsoleELEMENTS(out bool testPASSED)
    {
      ConsoleElements.SetConsoleELEMENTS();
      string[,,,] tested = ConsoleElements.consoleElements;
      string[,,,] expected = new string[
        Console.WindowWidth * Console.WindowHeight,
        Console.WindowWidth,
        Console.WindowHeight,
        ConsoleElements.attributes.Length
        ];
      testPASSED = false;
      Color.ColorString("print", "black;orange", "TEST consoleElements:");
      for (int d = 0; d < expected.Rank; d++)
      {
        testPASSED = expected.GetLength(d) == tested.GetLength(d) ? true : false;
        Console.Write($"\n -Länge der {d}.Dimension: " +
          $"{Color.ColorString("orange", expected.GetLength(d).ToString())} \n\twurde erwartet und " +
          $"{(testPASSED ? $"{Color.ColorString("green", "RICHTIG")}" : $"{Color.ColorString("red", "FALSCH")}")}" +
          $"{(testPASSED ? "" : $"{Color.ColorString("red", " [" + tested.GetLength(d).ToString() + "]")}")}" +
          " zurückgegeben.");
      }
      TEST_00_Null.PrintTestSeperator(testPASSED);
    }
    //    public static Func<int> horizontalElements = () => Console.WindowWidth;
    //    public static Func<int> verticalElements = () => Console.WindowHeight;
    private static void TESTlambdaGetConsoleSizeInChars(out bool testPASSED)
    {
      int[] expected = { Console.WindowWidth, Console.WindowHeight };
      int[] tested = { ConsoleElements.horizontalElements(), ConsoleElements.verticalElements() };
      testPASSED = false;
      Color.ColorString("print", "black;orange", "TEST Lambda GetConsoleSize:");
      for (int t = 0; t < 2; t++)
      {
        testPASSED = tested[t] == expected[t] ? true : false;
        Console.Write($"\n -{(t == 0 ? "Horizontale / Breite" : "Verticale / Höhe    ")}: " +
          $"{Color.ColorString("orange", expected[t].ToString())} \n\twurde erwartet und " +
          $"{(testPASSED ? $"{Color.ColorString("green", "RICHTIG")}" : $"{Color.ColorString("red", "FALSCH")}")}" +
          $"{(testPASSED ? "" : $"{Color.ColorString("red", " [" + tested[t].ToString() + "]")}")}" +
          " zurückgegeben.");
      }
      TEST_00_Null.PrintTestSeperator(testPASSED);
    }
    //    public static int[] elementIndex = new int[GetConsoleSizeInChars()];
    public static void TESTelementIndexLength(out bool testPASSED)
    {
      int[] expected = new int[Console.WindowWidth * Console.WindowHeight];
      Color.ColorString("print", "black;orange", "TEST elementIndexes - Length:");
      testPASSED = ConsoleElements.elementIndex.Length == expected.Length ? true : false;
      Console.Write($"\n -IndexLänge: {Color.ColorString("orange", expected.Length.ToString())} \n\twurde erwartet und " +
          $"{(testPASSED ? $"{Color.ColorString("green", "RICHTIG")}" : $"{Color.ColorString("red", "NICHT richtig")}")}" +
          " zurückgegeben.");
      TEST_00_Null.PrintTestSeperator(testPASSED);
    }

    public static void TESTattributes(out bool testPASSED)
    {
      string[] expected = [
        "[0] - empty.Null",
        "[1] - charToPrint",
        "[2] - foregroundColor",
        "[3] - backgroundColor",
        "[4] - printStatus",
        "[5] - logicStatus",
        "[6] - empty.Buffer"
      ];
      int a = 0;
      Color.ColorString("print", "black;orange", "\n TEST attributes:");
      do
      {
        testPASSED = ConsoleElements.attributes[a] == expected[a] ? true : false;
        Console.Write($"\n -Attribute-{a}: {Color.ColorString("orange", expected[a])} \n\twurde erwartet und " +
          $"{(testPASSED ? $"{Color.ColorString("green", "RICHTIG")}" : $"{Color.ColorString("red", "NICHT richtig")}")}" +
          " zurückgegeben.");
        a++;
      } while (testPASSED && a < expected.Length);
      TEST_00_Null.PrintTestSeperator(testPASSED);
    }

  }
}
