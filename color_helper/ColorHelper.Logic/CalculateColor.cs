namespace IxIsColorHelper
{
  //*‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗ • CALCULATE COLOR  ‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗*//
  public class CalculateColor
  {
    public void InitColorCalc(int cWidth)
    {
      Colorizer Call = new Colorizer();
      Header Print = new Header();
      CalculateHex CalcHex = new CalculateHex();

      string input, seperator = "";
      bool run = true;
      string hex;
      Console.Write(Call.Colorize("rgb(255,255,255)  Farben umrechnen:\t\t\trgb(120,120,120)    Geben Sie ihre Farbe ein\n"));

      for (int w = 0; w < cWidth; w++)
      {
        Random random = new Random();
        int randomR = random.Next(256) / 1;
        int randomG = random.Next(256) / 5;
        int randomB = random.Next(256) / 4;
        seperator += $"rgb({randomR},{randomG},{randomB})‾";
      }
      Console.Write(Call.Colorize(seperator));

      Console.Write(Call.Colorize("\n    rgb(100,100,100)[unterstützte Eingabe Methoden]:" +
                    "\nrgb(150,0,0)    ► " +
                    "rgb(255,255,255)\tRGB" +
                    "rgb(140,140,140): " +
                    "rgb(255,100,100)Rotwert" +
                    "rgb(140,140,140)[" +
                    "rgb(255,255,255)0-255" +
                    "rgb(140,140,140)], " +
                    "rgb(100,255,100)Grünwert" +
                    "rgb(140,140,140)[" +
                    "rgb(255,255,255)0-255" +
                    "rgb(140,140,140)], " +
                    "rgb(100,100,255)Blauwert" +
                    "rgb(140,140,140)[" +
                    "rgb(255,255,255)0-255" +
                    "rgb(140,140,140)]" +

                    "\nrgb(110,110,110)\t   Beispiel-" +
                    "rgb(255,170,0)Eingabe" +
                    "rgb(110,110,110): \"" +
                    "rgb(255,170,0)0" +
                    "rgb(255,100,70)," +
                    "rgb(255,170,0)200" +
                    "rgb(255,100,70)," +
                    "rgb(255,170,0)0" +
                    "rgb(110,110,110)\" ► " +
                    "rgb(0,200,0)██ " +

                    "\nrgb(150,0,0)    ► " +
                    "rgb(255,255,255)\tHEX" +
                    "rgb(140,140,140): Hex [" +
                    "rgb(255,255,255)0-9 " +
                    "rgb(140,140,140)+ " +
                    "rgb(255,255,255)A-F" +
                    "rgb(140,140,140)]" +

                    "\nrgb(110,110,110)\t   Beispiel-" +
                    "rgb(255,170,0)Eingabe" +
                    "rgb(110,110,110): \"" +
                    "rgb(255,100,70)#" +
                    "rgb(255,170,0)FB2B2B" +
                    "rgb(110,110,110)\" ► " +
                    "rgb(251,43,43)██ " +

                    "\n"));

      seperator = "";
      for (int w = 0; w < cWidth; w++)
      {
        Random random = new Random();
        int randomR = random.Next(256) / 1;
        int randomG = random.Next(256) / 5;
        int randomB = random.Next(256) / 4;
        seperator += $"rgb({randomR},{randomG},{randomB})¯";
      }
      Console.Write(Call.Colorize(seperator));

      while (run)
      {
        Console.Write(Call.Colorize("\n    rgb(255,255,255)Ihre rgb(255,170,0)Eingabe: " +
                               "\t\t\t\t     rgb(100,100,100)[0 beendet die Eingabe]" +
                                    "\r    rgb(255,255,255)Ihre rgb(255,170,0)Eingabe: "));
        input = Console.ReadLine();

        if (input != "")
        {
          if (input != "0" && input != "clear" && input[0] != '#')
          {
            string[] rgbValues = input.Split(',');
            if (rgbValues.Length == 3 &&
              int.TryParse(rgbValues[0], out int red) &&
              int.TryParse(rgbValues[1], out int green) &&
              int.TryParse(rgbValues[2], out int blue))
            {
              string colorCalc = ColorCalc(cWidth, red, green, blue);
              string hexColor = CalcHex.RGBToHex(red, green, blue);
              Console.Write(Call.Colorize(colorCalc + "Hex-Code: #" + hexColor));
            }
          }
          else if (input == "0")
          { run = false; }
          else if (input == "clear")
          {
            Console.Clear();
            run = false;
            Print.HeaderMain(cWidth);
            CalculateColor Calc = new CalculateColor();
            Calc.InitColorCalc(cWidth);
          }
          else if (input[0] == '#')
          {
            if (input.Length == 7)
            {
              string hexInput = "";
              for (int i = 1; i < input.Length; i++)
              {
                hexInput = hexInput + input[i];
              }
              //     Console.WriteLine("Hexinput: " + hexInput);
              string red = "",
                     green = "",
                     blue = "";
              for (int r = 0; r < 2; r++)
              {
                red = red + hexInput[r];
              }
              int redInt = Convert.ToInt32(red, 16);
              //      Console.WriteLine("Rot: " + redInt);
              for (int g = 2; g < 4; g++)
              {
                green = green + hexInput[g];
              }
              int greenInt = Convert.ToInt32(green, 16);
              //       Console.WriteLine("Grün: " + greenInt);
              for (int b = 4; b < 6; b++)
              {
                blue = blue + hexInput[b];
              }
              int blueInt = Convert.ToInt32(blue, 16);
              //       Console.WriteLine("Blau: " + blue);
              Console.Write(Call.Colorize($"rgb({redInt},{greenInt},{blueInt})    Ihre Farbe  : ██ " + $"RGB-Code: {redInt},{greenInt},{blueInt}"));
            }
          }
        }
      }
    }

    public string ColorCalc(int cWidth, int red, int green, int blue)
    {
      red = Math.Clamp(red, 0, 255);
      green = Math.Clamp(green, 0, 255);
      blue = Math.Clamp(blue, 0, 255);

      string colorCalc = $"rgb({red},{green},{blue})    Ihre Farbe  :" + $"rgb({red},{green},{blue}) ██ ";

      return new string(colorCalc);
    }
  }
}