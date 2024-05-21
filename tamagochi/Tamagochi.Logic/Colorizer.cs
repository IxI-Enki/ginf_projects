using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using IxIGotchi;
using Gotchi;
using System.Linq;

namespace Gotchi
{
  //*‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗ • COLORIZER  ‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗*//

  /// <summary>
  /// DE : Die Colorizer-Klasse bietet Methoden zum Einfärben von Konsolentext mit Vorder- und Hintergrundfarben.
  /// </summary>
  // <summary>
  // EN : Colorizer class provides methods for coloring console text with foreground and background colors.
  // </summary>
  public class Colorizer()
  { //*-----------------------------------------------------------------------------------------*//
    /// <summary>
    /// DE : ColorString(string inputText) 
    /// ━━━━━▶ färbt den angegebenen Eingabetext basierend auf RGBF- und RGBB-Farbdefinitionen ein.
    /// </summary>
    /// <param name="inputText">
    /// Der zu färbende Eingabetext.
    /// </param>
    /// <returns>
    /// Eine Zeichenkette, die den eingefärbten Text enthält.
    /// </returns>
    // <summary>
    // EN : ColorString(string inputText) colors the specified input text based on RGBF and RGBB color definitions.
    // </summary>
    // <param name="inputText">
    // The input text to be colored.
    // </param>
    // <returns>
    // A string containing the colored text.
    // </returns>
    public string ColorString
      (string inputText)
    { //
      if (ContainsRGBF(inputText))
      { // 
        inputText = ColorStringForeground(inputText);
      }
      if (ContainsRGBB(inputText))
      { // 
        inputText = ColorStringBackground(inputText);
      }

      return new string(inputText);
    }


    /* - - - - - - - - - - - - - CHECK: if an rgb-def is present - - - - - - - - - - - - - - - - */
    /// <summary>
    /// DE : ContainsRGBB(string input) 
    /// ━━━━━▶ überprüft, ob der Eingabetext RGBB-Farbdefinitionen enthält.
    /// </summary>
    /// <param name="input">
    /// Der zu überprüfende Eingabetext.
    /// </param>
    /// <returns>
    /// True, wenn RGBB-Farbdefinitionen vorhanden sind, sonst False.
    /// </returns>
    // <summary>
    // EN : ColorString(string inputText) colors the specified input text based on RGBF and RGBB color definitions.
    // </summary>
    // <param name="inputText">
    // The input text to be colored.
    // </param>
    // <returns>
    // A string containing the colored text.
    // </returns>
    static bool ContainsRGBF
      (string input)
    { return input.Contains("ℝ") && input.Contains("₲"); }
    /// <summary>
    /// DE : ContainsRGBF(string input) 
    /// ━━━━━▶ überprüft, ob der Eingabetext RGBF-Farbdefinitionen enthält.
    /// </summary>
    /// <param name="input">
    /// Der zu überprüfende Eingabetext.
    /// </param>
    /// <returns>
    /// True, wenn RGBF-Farbdefinitionen vorhanden sind, sonst False.
    /// </returns>
    // <summary>
    // EN : ContainsRGBB(string input) checks if the input text contains RGBB color definitions.
    // </summary>
    // <param name="input">
    // The input text to be checked.
    // </param>
    // <returns>
    // True if RGBB color definitions are present, otherwise false.
    // </returns>
    static bool ContainsRGBB
      (string input)
    { return input.Contains("rgbB[") && input.Contains("]"); }


    /*-------------------------- VORDERGRUND -----------------------------------------------------*/
    /// <summary>
    /// DE : ColorStringForeground(string inputText) 
    /// ━━━━━▶ färbt den Vordergrund des Eingabetexts basierend auf RGBF-Farbdefinitionen ein.
    /// </summary>
    /// <param name="inputText">
    /// Der zu färbende Eingabetext.
    /// </param>
    /// <returns>
    /// Eine Zeichenkette, die den eingefärbten Text mit Vordergrundfarben enthält.
    /// </returns>
    //*-------------------------- FOREGROUND -----------------------------------------------------*/
    // <summary>
    // EN : ColorStringForeground(string inputText) colors the foreground of the input text based on RGBF color definitions.
    // </summary>
    // <param name="inputText">
    // The input text to be colored.
    // </param>
    // <returns>
    // A string containing the colored text with foreground colors.
    // </returns>
    static string ColorStringForeground
      (string inputText)
    { // 
      string[] partsForeground = inputText.Split(new string[] { "ℝ", "₲" }, StringSplitOptions.None);
      // 
      for (int i = 1; i < partsForeground.Length; i += 2)
      { // 
        string[] rgbValues = partsForeground[i].Split(',');
        // 
        if (rgbValues.Length == 3 &&
            int.TryParse(rgbValues[0], out int r) &&
            int.TryParse(rgbValues[1], out int g) &&
            int.TryParse(rgbValues[2], out int b))
        { // 
          partsForeground[i] = "";
          string text = partsForeground[i + 1];
          string colouredText = $"\u001b[38;2;{r};{g};{b}m{text}\u001b[0m";
          partsForeground[i + 1] = colouredText;
        }
        else if (rgbValues.Length == 4 &&
            int.TryParse(rgbValues[0], out int rM) &&
            int.TryParse(rgbValues[1], out int gM) &&
            int.TryParse(rgbValues[2], out int bM) &&
            int.TryParse(rgbValues[3], out int colorMod)
            )
        { // 
          partsForeground[i] = "";
          string text = partsForeground[i + 1];
          string colouredText = $"\u001b[38;2;{rM};{gM};{bM}m{text}\u001b[0m";
          partsForeground[i + 1] = colouredText;
        }
      }
      return string.Concat(partsForeground); // 
    }
    /*-------------------------- HINTERGRUND -----------------------------------------------------*/
    /// <summary>
    /// DE : ColorStringBackground(string inputText) 
    /// ━━━━━▶ färbt den Hintergrund des Eingabetexts basierend auf RGBB-Farbdefinitionen ein.
    /// </summary>
    /// <param name="inputText">
    /// Der zu färbende Eingabetext.
    /// </param>
    /// <returns>
    /// Eine Zeichenkette, die den eingefärbten Text mit Hintergrundfarben enthält.
    /// </returns>
    //*-------------------------- BACKGROUND -----------------------------------------------------*/
    // <summary>
    // EN : ColorStringBackground(string inputText) colors the background of the input text based on RGBB color definitions.
    // </summary>
    // <param name="inputText">
    // The input text to be colored.
    // </param>
    // <returns>
    // A string containing the colored text with background colors.
    // </returns>
    static string ColorStringBackground
      (string inputText)
    { // 
      string[] partsBackground = inputText.Split(new string[] { "rgbB[", "]" }, StringSplitOptions.None);
      // 
      for (int i = 1; i < partsBackground.Length; i += 2)
      { // 
        string[] rgbValues = partsBackground[i].Split(',');
        // 
        if (rgbValues.Length == 3 &&
            int.TryParse(rgbValues[0], out int r) &&
            int.TryParse(rgbValues[1], out int g) &&
            int.TryParse(rgbValues[2], out int b))
        { // 
          partsBackground[i] = "";
          string text = partsBackground[i + 1];
          string colouredText = $"\u001b[48;2;{r};{g};{b}m{text}\u001b[0m";
          partsBackground[i + 1] = colouredText;
        }
      }
      return string.Concat(partsBackground);
    }


    public string ModulateColor
      (string colorMod)
    {




      return colorMod;
    }
    /*
    static string ColorTextForegroundAndBackground(string inputText)
    {
      string[] parts = inputText.Split(new string[] { "rgbFaB(", ")" }, StringSplitOptions.None);
      /* The parts array contains two elements.  
       * The first element corresponds to 
       *   - the content between "rgbFaB(" and ")"     
       *      parts[0] = "250,0,0;0,255,0";
       *   - the second element contains the remaining text after the closing parenthesis.
       *      parts[1] = "Text of choice";
      *
    string[] fabParts = parts[0].Split(new string[] { ";" }, StringSplitOptions.None);
      /* fabParts:
       * [0] = 250,0,0
       * [1] = 0,255,0
      *
      string[] foregroundParts = fabParts[0].Split(new string[] { "," }, StringSplitOptions.None);
      /* foregroundParts:
       * [0] = 250
       * [1] = 0
       * [2] = 0
      *
      string[] backgroundParts = fabParts[1].Split(new string[] { "," }, StringSplitOptions.None);
      /* backgroundParts:
       * [0] = 0
       * [1] = 255
       * [2] = 0
      */
  }
}
