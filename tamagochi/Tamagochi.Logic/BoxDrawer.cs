using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using IxIGotchi;
using Gotchi;
using System.Linq;
using System.Collections.Immutable;

namespace Gotchi
{ //*‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗ • BOXDRAWER  ‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗*//

  /// <summary>
  /// DE : BoxDrawer(int cWidth, int cHeight, int firstCornerW, int firstCornerH, int lastCornerW, int lastCornerH, int boxMod) 
  /// ━━━━━▶ richtet eine Box ein und zeichnet sie auf dem Bildschirm.
  /// </summary>
  /// <param name="cWidth">
  /// Die Breite des Konsolenfensters.
  /// </param>
  /// <param name="cHeight">
  /// Die Höhe des Konsolenfensters.
  /// </param>
  /// <param name="firstCornerW">
  /// Die horizontale Koordinate der oberen linken Ecke der Box.
  /// </param>
  /// <param name="firstCornerH">
  /// Die vertikale Koordinate der oberen linken Ecke der Box.
  /// </param>
  /// <param name="lastCornerW">
  /// Die horizontale Koordinate der unteren rechten Ecke der Box.
  /// </param>
  /// <param name="lastCornerH">
  /// Die vertikale Koordinate der unteren rechten Ecke der Box.
  /// </param>
  /// <param name="boxMod">
  /// Der Index, der das Linienformat des Rahmenzeichens repräsentiert (z. B. dünn, dick).
  /// </param>
  /// <returns>
  /// Void (kein Rückgabewert).
  /// </returns>
  // <summary>
  // EN : BoxDrawer(int cWidth, int cHeight, int firstCornerW, int firstCornerH, int lastCornerW, int lastCornerH, int boxMod)
  // ━━━━━▶ sets up and draws a box on the screen.
  // </summary>
  // <param name="cWidth">
  // The width of the console window.
  // </param>
  // <param name="cHeight">
  // The height of the console window.
  // </param>
  // <param name="firstCornerW">
  // The horizontal coordinate of the upper-left corner of the box.
  // </param>
  // <param name="firstCornerH">
  // The vertical coordinate of the upper-left corner of the box.
  // </param>
  // <param name="lastCornerW">
  // The horizontal coordinate of the lower-right corner of the box.
  // </param>
  // <param name="lastCornerH">
  // The vertical coordinate of the lower-right corner of the box.
  // </param>
  // <param name="boxMod">
  // The index representing the line format of the box character (e.g., thin, thick).
  // </param>
  // <returns>
  // Void (no return value).
  // </returns>
  public class Box()
  {
    public void BoxDrawer
      (
         int cWidth,
         int cHeight,
         int firstCornerW,
         int firstCornerH,
         int lastCornerW,
         int lastCornerH,
         int boxMod,
         string colorMod
      )
    {
      Colorizer Format = new Colorizer();
      Settings Set = new Settings(); Set.ScreenSettings(cWidth);
      // Test: 
      // firstCornerH = 0; firstCornerW = 0;
      // lastCornerH = cHeight; lastCornerW = cWidth;

      DrawBox(firstCornerW, firstCornerH, lastCornerW, lastCornerH, boxMod, colorMod);
    }

    /// <summary>
    /// DE : DrawBox(int firstCornerW, int firstCornerH, int lastCornerW, int lastCornerH, int boxMod)
    /// ━━━━━▶ zeichnet eine Box mit spezifizierten Ecken, Dimensionen und Linienformat.
    /// </summary>
    /// <param name="firstCornerW">
    /// Die horizontale Koordinate der oberen linken Ecke der Box.
    /// </param>
    /// <param name="firstCornerH">
    /// Die vertikale Koordinate der oberen linken Ecke der Box.
    /// </param>
    /// <param name="lastCornerW">
    /// Die horizontale Koordinate der unteren rechten Ecke der Box.
    /// </param>
    /// <param name="lastCornerH">
    /// Die vertikale Koordinate der unteren rechten Ecke der Box.
    /// </param>
    /// <param name="boxMod">
    /// Der Index, der das Linienformat des Rahmenzeichens repräsentiert (z. B. dünn, dick).
    /// </param>
    /// <returns>
    /// Eine Zeichenkettenrepräsentation der gezeichneten Box.
    /// </returns>
    // <summary>
    // EN : DrawBox(int firstCornerW, int firstCornerH, int lastCornerW, int lastCornerH, int boxMod)
    // ━━━━━▶ draws a box with specified corners, dimensions, and line format.
    // </summary>
    // <param name="firstCornerW">
    // The horizontal coordinate of the upper-left corner of the box.
    // </param>
    // <param name="firstCornerH">
    // The vertical coordinate of the upper-left corner of the box.
    // </param>
    // <param name="lastCornerW">
    // The horizontal coordinate of the lower-right corner of the box.
    // </param>
    // <param name="lastCornerH">
    // The vertical coordinate of the lower-right corner of the box.
    // </param>
    // <param name="boxMod">
    // The index representing the line format of the box character (e.g., thin, thick).
    // </param>
    // <returns>
    // A string representation of the drawn box.
    // </returns>
    public string DrawBox
      (
         int firstCornerW,
         int firstCornerH,
         int lastCornerW,
         int lastCornerH,
         int boxMod,
         string colorMod
      )
    {
      Colorizer Format = new Colorizer();
      string box = "";
      Console.CursorVisible = false;
      Console.SetCursorPosition(firstCornerW, firstCornerH);
      int lineCounter = firstCornerH;
      int charCounter = 0;
      int charToDraw;
      /// boundry: UP:
      for (int width = 0; width < (lastCornerW - firstCornerW); width++)
      {
        switch (charCounter)
        {
          case 0:
            charToDraw = (charCounter == 0) ? 3 : 0;
            break;
          default:
            charToDraw = 4;
            break;
        }
        charToDraw = (charCounter == (lastCornerW - firstCornerW - 1)) ? 5 : charToDraw;
        //  Colorizer Decompile = new Colorizer();
        //  Decompile.ModulateColor(colorMod);
        Console.Write(Format.ColorString(SetBoxChars(charToDraw, boxMod, colorMod)));
        charCounter++;
      }
      lineCounter++;
      /// boundary: SIDES:
      for (lineCounter = lineCounter; lineCounter < (lastCornerH - firstCornerH-1); lineCounter++)
      {
        for (int s = 1; s < 3; s++)
        {
          charToDraw = 0;
          Console.SetCursorPosition((s == 1 ? firstCornerW : (lastCornerW - 1)), lineCounter);

          Console.Write(Format.ColorString(SetBoxChars(charToDraw, boxMod, colorMod)));
        }
      }
      charCounter = 0;
      Console.SetCursorPosition(firstCornerW,lineCounter);
      /// boundary: DOWN:
      for (int width = 0; width < (lastCornerW - firstCornerW); width++)
      {
        switch (charCounter)
        {
          case 0:
            charToDraw = (charCounter == 0) ? 1 : 0;
            break;
          default:
            charToDraw = 4;
            break;
        }
        charToDraw = (charCounter == (lastCornerW - firstCornerW - 1)) ? 2 : charToDraw;
        
        Console.Write(Format.ColorString(SetBoxChars(charToDraw, boxMod, colorMod)));
        charCounter++;
      }
      return box;
    }

    /// <summary>
    /// DE : Die Methode SetBoxChars(int charIndex, int modIndex)
    /// ━━━━━▶ gibt das spezifizierte Rahmenzeichen aus dem vordefinierten Satz zurück.
    /// </summary>
    /// <param name="charIndex">
    /// Der Index, der den Typ des Rahmenzeichens repräsentiert (z. B. Linie, Ecke).
    /// </param>
    /// <param name="modIndex">
    /// Der Index, der das Linienformat des Rahmenzeichens repräsentiert (z. B. dünn, dick).
    /// </param>
    /// <returns>
    /// Ein String, der das ausgewählte Rahmenzeichen basierend auf den bereitgestellten Indizes enthält.
    /// </returns>
    // <summary>
    // EN : SetBoxChars(int charIndex, int modIndex)
    //  ━━━━━▶ returns the specified box character from the predefined set.
    // </summary>
    // <param name="charIndex">
    // The index representing the type of box character (e.g., line, corner).
    // </param>
    // <param name="modIndex">
    // The index representing the line format of the box character (e.g., thin, thick).
    // </param>
    // <returns>
    // A string containing the selected box character based on the provided indices.
    // </returns>
    public string SetBoxChars
      (
         int charIndex,
         int modIndex,
         string colorMod
      )
    { //  
      string[,] boxChars = new string[6, 12];
      /// defines the type of char ◀──╜  ╙──▶ defines the line format ///
      ///   ↳ e.g. line/corner etc.              ↳ e.g. thin/thick etc. //
      string[] lineChars = [/*
         0123456789..  ──────────▶ #nr of mod                          */
        "│┃║╎╏┆┇┊┋ ╽╿", // 0  ╖                                        */
        "└┗╚┕╘┖╙╰    ", // 1  ╢                                        */
        "┘┛╝┙╛┚╜╯    ", // 2  ╢                                        */
        "┌┏╔┎╓┍╒╭    ", // 3  ╢                                        */
        "─━═╌╍┄┅┈┉ ╼╾", // 4  ╢                                        */
        "┐┓╗┑╕┒╖╮    "  // 5  ╢                                        */
                   ];   /*    ╙──▶ #nr of boxChar                      */
      
      string[] 
      threeWayLineChars = [/*
         0123456789..                                  ──────────▶ #nr of mod                          */
        "├┣╠┟┞┝╞┢┡┠ ╟",
        "┴┻╩┵┸╨╧┶┹┷ ┺",
        "┤┫╣┦┧┥╡┩┪┨ ╢",
        "┬┳╦┭┰╥╤┮┱┯ ┲",
      ];
      // initiate boxChars[,] with above table
      int lineCounter = 0;
      foreach (string lcat in lineChars)
      {
        string category = lineChars[lineCounter].ToString();

        int charCounter = 0;
        foreach (char ch in category)
        {
          boxChars[lineCounter, charCounter] = ch.ToString();
          charCounter++;
        }
        lineCounter++;
      }
      return new string(colorMod + boxChars[charIndex, modIndex]);
    }

  }
}