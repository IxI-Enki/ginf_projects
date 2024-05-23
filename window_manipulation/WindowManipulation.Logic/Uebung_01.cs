using System;
using System.Drawing;
using System.Diagnostics;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using System.Reflection.Metadata;
using System.Xml.Linq;
using System.Xml;
// D:\HTL\~Software - Projekte\Visual Studio Code\[ C# ] - Projekte\
//
//          CABS-GINF\
//                         Uebung-01 -- SetSettings\
//                                                   SetSettings

namespace Ritt_4ACIFT_Abgabe.ConApp
{
  public class Settings
  {
    // Constants:
    public const string PROGRAM_TITLE = " Uebung_01 -- Settings",
                                TITLE = PROGRAM_TITLE;
    // UPDATE_ . . .
    public static void UPDATE_CONST()
    {
      // INTEGER:
      OUTPUT_MODE = Settings.GetConstantINT(0);
      CONSOLE_COLUMNS = Settings.GetConstantINT(1);
      CONSOLE_ROWS = Settings.GetConstantINT(2);
      CONSOLE_W_PXL = Settings.GetConstantINT(3);
      CONSOLE_H_PXL = Settings.GetConstantINT(4);
      CONSOLE_POX = Settings.GetConstantINT(5);
      CONSOLE_POY = Settings.GetConstantINT(6);
      // SBYTE:
      CONSOLE_FONT_SIZE = Settings.GetConstantSBYTE(0);
      // BYTE:
      CONSOLE_TRNSP = Settings.GetConstantBYTE(0);
      // STRINGS:
      ESC = Settings.GetConstantSTRING(0);
      RES = Settings.GetConstantSTRING(1);
      OS = Settings.GetConstantSTRING(2);
    }
    public static void UPDATE_CONSTANTS()
    {
      UPDATE_settings(
      out sbyte console_FONT_SIZE,
      out byte console_TRNSP,
      out int console_OUTPUT_MODE,
      out int console_CONSOLE_COLUMNS,
      out int console_CONSOLE_ROWS,
      out int console_CONSOLE_POX,
      out int console_CONSOLE_POY,
      out int console_CONSOLE_W_PXL,
      out int console_CONSOLE_H_PXL);
    }
    public static void UPDATE_settings(
      out sbyte console_FONT_SIZE,
      out byte console_TRNSP,
      out int console_OUTPUT_MODE,
      out int console_CONSOLE_COLUMNS, out int console_CONSOLE_ROWS,
      out int console_CONSOLE_POX, out int console_CONSOLE_POY,
      out int console_CONSOLE_W_PXL, out int console_CONSOLE_H_PXL
      )
    {
      console_FONT_SIZE = GetConstantSBYTE(0);
      console_TRNSP = GetConstantBYTE(0);
      console_OUTPUT_MODE = GetConstantINT(0);
      console_CONSOLE_COLUMNS = GetConstantINT(1);
      console_CONSOLE_ROWS = GetConstantINT(2);
      console_CONSOLE_W_PXL = GetConstantINT(3);
      console_CONSOLE_H_PXL = GetConstantINT(4);
      console_CONSOLE_POX = GetConstantINT(5);
      console_CONSOLE_POY = GetConstantINT(6);
    }
    // SET_ . . .
    public static void SET_font_SIZE(int size)
    {
      IntPtr hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
      if (hConsole != IntPtr.Zero) { SetFont(hConsole, Convert.ToSByte(size)); }
      else { ERROR.HANDLER(); }
    }

    // GET_ . . .




    // CONSOLE CONSTANTS:
    public static int GetConstantINT(int Param)
    {
      switch (Param)
      {
        case 0:
          return Settings.OUTPUT_MODE;
        case 1:
          return Settings.CONSOLE_COLUMNS;
        case 2:
          return Settings.CONSOLE_ROWS;
        case 3:
          return Settings.CONSOLE_W_PXL;
        case 4:
          return Settings.CONSOLE_H_PXL;
        case 5:
          return Settings.CONSOLE_POX;
        case 6:
          return Settings.CONSOLE_POY;
        default: break;
      }
      return 0;
    }
    public static int GetOutputMode() { return GetConstantINT(0); }
    public static int GetColumns() { return GetConstantINT(1); }
    public static int GetRows() { return GetConstantINT(2); }
    public static int GetWidthPXL() { return GetConstantINT(3); }
    public static int GetHeightPXL() { return GetConstantINT(4); }
    public static int GetPosX() { return GetConstantINT(5); }
    public static int GetPosY() { return GetConstantINT(6); }
    public static Func<int> GetCONSOLE_COLUMNS = () => Console.WindowWidth;
    public static Func<int> GetCONSOLE_ROWS = () => Console.WindowHeight;
    public static int OUTPUT_MODE = 0,  // INIT setting:  0 = black/white
                      CONSOLE_COLUMNS = 90,
                      CONSOLE_ROWS = Convert.ToInt32(CONSOLE_COLUMNS * CONSOLE_SIZE_RATIO),
                      CONSOLE_POX = 150,
                      CONSOLE_POY = 150,
                      CONSOLE_W_PXL = 900,
                      CONSOLE_H_PXL = 480;
    //
    public static byte GetConstantBYTE(int Param)
    {
      switch (Param)
      {
        case 0:
          return Settings.CONSOLE_TRNSP;
        default: break;
      }
      return 0;
    }
    public static byte GetConsoleTRNSP() { return GetConstantBYTE(0); }
    public static byte CONSOLE_TRNSP = 180;
    //
    public static sbyte GetConstantSBYTE(int Param)
    {
      switch (Param)
      {
        case 0:
          return Settings.CONSOLE_FONT_SIZE;
        default: break;
      }
      return 0;
    }
    public static sbyte GetFontSize() { return GetConstantSBYTE(0); }
    public static sbyte CONSOLE_FONT_SIZE = 20;           // 20 px height & 10 px width
    //
    public const double CONSOLE_SIZE_RATIO = 0.5;
    // COLOR CONSTANTS:
    public static string GetConstantSTRING(int Param)
    {
      switch (Param)
      {
        case 0:
          return Settings.ESC;
        case 1:
          return Settings.RES;
        case 2:
          return Settings.OS;
        default: break;
      }
      return null;
    }
    public static string GetESCseq() { return GetConstantSTRING(0); }
    public static string ESC = Color.GetSEQUENCES(0);
    public static string GetRESseq() { return GetConstantSTRING(1); }
    public static string RES = Color.GetSEQUENCES(1);
    public static string GetOS() { return GetConstantSTRING(2); }
    public static string OS = Environment.OSVersion.ToString();
    //
    public static Semaphore semaphore = new Semaphore(1, 1); // Nur ein Thread hat Zugriff

    // Dynamic Link Libraries:
    // - - HANDLE DDL:
    [DllImport("kernel32.dll", SetLastError = true)]  // getting window handle
    public static extern IntPtr GetConsoleWindow();
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr GetStdHandle(int nStdHandle);
    // - - POS DDL:
    /// SetWindowPos: This is a Windows API function
    /// It is used to change the size, position, and Z order of a window
    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SetWindowPos
      (IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
    // - - FONT DDL: 
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CONSOLE_FONT_INFO_EX
    {
      public int cbSize; public int nFont; public COORD dwFontSize; public int FontFamily; public int FontWeight;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = LF_FACESIZE)] public string FaceName;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct COORD { public short X; public short Y; }
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool SetCurrentConsoleFontEx
      (IntPtr hConsoleOutput, bool bMaximumWindow, ref CONSOLE_FONT_INFO_EX lpConsoleCurrentFontEx);
    // - - WINDOWS DDL:
    [DllImport("user32.dll")]
    public static extern int SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);
    [DllImport("user32.dll", SetLastError = true)]
    public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
    [DllImport("user32.dll", SetLastError = true)]
    public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

    // - - POS: - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
    public static readonly IntPtr HWND_TOP = IntPtr.Zero;
    public const uint SWP_NOSIZE = 0x0001;   // flag indicates that the size of the window should not be changed
    public const uint SWP_NOZORDER = 0x0004; // flag indicates that the Z order of the window should not be changed
    public const uint SWP_NOMOVE = 0x0002;   //
    // -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
    public static void SetConsoleWindowPosition(IntPtr hWnd, int x, int y)
    {
      /// hWnd     : Representing the handle to the window whose position we want to set
      ///            In this case, it's the handle to the console window
      /// HWND_TOP : Specifying that the window should be placed at the top of the Z order 
      ///            (above all other windows)
      /// x, y     : Representing the X and Y coordinates of the new position of the window
      /// 0, 0     : Representing the width and height of the window
      ///      !! Since we don't want to change the size of the window, they are set to 0 !!
      /// SWP_NOSIZE | SWP_NOZORDER : These are flags that modify the behavior of SetWindowPos
      ///    SWP_NOSIZE    : Indicates that the size of the window should not be changed
      ///    SWP_NOZORDER  : Indicates that the Z order of the window should not be changed
      ///                    (These flags are combined using the bitwise OR(|) operator)
      SetWindowPos(hWnd, HWND_TOP, x, y, 0, 0, SWP_NOSIZE | SWP_NOZORDER);
    }
    public static void SetConsolePosition(int xPos, int yPos)
    {
        IntPtr consoleWindowHandle = GetConsoleWindow();
        SetConsoleWindowPosition(consoleWindowHandle, xPos, yPos);
      }
      // - - SIZE: - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
      public static void SetConsoleSize(int width_PXL, int height_PXL)
      {
        IntPtr hWnd = GetConsoleWindow();
        SetWindowPos(hWnd, HWND_TOP, 0, 0, width_PXL, height_PXL, SWP_NOMOVE | SWP_NOZORDER);
      }
    // - - FONT: - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    public const int STD_OUTPUT_HANDLE = -11;
    public const int TMPF_TRUETYPE = 4;
    public const int LF_FACESIZE = 32;
    // -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
    public static void SetConsoleFont(sbyte fontSize)
    {
      IntPtr hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
      if (hConsole != IntPtr.Zero)
        SetFont(hConsole, fontSize);
      else
        ERROR.HANDLER();
    }
    public static void SetFont(IntPtr hConsole, sbyte fontSize)
    {
      CONSOLE_FONT_INFO_EX fontInfo = new CONSOLE_FONT_INFO_EX();
      fontInfo.cbSize = Marshal.SizeOf(fontInfo);
      fontInfo.FaceName = "DejaVu Sans Mono";
      fontInfo.dwFontSize.X = 0;                             // Width of font in logical units (pixels)
      fontInfo.dwFontSize.Y = fontSize;                      // Height of font in logical units (pixels)
      fontInfo.FontFamily = TMPF_TRUETYPE;
      if (!SetCurrentConsoleFontEx(hConsole, false, ref fontInfo)) { ERROR.HANDLER(); }
    }
    // - - WINDOS: - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    public const int GWL_EXSTYLE = -20;
    public const int WS_EX_LAYERED = 0x80000;
    public const int LWA_COLORKEY = 0x1;
    public const int LWA_ALPHA = 0x2;
    // -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
    public static void SetCONSOLE_TRSP(byte transparency)
    {
      IntPtr hWnd = GetConsoleWindow();
      // IntPtr hWND = GetStdHandle(STD_OUTPUT_HANDLE);
      // Setze das Konsolenfenster als Layered Window, damit die Transparenz funktioniert
      SetWindowLong(hWnd, GWL_EXSTYLE, GetWindowLong(hWnd, GWL_EXSTYLE) | WS_EX_LAYERED);
      // Setze die Transparenz des Konsolenfensters
      SetLayeredWindowAttributes(hWnd, 0, transparency, LWA_ALPHA);
    }

    public static void SetConsoleSizeROWS_COLUMNS(int wPXL, int hPXL)
    {
      CONSOLE_COLUMNS = wPXL / CONSOLE_FONT_SIZE / 2;
      CONSOLE_ROWS = hPXL / CONSOLE_FONT_SIZE;
    }

    // - - INIT: - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    public static void InitConsole()
    {
      Console.OutputEncoding = Encoding.UTF8;
      Console.CursorVisible = false;
      InitSetting();
      // IntPtr hWnd = GetConsoleWindow();
      // SetWindowPos(hWnd, HWND_TOP, CONSOLE_POX, CONSOLE_POY, CONSOLE_W_PXL, CONSOLE_H_PXL, SWP_NOZORDER);
    }
    public static void SetConsoleSettings(sbyte i)
    {
      if (i == 0)
      {
        SetConsolePosition(0, 0);
        CONSOLE_FONT_SIZE = 20;
        CONSOLE_TRNSP = 200;
        CONSOLE_POX = 150;
        CONSOLE_POY = 150;
        CONSOLE_W_PXL = 900;
        CONSOLE_H_PXL = 480;
      }
      // NOT IMPLEMENTED : SetConsoleFontOpaque(255);
      if (i == -1)
      {
        PromptOutputMode(out OUTPUT_MODE);
      }
      SetConsoleSettings();
    }
    public static void SetConsoleSettings()
    {
      // Pos X & Y on Screen (Pixel)
      SetConsolePosition(CONSOLE_POX, CONSOLE_POY);

      // Console Size (Pixel)
      SetConsoleSize(CONSOLE_W_PXL, CONSOLE_H_PXL);

      // Font Height = Width/2  (Pixel)
      SetConsoleFont
        (CONSOLE_FONT_SIZE);

      //      SetConsoleSizeROWS_COLUMNS(CONSOLE_W_PXL, CONSOLE_H_PXL);
      // Transparency
      SetCONSOLE_TRSP(CONSOLE_TRNSP); // 0 für vollständig transparent, 255 für undurchsichtig
    }

    //// USER SET OUTPUT MODE:
    public static void PromptOutputMode(out int OUTPUT_MODE)
    {
      string[] menuPoints = [
        "  0 = White on Black   ",
        "  1 = Console.Colored  ",
        "  2 = ANSI.Colored     "
        ];
      PromptSetting();
      Console.Write("\nWählen Sie die Art der " +
                    "\nfarblichen Darstellung," +
                    "\ndie ihr Terminal unterstützt.\n" +
                    "\n");

      int mPoints = 0;
      while (mPoints < menuPoints.Length)
      {
        switch (mPoints)
        {
          case 0:
            OUTPUT_MODE = 0;
            break;
          case 1:
            OUTPUT_MODE = 1;
            break;
          case 2:
            OUTPUT_MODE = 2;
            break;
        }
        Color.ColorString("print", "green;black", menuPoints[mPoints]);
        Console.Write("\n");
        mPoints++;
      }
      Console.CursorVisible = true;
      Console.Write("  ");
      string input = Console.ReadLine();
      Console.CursorVisible = false;

      if (int.TryParse(input, out int inputInt) && inputInt > 0 && inputInt <= 3) OUTPUT_MODE = inputInt;
      else OUTPUT_MODE = 0;
    }
    // print settings:
    public static void PrintConsoleSettings()
    {
      OUTPUT_MODE = 0;
      Color.ColorString("print", "red", $"\n  Operating System: "); Color.ColorString("print", "darkgreen", OS);
      OUTPUT_MODE = 1;
      Color.ColorString("print", "red", $"\n  ConsoleSize     : "); Color.ColorString("print", "darkgreen", $"{CONSOLE_COLUMNS} x {CONSOLE_ROWS}");
      OUTPUT_MODE = 2;
      Color.ColorString("print", "red", $"\n  OutputMode      : "); Color.ColorString("print", "darkgreen", OUTPUT_MODE.ToString());
      Console.WriteLine();
    }



    public static void SetPauseScreen(int width, int height)
    {
      SetConsolePosition(0, 0);
      CONSOLE_FONT_SIZE = 36;

      CONSOLE_ROWS = height;
      CONSOLE_COLUMNS = width;
      CONSOLE_TRNSP = 250;

      CONSOLE_W_PXL = CONSOLE_COLUMNS * GetConstantSBYTE(0) / 2;
      CONSOLE_H_PXL = CONSOLE_ROWS * GetConstantSBYTE(0);
      SetConsoleSettings();

      //  SetConsoleFont(CONSOLE_FONT_SIZE);
      //  SetCONSOLE_TRSP(CONSOLE_TRNSP);
      IntPtr hWnd = GetConsoleWindow();
      // IntPtr hWnd = GetStdHandle(STD_OUTPUT_HANDLE);
      SetWindowPos(hWnd, HWND_TOP, 10, 0, CONSOLE_W_PXL, CONSOLE_H_PXL, SWP_NOZORDER);
    }

    public static void InitSetting()
    {
      Settings.CONSOLE_TRNSP = 255;
      Settings.CONSOLE_POX = 0;
      Settings.CONSOLE_POY = 0;
      Settings.CONSOLE_FONT_SIZE = 25;
      Settings.CONSOLE_W_PXL = 1600;
      Settings.CONSOLE_H_PXL = 900;
      Settings.SetConsoleSettings();
      Console.SetCursorPosition(0, 0);

    }
    public static void OutroSetting()
    {
      Settings.CONSOLE_TRNSP = 200;
      Settings.CONSOLE_POX = 0;
      Settings.CONSOLE_POY = 0;
      Settings.CONSOLE_FONT_SIZE = 20;
      Settings.CONSOLE_W_PXL = 1600;
      Settings.CONSOLE_H_PXL = 900;
      Settings.CONSOLE_ROWS = 20;
      Settings.SetConsoleSettings();
      Console.SetCursorPosition(0, 0);
    }
    public static void PromptSetting()
    {
      Settings.CONSOLE_TRNSP = 252;
      Settings.CONSOLE_POX = 355;
      Settings.CONSOLE_POY = 250;
      Settings.CONSOLE_FONT_SIZE = 25;
      Settings.CONSOLE_W_PXL = 450;
      Settings.CONSOLE_H_PXL = 300;
      Settings.SetConsoleSettings();
      Console.SetCursorPosition(0, 0); Console.CursorVisible = false;
    }
    public static void MenuSetting()
    {
      Settings.CONSOLE_TRNSP = 200;
      Settings.CONSOLE_POX = 655;
      Settings.CONSOLE_POY = 250;
      Settings.CONSOLE_FONT_SIZE = 20;
      Settings.CONSOLE_W_PXL = 190;
      Settings.CONSOLE_H_PXL = 180;
      Settings.SetConsoleSettings();
      Console.SetCursorPosition(0, 0); Console.CursorVisible = false;
    }



    // -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   - 
    /*    public static int consoleRed = 255, consoleGreen = 255, consoleBlue = 255;
        public static string[] legendArrowKeys =
          ["ArrowKeys:", " up   : - Pos Y", " down : + Pos Y", " left : - Pos X", " right: + Pos X"];
        public static string[] legendNumPadKeys =
          ["Numpad:", " 8 : - height", " 2 : + height", " 4 : - width", " 6 : + width", " 7 : + opacity", " 1 : - opacity", " 9 : + fontSize", " 3 : - fontSize"];
        public static string[] legendOtherKeys =
          ["OtherKeys:", " R : + red", " E : - red", " G : + green", " F : - green", " B : + blue", " V : - blue"];
    // -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
    */
  }
}
