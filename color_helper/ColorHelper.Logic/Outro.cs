namespace IxIsColorHelper
{
  //*‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗ • OUTRO  ‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗*//
  public class Outro
  {
    public void Exit(int cWidth)
    {
      string outro = OutroHead(cWidth);
      Colorizer Call = new Colorizer();
      Console.Write(Call.Colorize(outro));
    }

    private static string OutroHead(int cWidth)
    {
      string git = "rgb(37,107,255)https://github.com/IxI-Enki";
      string creator = "\n rgb(160,166,166) created rgb(255,255,255)by IxI-Enki";
      string outro = "                  ▒▓█████████████░         ░█░            " +
                    "\n                                    ░▒███ ▓        ▓           ▓███             " +
                    "\n ░███▓           ░███▓            ▒▓  ▓██ ▓     ▓░              ▓██      ▒███░  " +
                    "\n                                 █▓   ▒██ ▓  ░▓          ▓░     ▒██  ░▒         " +
                    "\n ░▒██   ░█▒ ░▓█   ▒▓█▒         ░▓█    ▒██ ▒ ▓░       ▒▒█▓████▓  ▒██ ░██▓  ░▒█   " +
                    "\n ▒███  ▒███░▓███▒░███▒         ▒█▓    ▓██ ▓██████▒  ░███  ▓██▒  ▒██▓ ▒██  ███   " +
                    "\n  ▓██    ▓███  ██ ░██░         ███   ░███ ▓  ░█      ▒██  ░▓█░  ▒██   ███ ▒██   " +
                    "\n  ▓█▓     ▓██▓    ░██░  ▒███▓  ███    ▒█▓ ▒░█▒       ▒██  ░▓█   ▒████▓▓█▒ ▒██   " +
                    "\n  ▓█▒    ▓░ ██▓   ░██          ▓███   ▒█▓ ▓ █        ▒██  ░▓█   ▒███ ██░  ▒██   " +
                    "\n  ▒█▓   ▒█  ░██▒  ░██░ ▓       ░████  ██  ▓  ▓ █     ▒██  ░▓█▒  ▒██  ░██░ ░██ ░ " +
                    "\n ░▒██▒▒▓███   ██▓▒░███▓          ████▒    ▓         ▒░███  ███░▓░███ ░██ ▒░███▓ " +
                    "\n   ░█▓   ██   ░██   ▓█░           █████░  ▓            ██   ▒█▒   ██  ░██   ▓█  " +
                    "\n                                    ▒█████▓                            ░█▓      " +
                    "\n                                       ░█████████▒ ";
      char[] outroArray = outro.ToCharArray();
      string outroCache = "";

      foreach (char c in outroArray)
      {
        Random random = new Random();
        int r = random.Next(256) / 1;
        int g = random.Next(256) / 3;
        int b = random.Next(256) / 4;
        string colorRGB = $"{r},{g},{b}";
        if (c != '█')
        {
          outroCache = outroCache + $"rgb({r},{g},{b})" + c;
        }
        else if (c == '▓')
        {
          outroCache = outroCache + $"rgb({r - 20},{g - 60},{b - 80})" + c;
        }
        else if (c == '▒')
        {
          outroCache = outroCache + $"rgb({r - 30},{g - 90},{b - 120})" + c;
        }
        else if (c == '░')
        {
          outroCache = outroCache + $"rgb({r - 40},{g - 120},{b - 160})" + c;
        }
        else if (c == ' ')
        {
          outroCache = outroCache + "rgb(0,0,0)" + c;
        }
        else
        {
          outroCache = outroCache + "rgb(230,230,230)" + c;
        }
      }
      outroCache = creator + outroCache + git + "\n";
      return new string(outroCache);
    }
  }
}