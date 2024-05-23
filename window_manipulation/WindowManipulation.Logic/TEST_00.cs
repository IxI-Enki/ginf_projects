using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ritt_4ACIFT_Abgabe.ConApp
{
  public class TEST_00_Null
  {


    public static void PrintTestSeperator(bool testPASSED)
    {
      Console.WriteLine();
      for (int w = 0; w < Settings.GetCONSOLE_COLUMNS(); w++)
        Color.ColorString("print", $"{(testPASSED ? "green" : "red")}", "-");
      Console.ReadLine();
    }
  }
}
