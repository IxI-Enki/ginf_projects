using IxIsColorHelper;


namespace IxIsColorHelper
{
  //*‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗ • CONVERTER  ‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗*//
  public class ConvertColor
  {
    public string Converter(string colorToConvert)
    {
      CalculateHex CalcHex = new CalculateHex();

      string rgbColor = "";
      string hexColor = "";
      string ColorPrefix = "-";
      int red;
      int green;
      int blue;

      if (colorToConvert[0] == '#')
      {
        if (colorToConvert.Length == 7)
        {
          string hexInput = "";
          for (int i = 1; i < colorToConvert.Length; i++)
          {
            hexInput = hexInput + char.ToString(char.ToUpper(colorToConvert[i]));
          }
          hexColor = "#" + hexInput;
          string redString = "",
                 greenString = "",
                 blueString = "";

          for (int r = 0; r < 2; r++)
          {
            redString = redString + hexInput[r];
          }
          red = Convert.ToInt32(redString, 16);

          for (int g = 2; g < 4; g++)
          {
            greenString = greenString + hexInput[g];
          }
          green = Convert.ToInt32(greenString, 16);

          for (int b = 4; b < 6; b++)
          {
            blueString = blueString + hexInput[b];
          }
          blue = Convert.ToInt32(blueString, 16);
          ColorPrefix = ($"rgb({red},{green},{blue})");
          rgbColor = ($"{red},{green},{blue}");
        }
        else
        {
          ColorPrefix = "-";
        }
      }
      else if (colorToConvert[0] != '#')
      {
        if (colorToConvert.Length >= 5 && colorToConvert.Length <= 11)
        {
          string[] rgbValues = colorToConvert.Split(',');
          if (rgbValues.Length == 3 &&
            int.TryParse(rgbValues[0], out red) &&
            int.TryParse(rgbValues[1], out green) &&
            int.TryParse(rgbValues[2], out blue))
          {
            ColorPrefix = ($"rgb({red},{green},{blue})");
            rgbColor = ($"{red},{green},{blue}");
            hexColor = CalcHex.RGBToHex(red, green, blue);
            hexColor = ($"#{hexColor}");
          }
          else
          {
            ColorPrefix = "-";
          }
        }
      }
      else if (colorToConvert.Length < 5 || colorToConvert.Length > 11)
      {
        ColorPrefix = "-";
      }

      string convertedColor = ColorPrefix + "|" + rgbColor + "|" + hexColor;

      return (convertedColor);
    }
  }
}