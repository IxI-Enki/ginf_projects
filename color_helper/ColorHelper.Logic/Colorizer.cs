using IxIsColorHelper;


namespace IxIsColorHelper
{
  //*‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗ • COLORIZE  ‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗*//
  public class Colorizer()
  {
    public string Colorize(string input)
    {
      string[] parts = input.Split(new string[] { "rgb(", ")" }, StringSplitOptions.None);
      for (int i = 1; i < parts.Length; i += 2)
      {
        string[] rgbValues = parts[i].Split(',');

        if (rgbValues.Length == 3 &&
          int.TryParse(rgbValues[0], out int r) &&
          int.TryParse(rgbValues[1], out int g) &&
          int.TryParse(rgbValues[2], out int b))
        {
          parts[i] = "";
          string text = parts[i + 1];
          string coloredText = $"\u001b[38;2;{r};{g};{b}m{text}\u001b[0m";
          parts[i + 1] = coloredText;
        }
      }
      return string.Concat(parts);
    }
  }
}