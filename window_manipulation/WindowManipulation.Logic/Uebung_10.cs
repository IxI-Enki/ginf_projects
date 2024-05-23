using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ritt_4ACIFT_Abgabe.ConApp
{
  public class TEST_CLASS
  {





    public static void WanderString(int coordinateW, int coordinateH, int steps, string inputString)
    {
      int[] colorValue = Color.ExtractExistingColor(inputString, out string unformattedString);
      Color.GetColorArray(colorValue, out int r, out int g, out int b, out int R, out int G, out int B);

      int coloredPartLength = inputString.Length / 3;
      char[] inputChars = inputString.ToArray();
      for (int c = 0; c < inputString.Length; c++)
      {

      }

    }
  }
}
