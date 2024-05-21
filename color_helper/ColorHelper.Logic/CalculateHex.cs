namespace IxIsColorHelper
{
  //*‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗ • CALCULATE HEX  ‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗*//
  public class CalculateHex
  {
    public string RGBToHex(int red, int green, int blue)
    {
      // Ensure that the RGB values are within the valid range (0-255)
      red = Math.Clamp(red, 0, 255);
      green = Math.Clamp(green, 0, 255);
      blue = Math.Clamp(blue, 0, 255);

      // Convert to hex format
      string hexColor = $"{red:X2}{green:X2}{blue:X2}";

      return hexColor;
    }
  }
}