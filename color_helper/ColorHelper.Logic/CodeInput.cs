using System.Text;
using IxIsColorHelper;

namespace IxIsColorHelper
{
  public class CodeReader
  {
    public void CodeInput(int cWidth)
    {
      Colorizer Call = new Colorizer();          // Call.Colorize(input);
      Console.Write(Call.Colorize("rgb(255,255,255)  Befehle eingeben:\t\t\t\trgb(120,120,120)    0 beendet die Eingabe\n"));

      Console.Write(Call.Colorize("\trgb(70,70,70) Testen Sie hier beispielsweise die \"rgb-Syntax\":\n"));
      Console.Write("\t Eingabe: \"rgb(200,200,0) Test-Text\" "); Console.Write(Call.Colorize("rgb(70,70,70) → Ausgabe: rgb(200,200,0) Test-Text ██\n"));

      string seperator = "";
      for (int w = 0; w < cWidth; w++)
      {
        Random random = new Random();
        int randomR = random.Next(256) / 1;
        int randomG = random.Next(256) / 5;
        int randomB = random.Next(256) / 4;
        seperator += $"rgb({randomR},{randomG},{randomB})‾";
      }
      Console.Write(Call.Colorize(seperator + "\n"));



      bool run = true;
      while (run)
      {
        string input;
        input = Console.ReadLine();
        if (input != "pet" && input != "0" && input != "")
        {
          Console.Write(Call.Colorize(input + " ██" + "\n"));
        }


        else if (input == "")
        {
          Console.Write("\n");
        }





        else if (input == "pet")
        {
          ColorPet Pet = new ColorPet();
          Pet.Pet(cWidth);
        }

        else if (input == "0")
        {
          run = false;
        }

      }
    }
  }
}
