using System.Text;

namespace IxIsColorHelper
{
  //*‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗ • SETTINGS  ‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗*//
  public class Settings()
  {
    public void ScreenSettings(int cWidth)
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