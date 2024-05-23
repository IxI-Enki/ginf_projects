using Ritt_4ACIFT_Abgabe.ConApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
// D:\HTL\~Software - Projekte\Visual Studio Code\[ C# ] - Projekte\
//
//          CABS-GINF\
//                         Uebung-02 -- ColorStrings\
//                                                    ColorStrings

namespace Ritt_4ACIFT_Abgabe.ConApp
{
  public class Color
  {
    // Constants:
    public const string PROGRAM_TITLE = "Uebung_02 -- ColorStrings",
                                TITLE = PROGRAM_TITLE;
    public static Semaphore semaphore = new Semaphore(1, 1); // Nur ein Thread hat Zugriff
    public static int CONSOLE_COLUMNS = Settings.GetCONSOLE_COLUMNS();
    public static int CONSOLE_ = Settings.GetCONSOLE_ROWS();

    //  -  -  -
    /// COLOR STRINGS:
    public const string ESC_SEQUENCE = "\u001b" + "[",
                                  ESC = ESC_SEQUENCE;
    //        different ESC_SEQUENCES = "\033"
    //                                = "\x1b"
    //                                = "\e"
    public const string RESET_ALL_SEQUENCE = ESC + "0m",
                                       RES = RESET_ALL_SEQUENCE;
    public static string GetSEQUENCES(int Param)
    {
      switch (Param)
      {
        case 0:
          return ESC;
        case 1:
          return RES;
      }
      return null;
    }

    // - - OUTPUT_MODE 1: - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    public static void ColorConsole(string layerInstruction, string color)
    {
      switch (layerInstruction)
      {
        // FOREGROUND
        case "foreground":
          switch (color)
          {
            case "white":
            case "WHITE":
            case "White":
              Console.ForegroundColor = ConsoleColor.White;
              break;
            case "gray":
            case "GRAY":
            case "Gray":
              Console.ForegroundColor = ConsoleColor.Gray;
              break;
            case "darkgray":
            case "DARKGRAY":
            case "DarkGray":
              Console.ForegroundColor = ConsoleColor.DarkGray;
              break;
            case "black":
            case "BLACK":
            case "Black":
              Console.ForegroundColor = ConsoleColor.Black;
              break;

            case "blue":
            case "BLUE":
            case "Blue":
              Console.ForegroundColor = ConsoleColor.Blue;
              break;
            case "darkblue":
            case "DARKBLUE":
            case "DarkBlue":
              Console.ForegroundColor = ConsoleColor.DarkBlue;
              break;
            case "red":
            case "RED":
            case "Red":
              Console.ForegroundColor = ConsoleColor.Red;
              break;
            case "darkred":
            case "DARKRED":
            case "DarkRed":
              Console.ForegroundColor = ConsoleColor.DarkRed;
              break;
            case "green":
            case "GREEN":
            case "Green":
              Console.ForegroundColor = ConsoleColor.Green;
              break;
            case "darkgreen":
            case "DARKGREEN":
            case "DarkGreen":
              Console.ForegroundColor = ConsoleColor.DarkGreen;
              break;
            case "cyan":
            case "CYAN":
            case "Cyan":
              Console.ForegroundColor = ConsoleColor.Cyan;
              break;
            case "darkcyan":
            case "DARKCYAN":
            case "DarkCyan":
              Console.ForegroundColor = ConsoleColor.DarkCyan;
              break;
            case "magenta":
            case "MAGENTA":
            case "Magenta":
              Console.ForegroundColor = ConsoleColor.Magenta;
              break;
            case "darkmagenta":
            case "DARKMAGENTA":
            case "DarkMagenta":
              Console.ForegroundColor = ConsoleColor.DarkMagenta;
              break;
            case "yellow":
            case "YELLOW":
            case "Yellow":
              Console.ForegroundColor = ConsoleColor.Yellow;
              break;
            case "darkyellow":
            case "DARKYELLOW":
            case "DarkYellow":
              Console.ForegroundColor = ConsoleColor.DarkYellow;
              break;
          }
          break;
        // BACKGROUND
        case "background":
          switch (color)
          {
            case "white":
            case "WHITE":
            case "White":
              Console.BackgroundColor = ConsoleColor.White;
              break;
            case "gray":
            case "GRAY":
            case "Gray":
              Console.BackgroundColor = ConsoleColor.Gray;
              break;
            case "darkgray":
            case "DARKGRAY":
            case "DarkGray":
              Console.BackgroundColor = ConsoleColor.DarkGray;
              break;
            case "black":
            case "BLACK":
            case "Black":
              Console.BackgroundColor = ConsoleColor.Black;
              break;

            case "blue":
            case "BLUE":
            case "Blue":
              Console.BackgroundColor = ConsoleColor.Blue;
              break;
            case "darkblue":
            case "DARKBLUE":
            case "DarkBlue":
              Console.BackgroundColor = ConsoleColor.DarkBlue;
              break;
            case "red":
            case "RED":
            case "Red":
              Console.BackgroundColor = ConsoleColor.Red;
              break;
            case "darkred":
            case "DARKRED":
            case "DarkRed":
              Console.BackgroundColor = ConsoleColor.DarkRed;
              break;
            case "green":
            case "GREEN":
            case "Green":
              Console.BackgroundColor = ConsoleColor.Green;
              break;
            case "darkgreen":
            case "DARKGREEN":
            case "DarkGreen":
              Console.BackgroundColor = ConsoleColor.DarkGreen;
              break;
            case "cyan":
            case "CYAN":
            case "Cyan":
              Console.BackgroundColor = ConsoleColor.Cyan;
              break;
            case "darkcyan":
            case "DARKCYAN":
            case "DarkCyan":
              Console.BackgroundColor = ConsoleColor.DarkCyan;
              break;
            case "magenta":
            case "MAGENTA":
            case "Magenta":
              Console.BackgroundColor = ConsoleColor.Magenta;
              break;
            case "darkmagenta":
            case "DARKMAGENTA":
            case "DarkMagenta":
              Console.BackgroundColor = ConsoleColor.DarkMagenta;
              break;
            case "yellow":
            case "YELLOW":
            case "Yellow":
              Console.BackgroundColor = ConsoleColor.Yellow;
              break;
            case "darkyellow":
            case "DARKYELLOW":
            case "DarkYellow":
              Console.BackgroundColor = ConsoleColor.DarkYellow;
              break;
          }
          break;
      }
    }
    // - - OUTPUT_MODE 2: - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    public static void ColorString(string outputInstruction, string colorInstruction, string inputString)
    {
      CONSOLE_COLUMNS = Settings.GetCONSOLE_COLUMNS();
      CONSOLE_ = Settings.GetCONSOLE_ROWS();

      if (outputInstruction == "print")
      {
        switch (Settings.OUTPUT_MODE)
        {
          case 0:
            Console.Write(inputString);
            break;

          case 1:
          case 2:
            Console.Write(ColorString(colorInstruction, inputString));
            break;
          default: /*THROW ERROR*/ break;
        }
      }
      if (outputInstruction == "printLine")
      {
        int screenWidthIndex = 0,
            colorsIndex = 0,
            red = 0, green = 0, blue = 255;

        for (int w = screenWidthIndex; w < Settings.CONSOLE_COLUMNS; w++)
        {
          switch (Settings.OUTPUT_MODE)
          {
            case 0:
              Console.Write(inputString);
              break;
            case 1:
              string[] colors = ["darkblue", "blue", "darkcyan", "cyan", "green", "darkgreen"];
              int partLength = Settings.CONSOLE_COLUMNS / colors.Length;
              ColorString("print", colors[colorsIndex], inputString);
              colorsIndex = (w % partLength == 0 && w > 0) ? colorsIndex + 1 : colorsIndex;
              break;
            case 2:
              green = green + 2; green = Math.Clamp(green, 0, 255);
              blue = blue - 2; blue = Math.Clamp(blue, 0, 255);
              ColorString("print", $"{red},{green},{blue}", inputString);
              break;
            default: /*THROW ERROR*/ break;
          }
          screenWidthIndex++;
          if (screenWidthIndex == Settings.CONSOLE_COLUMNS)
          {
            Console.WriteLine();
          }
        }
      }
      if (outputInstruction == "printRainbowLine")
      {
        int screenWidthIndex;

        int[] widthOfParts = CalculatePartWidth(CONSOLE_COLUMNS, 3);

        int colorDifference;
        int redValue = 255,
            greenValue = 0,
            blueValue = 0;
        int colorsIndex = 0;

        for (screenWidthIndex = 0; screenWidthIndex < CONSOLE_COLUMNS; screenWidthIndex++)
        {
          switch (Settings.OUTPUT_MODE)
          {
            case 0:
              Console.Write(inputString);
              break;
            case 1:
              string[] colors = ["darkred", "red", "darkyellow", "yellow", "darkgreen", "green", "cyan", "darkcyan", "blue", "darkblue", "darkmagenta", "magenta"];
              int partLength = CONSOLE_COLUMNS / colors.Length;
              ColorString("print", colors[colorsIndex], inputString);
              colorsIndex = (screenWidthIndex % partLength == 0 && screenWidthIndex > 0) ? colorsIndex + 1 : colorsIndex;
              break;
            case 2:
              if (screenWidthIndex < widthOfParts[0])
              {
                redValue = redValue - 255 / widthOfParts[0];
                greenValue = greenValue + 255 / widthOfParts[0];
                ColorString("print", $"{redValue},{greenValue},{blueValue}", inputString);
              }
              if (screenWidthIndex >= widthOfParts[0] &&
                 screenWidthIndex < widthOfParts[1] + widthOfParts[0])
              {
                greenValue = greenValue - 255 / widthOfParts[0];
                blueValue = blueValue + 255 / widthOfParts[0];
                ColorString("print", $"{redValue},{greenValue},{blueValue}", inputString);
              }
              if (screenWidthIndex >= widthOfParts[1] + widthOfParts[0])
              {
                blueValue = blueValue - 255 / widthOfParts[0];
                redValue = redValue + 255 / widthOfParts[0];
                ColorString("print", $"{redValue},{greenValue},{blueValue}", inputString);
              }
              break;
            default: /*THROW ERROR*/ break;

          }
        }
      }
      // DIFFERENT OUTPUT INSTRUCTIONS HERE
      if (outputInstruction == "printGrayScaleLine")
      {
        int redValue = 0, greenValue = 0, blueValue = 0;

        for (int screenWidthIndex = 0; screenWidthIndex < CONSOLE_COLUMNS; screenWidthIndex++)
        {
          bool upperBoundReached = blueValue > 254 ? true : false;
          bool lowerBoundReached = blueValue < 1 ? true : false;
          switch (Settings.OUTPUT_MODE)
          {
            case 0:
            case 2:
              if (screenWidthIndex < CONSOLE_COLUMNS / 2)
              {
                redValue = greenValue = blueValue = Math.Clamp(blueValue + 7, 0, 255);
              }
              else
              {
                redValue = greenValue = blueValue = Math.Clamp(blueValue - 7, 0, 255);
              }
              Color.ColorString("print", $"{redValue},{greenValue},{blueValue}", inputString);
              break;
          }
        }


      }


      Console.ResetColor();
    }

    private static int[] CalculatePartWidth(int cONSOLE_COLUMNS, int colorParts)
    {
      int[] partWidth = new int[3];
      int remainder = cONSOLE_COLUMNS % colorParts;

      for (int i = 0; i < colorParts; i++)
      { partWidth[i] = cONSOLE_COLUMNS / colorParts; }
      switch (remainder)
      {
        case 1:
          partWidth[0]++;
          break;
        case 2:
          partWidth[0]++;
          partWidth[1]++;
          break;
      }
      return partWidth;
    }

    public static string ColorString(string colorInstruction, string inputString)
    {
      string coloredString = "";
      Settings.UPDATE_CONST();
      if (Settings.OUTPUT_MODE == 0) coloredString = inputString;
      else
      {
        string instruction = String.Empty;
        string[] layers;
        if (colorInstruction.Contains(";"))
        {
          layers = colorInstruction.Split(';');
          switch (Settings.OUTPUT_MODE)
          {
            case 1:
              ColorConsole("foreground", layers[0]);
              ColorConsole("background", layers[1]);
              coloredString = inputString;
              break;
            case 2:
              string forgroundInstructions = layers[0];
              string backgroundInstructions = layers[1];
              coloredString = ColorForeground(forgroundInstructions) +
                              ColorBackground(backgroundInstructions) +
                              inputString + ColorReset();
              break;
            default: /*THROW ERROR*/ break;
          }
        }
        else
        {
          switch (Settings.OUTPUT_MODE)
          {
            case 1:
              ColorConsole("foreground", colorInstruction);
              coloredString = inputString;
              break;
            case 2:
              coloredString = ColorForeground(colorInstruction) + inputString + ColorReset();
              break;
            default: /*THROW ERROR*/ break;
          }
        }
      }
      return coloredString;
    }
    public static string ColorReset()
    {
      return RESET_ALL_SEQUENCE;
    }
    public static string ColorForeground(string colorInstruction)
    {
      return ESC_SEQUENCE + $"38;2;" + SplitColorInstruction(colorInstruction) + "m";
    }
    public static string ColorBackground(string colorInstruction)
    {
      return ESC_SEQUENCE + $"48;2;" + SplitColorInstruction(colorInstruction) + "m";
    }
    public static string SplitColorInstruction(string colorInstruction)
    {
      string instruction = " ";
      int redValue = 255,
          greenValue = 255,
          blueValue = 255;
      string[] rgbValues;
      if (colorInstruction.Contains(","))
      {
        rgbValues = colorInstruction.Split(',');
        int.TryParse(rgbValues[0], out redValue);
        int.TryParse(rgbValues[1], out greenValue);
        int.TryParse(rgbValues[2], out blueValue);
      }
      else if (colorInstruction == "red"
            || colorInstruction == "Red"
            || colorInstruction == "RED")
      { redValue = 255; greenValue = 0; blueValue = 0; }
      else if (colorInstruction == "darkred"
            || colorInstruction == "DarkRed"
            || colorInstruction == "DARKRED")
      { redValue = 75; greenValue = 0; blueValue = 0; }
      else if (colorInstruction == "orange"
            || colorInstruction == "Orange"
            || colorInstruction == "ORANGE")
      { redValue = 255; greenValue = 155; blueValue = 0; }
      else if (colorInstruction == "darkorange"
            || colorInstruction == "DarkOrange"
            || colorInstruction == "DARKORANGE")
      { redValue = 95; greenValue = 45; blueValue = 0; }
      else if (colorInstruction == "yellow"
            || colorInstruction == "Yellow"
            || colorInstruction == "YELLOW")
      { redValue = 255; greenValue = 255; blueValue = 0; }
      else if (colorInstruction == "darkyellow"
            || colorInstruction == "DarkYellow"
            || colorInstruction == "DARKYELLOW")
      { redValue = 85; greenValue = 85; blueValue = 0; }
      else if (colorInstruction == "green"
            || colorInstruction == "Green"
            || colorInstruction == "GREEN")
      { redValue = 0; greenValue = 255; blueValue = 0; }
      else if (colorInstruction == "darkgreen"
            || colorInstruction == "DarkGreen"
            || colorInstruction == "DARKGREEN")
      { redValue = 0; greenValue = 95; blueValue = 0; }
      else if (colorInstruction == "cyan"
            || colorInstruction == "Cyan"
            || colorInstruction == "CYAN")
      { redValue = 0; greenValue = 255; blueValue = 255; }
      else if (colorInstruction == "blue"
            || colorInstruction == "Blue"
            || colorInstruction == "BLUE")
      { redValue = 0; greenValue = 0; blueValue = 255; }
      else if (colorInstruction == "magenta"
            || colorInstruction == "Magenta"
            || colorInstruction == "MAGENTA")
      { redValue = 255; greenValue = 0; blueValue = 255; }
      else if (colorInstruction == "brown"
            || colorInstruction == "Brown"
            || colorInstruction == "BROWN")
      { redValue = 170; greenValue = 65; blueValue = 35; }
      else if (colorInstruction == "white"
            || colorInstruction == "While"
            || colorInstruction == "WHITE")
      { redValue = 255; greenValue = 255; blueValue = 255; }
      else if (colorInstruction == "lightgray"
            || colorInstruction == "LightGray"
            || colorInstruction == "LIGHTGRAY")
      { redValue = 100; greenValue = 100; blueValue = 100; }
      else if (colorInstruction == "gray"
            || colorInstruction == "Gray"
            || colorInstruction == "GRAY")
      { redValue = 55; greenValue = 55; blueValue = 55; }
      else if (colorInstruction == "darkgray"
            || colorInstruction == "DarkGray"
            || colorInstruction == "DARKGRAY")
      { redValue = 20; greenValue = 20; blueValue = 20; }
      else if (colorInstruction == "darkestgray"
            || colorInstruction == "DarkestGray"
            || colorInstruction == "DARKESTGRAY")
      { redValue = 12; greenValue = 12; blueValue = 12; }
      else if (colorInstruction == "black"
            || colorInstruction == "Black"
            || colorInstruction == "BLACK")
      { redValue = 0; greenValue = 0; blueValue = 0; }
      else if (colorInstruction == "IxIdarkgreen"
      || colorInstruction == "ixidarkgreen"
      || colorInstruction == "IXIDARKGREEN")
      { redValue = 0; greenValue = 70; blueValue = 33; }

      instruction = $"{redValue};{greenValue};{blueValue}";
      return instruction;
    }
    // -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
    public static int[] ExtractExistingColor(string inputString, out string unformattedString)
    {
      int[] colorValues = new int[6];
      unformattedString = "";
      switch (Settings.OUTPUT_MODE)
      {
        case 2:
          if (inputString.EndsWith("\u001b[0m"))
          {
            if (inputString.EndsWith("0m")) inputString = inputString.TrimEnd('0', 'm');

            string[] stringParts = inputString.Split("\u001b[");
            if (stringParts[1].StartsWith("38;2;")) stringParts[1] = stringParts[1].Substring(5);
            if (stringParts[2].StartsWith("48;2;")) stringParts[2] = stringParts[2].Substring(5);

            // DO SOMETHING WITH THE FOREGROUND:
            string[] foregroundParts = stringParts[1].Split(';');
            int foregroundRed = Convert.ToInt32(foregroundParts[0]); colorValues[0] = foregroundRed;
            int foregroundGreen = Convert.ToInt32(foregroundParts[1]); colorValues[1] = foregroundGreen;
            int foregroundBlue = CutASCIIInstructionFromBlue(foregroundParts[2], out string remainingText); colorValues[2] = foregroundBlue;
            /* TESTING - Output: 
             *   Console.Clear(); Console.SetCursorPosition(0, 0);
             *   Console.Write($"Rotwert-Text      : {foregroundRed}\n" +
             *                 $"Grünwert-Text     : {foregroundGreen}\n" +
             *                 $"Blauwert-Text     : {foregroundBlue}\n\n" +
             *                 $"Verbleibender Text: {remainingText}");
             *   Console.ReadLine(); */
            // DO SOMETHING WITH THE BACKGROUND:
            int backgroundRed,
                backgroundGreen,
                backgroundBlue;
            if (stringParts[2] != String.Empty)
            {
              string[] backgroundParts = stringParts[2].Split(';');
              backgroundRed = Convert.ToInt32(backgroundParts[0]); colorValues[3] = backgroundRed;
              backgroundGreen = Convert.ToInt32(backgroundParts[1]); colorValues[4] = backgroundGreen;
              backgroundBlue = CutASCIIInstructionFromBlue(backgroundParts[2], out remainingText); colorValues[5] = backgroundBlue;
            }
            /* TESTING - Output:
             * if (stringParts.Length > 1) { Console.Clear();
             *   Console.SetCursorPosition(0, 0); Console.WriteLine();
             *   Console.Write($"Rotwert-Back      : {backgroundRed}\n" +
             *                 $"Grünwert-Back     : {backgroundGreen}\n" +
             *                 $"Blauwert-Back     : {backgroundBlue}\n\n" +
             *                 $"Verbleibender Text: {remainingText}");
             *   Console.ReadLine(); } Console.ReadLine();  */
            unformattedString = remainingText;
          }
          return colorValues;
        default:
          return colorValues = null;
      }
    }
    public static int CutASCIIInstructionFromBlue(string blueValue_ANDTEXT, out string remainingText)
    {
      int blueValue,
          startOfText = FindIndexOfm(blueValue_ANDTEXT, out blueValue);
      remainingText = blueValue_ANDTEXT.Substring(startOfText);
      return blueValue;
    }
    public static int FindIndexOfm(string blueValue_ANDTEXT, out int blueValue)
    {
      bool foundM = false;
      int index = 0;
      string blueValueString = string.Empty;

      while (!foundM)
      {
        foundM = blueValue_ANDTEXT[index] == 'm' ? true : false;
        blueValueString = blueValueString + blueValue_ANDTEXT[index];
        index++;
      }
      blueValue = Convert.ToInt32(blueValueString.TrimEnd('m'));
      return index;
    }

    // -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
    public static void GetColorArray(int[] colorValues,
       out int redF, out int greenF, out int blueF, out int redB, out int greenB, out int blueB)
    {
      redF = colorValues[0];
      greenF = colorValues[1];
      blueF = colorValues[2];
      redB = colorValues[3];
      greenB = colorValues[4];
      blueB = colorValues[5];
    }

    // - - ANIMATE STRING: - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    public static void AnimateString(int coordinateW, int coordinateH, string animationInstruction, int duration, string inputString)
    {
      Thread animate = new Thread(() =>
      {
        semaphore.WaitOne(); // Warte auf Erlaubnis
        AnimateStrings(1, 0, "fadeOut", 3, inputString);
        semaphore.Release(); // Freigeben für den nächsten Thread
      });
      animate.Start();
    }
    public static void AnimateStrings(int coordinateW, int coordinateH, string animationInstruction, int steps, string inputString)
    {
      if (animationInstruction == "fadeOut")
        FadeOutString(coordinateW, coordinateH, steps, inputString);
      if (animationInstruction == "blink")
        BlinkString(coordinateW, coordinateH, steps, inputString);
      if (animationInstruction.StartsWith("wandering"))
        WanderString(coordinateW, coordinateH, steps, inputString);
    }

    private static void WanderString(int coordinateW, int coordinateH, int steps, string inputString)
    {
      TEST_CLASS.WanderString(coordinateW, coordinateH, steps, inputString);
    }
    // -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
    public static void FadeOutString(int coordinateW, int coordinateH, int steps, string inputString)
    {
      if (Settings.OUTPUT_MODE == 2)
      {
        int[] colorValues = ExtractExistingColor(inputString, out string unformattedString);
        GetColorArray(colorValues, out int redF, out int greenF, out int blueF, out int redB, out int greenB, out int blueB);
        int maxValue = colorValues.Max();
        int stepSize = steps < 0 ?
           -maxValue / steps : maxValue / steps;

        bool hitBackground = false;
        while (!hitBackground)
        {
          Thread.Sleep(2);
          Console.SetCursorPosition(coordinateW, coordinateH);
          ColorString("print", $"{redF},{greenF},{blueF};{redB},{greenB},{blueB}", unformattedString);
          ChangeHue(-stepSize, ref redF, ref greenF, ref blueF, ref redB, ref greenB, ref blueB);
          hitBackground = CheckIfFadedOut(redF, greenF, blueF, redB, greenB, blueB);
        }
      }
    }
    public static bool CheckIfFadedOut(int redF, int greenF, int blueF, int redB, int greenB, int blueB)
    {
      bool hitBackground = false;

      if (redF < 13 && greenF < 13 && blueF < 13 &&
        redB < 13 && greenB < 13 && blueB < 13)
        hitBackground = true;

      return hitBackground;
    }
    public static void ChangeHue(int changingAmount, ref int redF, ref int greenF, ref int blueF, ref int redB, ref int greenB, ref int blueB)
    {
      redF += changingAmount;
      greenF += changingAmount;
      blueF += changingAmount;
      redB += changingAmount;
      greenB += changingAmount;
      blueB += changingAmount;
      redF = Math.Clamp(redF, 12, 255);
      greenF = Math.Clamp(greenF, 12, 255);
      blueF = Math.Clamp(blueF, 12, 255);
      redB = Math.Clamp(redB, 12, 255);
      greenB = Math.Clamp(greenB, 12, 255);
      blueB = Math.Clamp(blueB, 12, 255);
    }
    // -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
    public static void BlinkString(int coordinateW, int coordinateH, int steps, string inputString)
    {
      int[] savedColorValues = ExtractExistingColor(
                                 inputString,
                                 out string unformattedString);
      GetColorArray(
        savedColorValues,
          out int redF,
          out int greenF,
          out int blueF,
          out int redB,
          out int greenB,
          out int blueB);

      int stepsize = steps < 0 ? savedColorValues.Max() / steps : savedColorValues.Max() / steps;

      ChangeHue(stepsize, ref redF, ref greenF, ref blueF, ref redB, ref greenB, ref blueB);
      Console.SetCursorPosition(coordinateW, coordinateH);
      ColorString("print", $"{redF},{greenF},{blueF};{redB},{greenB},{blueB}", unformattedString);
    }
  }
}
