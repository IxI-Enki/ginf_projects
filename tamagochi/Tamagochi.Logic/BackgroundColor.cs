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
  internal class BackgroundColor
  {




    public static void ColorField(int firstCornerW, int firstCornerH, int lastCornerW, int lastCornerH, string color)
    {
      Colorizer Format = new Colorizer();
      string inputToColor = "";
      string coloredField = "";

      Console.SetCursorPosition(firstCornerW, firstCornerH);



    }



    public static string ColorStringBackground(string inputToColor)
    {
      Colorizer Format = new Colorizer();
      string coloredBackground = " ";





      coloredBackground = Format.ColorString(coloredBackground);
      return (coloredBackground);
    }



  }
}
