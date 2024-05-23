using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ritt_4ACIFT_Abgabe.ConApp
{
  public class ERROR
  {
    public static void HANDLER() { ErrorMessage(0); }

    public static string ErrorMessage(int ERRORcode)
    {
      string errorMsg = string.Empty;
      switch (ERRORcode)
      {
        case -1:
          errorMsg = "FAILED to get outputInstruction";
          break;
        case 0:
          errorMsg = "FAILED to get CONSOLE HANDLE";
          break;
        case 1:
          errorMsg = "FAILED to get";
          break;
        case 2:
          errorMsg = "FAILED to get";
          break;

        default:
          errorMsg = "unknown ERROR";
          break;
      }
      Color.ColorString("print", "black;red", errorMsg);
      return errorMsg;
    }

    internal static void COLOR(int ERRORcode)
    {
      switch (ERRORcode)
      {
        case 0:
          ErrorMessage(-1);
          break;
      }
    }
  }
}
