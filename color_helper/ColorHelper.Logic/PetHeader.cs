using IxIsColorHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorHelper
{
  public class PetHeader()
  {
    public void PetHeaderMain(int cWidth, string petName)
    {
      Colorizer Call = new Colorizer();
      string petHeader = PetHead(cWidth, petName);
      Call.Colorize(petHeader);
      Console.Write(Call.Colorize(petHeader));
    }

    private static string PetHead(int cWidth, string petName)
    {
      string petHeader = "";
      int headWidth = 9;

      if (petName == "pet.")
      {
        for (int w = 0; w < ((cWidth - headWidth) / 2); w++)
        {
          petHeader += " ";
        }
        petHeader += "rgb(255,255,255)" + "╔═╗┌─┐┌┬┐" +
          "\n";
        for (int w = 0; w < ((cWidth - headWidth) / 2); w++)
        {
          petHeader += " ";
        }
        petHeader += "rgb(200,200,200)" + "╠═╝├┤  │ " +
          "\n";
        for (int w = 0; w < ((cWidth - headWidth) / 2); w++)
        {
          petHeader += " ";
        }
        petHeader += "rgb(150,150,150)" + "╩  └─┘ ┴" + "rgb(60,255,30)" + "o" +
          "\n";

        for (int w = 0; w < cWidth; w++)
        {
          Random random = new Random();
          int randomR = random.Next(256) / 1;
          int randomG = random.Next(256) / 5;
          int randomB = random.Next(256) / 4;

          petHeader += $"rgb({randomR},{randomG},{randomB})‾";
        }
        petHeader += "\n";
      }
      else
      {

        petHeader += "pet";
      }

      return new string(petHeader);
    }
  }
}

/*
╔═╗ ╔╗  ╔═╗ ╔╦╗ ╔═╗ ╔═╗ ╔═╗ ╦ ╦ ╦  ╦ ╦╔═ ╦   ╔╦╗ ╔╗╔ ╔═╗ ╔═╗ ╔═╗  ╦═╗ ╔═╗ ╔╦╗ ╦ ╦ ╦  ╦ ╦ ╦ ═╗ ╦ ╦ ╦ ╔═╗
╠═╣ ╠╩╗ ║    ║║ ║╣  ╠╣  ║ ╦ ╠═╣ ║  ║ ╠╩╗ ║   ║║║ ║║║ ║ ║ ╠═╝ ║═╬╗ ╠╦╝ ╚═╗  ║  ║ ║ ╚╗╔╝ ║║║ ╔╩╦╝ ╚╦╝ ╔═╝
╩ ╩ ╚═╝ ╚═╝ ═╩╝ ╚═╝ ╚   ╚═╝ ╩ ╩ ╩ ╚╝ ╩ ╩ ╩═╝ ╩ ╩ ╝╚╝ ╚═╝ ╩   ╚═╝╚ ╩╚═ ╚═╝  ╩  ╚═╝  ╚╝  ╚╩╝ ╩ ╚═  ╩  ╚═╝
┌─┐ ┌┐  ┌─┐ ┌┬┐ ┌─┐ ┌─┐ ┌─┐ ┬ ┬ ┬  ┬ ┬┌─ ┬   ┌┬┐ ┌┐┌ ┌─┐ ┌─┐ ┌─┐  ┬─┐ ┌─┐ ┌┬┐ ┬ ┬ ┬  ┬ ┬ ┬ ─┐ ┬ ┬ ┬ ┌─┐
├─┤ ├┴┐ │    ││ ├┤  ├┤  │ ┬ ├─┤ │  │ ├┴┐ │   │││ │││ │ │ ├─┘ │─┼┐ ├┬┘ └─┐  │  │ │ └┐┌┘ │││ ┌┴┬┘ └┬┘ ┌─┘
┴ ┴ └─┘ └─┘ ─┴┘ └─┘ └   └─┘ ┴ ┴ ┴ └┘ ┴ ┴ ┴─┘ ┴ ┴ ┘└┘ └─┘ ┴   └─┘└ ┴└─ └─┘  ┴  └─┘  └┘  └┴┘ ┴ └─  ┴  └─┘
*/