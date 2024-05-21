using System.Text;
using IxIsColorHelper;
  
namespace IxIsColorHelper
{
  //*‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗ • MAIN  ‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗*//
   class MainProgram
  {
     static int cWidth = 81;

     static void Main()
    {/*------------------------------- declare_variables ----------------------------------------*/
      Console.OutputEncoding = Encoding.UTF8;        //    Using Unicode Symbols

      int linebreak = cWidth,                    //   Console Window - Line Break
          choice = 0;                            //   Menu Choice
      string menu,                               //   Program Menu
             input;                              //   User Input

      //*________________________________________// set_settings
      Settings Set = new Settings(); /*          */ Set.ScreenSettings(cWidth);

      //*________________________________________// open_help
      Help Open = new Help();                    // Open.HelpScreen();

      //*________________________________________// call_colorizer
      Colorizer Call = new Colorizer();          // Call.Colorize(input);

      /*------------------------------ main_program ---------------------------------------------*/
      while (true)
      {
        Console.Clear();
        //*______________________________________// print_header
        Header Print = new Header(); /*          */ Print.HeaderMain(cWidth);
        //*______________________________________// show_menu
        MainMenu Show = new MainMenu(); /*       */ Show.Menu(cWidth, choice);
        menu = Show.Menu(cWidth, choice);
        Console.Write(Call.Colorize(menu));

        /*---------------------------- user_input -----------------------------------------------*/
        ///  INPUT-LOOP
        while (true)
        {
          /*-------------------------- check_pressed_key ----------------------------------------*/

          ConsoleKeyInfo keyInfo = Console.ReadKey(true);
          switch (keyInfo.Key)
          {
            /*  -  -  -  -  - ↑↑↑ -  -  -  -  -  */
            case ConsoleKey.UpArrow: /*          */
            case ConsoleKey.W: /*                */
              Console.Write(Call.Colorize($"{"rgb(50,255,50)↑".PadLeft(90)}\r"));
              { choice--; choice = (choice < 0) ? 5 : choice; Console.Clear(); }
              break;

            /*  -  -  -  -  - ↓↓↓ -  -  -  -  -  */
            case ConsoleKey.DownArrow: /*        */
            case ConsoleKey.S: /*                */
              Console.Write(Call.Colorize($"{"rgb(255,255,50)↓".PadLeft(91)}\r"));
              { choice++; choice = (choice <= 5) ? choice : 0; Console.Clear(); }
              break;

            /*  -  -  -  -  - ESC -  -  -  -  -  */
            case ConsoleKey.Escape: /*           */
              Console.Write(Call.Colorize("\nrgb(200,0,0)  ESC -rgb(255,30,30) Program beendet."));
              return;

            /*  -  -  -  -  -ENTER-  -  -  -  -  */
            case ConsoleKey.Enter: /*            */
              Console.Write(Call.Colorize($"{"rgb(0,255,0)⏎".PadLeft(88)}\r"));

              /* - - - - - - - - - - - check_choice - - - - - - - - - - - - - - - - - - - - - - -*/

              switch (choice)
              {
                /*. . . PAINT COLOR PALETTE . . .*/
                case 0:
                  Console.Clear();
                  Print.HeaderMain(cWidth);

                  ColorPalette Draw = new ColorPalette();
                  Draw.InitColorPalette(cWidth);
                  break;

                /* . . . CALCULATE COLOR . . . . */
                case 1:
                  Console.Clear();
                  Print.HeaderMain(cWidth);

                  CalculateColor Calc = new CalculateColor();
                  Calc.InitColorCalc(cWidth);
                  break;

                /* . . GENERATE COLOR WHEELS . . */
                case 2:
                  Console.Clear();
                  Print.HeaderMain(cWidth);

                  ColorWheel ProgramPartWheel = new ColorWheel();
                  ProgramPartWheel.InitColorWheel(cWidth);
                  break;

                /* . . INPUT DIRECT COMMANDS . . */
                case 3:
                  Console.Clear();
                  Print.HeaderMain(cWidth);
                  CodeReader Input = new CodeReader();
                  Input.CodeInput(cWidth);

                  break;

                /* . . . . . SHOW HELP . . . . . */
                case 4:
                  Console.Clear();
                  Print.HeaderMain(cWidth);
                  Console.Write(Call.Colorize("rgb(0,200,0)  Hilfe-Text: "));
                  string helpC = Open.HelpScreen();
                  Console.Write(Call.Colorize(helpC));
                  Console.ReadLine();
                  break;

                /*. . . . . END PROGRAM . . . . .*/
                case 5:

                  Outro View = new Outro();
                  View.Exit(cWidth);
                  Console.WriteLine(Call.Colorize("\n rgb(200,0,0) Programm beendet."));
                  return;
              }
              break;

            /*  -  -  -  -  DEFAULT  -  -  -  -  */
            default:
              Console.WriteLine($"Taste: {keyInfo.KeyChar}".PadLeft(77));
              break;
          }
          break;
        }
      }
    }
  }
}