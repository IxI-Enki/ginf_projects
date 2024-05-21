namespace IxIsColorHelper
{
  //*‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗ • WHEEL  ‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗*//
  public class ColorWheel
  {
    public void InitColorWheel(int cWidth)
    {
      Colorizer Call = new Colorizer();

      string colorWheel = DrawColorWheel();
      Console.Write(Call.Colorize(colorWheel));
      Console.ReadLine();
    }

    public string DrawColorWheel()
    {
      string colorWheel = "rgb(200,200,0) Farbrad rgb(0,255,0)soll hier sein";
      return new string(colorWheel);
    }
  }
}