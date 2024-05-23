using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ritt_4ACIFT_Abgabe.ConApp
{
  public class TEST_02_Color
  {


    // - -NEW TO IMPLEMENT- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    public static void INSTRUCTIONS()
    {

    byte PRINT = 1,
          LINE = 1;

    byte[] printInstructions = [PRINT, LINE];


      string[,] InstructionsCOLOR;
    }



    public static string ColorString(string colorInstruction, string stringToColor)
    {
      return stringToColor;
    }
    public static void ColorString(string outputInstruction, string colorInstruction, string stringToColor)
    {
      sbyte
        PRINT = (sbyte)(outputInstruction.Contains("print") || outputInstruction.Contains("Print") ? 1 : 0),
        LINE = (sbyte)(outputInstruction.Contains("line") || outputInstruction.Contains("Line") ? 1 : 0);
      //   GRAYSCALE = (sbyte)(outputInstruction.Contains("grayscale") || outputInstruction.Contains("GrayScale") ? 1 : 0);
      //   sbyte[] INSTRUCTION = [PRINT, LINE, GRAYSCALE];
      string output = string.Empty;
      if (LINE == 1)
        output += ColorLine(outputInstruction, colorInstruction, stringToColor);
      if (PRINT == 1)
      {
        output += ColorString(colorInstruction, stringToColor);
        Console.Write(output);
      }
    }

    public static string ColorLine(string outputInstruction, string colorInstruction, string stringToColor)
    {
      sbyte
        PRINT = (sbyte)(outputInstruction.Contains("print") || outputInstruction.Contains("Print") ? 1 : 0),
        GRAYSCALE = (sbyte)(outputInstruction.Contains("grayscale") || outputInstruction.Contains("GrayScale") ? 1 : 0);
      return DoFor_ConsoleWidth((sbyte)(GRAYSCALE == 0 ? 0 : 1), colorInstruction, stringToColor);
    }

    public static string DoFor_ConsoleWidth(sbyte grayScale, string colorInstruction, string stringToColor)
    {
      string output = string.Empty;
      for (int w = 0; w < Settings.CONSOLE_COLUMNS; w++)
      {
        if (grayScale == 0)
          output += (colorInstruction + stringToColor);
     //   else if (grayScale == 1)
   //       output += 
      }
      return output;
    }



    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
    public static void TEST_parameter_Amount(string nameOfMethod)
    {
      MethodInfo methodInfo = typeof(Color).GetMethod(nameOfMethod);
      // Get the parameters of the method
      ParameterInfo[] parameters = methodInfo.GetParameters();
      // Get the number of parameters
      int parameterCount = parameters.Length;
      Console.Write($"\nNumber of parameters in {nameOfMethod}: " + parameterCount);
    }
    /*
    public static void ColorString(string outputInstruction, string colorInstruction, string inputString, int posW, int posH) { }
    public static string ColorString(string colorInstruction, string inputString, int posW, int posH)
    { return ""; }

    public static void ColorString(string outputInstruction, string colorInstruction, string inputString) { }
    public static string ColorString(string colorInstruction, string inputString)
    {
      string outputSting = inputString;
      return outputSting;
    }
    */

  }
}
