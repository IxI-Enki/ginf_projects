using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using IxIGotchi;
using Gotchi;
using System.Security.Cryptography.X509Certificates;

namespace Gotchi
{
  //*‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗ • SETTINGS  ‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗*//
  
  /// <summary>
  /// DE : Die Settings-Klasse stellt Methoden zum Konfigurieren von Konsolenfenster-Einstellungen bereit.
  /// </summary>
  // <summary>
  // EN : Settings class provides methods to configure console window settings.
  // </summary>
  public class Settings
  {
    /// <summary>
    /// DE : ScreenSettings(int cWidth)
    /// ━━━━━▶ konfiguriert die Einstellungen des Konsolenfensters basierend auf der angegebenen Breite.
    /// </summary>
    /// <param name="cWidth">
    /// Die Breite des Konsolenfensters.
    /// </param>
    // <summary>
    // EN : ScreenSettings(int cWidth) configures console window settings based on the specified width.
    // </summary>
    // <param name="cWidth">
    // The width of the console window.
    // </param>
    public void ScreenSettings
      (int cWidth)
    {
      int cHeight = cWidth / 3;                 //            Height
      int cWBuffer = cWidth;                    //            Size Buffer Width
      int cHBuffer = cHeight * 6;               //            Size Buffer Height
      /*------------------------------ settings_variables ---------------------------------------*/
      Console.SetWindowSize(cWidth, cHeight);        //    Set Size
      Console.SetBufferSize(cWBuffer, cHBuffer);     //    Set Buffer Size
      Console.OutputEncoding = Encoding.UTF8;        //    Using Unicode Symbols 

    }

  }
}