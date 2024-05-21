  namespace IxIsColorHelper
{
  //*‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗ • HEADER  ‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗*//
  public class Header()
  {
    public void HeaderMain(int cWidth)
    {
      Colorizer Call = new Colorizer();

      string header = Head(cWidth);

      Call.Colorize(header);

      Console.Write(Call.Colorize(header));
    }

    private static string Head(int cWidth)
    {
      //*----------------------------------------------------------------------------------------*/
      /*  ╔═╗┌─┐┬  ┌─┐┬─┐  ╦ ╦┌─┐┬  ┌─┐┌─┐┬─┐   ╦═╗╔═╗╔╗   *    ░▀█▀░░░█░█░░░▀█▀░░
      /*  ║  │ ││  │ │├┬┘  ╠═╣├┤ │  ├─┘├┤ ├┬┘   ╠╦╝║ ╦╠╩╗  *    ░░█░░░░▄▀▄░░░░█░░░
      /*  ╚═╝└─┘┴─┘└─┘┴└─  ╩ ╩└─┘┴─┘┴  └─┘┴└─   ╩╚═╚═╝╚═╝  *    ░▀▀▀░░░▀░▀░░░▀▀▀░░
      /*  01234567890123456789012345678901234567890123456  */
      /*            10        20        30        40    46 */
      /* ===== ===== ===== == (17 spaces in front)
      /* vs
      /* ===== ===== ===== =  (16 spaces in the back)
      */
      string header = "";
      int headWidth = 46;
      for (int w = 0; w < ((cWidth - headWidth) / 2); w++)
      {
        header += " ";
      }
      header += "rgb(255,255,255)" + "╔═╗┌─┐┬  ┌─┐┬─┐  ╦ ╦┌─┐┬  ┌─┐┌─┐┬─┐   " +
        "rgb(255,0,0)" + "╦═╗" +
        "rgb(0,255,0)" + "╔═╗" +
        "rgb(0,0,255)" + "╔╗ " +
        "\n";
      for (int w = 0; w < ((cWidth - headWidth) / 2); w++)
      {
        header += " ";
      }
      header += "rgb(200,200,200)" + "║  │ ││  │ │├┬┘  ╠═╣├┤ │  ├─┘├┤ ├┬┘   " +
        "rgb(200,30,30)" + "╠╦╝" +
        "rgb(30,200,30)" + "║ ╦" +
        "rgb(30,30,200)" + "╠╩╗" +
        "\n";
      for (int w = 0; w < ((cWidth - headWidth) / 2); w++)
      {
        header += " ";
      }
      header += "rgb(150,150,150)" + "╚═╝└─┘┴─┘└─┘┴└─  ╩ ╩└─┘┴─┘┴  └─┘┴└─   " +
        "rgb(150,60,60)" + "╩╚═" +
        "rgb(60,150,60)" + "╚═╝" +
        "rgb(60,60,150)" + "╚═╝" +
        "\n";
      for (int w = 0; w < cWidth; w++)
      {
        Random random = new Random();
        int randomR = random.Next(256) / 1;
        int randomG = random.Next(256) / 5;
        int randomB = random.Next(256) / 4;
        header += $"rgb({randomR},{randomG},{randomB})=";
      }
      header += "\n";

      return new string(header);
    }
  }
}