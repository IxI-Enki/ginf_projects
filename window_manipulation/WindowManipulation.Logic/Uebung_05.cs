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
//                     Uebung_05 -- ConsoleElements\
//                                                   ConsoleElements

namespace Ritt_4ACIFT_Abgabe.ConApp
{
  public class ConsoleElements
  {
    // CONSOLE ELEMENTS:  (chars to print on screen + instructions for color and logic.. e.g animate etc..)
    // consoleELEMENTS [ elementIndex , posW , posY, attributes ]
    public static string[,,,] consoleElements = null;
    public static string[,,,] clearSCREEN = null;
    // - elementIndex
    public static Func<int> horizontalElements = () => Console.WindowWidth;
    public static Func<int> verticalElements = () => Console.WindowHeight;
    public static int GetConsoleSizeInChars() => horizontalElements() * verticalElements();
    public static int[] elementIndex = new int[GetConsoleSizeInChars()];
    // - posW
    public static int[] posW = new int[horizontalElements()];
    // - posH
    public static int[] posH = new int[verticalElements()];
    // - attributes: [0] - empty Null Cell (Debug)
    //               [1] - char to be shown
    //               [2] - foreground color
    //               [3] - background color
    //               [4] - status of updating / printing => 0=ignore -1=clear 1=print
    //               [5] - logic to be applied => 0=static 1=animate 
    //               [6] - empty Buffer Cell (e.g. further attributes)
    public static string[] attributes = [
      "[0] - empty.Null",
      "[1] - charToPrint",
      "[2] - foregroundColor",
      "[3] - backgroundColor",
      "[4] - printStatus",
      "[5] - logicStatus",
      "[6] - empty.Buffer"
      ];
    // 


    public static void SetConsoleELEMENTS()
    {
      consoleElements = new string[
                   elementIndex.Length,
                   posW.Length,
                   posH.Length,
                   attributes.Length
                   ];
    }




    private static void SetPrintStatus(int w, int h) { WriteToElement(w, h, 3, "1"); }
    private static void SetClearStatus(int w, int h) { WriteToElement(w, h, 3, "-1"); }

    public static void RunLogic()
    {
      bool run = true;
      do
      {
        PrintElements(consoleElements);
        EvolveElements(consoleElements);
        //    Frames();
      } while (run);
    }
    private static void EvolveElements(string[,,,] elements)
    {
      int[] elementsToEvolve = FindElements(elements);

      for (int e = 0; e < elementsToEvolve.Length; e++)
      {
        ApplyLogic(elementsToEvolve, elements);
      }
    }
    private static void ApplyLogic(int[] elementsToEvolve, string[,,,] elements)
    {
      for (int e = 0; e < elementsToEvolve.Length; e++)
      {
        string instruction = ExtractInstructions(elementsToEvolve[e], elements);
        switch (instruction)
        {
          case "":
          case "0":
            break;
          case "1":
            break;
        }
      }
    }
    private static string ExtractInstructions(int elementsToEvolve, string[,,,] elements)
    {
      int[] coordinates = GetCoordinates(elementsToEvolve);
      int w = coordinates[0],
          h = coordinates[1];
      int e = GetElementIndex(w, h);
      return elements[e, w, h, 5];
    }
    private static int[] FindElements(string[,,,] elements)
    {
      int[] elementIndexes = null;
      int i = 0;

      for (int h = 0; h < verticalElements(); h++)
        for (int w = 0; w < horizontalElements(); w++)
        {
          int e = GetElementIndex(w, h);
          switch (elements[e, w, h, 5])
          {
            case "0":
              break;

            // APPLY LOGIC
            case "1":
              elementIndexes[i] = e;
              i++;
              break;
          }
        }
      return elementIndexes;
    }


    public static string clearF = "white";
    public static string clearB = "black";
    public static void InitiateElements()
    {
      ClearElements(out clearSCREEN);

      consoleElements = new string[horizontalElements() * verticalElements(), horizontalElements(), verticalElements(), attributes.Length];
      string foregroundINIT = "red",
             backgroundINIT = "green";
      int elementIndex = 0;

      for (int h = 0; h < verticalElements(); h++)
        for (int w = 0; w < horizontalElements(); w++)
        {

          consoleElements[elementIndex, w, h, 0] = elementIndex.ToString();
          SetChar(w, h, "x");
          SetForeground(w, h, foregroundINIT);
          SetBackground(w, h, backgroundINIT);
          SetPrintStatus(w, h);
          elementIndex++;
        }
    }
    private static void SetChar(int w, int h, string charToPrint) { WriteToElement(w, h, 1, charToPrint); }
    private static void SetForeground(int w, int h, string colorF) { WriteToElement(w, h, 2, colorF); }
    private static void SetBackground(int w, int h, string colorB) { WriteToElement(w, h, 3, colorB); }
    private static void WriteToElement(int w, int h, int a, string s)
    {
      int e = GetElementIndex(w, h); consoleElements[e, w, h, a] = s;
    }

    public static int GetElementIndex(int w, int h)
    { return h <= 0 ? w : h * consoleElements.GetLength(1) + w; }
    public static int[] GetCoordinates(int elementIndex)
    {
      int[] coordinates = null;
      coordinates[0] = elementIndex % consoleElements.GetLength(1);
      coordinates[1] = elementIndex / consoleElements.GetLength(1);
      return coordinates;
    }

    public static void DEMO()
    {

      Settings.SetConsoleSettings();
      InitiateElements();

      PrintElements(consoleElements);
      Console.ReadLine();

      PrintClearScreen();
      Console.ReadLine();
    }
    private static void PrintClearScreen()
    {
      PrintElements(clearSCREEN);
    }
    public static void ClearElements(out string[,,,] clearSCREEN)
    {
      int eLementIndex = 0;
      clearSCREEN = new string[elementIndex.Length, horizontalElements(), verticalElements(), attributes.Length];
      for (int h = 0; h < verticalElements(); h++)
        for (int w = 0; w < horizontalElements(); w++)
        {
          clearSCREEN[eLementIndex, w, h, 0] = elementIndex.ToString();
          clearSCREEN[eLementIndex, w, h, 1] = " ";
          clearSCREEN[eLementIndex, w, h, 2] = clearF;
          clearSCREEN[eLementIndex, w, h, 3] = clearB;
          clearSCREEN[eLementIndex, w, h, 4] = "-1";
          eLementIndex++;
        }
    }
    public static void PrintElements(string[,,,] screenElements)
    {
      string SCREEN = string.Empty;
      for (int h = 0; h < verticalElements(); h++)
      {
        for (int w = 0; w < horizontalElements(); w++)
        {
          int e = GetElementIndex(w, h);
          SCREEN += Color.ColorString($"{screenElements[e, w, h, 1]};{screenElements[e, w, h, 2]}", screenElements[e, w, h, 0]);
        }
        SCREEN += h < verticalElements() - 1 ? "\n" : "";
      }
      Console.SetCursorPosition(0, 0); Console.Write(SCREEN);
    }



  }
}