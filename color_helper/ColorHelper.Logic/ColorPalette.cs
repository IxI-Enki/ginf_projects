using IxIsColorHelper;

namespace IxIsColorHelper
{
  //*‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗ • PALETTE  ‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗*//
  public class ColorPalette
  {
    public void InitColorPalette(int cWidth)
    {
      Colorizer Call = new Colorizer();

      string colorPalette = Palette(cWidth);
      Console.Write(Call.Colorize(colorPalette));
    }

    public string Palette(int cWidth)
    {
      ColorPalette Draw = new ColorPalette();
      Colorizer Call = new Colorizer();
      ConvertColor Input = new ConvertColor();
      Header Print = new Header();

      bool run = true;
      string input, seperator = "";
      string colorPalette = "";

      Console.Write(Call.Colorize("rgb(255,255,255)  Palette erstellen:\t\t\trgb(120,120,120)    Geben Sie eine Ausgangsfarbe ein\n"));

      for (int w = 0; w < cWidth; w++)
      {
        Random random = new Random();
        int randomR = random.Next(256) / 1;
        int randomG = random.Next(256) / 5;
        int randomB = random.Next(256) / 4;
        seperator += $"rgb({randomR},{randomG},{randomB})‾";
      }
      Console.Write(Call.Colorize(seperator));

      Console.Write(Call.Colorize("\n     rgb(100,100,100)[unterstützte Eingabe Methoden]:" +
                            "\nrgb(150,0,0)     ►" +
                            "rgb(110,110,110)\t   Beispiel-" +
                            "rgb(255,170,0)Eingabe" +
                            "rgb(110,110,110): \"" +
                            "rgb(255,170,0)0" +
                            "rgb(255,100,70)," +
                            "rgb(255,170,0)200" +
                            "rgb(255,100,70)," +
                            "rgb(255,170,0)0" +
                            "rgb(110,110,110)\" ► " +
                            "rgb(0,200,0)██ " +
                            "" +
                            "\nrgb(150,0,0)     ►" +
                            "rgb(110,110,110)\t   Beispiel-" +
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
        char choice;
        string combinedColor;

        Console.Write(Call.Colorize("\n     rgb(255,255,0)► rgb(255,170,0)Eingabe: " +
                               "\t\t\t\t     rgb(100,100,100)[0 beendet die Eingabe]" +
                                    "\r     rgb(255,255,0)► rgb(255,170,0)Eingabe: "));
        input = Console.ReadLine();

        if (input != "" && input != "0" && input != "clear")
        {
          combinedColor = Input.Converter(input);
          if (combinedColor[0] != '-')
          {
            int hueCounter, stepsize;
            bool isInt = false;
            string[] Color = new string[3];
            Color = combinedColor.Split('|', 3);
            Console.Write(Call.Colorize($"     rgb(255,255,0)↳ {Color[0]}Farbe  : {(Color[1].PadRight(11) + " ".PadLeft(6) + Color[2] + "  ██")}"));

            Console.Write("\n Wie viele Abstufungen sollen generiert werden: ");
            do
            {
              string hueInput = Console.ReadLine();
              isInt = int.TryParse(hueInput, out hueCounter);
            } while (!isInt);

            Console.Write("\n Wie groß sollen die Schritte zwischen den Abstufungen werden: ");
            isInt = false;
            do
            {
              string stepInput = Console.ReadLine();
              isInt = int.TryParse(stepInput, out stepsize);
            } while (!isInt);

            Console.Write("\n        Helligkeiten: \n");
            int hueOverflow;
            int counter = 0;
            int maxHue = 0;
            if (hueCounter % 2 == 0)
            {
              counter = (hueCounter / 2);
              maxHue = counter;
            }
            else if (hueCounter % 2 != 0)
            {
              counter = (hueCounter / 2);
              maxHue = counter + 1;
            }

            do
            {
              hueOverflow = 0;
              string hueColor = HueD(Color, counter, stepsize);
              string[] hueCache = hueColor.Split('|', 2);
              hueColor = hueCache[0];
              hueOverflow = int.Parse(hueCache[1]);
              if (hueOverflow > 0)
              {
                maxHue++;
              }
              counter--;
              Console.Write(Call.Colorize($"{hueColor}"));
            } while (counter > 0);

            do
            {
              string hueColor = HueL(Color, counter, stepsize);
              string[] hueCache = hueColor.Split('|', 2);
              hueColor = hueCache[0];
              counter++;
              Console.Write(Call.Colorize($"{hueColor}"));
            } while (counter < maxHue);
          }
        }
        if (input == "0") { run = false; }
        if (input == "clear")
        {
          Console.Clear();
          run = false;
          Print.HeaderMain(cWidth);
          Draw.InitColorPalette(cWidth);
        }
      }
      return new string(colorPalette);
    }

    public string HueD(string[] Color, int hueCounter, int stepsize)
    {
      string hue = Color[1];
      int hueOverflow = 0;
      int red,
          green,
          blue;
      string[] color = (hue.Split(',', 3));
      red = Convert.ToInt32(color[0]);
      green = Convert.ToInt32(color[1]);
      blue = Convert.ToInt32(color[2]);

      int redD = red,
          greenD = green,
          blueD = blue;
      redD = redD - hueCounter * stepsize;
      greenD = greenD - hueCounter * stepsize;
      blueD = blueD - hueCounter * stepsize;
      redD = Math.Clamp(redD, 0, 255);
      greenD = Math.Clamp(greenD, 0, 255);
      blueD = Math.Clamp(blueD, 0, 255);
      if (redD == 0 && greenD == 0 && blueD == 0)
      {
        hue = "";
        hueOverflow++;
      }
      else
      {
        //                                     Console.Write($"\nRot:{redD} Grün:{greenD} Blau:{blueD}");
        hue = $" -{Convert.ToString(hueCounter).PadLeft(2)}.▻\trgb({redD},{greenD},{blueD})██  {Convert.ToString(redD).PadLeft(3)},{Convert.ToString(greenD).PadLeft(3)},{Convert.ToString(blueD).PadLeft(3)}\n";
      }
      return String.Concat(hue + ("|" + hueOverflow));
    }

    public string HueL(string[] Color, int hueCounter, int stepsize)
    {
      string hue = Color[1];
      int hueOverflow = 0;
      int red,
          green,
          blue;
      string[] color = (hue.Split(',', 3));
      red = Convert.ToInt32(color[0]);
      green = Convert.ToInt32(color[1]);
      blue = Convert.ToInt32(color[2]);

      int redL = red,
          greenL = green,
          blueL = blue;
      redL = redL + hueCounter * stepsize;
      greenL = greenL + hueCounter * stepsize;
      blueL = blueL + hueCounter * stepsize;
      redL = Math.Clamp(redL, 0, 255);
      greenL = Math.Clamp(greenL, 0, 255);
      blueL = Math.Clamp(blueL, 0, 255);
      if (redL == 255 && greenL == 255 && blueL == 255)
      {
        hue = "";
        hueOverflow++;
      }
      else
      {
        //                                     Console.Write($"\nRot:{redL} Grün:{greenL} Blau:{blueL}");
        if (hueCounter == 0)
        {
          hue = $" ±{Convert.ToString(hueCounter).PadLeft(2)}.▻\trgb({redL},{greenL},{blueL})██  {Convert.ToString(redL).PadLeft(3)},{Convert.ToString(greenL).PadLeft(3)},{Convert.ToString(blueL).PadLeft(3)}\n";
        }
        if (hueCounter > 0)
        {
          hue = $" +{Convert.ToString(hueCounter).PadLeft(2)}.▻\trgb({redL},{greenL},{blueL})██  {Convert.ToString(redL).PadLeft(3)},{Convert.ToString(greenL).PadLeft(3)},{Convert.ToString(blueL).PadLeft(3)}\n";
        }
      }
      return new string(hue + ("|" + hueOverflow));
    }
  }
}