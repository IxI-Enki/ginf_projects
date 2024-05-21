using System.Reflection.PortableExecutable;
using System.Text;

namespace MyGameOfLife
{
  internal class MyGoLLogic
  {
    /*━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┯━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━*/
    public static string header = "GameOfLife";          //│ give the program a different name HERE
    public static int consoleWidth = 55,                 //│ set ConsoleWidth                  HERE
                      consoleHeight = consoleWidth / 3;  //│ console height is third of the width  
    /*─────────────────────────────────────────────────────┼─────────────────────────────────────*/
    public static int frame = 0,                         //│ framecounter                          
                      maxFrame = 254;                    //│ frameLimit                            
    /*─────────────────────────────────────────────────────┼─────────────────────────────────────*/
    public static int lastW = consoleWidth - 1,          //│ to make my life easier                
                      lastH = consoleHeight - 1;         //│ to make my life easier                
    /*─────────────────────────────────────────────────────┼─────────────────────────────────────*/
    public static string[] pixelAttributes =             //│ pixelAttributes:                      
      [                                                  //│                                       
        "temporaryState",                                //│  0 = nextState   0:dead    1:alive    
        "liveState",                                     //│  1 = lifeState   0:dead    1:alive    
        "neighbours",                                    //│  2 = neighbours  0:ignore  "12345678" 
        "lifeNeighbours",                                //│  3 = aliveNeighbours                  
        "charState",                                     //│  4 = charState   0:ignore  charToPrint
        "colorState",                                    //│  5 = colorState  0:ignore  "fore;back"
      ];                                                 //│                                       
    public static int numberOfPixelAttributes =          //│                                       
                        pixelAttributes.Length;          //│                                       
    public static string[,,] playfieldPixels             //│                                       
            = new string[                                //│                                       
                          consoleWidth - 0,              //│                                       
                          consoleHeight - 3,             //│                                       
                          numberOfPixelAttributes        //│                                       
                          ];                             //│                                       
                                                         //│                                       
    public static string[,,] consolePixels               //│ states of the screen pixels           
            = new string[                                //│                                       
                          consoleWidth, consoleHeight,   //│ each pixel @ wIdx/hIdx has:           
                          numberOfPixelAttributes        //│  Attributes 0 to 5                    
                          ];                             //│                                       
    public static int[] userChoices = new int[3];        //│                                       
    /*─────────────────────────────────────────────────────┼─────────────────────────────────────*/

    ///.     ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
    ///.     ┃                            __ GAME __ OF __ LIFE __                                ┃
    ///.     ┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━┯━━━━━━━━━━━━━━━━━━━━━━┯━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫
    ///.  ³³ ┃       by John Conway       │     MAIN PROGRAM     │     programmed by Jan Ritt     ┃
    ///. ━━━━┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━┷━━━━━━━━━━━━━━━━━━━━━━┷━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫
    ///.     ┃                                                                                    ┃
    ///.     ┠────────────────────────────                                                        ┃
    ///.     ┃ MAIN :                                                                             ┃
    ///<summary>                                                                                   
    ///Main entry point of the program                                                            ┃
    ///</summary>.                                                                                ┃
    ///.     ┖────────────────────────────╮                                                       ┃
    static void Main() //. ═══════════════╪═════════════════════════════════════════════════════╗ ┃
    {                                   //│                                                     ║ ┃
      SetSettings();                    //│  1 set console settings                             ║ ┃
      PlayIntro();                      //│  2 print program usage                              ║ ┃
      PlayGameLogic();                  //│  3 give the "player" a cursor                       ║ ┃
      ExitProgram();                    //│  4 print exit message                               ║ ┃
    }                                   //│                                                     ║ ┃
    ///. ━━━━┓════════════════════════════╧═════════════════════════════════════════════════════╝ ┃
    ///. ━━━━┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
    ///
    ///.     ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
    ///.     ┃ Play Intro :                                                                       ┃
    ///<summary>                                                                                   
    ///Prints the Header and the explanation of the program usage                                 ┃
    ///</summary>.                                                                                ┃
    ///.     ┖────────────────────────────────────────────────────╮                               ┃
    private static void PlayIntro() //. ══════════════════════════╪═════════════════════════════╗ ┃
    {                                                           //│                             ║ ┃
      PrintHeader();                                            //│                             ║ ┃
      Thread.Sleep(2000);                                       //│                             ║ ┃
      Console.SetCursorPosition(0, 4);                          //│                             ║ ┃
      ColorString("print", "white;darkgreen",                   //│                             ║ ┃
                "Mit Pfeiltasten/WASD wird der Cursor bewegt.");//│                             ║ ┃
      Thread.Sleep(1000);                                       //│                             ║ ┃
      Console.SetCursorPosition(0, 7);                          //│                             ║ ┃
      ColorString("print", "white;red",                         //│                             ║ ┃
                "Mit C wird das Programm beendet.");            //│                             ║ ┃
      Console.ReadLine();                                       //│                             ║ ┃
      Console.Clear();                                          //│                             ║ ┃
    }                                                           //│                             ║ ┃
    ///. ━━━━┓════════════════════════════════════════════════════╧═════════════════════════════╝ ┃
    ///.     ┃ PlayGameLogic :                                                                    ┃
    ///<summary>                                                                                   
    ///Let the player choose life and dead pixels                                                 ┃
    ///</summary>.                                                                                ┃
    ///.     ┖────────────────────────────────────────────────────╮                               ┃
    static void PlayGameLogic() //. ══════════════════════════════╪═════════════════════════════╗ ┃
    {                                                           //│                             ║ ┃
      string line = "";                                         //╰────────╮                    ║ ┃
      for (int hIdx = 0; hIdx < playfieldPixels.GetLength(1); hIdx++)    //│                    ║ ┃
      {                                                                  //│                    ║ ┃
        for (int wIdx = 0; wIdx < playfieldPixels.GetLength(0); wIdx++)  //│                    ║ ┃
        {                                                        //╭───────╯                    ║ ┃
          playfieldPixels[wIdx, hIdx, 1] = "0";                  //│                            ║ ┃
          line = line + playfieldPixels[0, hIdx, 1];             //│                            ║ ┃
        }                                                        //│                            ║ ┃
        Console.SetCursorPosition(0, hIdx);                      //│                            ║ ┃
        ColorString("print", $"0,0,{frame * 20};darkgrey", line);//│                            ║ ┃
        line = "";                                               //│                            ║ ┃
      }                                                          //│                            ║ ┃
      // cursor:                                                 //│                            ║ ┃
      Console.CursorVisible = false;                             //│                            ║ ┃
      int[] cursorCoordinates = new int[2];                      //│                            ║ ┃
      int cursorWIdx = 0,                                        //│                            ║ ┃
          cursorHIdx = 1;                                        //│                            ║ ┃
      int cursorPosW = 0,                                        //│                            ║ ┃
          cursorPosH = 0;                                        //│                            ║ ┃
      bool run = true;                                           //│                            ║ ┃
      while (run)                                                //│                            ║ ┃
      {                                                          //╰─────────╮                  ║ ┃
        Console.SetCursorPosition(consoleWidth / 2 - 5, consoleHeight - 1);//│                  ║ ┃
        ColorString("print", "0,120,88;darkgrey", "Enter: swap");          //│                  ║ ┃
        Console.SetCursorPosition(consoleWidth / 2 - 5, consoleHeight - 2);//│                  ║ ┃
        ColorString("print", "0,100,68;darkgrey", " Esc: run  ");          //│                  ║ ┃
        Console.SetCursorPosition(consoleWidth / 2 - 5, consoleHeight - 3);//│                  ║ ┃
        ColorString("print", "0,70,40;darkgrey", " R: random ");           //│                  ║ ┃
        if (Console.KeyAvailable)                                          //│                  ║ ┃
        {                                                                  //│                  ║ ┃
          Console.SetCursorPosition(cursorCoordinates[cursorWIdx],         //│                  ║ ┃
                                    cursorCoordinates[cursorHIdx]);        //│                  ║ ┃
          if (playfieldPixels[cursorCoordinates[cursorWIdx],               //│                  ║ ┃
                              cursorCoordinates[cursorHIdx], 1] == "1")    //│                  ║ ┃
            ColorString("print", $"0,255,255;darkgreen",                   //│                  ║ ┃
              playfieldPixels[cursorCoordinates[cursorWIdx],               //│                  ║ ┃
                              cursorCoordinates[cursorHIdx], 1]);          //│                  ║ ┃
          else                                                             //│                  ║ ┃
            ColorString("print", $"black;darkgrey",                        //│                  ║ ┃
              playfieldPixels[cursorCoordinates[cursorWIdx],               //│                  ║ ┃
                              cursorCoordinates[cursorHIdx], 1]);          //│                  ║ ┃
                                                                           //│                  ║ ┃
          ConsoleKeyInfo keyInfo = Console.ReadKey(true);            //╭─────╯                  ║ ┃
          switch (keyInfo.Key)                                       //│                        ║ ┃
          {                                                          //│                        ║ ┃
            case ConsoleKey.UpArrow:                                 //│                        ║ ┃
            case ConsoleKey.W:                                       //│                        ║ ┃
              {                                                      //│                        ║ ┃
                cursorPosH--;                                        //│                        ║ ┃
                cursorPosH = cursorPosH < 0 ? playfieldPixels.GetLength(1) - 1 : cursorPosH; // ║ ┃
              }                                                      //│                        ║ ┃
              break;                                                 //│                        ║ ┃
            case ConsoleKey.DownArrow:                               //│                        ║ ┃
            case ConsoleKey.S:                                       //│                        ║ ┃
              {                                                      //│                        ║ ┃
                cursorPosH++;                                        //│                        ║ ┃
                cursorPosH = cursorPosH > playfieldPixels.GetLength(1) - 1 ? 0 : cursorPosH; // ║ ┃
              }                                                      //│                        ║ ┃
              break;                                                 //│                        ║ ┃
            case ConsoleKey.LeftArrow:                               //│                        ║ ┃
            case ConsoleKey.A:                                       //│                        ║ ┃
              {                                                      //│                        ║ ┃
                cursorPosW--;                                        //│                        ║ ┃
                cursorPosW = cursorPosW < 0 ? playfieldPixels.GetLength(0) - 1 : cursorPosW; // ║ ┃
              }                                                      //│                        ║ ┃
              break;                                                 //│                        ║ ┃
            case ConsoleKey.RightArrow:                              //│                        ║ ┃
            case ConsoleKey.D:                                       //│                        ║ ┃
              {                                                      //│                        ║ ┃
                cursorPosW++;                                        //│                        ║ ┃
                cursorPosW = cursorPosW > playfieldPixels.GetLength(0) - 1 ? 0 : cursorPosW; // ║ ┃
              }                                                      //│                        ║ ┃
              break;                                                 //│                        ║ ┃
            case ConsoleKey.E:                                       //│                        ║ ┃
            case ConsoleKey.Enter:                                   //│                        ║ ┃
              {                                                      //│                        ║ ┃
                playfieldPixels[cursorCoordinates[cursorWIdx],       //│                        ║ ┃
                                cursorCoordinates[cursorHIdx], 1] =  //│                        ║ ┃
                  playfieldPixels[cursorCoordinates[cursorWIdx],     //╰─────────────────╮      ║ ┃
                                  cursorCoordinates[cursorHIdx], 1] == "0" ? "1" : "0";//│      ║ ┃
              }                                                      //╭─────────────────╯      ║ ┃
              break;                                                 //│                        ║ ┃
            case ConsoleKey.Escape:                                  //│                        ║ ┃
              //RunTest();                                           //│                        ║ ┃
              RunLogic();                                            //│                        ║ ┃
              break;                                                 //│                        ║ ┃
            case ConsoleKey.R:                                       //│                        ║ ┃
              SetRandomPixelsAlive(10);                              //│                        ║ ┃
              break;                                                 //│                        ║ ┃
            case ConsoleKey.C:                                       //│                        ║ ┃
              return;                                                //│                        ║ ┃
          }                                                          //│                        ║ ┃
        }                                                            //│                        ║ ┃
        cursorCoordinates[cursorWIdx] = cursorPosW;                  //│                        ║ ┃
        cursorCoordinates[cursorHIdx] = cursorPosH;                  //│                        ║ ┃
        Console.SetCursorPosition(cursorCoordinates[cursorWIdx],     //│                        ║ ┃
                                  cursorCoordinates[cursorHIdx]);    //│                        ║ ┃
        if (playfieldPixels[cursorCoordinates[cursorWIdx],           //│                        ║ ┃
                            cursorCoordinates[cursorHIdx], 1] == "1")//│                        ║ ┃
        {                                                            //│                        ║ ┃
          ColorString("print", "red;darkgreen", "+");                //│                        ║ ┃
        }                                                            //│                        ║ ┃
        else                                                         //│                        ║ ┃
          ColorString("print", "red;darkgrey", "+");                 //│                        ║ ┃
      }                                                         //╭────╯                        ║ ┃
    }                                                           //│                             ║ ┃
    ///. ━━━━┓════════════════════════════════════════════════════╧═════════════════════════════╝ ┃
    ///.     ┃ RunLogic :                                                                         ┃
    ///<summary>                                                                                   
    ///                                                                                         ┃
    ///</summary>.                                                                                ┃
    ///.     ┖────────────────────────────────────────────────────╮                               ┃
    static void RunLogic() //. ═══════════════════════════════════╪═════════════════════════════╗ ┃
    { ///.                                                        │                             ║ ┃
      FindNeighbours(playfieldPixels);                          //│                             ║ ┃
      int times = 0;                                            //│                             ║ ┃
      bool run = true;                                          //│                             ║ ┃
      do                                                        //│                             ║ ┃
      {                                                         //│                             ║ ┃
        Thread.Sleep(0);                                        //│                             ║ ┃
        PrintLifeNeighbours(playfieldPixels);                   //│                             ║ ┃
        Thread.Sleep(0);                                        //│                             ║ ┃
        SetLifeStates();                                        //│                             ║ ┃
        PrintLifeState(playfieldPixels);                        //│                             ║ ┃
        if (times <= 0)                                         //╰──────────────╮              ║ ┃
        {                                                                      //│              ║ ┃
          Console.SetCursorPosition(consoleWidth / 2 - 5, consoleHeight - 3);  //│              ║ ┃
          ColorString("print", "0,157,0;darkgrey", "R: run x10 ");             //│              ║ ┃
          WaitForUser(out run, out times);                                     //│              ║ ┃
        }                                                                      //│              ║ ┃
        times--;                                                               //│              ║ ┃
        Console.SetCursorPosition(consoleWidth / 2 - 5, consoleHeight - 3);    //│              ║ ┃
        ColorString("print", "0,157,0;0,46,0", $"R: run x{times}  ");          //│              ║ ┃
      } while (run);                                                           //│              ║ ┃
    }                                                           //╭──────────────╯              ║ ┃
    ///. ━━━━┓════════════════════════════════════════════════════╧═════════════════════════════╝ ┃
    ///.     ┃ WaitForUser :                                                                      ┃
    ///<summary>                                                                                   
    ///                                                                                         ┃
    ///</summary>.                                                                                ┃
    ///.     ┖────────────────────────────────────────────────────╮                               ┃
    private static void WaitForUser //. ══════════════════════════╪═════════════════════════════╗ ┃
      (out bool run, out int times) //.                           │ > RUN + STEP AMOUNT         ║ ┃
    { ///.                                                        ╰─────────╮                   ║ ┃
      run = true;                                                         //│                   ║ ┃
      Console.SetCursorPosition(consoleWidth / 2 - 5, consoleHeight - 2); //│                   ║ ┃
      Thread.Sleep(200);                                                  //│                   ║ ┃
      ColorString("print", "0,120,88;darkgrey", "Enter: run ");           //│                   ║ ┃
      Console.SetCursorPosition(consoleWidth / 2 - 5, consoleHeight - 1); //│                   ║ ┃
      ColorString("print", "120,33,0;55,0,0", "Esc: cursor");             //│                   ║ ┃
      Console.SetCursorPosition(0, 0);                                    //│                   ║ ┃
      do                                                        //╭─────────╯                   ║ ┃
      {                                                         //│                             ║ ┃
        if (Console.KeyAvailable)                               //│                             ║ ┃
        {                                                       //│                             ║ ┃
          ConsoleKeyInfo keyInfo = Console.ReadKey(true);       //│                             ║ ┃
          switch (keyInfo.Key)                                  //│                             ║ ┃
          {                                                     //│                             ║ ┃
            case ConsoleKey.Escape:                             //│                             ║ ┃
              run = false;                                      //│                             ║ ┃
              times = 1;                                        //│                             ║ ┃
              return;                                           //│                             ║ ┃
            case ConsoleKey.Enter:                              //│                             ║ ┃
              run = true;                                       //│                             ║ ┃
              times = 1;                                        //│                             ║ ┃
              return;                                           //│                             ║ ┃
            case ConsoleKey.R:                                  //│                             ║ ┃
              run = true;                                       //│                             ║ ┃
              times = 10;                                       //│                             ║ ┃
              return;                                           //│                             ║ ┃
          }                                                     //│                             ║ ┃
        }                                                       //│                             ║ ┃
      } while (true);                                           //│                             ║ ┃
    }                                                           //│                             ║ ┃
    ///. ━━━━┓════════════════════════════════════════════════════╧═════════════════════════════╝ ┃
    ///. ━━━━┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛

    ///.     ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
    ///.     ┃ TESTS :                                                                            ┃
    ///.     ┠────────────────────────────                                                        ┃
    ///.     ┃ RunTest :                                                                          ┃
    ///<summary>                                                                                   
    ///Run the test logic                                                                         ┃
    ///</summary>.                                                                                ┃
    ///.     ┖────────────────────────────────────────────────────╮                               ┃
    static void RunTest() //. ════════════════════════════════════╪═════════════════════════════╗ ┃
    {                                                           //│                             ║ ┃
      /// setup:                                                //│                             ║ ┃
      FindNeighbours(playfieldPixels);                          //│                             ║ ┃
      do                                                        //│                             ║ ┃
      {                                                         //│                             ║ ┃
        // animations:                                          //│                             ║ ┃
        RotateThroughNeighbours(playfieldPixels);               //│                             ║ ┃
        // LIFE:                                                //│                             ║ ┃
        PrintLifeState(playfieldPixels);                        //│                             ║ ┃
        Console.SetCursorPosition(0, 0);                        //│                             ║ ┃
        ColorString("print", "black;blue", "lifeState:");       //│                             ║ ┃
        ///Thread.Sleep(0);                                     //│                             ║ ┃
        Console.ReadLine();                                     //│                             ║ ┃
        // LIFENEIGHBOURS:                                      //│                             ║ ┃
        PrintLifeNeighbours(playfieldPixels);                   //│                             ║ ┃
        Console.SetCursorPosition(0, 0);                        //╰╮                            ║ ┃
        ColorString("print", "black;green", "alive Neighbours:");//│                            ║ ┃
        ///Thread.Sleep(10);                                    //╭╯                            ║ ┃
        Console.ReadLine();                                     //│                             ║ ┃
        // SET NEW LIFES:                                       //│                             ║ ┃
        SetLifeStates();                                        //│                             ║ ┃
        Console.SetCursorPosition(0, 0);                        //│                             ║ ┃
        ColorString("print", "black;red", "new lifeStates:");   //│                             ║ ┃
        ///Thread.Sleep(500);                                   //│                             ║ ┃
      } while (true);                                           //│                             ║ ┃
    }                                                           //│                             ║ ┃
    ///. ━━━━┓════════════════════════════════════════════════════╧═════════════════════════════╝ ┃
    ///.     ┃ Print Demo :                                                                       ┃
    ///<summary>                                                                                   
    ///Print a text: "DEM" on test logics DemoScreens                                             ┃
    ///</summary>.                                                                                ┃
    ///.     ┖────────────────────────────────────────────────────╮                               ┃
    private static void PrintDemo //. ════════════════════════════╪═════════════════════════════╗ ┃
      (string[,,] array) //.                                      │ > PLAYFIELD ARRAY           ║ ┃
    { ///.                                                        │                             ║ ┃
      Console.SetCursorPosition((array.GetLength(0) / 2) - 1,  //.│                             ║ ┃
                                 array.GetLength(1) / 2);      //.│                             ║ ┃
      ColorString("print", "red;black", "DEM");                //.│                             ║ ┃
    }                                                          //.│                             ║ ┃
    ///. ━━━━┓════════════════════════════════════════════════════╧═════════════════════════════╝ ┃
    ///.     ┃ SetRandomPixelsAlive:                                                              ┃
    ///<summary>                                                                                   
    ///                                                                                         ┃
    ///</summary>.                                                                                ┃
    ///.     ┖────────────────────────────────────────────────────╮                               ┃
    static void SetRandomPixelsAlive //. ═════════════════════════╪═════════════════════════════╗ ┃
      (int randomAmounts) //.                                     │ > NUMBER OF ALIVE CELLS     ║ ┃
    { ///.                                                        │                             ║ ┃
      Random width = new Random(),                             //.│                             ║ ┃
            height = new Random();                             //.│                             ║ ┃
      for (int i = 0; i < randomAmounts; i++)                  //.│                             ║ ┃
      {                                                        //.╰─────────╮                   ║ ┃
        int randomWidth = width.Next(0, playfieldPixels.GetLength(0));   //.│                   ║ ┃
        int randomHeight = height.Next(0, playfieldPixels.GetLength(1)); //.│                   ║ ┃
                                                                         //.│                   ║ ┃
        SetLifeAttribute(randomWidth, randomHeight, playfieldPixels);    //.│                   ║ ┃
      }                                                        //.╭─────────╯                   ║ ┃
      PrintLifeState(playfieldPixels);                         //.│                             ║ ┃
    }                                                          //.│                             ║ ┃
    ///. ━━━━┓════════════════════════════════════════════════════╧═════════════════════════════╝ ┃
    ///.     ┃ SetLifeAttribute:                                                                  ┃
    ///<summary>
    ///
    ///</summary>.                                                                                ┃
    ///<param name="wIdx">                                                                </param>┃
    ///<param name="hIdx">                                                                </param>┃
    ///<param name="array">                                                               </param>┃
    ///.     ┖────────────────────────────────────────────────────╮                               ┃
    static void SetLifeAttribute //. ═════════════════════════════╪═════════════════════════════╗ ┃
      (int wIdx, int hIdx, string[,,] array) //.                  │ > COORDINATES: W, H         ║ ┃
    { ///.                                                        │   + PLAYFIELD ARRAY         ║ ┃
      array[wIdx, hIdx, 1] = "1";                              //.│  array_attribute 1 : "1"    ║ ┃
    }                                                          //.│                             ║ ┃
    ///. ━━━━┓════════════════════════════════════════════════════╧═════════════════════════════╝ ┃
    ///. ━━━━┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛

    ///.     ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
    ///.     ┃ NEIGHBOURS :                                                                       ┃
    ///.     ┠────────────────────────────                                                        ┃
    ///.     ┃ FindNeighbours :                                                                   ┃
    ///<summary>                                                                                   
    ///                                                                                         ┃
    ///</summary>.                                                                                ┃
    ///.     ┖────────────────────────────────────────────────────╮                               ┃
    static void FindNeighbours //. ═══════════════════════════════╪═════════════════════════════╗ ┃
      (string[,,] array) //.                                      │ > PLAYFIELD ARRAY           ║ ┃
    { ///.                                                        │                             ║ ┃
      ///positions of neighbours:                                 │                             ║ ┃
      ///8  1  2                                                  │                             ║ ┃
      ///7  +  3                                                  │                             ║ ┃
      ///6  5  4                                                  │                             ║ ┃
      for (int wIdx = 0; wIdx < array.GetLength(0); wIdx++)     //│                             ║ ┃
      {                                                         //│                             ║ ┃
        for (int hIdx = 0; hIdx < array.GetLength(1); hIdx++)   //│                             ║ ┃
        {                                                       //│                             ║ ┃
          array[wIdx, hIdx, 2] = "";                            //│                             ║ ┃
          ///corners:                                           //│                             ║ ┃
          if (wIdx == 0 && hIdx == 0)                           //│                             ║ ┃
          {                                                     //│                             ║ ┃
            array[wIdx, hIdx, 2] = "345";                       //│                             ║ ┃
          }                                                     //│                             ║ ┃
          else if (wIdx == 0 && hIdx == array.GetLength(1) - 1) //│                             ║ ┃
          {                                                     //│                             ║ ┃
            array[wIdx, hIdx, 2] = "123";                       //│                             ║ ┃
          }                                                     //│                             ║ ┃
          else if (wIdx == array.GetLength(0) - 1 && hIdx == 0) //│                             ║ ┃
          {                                                     //│                             ║ ┃
            array[wIdx, hIdx, 2] = "567";                       //│                             ║ ┃
          }                                                     //│                             ║ ┃
          else if (wIdx == array.GetLength(0) - 1               //│                             ║ ┃
                        && hIdx == array.GetLength(1) - 1)      //│                             ║ ┃
          {                                                     //│                             ║ ┃
            array[wIdx, hIdx, 2] = "781";                       //│                             ║ ┃
          }                                                     //╰──────────────╮              ║ ┃
          ///sides:                                                            //│              ║ ┃
          else if (wIdx == 0 && (hIdx > 0 && hIdx < array.GetLength(1) - 1))   //│              ║ ┃
          {                                                                    //│              ║ ┃
            array[wIdx, hIdx, 2] = "12345";                                    //│              ║ ┃
          }                                                                    //│              ║ ┃
          else if (wIdx == array.GetLength(0) - 1                              //│              ║ ┃
                        && (hIdx > 0 && hIdx < array.GetLength(1) - 1))        //│              ║ ┃
          {                                                                    //│              ║ ┃
            array[wIdx, hIdx, 2] = "56781";                                    //│              ║ ┃
          }                                                                    //│              ║ ┃
          else if (hIdx == 0 && (wIdx > 0 && wIdx < array.GetLength(0) - 1))   //│              ║ ┃
          {                                                                    //│              ║ ┃
            array[wIdx, hIdx, 2] = "34567";                                    //│              ║ ┃
          }                                                                    //│              ║ ┃
          else if (hIdx == array.GetLength(1) - 1                              //│              ║ ┃
                        && (wIdx > 0 && wIdx < array.GetLength(0) - 1))        //│              ║ ┃
          {                                                                    //│              ║ ┃
            array[wIdx, hIdx, 2] = "78123";                                    //│              ║ ┃
          }                                                     //╭──────────────╯              ║ ┃
          ///inside:                                            //│                             ║ ┃
          else                                                  //│                             ║ ┃
            array[wIdx, hIdx, 2] = "12345678";                  //│                             ║ ┃
        }                                                       //│                             ║ ┃
      }                                                         //│                             ║ ┃
    }                                                           //│                             ║ ┃
    ///. ━━━━┓════════════════════════════════════════════════════╧═════════════════════════════╝ ┃
    ///.     ┃ RotateThroughNeighbours :                                                          ┃
    ///<summary>                                                                                   
    ///                                                                                         ┃
    ///</summary>.                                                                                ┃
    ///.     ┖────────────────────────────────────────────────────╮                               ┃
    private static void RotateThroughNeighbours //. ══════════════╪═════════════════════════════╗ ┃
      (string[,,] array) //.                                      │ > PLAYFIELD ARRAY           ║ ┃
    { ///.                                                        │                             ║ ┃
      bool runFrames;                                           //│                             ║ ┃
      do                                                        //│                             ║ ┃
      {                                                         //│                             ║ ┃
        for (int wIdx = 0; wIdx < array.GetLength(0); wIdx++)   //│                             ║ ┃
        {                                                       //│                             ║ ┃
          for (int hIdx = 0; hIdx < array.GetLength(1); hIdx++) //│                             ║ ┃
          {                                                     //│                             ║ ┃
            Console.SetCursorPosition(wIdx, hIdx);              //│                             ║ ┃
            PrintNeighbour(wIdx, hIdx, array, frame);           //│                             ║ ┃
            PrintDemo(array);                                   //│                             ║ ┃
          }                                                     //│                             ║ ┃
        }                                                       //│                             ║ ┃
        frame = (frame + 1) % 30;                               //│                             ║ ┃
        runFrames = frame < 29 ? true : false;                  //│                             ║ ┃
      } while (runFrames);                                      //│                             ║ ┃
    }                                                           //│                             ║ ┃
    ///. ━━━━┓════════════════════════════════════════════════════╧═════════════════════════════╝ ┃
    ///.     ┃ FindLivingNeighbours :                                                             ┃
    ///<summary>                                                                                   
    ///                                                                                         ┃
    ///</summary>.                                                                                ┃
    ///.     ┖────────────────────────────────────────────────────╮                               ┃
    static void FindLivingNeighbours //. ═════════════════════════╪═════════════════════════════╗ ┃
      (string[,,] array) //.                                      │ > PLAYFIELD ARRAY           ║ ┃
    { ///.                                                        │                             ║ ┃
      for (int wIdx = 0; wIdx < array.GetLength(0); wIdx++)    //.│                             ║ ┃
      {                                                        //.│                             ║ ┃
        for (int hIdx = 0; hIdx < array.GetLength(1); hIdx++)  //.│                             ║ ┃
        {                                                      //.╰───╮                         ║ ┃
          if (playfieldPixels[wIdx, hIdx, 1] == "1")               //.│                         ║ ┃
          {                                                        //.│                         ║ ┃
            CheckNeighbours(wIdx, hIdx, out int livingNeighbours); //.╰───╮                     ║ ┃
            if (livingNeighbours >= 2 && livingNeighbours <= 3)        //.│                     ║ ┃
            {                                                          //.│                     ║ ┃
              playfieldPixels[wIdx, hIdx, 0] = "1";                    //.│                     ║ ┃
            }                                                          //.│                     ║ ┃
            else                                                       //.│                     ║ ┃
            {                                                          //.│                     ║ ┃
              playfieldPixels[wIdx, hIdx, 0] = "0";                    //.│                     ║ ┃
            }                                                          //.│                     ║ ┃
          }                                                        //.╭───╯                     ║ ┃
          if (playfieldPixels[wIdx, hIdx, 1] == "0")               //.│                         ║ ┃
          {                                                        //.│                         ║ ┃
            CheckNeighbours(wIdx, hIdx, out int livingNeighbours); //.╰───╮                     ║ ┃
            if (livingNeighbours == 3)                                 //.│                     ║ ┃
            {                                                          //.│                     ║ ┃
              playfieldPixels[wIdx, hIdx, 0] = "1";                    //.│                     ║ ┃
            }                                                          //.│                     ║ ┃
          }                                                    //.╭───────╯                     ║ ┃
        }                                                      //.│                             ║ ┃
      }                                                        //.│                             ║ ┃
    }                                                          //.│                             ║ ┃
    ///. ━━━━┓════════════════════════════════════════════════════╧═════════════════════════════╝ ┃
    ///.     ┃ CheckNeighbours :                                                                  ┃
    ///<summary>                                                                                   
    ///                                                                                         ┃
    ///</summary>.                                                                                ┃
    ///.     ┖────────────────────────────────────────────────────╮                               ┃
    static void CheckNeighbours //. ══════════════════════════════╪═════════════════════════════╗ ┃
      (int wIdx, int hIdx, //.                                    │ > COORDINATES               ║ ┃
      out int livingNeighbours) //.                               │ > NUMBER OF LIVING NEIGBOURS║ ┃
    { ///.                                                        │                             ║ ┃
      livingNeighbours = 0;                                    //.│                             ║ ┃
      // e.g.: array[wIdx,hIdx,2] = "12345678"                 //.│                             ║ ┃
      string inputNeighbours = playfieldPixels[wIdx, hIdx, 2]; //.│                             ║ ┃
      int numberOfNeighbours = inputNeighbours.Length;         //.╰───╮                         ║ ┃
      int convertedNeighbours = Convert.ToInt32(inputNeighbours);  //.│                         ║ ┃
                                                                   //.│                         ║ ┃
      int[] neighbours = new int[numberOfNeighbours];              //.│                         ║ ┃
      ///neighbours[0] = 1 ... means look to the north                │                         ║ ┃
      ///neighbours[1] = 2 ... means look to the northeast            │                         ║ ┃
      ///neighbours[2] = 3 ...                   east                 │                         ║ ┃
      ///neighbours[3] = 4 ..                    and so on            │                         ║ ┃
                                                                   //.│                         ║ ┃
      int temp = convertedNeighbours;                              //.│                         ║ ┃
      for (int nIdx = 0; nIdx < numberOfNeighbours; nIdx++)        //.│                         ║ ┃
      {                                                            //.│                         ║ ┃
        neighbours[nIdx] = temp % 10;                              //.│                         ║ ┃
        temp = temp / 10;                                          //.│                         ║ ┃
        livingNeighbours = isAlive(wIdx, hIdx, neighbours[nIdx])   //.│                         ║ ┃
                         ? livingNeighbours + 1 : livingNeighbours;//.│                         ║ ┃
      }                                                        //.╭───╯                         ║ ┃
    }                                                          //.│                             ║ ┃
    ///. ━━━━┓════════════════════════════════════════════════════╧═════════════════════════════╝ ┃
    ///.     ┃ isAlive :                                                                          ┃
    ///<summary>                                                                                   
    ///                                                                                         ┃
    ///</summary>.                                                                                ┃
    ///.     ┖────────────────────────────────────────────────────╮                               ┃
    static bool isAlive //. ══════════════════════════════════════╪═════════════════════════════╗ ┃
      (int wIdx, int hIdx, //.                                    │ > COORDINATES               ║ ┃
      int direction) //.                                          │ > PLAYFIELD ARRAY           ║ ┃
    { ///.                                                        │                             ║ ┃
      bool isAlive = false;                                    //.│                             ║ ┃
      if (direction == 1)                                      //.│                             ║ ┃
      {                                                        //.│                             ║ ┃
        isAlive = (playfieldPixels                             //.│                             ║ ┃
          [wIdx, hIdx - 1, 1] == "1") ? true : false;          //.│                             ║ ┃
      }                                                        //.│                             ║ ┃
      if (direction == 2)                                      //.│                             ║ ┃
      {                                                        //.│                             ║ ┃
        isAlive = (playfieldPixels                             //.│                             ║ ┃
          [wIdx + 1, hIdx - 1, 1] == "1") ? true : false;      //.│                             ║ ┃
      }                                                        //.│                             ║ ┃
      if (direction == 3)                                      //.│                             ║ ┃
      {                                                        //.│                             ║ ┃
        isAlive = (playfieldPixels                             //.│                             ║ ┃
          [wIdx + 1, hIdx, 1] == "1") ? true : false;          //.│                             ║ ┃
      }                                                        //.│                             ║ ┃
      if (direction == 4)                                      //.│                             ║ ┃
      {                                                        //.│                             ║ ┃
        isAlive = (playfieldPixels                             //.│                             ║ ┃
          [wIdx + 1, hIdx + 1, 1] == "1") ? true : false;      //.│                             ║ ┃
      }                                                        //.│                             ║ ┃
      if (direction == 5)                                      //.│                             ║ ┃
      {                                                        //.│                             ║ ┃
        isAlive = (playfieldPixels                             //.│                             ║ ┃
          [wIdx, hIdx + 1, 1] == "1") ? true : false;          //.│                             ║ ┃
      }                                                        //.│                             ║ ┃
      if (direction == 6)                                      //.│                             ║ ┃
      {                                                        //.│                             ║ ┃
        isAlive = (playfieldPixels                             //.│                             ║ ┃
          [wIdx - 1, hIdx + 1, 1] == "1") ? true : false;      //.│                             ║ ┃
      }                                                        //.│                             ║ ┃
      if (direction == 7)                                      //.│                             ║ ┃
      {                                                        //.│                             ║ ┃
        isAlive = (playfieldPixels                             //.│                             ║ ┃
          [wIdx - 1, hIdx, 1] == "1") ? true : false;          //.│                             ║ ┃
      }                                                        //.│                             ║ ┃
      if (direction == 8)                                      //.│                             ║ ┃
      {                                                        //.│                             ║ ┃
        isAlive = (playfieldPixels                             //.│                             ║ ┃
          [wIdx - 1, hIdx - 1, 1] == "1") ? true : false;      //.│                             ║ ┃
      }                                                        //.│                             ║ ┃
      return isAlive;                                          //.│                             ║ ┃
    }                                                          //.│                             ║ ┃
    ///. ━━━━┓════════════════════════════════════════════════════╧═════════════════════════════╝ ┃
    ///.     ┃ PrintNeighbour :                                                                   ┃
    ///<summary>                                                                                   
    ///                                                                                         ┃
    ///</summary>.                                                                                ┃
    ///.     ┖────────────────────────────────────────────────────╮                               ┃
    private static void PrintNeighbour //. ═══════════════════════╪═════════════════════════════╗ ┃
      (int wIdx, int hIdx, //.                                    │ > COORDINATES               ║ ┃
      string[,,] array, //.                                       │ > PLAYFIELD ARRAY           ║ ┃
      int frame) //.                                              │ > FRAME                     ║ ┃
    { ///.                                                        │                             ║ ┃
      string neighbours = array[wIdx, hIdx, 2];                 //│                             ║ ┃
      string neighbour = CutNeighbour(neighbours, frame);       //│                             ║ ┃
      ColorString("print", $"red;0,0,60", neighbour.ToString());//│                             ║ ┃
    }                                                           //│                             ║ ┃
    ///. ━━━━┓════════════════════════════════════════════════════╧═════════════════════════════╝ ┃
    ///.     ┃ PrintLifeNeighbours :                                                              ┃
    ///<summary>                                                                                   
    ///                                                                                         ┃
    ///</summary>.                                                                                ┃
    ///.     ┖────────────────────────────────────────────────────╮                               ┃
    private static void PrintLifeNeighbours //. ══════════════════╪═════════════════════════════╗ ┃
      (string[,,] array) //.                                      │ > PLAYFIELD ARRAY           ║ ┃
    { ///.                                                        │                             ║ ┃
      for (int wIdx = 0; wIdx < array.GetLength(0); wIdx++)    //.│                             ║ ┃
      {                                                        //.│                             ║ ┃
        for (int hIdx = 0; hIdx < array.GetLength(1); hIdx++)  //.│                             ║ ┃
        {                                                      //.╰─────────────────────────╮   ║ ┃
          CheckNeighbours(wIdx, hIdx, out int livingNeighbours);                         //.│   ║ ┃
          playfieldPixels[wIdx, hIdx, 3] = livingNeighbours.ToString();                  //.│   ║ ┃
          Console.SetCursorPosition(wIdx, hIdx);                                         //.│   ║ ┃
          if (livingNeighbours == 1)                                                     //.│   ║ ┃
          {                                                                              //.│   ║ ┃
            ColorString("print", "darkyellow;darkgrey", livingNeighbours.ToString());    //.│   ║ ┃
          }                                                                              //.│   ║ ┃
          if (livingNeighbours == 2)                                                     //.│   ║ ┃
          {                                                                              //.│   ║ ┃
            if (array[wIdx, hIdx, 1] == "1")                                             //.│   ║ ┃
            {                                                                            //.│   ║ ┃
              ColorString("print", "yellow;darkgreen", livingNeighbours.ToString());     //.│   ║ ┃
            }                                                                            //.│   ║ ┃
            else                                                                         //.│   ║ ┃
              ColorString("print", "yellow;darkgrey", livingNeighbours.ToString());      //.│   ║ ┃
          }                                                                              //.│   ║ ┃
          if (livingNeighbours == 3)                                                     //.│   ║ ┃
          {                                                                              //.│   ║ ┃
            ColorString("print", "green;darkgreen", livingNeighbours.ToString());        //.│   ║ ┃
          }                                                                              //.│   ║ ┃
          if (livingNeighbours == 4)                                                     //.│   ║ ┃
          {                                                                              //.│   ║ ┃
            ColorString("print", "darkorange;darkestgrey", livingNeighbours.ToString()); //.│   ║ ┃
          }                                                                              //.│   ║ ┃
          if (livingNeighbours > 4)                                                      //.│   ║ ┃
          {                                                                              //.│   ║ ┃
            ColorString("print", "darkred;darkestgrey", livingNeighbours.ToString());    //.│   ║ ┃
          }                                                    //.╭─────────────────────────╯   ║ ┃
        }                                                      //.│                             ║ ┃
      }                                                        //.│                             ║ ┃
    }                                                          //.│                             ║ ┃
    ///. ━━━━┓════════════════════════════════════════════════════╧═════════════════════════════╝ ┃
    ///.     ┃ CutNeighbour :                                                                     ┃
    ///<summary>                                                                                   
    ///                                                                                         ┃
    ///</summary>.                                                                                ┃
    ///.     ┖────────────────────────────────────────────────────╮                               ┃
    private static string CutNeighbour //. ═══════════════════════╪═════════════════════════════╗ ┃
      (string neighbours, //.                                     │ > ALL NEIGHBOURS            ║ ┃
      int frame) //.                                              │ > FRAME                     ║ ┃
    { ///.                                                        │                             ║ ┃
      string neighbour;                                        //.╰────╮                        ║ ┃
      neighbour = neighbours[frame % neighbours.Length].ToString(); //.│                        ║ ┃
      return neighbour;                                        //.╭────╯                        ║ ┃
    }                                                          //.│                             ║ ┃
    ///. ━━━━┓════════════════════════════════════════════════════╧═════════════════════════════╝ ┃
    ///. ━━━━┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛

    ///.     ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
    ///.     ┃ LIFELOGIC :                                                                        ┃
    ///.     ┠────────────────────────────                                                        ┃
    ///.     ┃ SetLifeStates :                                                                    ┃
    ///<summary>                                                                                   
    ///                                                                                         ┃
    ///</summary>.                                                                                ┃
    ///.     ┖────────────────────────────────────────────────────╮                               ┃
    private static void SetLifeStates() //. ══════════════════════╪═════════════════════════════╗ ┃
    { ///.                                                        ╰───────╮                     ║ ┃
      for (int wIdx = 0; wIdx < playfieldPixels.GetLength(0); wIdx++)   //│                     ║ ┃
      {                                                                 //│                     ║ ┃
        for (int hIdx = 0; hIdx < playfieldPixels.GetLength(1); hIdx++) //│                     ║ ┃
        {                                                       //╭───────╯                     ║ ┃
          if (playfieldPixels[wIdx, hIdx, 1] == "1")            //│                             ║ ┃
          {                                                     //│                             ║ ┃
            LogicForLifeCell(wIdx, hIdx);                       //│                             ║ ┃
          }                                                     //│                             ║ ┃
          else if (playfieldPixels[wIdx, hIdx, 1] == "0")       //│                             ║ ┃
          {                                                     //│                             ║ ┃
            LogicForDeadCell(wIdx, hIdx);                       //│                             ║ ┃
          }                                                     //│                             ║ ┃
          Console.SetCursorPosition(wIdx, hIdx);                //│                             ║ ┃
          if (playfieldPixels[wIdx, hIdx, 1] == "1")            //│                             ║ ┃
            ColorString("print", "green;0,16,50", playfieldPixels[wIdx, hIdx, 1].ToString());// ║ ┃
          else                                                  //│                             ║ ┃
            ColorString("print", "black;0,16,50", playfieldPixels[wIdx, hIdx, 1].ToString());// ║ ┃
        }                                                       //│                             ║ ┃
      }                                                         //│                             ║ ┃
    }                                                           //│                             ║ ┃
    ///. ━━━━┓════════════════════════════════════════════════════╧═════════════════════════════╝ ┃
    ///.     ┃ PrintLifeState :                                                                   ┃
    ///<summary>                                                                                   
    ///                                                                                         ┃
    ///</summary>.                                                                                ┃
    ///.     ┖────────────────────────────────────────────────────╮                               ┃
    private static void PrintLifeState //. ═══════════════════════╪═════════════════════════════╗ ┃
      (string[,,] array) //.                                      │ > PLAYFIELD ARRAY           ║ ┃
    { ///.                                                        │                             ║ ┃
      for (int wIdx = 0; wIdx < array.GetLength(0); wIdx++)    //.│                             ║ ┃
      {                                                        //.│                             ║ ┃
        for (int hIdx = 0; hIdx < array.GetLength(1); hIdx++)  //.│                             ║ ┃
        {                                                      //.│                             ║ ┃
          string pixel = array[wIdx, hIdx, 1].ToString();      //.│                             ║ ┃
          Console.SetCursorPosition(wIdx, hIdx);               //.│                             ║ ┃
          if (playfieldPixels[wIdx, hIdx, 1] == "1")           //.│                             ║ ┃
            ColorString("print", "green;0,170,0", playfieldPixels[wIdx, hIdx, 1].ToString()); //║ ┃
          else                                                 //.│                             ║ ┃
            ColorString("print", $"black;darkgrey", pixel);    //.│                             ║ ┃
        }                                                      //.│                             ║ ┃
      }                                                        //.│                             ║ ┃
    }                                                          //.│                             ║ ┃
    ///. ━━━━┓════════════════════════════════════════════════════╧═════════════════════════════╝ ┃
    ///.     ┃ LogicForDeadCell :                                                                 ┃
    ///<summary>                                                                                   
    ///                                                                                         ┃
    ///</summary>.                                                                                ┃
    ///.     ┖────────────────────────────────────────────────────╮                               ┃
    private static void LogicForDeadCell //. ═════════════════════╪═════════════════════════════╗ ┃
      (int wIdx, int hIdx) //.                                    │ > COORDINATES               ║ ┃
    { ///.                                                        ╰───────╮                     ║ ┃
      int neighbours = Convert.ToInt32(playfieldPixels[wIdx, hIdx, 3]); //│                     ║ ┃
      if (neighbours == 3)                                      //╭───────╯                     ║ ┃
      {                                                         //│                             ║ ┃
        playfieldPixels[wIdx, hIdx, 1] = "1";                   //│                             ║ ┃
      }                                                         //│                             ║ ┃
      else                                                      //│                             ║ ┃
        playfieldPixels[wIdx, hIdx, 1] = "0";                   //│                             ║ ┃
    }                                                           //│                             ║ ┃
    ///. ━━━━┓════════════════════════════════════════════════════╧═════════════════════════════╝ ┃
    ///.     ┃ LogicForLifeCell :                                                                 ┃
    ///<summary>                                                                                   
    ///                                                                                         ┃
    ///</summary>.                                                                                ┃
    ///.     ┖────────────────────────────────────────────────────╮                               ┃
    private static void LogicForLifeCell //. ═════════════════════╪═════════════════════════════╗ ┃
      (int wIdx, int hIdx) //.                                    │ > COORDINATES               ║ ┃
    { ///.                                                        ╰───────╮                     ║ ┃
      int neighbours = Convert.ToInt32(playfieldPixels[wIdx, hIdx, 3]); //│                     ║ ┃
      if (neighbours > 3 || neighbours < 2)                     //╭───────╯                     ║ ┃
      {                                                         //│                             ║ ┃
        playfieldPixels[wIdx, hIdx, 1] = "0";                   //│                             ║ ┃
      }                                                         //│                             ║ ┃
      else                                                      //│                             ║ ┃
        playfieldPixels[wIdx, hIdx, 1] = "1";                   //│                             ║ ┃
    }                                                           //│                             ║ ┃
    ///. ━━━━┓════════════════════════════════════════════════════╧═════════════════════════════╝ ┃
    ///. ━━━━┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛

    ///.     ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━┯━━━━━━━━━━━━━━━━━━━━━━━┯━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
    ///.  ³³ ┃                            │    RE USED METHODS    │  Version 1.2                  ┃
    ///. ━━━━┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━┷━━━━━━━━━━━━━━━━━━━━━━━┷━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫
    ///.     ┃ GENERAL METHODS __________________________________________________________________ ┃
    ///.     ┖────────────────────────────╮                                                       ┃
                                        //│                                                       ┃
    ///.     ┎────────────────────────────╯                                                       ┃
    ///.     ┃ SetSettings :                                                                      ┃
    ///<summary>                                                                                   
    ///Sets console settings including window size, buffer size, and output encoding.             ┃
    ///</summary>.                                                                                ┃
    ///.     ┖────────────────────────────────────────────────────╮                               ┃
    public static void SetSettings() //. ═════════════════════════╪═════════════════════════════╗ ┃
    { ///.                                                        │                             ║ ┃
      Console.SetWindowSize(consoleWidth, consoleHeight);      //.│  1 consolewindow size       ║ ┃
      Console.SetBufferSize(consoleWidth, consoleHeight);      //.│  2 consolebuffer            ║ ┃
      Console.OutputEncoding = Encoding.UTF8;                  //.│  3 unicode symbols          ║ ┃
      Console.CursorVisible = false;                           //.│  4 curser invisible         ║ ┃
    }                                                          //.│                             ║ ┃
    ///. ━━━━┓════════════════════════════════════════════════════╧═════════════════════════════╝ ┃
    ///.     ┃ PrintHeader :                                                                      ┃
    ///<summary>                                                                                   
    ///Prints a header centred on the console with colored text.                                  ┃
    ///</summary>.                                                                                ┃
    ///.     ┖────────────────────────────────────────────────────╮                               ┃
    static void PrintHeader() //. ════════════════════════════════╪═════════════════════════════╗ ┃
    { ///.                                                        │                             ║ ┃
      PrintHeader("40,242,78");                                //.│  feel free to change        ║ ┃
    }                                                          //.│  color                      ║ ┃
    static void PrintHeader //. ══════════════════════════════════╪═════════════════════════════╣ ┃
      (string colorInstruction)                                //.│  > COLORINSTRUCTION         ║ ┃
    { ///.                                                        │                             ║ ┃
      Console.Write("\n");                                     //.│  1 empty line               ║ ┃
      int spacing = (consoleWidth - header.Length) / 2;        //.│  2 empty space r&l          ║ ┃
      header = ColorString(colorInstruction, header);          //.│  3 color header text        ║ ┃
      for (int w = 0; w < spacing; w++)                        //.│  4 empty space r&l          ║ ┃
      {                                                        //.│                             ║ ┃
        header = " " + header;                                 //.│  5 concat header            ║ ┃
      }                                                        //.│                             ║ ┃
      Console.Write(header);                                   //.│  6 print fin. header        ║ ┃
      ColorString("printLine", "", "‗");                       //.│  7 print doubleline         ║ ┃
    }                                                          //.│                             ║ ┃
    ///. ━━━━┓════════════════════════════════════════════════════╧═════════════════════════════╝ ┃
    ///.     ┃ ExitProgram :                                                                      ┃
    ///<summary>                                                                                   
    ///Exits the program after displaying a closing message.                                      ┃
    ///</summary>.                                                                                ┃
    ///.     ┖────────────────────────────────────────────────────╮                               ┃
    static void ExitProgram() //. ════════════════════════════════╪═════════════════════════════╗ ┃
    { ///.                                                        │                             ║ ┃
      Console.SetCursorPosition(0, lastH - 3);                 //.│  1 set cursorPos            ║ ┃
      ColorString("printLine", "", "̿");                       //.│  2 print double line        ║ ┃
      Thread.Sleep(1500); //Console.ReadLine();                //.│  3 wait one and a half a sec║ ┃
      Console.SetCursorPosition(1, 1);                         //.│  4 set cursorPos            ║ ┃
      ColorString("print", "46,201,86", "made by Jan Ritt");   //.│  5 display outro            ║ ┃
      Console.SetCursorPosition(1, 4);                         //.│  6 set cursorPos            ║ ┃
      ColorString("print", "201,86,0", "Eingabetaste zum beenden drücken..");  //.              ║ ┃
      Console.ReadLine();                                      //.│  8 last user input          ║ ┃
    }                                                          //.│                             ║ ┃
    ///. ━━━━┓════════════════════════════════════════════════════╧═════════════════════════════╝ ┃
    ///.     ┃                                                                                    ┃
    ///.     ┃                                                                                    ┃
    ///.     ┃                                                                                    ┃
    ///.     ┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━┯━━━━━━━━━━━━━━━━━━━━━━━┯━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫
    ///.  ³³ ┃                            │      DRAW METHODS     │  Version 1.2                  ┃
    ///. ━━━━┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━┷━━━━━━━━━━━━━━━━━━━━━━━┷━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫
    ///.     ┃ COLOR METHODS ____________________________________________________________________ ┃
    ///.     ┖────────────────────────────╮                                                       ┃
                                        //│                                                       ┃
    ///.     ┎────────────────────────────╯                                                       ┃
    ///.     ┃ ColorString:                                                                       ┃
    ///<summary>                                                                                   
    ///Applies color formatting to an input string and returns the formatted string.              ┃
    ///</summary>.                                                                                ┃
    ///<param name="colorInstruction">The color instruction string (e.g., "red").         </param>┃
    ///<param name="input">The input string to be colored.                                </param>┃
    ///<returns>The input string formatted with the specified color.                    </returns>┃
    ///.     ┖────────────────────────────────────────────────────╮                               ┃
    static string ColorString //. ════════════════════════════════╪═════════════════════════════╗ ┃
      (string colorInstruction, string input)                  //.│ > INSTRUCTION + STRING      ║ ┃
    { ///.                                                        │                             ║ ┃
      string coloredString;                                    //.│                             ║ ┃
      string[] instructions;                                   //.│                             ║ ┃
      ///. TWO COLOR INSTRUCTIONS, SEPERATED BY ';' ________________________________________    ║ ┃
      if (colorInstruction.Contains(";"))                      //.│ 1A) split string when ';''''║ ┃
      {                                                        //.│                             ║ ┃
        instructions = colorInstruction.Split(';');            //.│                             ║ ┃
        string forgroundInstructions = instructions[0];        //.│ 2 foreground is first       ║ ┃
        string backgroundInstructions = instructions[1];       //.│ 3 background is second      ║ ┃
                                                               //.│                             ║ ┃
        coloredString = ColorForground(forgroundInstructions) +//.│ 4 concat instruction:       ║ ┃
                     ColorBackground(backgroundInstructions) + //.│           +                 ║ ┃
                     input + ColorReset();                     //.│     input & reset           ║ ┃
      } ///. JUST ONE INSTRUCTION: _________________________________________________________    ║ ┃
      else                                                     //.│ 1B) else                    ║ ┃
        coloredString = ColorForground(colorInstruction)       //.│                             ║ ┃
                      + input + ColorReset();                  //.│ no ';'                      ║ ┃
      return coloredString;                                    //.│ 5 return                    ║ ┃
    }                                                          //.│                             ║ ┃
    ///. ━━━━┓════════════════════════════════════════════════════╧═════════════════════════════╝ ┃
    ///.     ┃ ColorString:                                                                       ┃
    ///<summary>                                                                                   
    ///Prints the input string with color formatting to the console.                              ┃
    ///</summary>.                                                                                ┃
    ///<param name="outputInstruction">The output mode instruction.                       </param>┃
    ///<param name="colorInstruction">The color instruction string.                       </param>┃
    ///<param name="inputString">The input string to be colored and printed.              </param>┃
    ///.     ┖────────────────────────────────────────────────────╮                               ┃
    static void ColorString //. ══════════════════════════════════╪═════════════════════════════╗ ┃
      (string outputInstruction,                               //.│ > PRINT_INSTRUCTION +       ║ ┃
      string colorInstruction,                                 //.│   COLOR_INSTRUCTION +       ║ ┃
      string inputString)                                      //.│   STRING                    ║ ┃
    { ///.                                                        │                             ║ ┃
      string outputString;                                     //.│                             ║ ┃
      ///. PRINT: _____________________________________________________________________________ ║ ┃
      if (outputInstruction == "print")                        //.│ A) PRINT:                   ║ ┃
      {                                                        //.                          ║ ┃
        Console.Write(
          ColorString(colorInstruction, inputString));         //.│                          ║ ┃
      }                                                        //.                          ║ ┃
      ///. PRINTLINE: _________________________________________________________________________ ║ ┃
      if (outputInstruction == "printLine")                    //.│ B) LINE:                    ║ ┃
      {                                                        //.│                             ║ ┃
        int screenWidthIndex = 0;                              //.│                             ║ ┃
        Console.WriteLine();                                   //.│                             ║ ┃
        int red = 0, green = 25, blue = 250;                   //.│                             ║ ┃
        for (int w = screenWidthIndex; w < consoleWidth; w++)  //.│                             ║ ┃
        {                                                      //.│                             ║ ┃
          green = green + 2; Math.Clamp(green, 0, 255);        //.│                             ║ ┃
          blue = blue - 3; Math.Clamp(blue, 0, 255);           //.╰─────╮                       ║ ┃
          ColorString("print", $"{red},{green},{blue}", inputString);//.│                       ║ ┃
          screenWidthIndex++;                                  //.╭─────╯                       ║ ┃
          if (screenWidthIndex == consoleWidth)                //.│                             ║ ┃
          {                                                    //.│                             ║ ┃
            Console.WriteLine();                               //.│                             ║ ┃
          }                                                    //.│                             ║ ┃
        }                                                      //.│                             ║ ┃
      }                                                        //.│                             ║ ┃
      ///. PRINTRAINBOWLINE: __________________________________________________________________ ║ ┃
      if (outputInstruction == "printRainbowLine")             //.│ C) RAINBOW:                 ║ ┃
      {                                                        //.╰────────────────────────────╮║ ┃
        int screenWidthIndex,                         // ┏ Rainbow ━━━━━━━━━━━━━━━━━━━━━━━━━━━━┪║ ┃
            colorParts = 3,                           // ┃ /* goes                             ┃║ ┃
            widthOfParts = consoleWidth / colorParts, // ┃ *   from                            ┃║ ┃
            colorDifference = 255 / widthOfParts;     // ┃ * red to green  // colorpart        ┃║ ┃
                                                      // ┃ *   from                            ┃║ ┃
                                                      // ┃ * green to blue // colorpart        ┃║ ┃
        int redValue = 255,                           // ┃ *   from                            ┃║ ┃
            greenValue = 0,                           // ┃ * blue to red   // colorpart        ┃║ ┃
            blueValue = 0;                            // ┃ */                                  ┃║ ┃
        Console.WriteLine();                          // ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛║ ┃
        for (screenWidthIndex = 0;                             //.│ 1 for screenwidth do:       ║ ┃
              screenWidthIndex < consoleWidth;                 //.│                             ║ ┃
              screenWidthIndex++)                              //.│                             ║ ┃
        {                                                      //.│                             ║ ┃
          if (screenWidthIndex < widthOfParts)                 //.│ 2 for the first third:      ║ ┃
          {                                                    //.│                             ║ ┃
            redValue = redValue - colorDifference;             //.│                             ║ ┃
            greenValue = greenValue + colorDifference;         //.│                             ║ ┃
            ColorString("print", $"{redValue},{greenValue},{blueValue}", inputString); //.      ║ ┃
          }                                                    //.│                             ║ ┃
                                                               //.│                             ║ ┃
          if (screenWidthIndex >= (widthOfParts) &&            //.│ 3 for the second third:     ║ ┃
             screenWidthIndex < (widthOfParts * 2))            //.│                             ║ ┃
          { //  redValue = 0; greenValue = 255;                //.│                             ║ ┃
            greenValue = greenValue - colorDifference;         //.│                             ║ ┃
            blueValue = blueValue + colorDifference;           //.│                             ║ ┃
            ColorString("print", $"{redValue},{greenValue},{blueValue}", inputString); //.      ║ ┃
          }                                                    //.│                             ║ ┃
          if (screenWidthIndex >= (widthOfParts * 2))          //.│ 4 for the third third:      ║ ┃
          {//  greenValue = 0; blueValue = 255;                //.│                             ║ ┃
            blueValue = blueValue - colorDifference;           //.│                             ║ ┃
            redValue = redValue + colorDifference;             //.│                             ║ ┃
            ColorString("print", $"{redValue},{greenValue},{blueValue}", inputString); //.      ║ ┃
          }                                                    //.│                             ║ ┃
        }                                                      //.│                             ║ ┃
      }                                                        //.│                             ║ ┃
    }                                                          //.│                             ║ ┃
    ///. ━━━━┓════════════════════════════════════════════════════╧═════════════════════════════╝ ┃
    ///.     ┃ ColorReset:                                                                        ┃
    ///<summary>                                                                                   
    ///Resets the color to default.                                                               ┃
    ///</summary>.                                                                                ┃
    ///<returns>The ANSI escape sequence to reset the color to default.                 </returns>┃
    ///.     ┖────────────────────────────────────────────────────╮                               ┃
    static string ColorReset() //. ═══════════════════════════════╪═════════════════════════════╗ ┃
    { ///.                                                        │                             ║ ┃
      string colorReset = "\u001b[0m";                         //.│ 1 Ansi Reset: \u001b[0m     ║ ┃
      return colorReset;                                       //.│ 2 Return reset string       ║ ┃
    }                                                          //.│                             ║ ┃
    ///. ━━━━┓════════════════════════════════════════════════════╧═════════════════════════════╝ ┃
    ///.     ┃ ColorForground:                                                                    ┃
    ///<summary>                                                                                   
    ///Generates a foreground color string based on the given color instruction.                  ┃
    ///</summary>.                                                                                ┃
    ///<param name="colorInstruction">Color instruction to generate the foreground color  </param>┃
    ///<returns>The generated foreground color string.                                  </returns>┃
    ///.     ┖────────────────────────────────────────────────────╮                               ┃
    static string ColorForground //. ═════════════════════════════╪═════════════════════════════╗ ┃
      (string colorInstruction)                                //.│ > COLOR_INSTRUCTION         ║ ┃
    { ///.                                                        │                             ║ ┃
      string colorString =                                     //.╰────────╮ 1 foreground       ║ ┃
        $"\u001b[38;2;" + SplitColorInstruction(colorInstruction) + "m";//.│ 2 \u001b[38;2 +    ║ ┃
      return colorString;                                      //.╭────────╯ 3 return string    ║ ┃
    }                                                          //.│                             ║ ┃
    ///. ━━━━┓════════════════════════════════════════════════════╧═════════════════════════════╝ ┃
    ///.     ┃ ColorBackground:                                                                   ┃
    ///<summary>                                                                                   
    ///Generates a color string based on the given color instruction.                             ┃
    ///</summary>.                                                                                ┃
    ///<param name="colorInstruction">Color instruction to generate the color string      </param>┃
    ///<returns>The generated background color string.                                  </returns>┃
    ///.     ┖────────────────────────────────────────────────────╮                               ┃
    static string ColorBackground //. ════════════════════════════╪═════════════════════════════╗ ┃
      (string colorInstruction)                                //.│ > COLOR_INSTRUCTION         ║ ┃
    { ///.                                                        │                             ║ ┃
      string colorString =                                     //.╰────────╮ 1 background       ║ ┃
        $"\u001b[48;2;" + SplitColorInstruction(colorInstruction) + "m";//.│ 2 \u001b[48;2 +    ║ ┃
      return colorString;                                      //.╭────────╯ 3 return string    ║ ┃
    }                                                          //.│                             ║ ┃
    ///. ━━━━┓════════════════════════════════════════════════════╧═════════════════════════════╝ ┃
    ///.     ┃ SplitColorInstruction:                                                             ┃
    ///<summary>                                                                                   
    ///Splits a color instruction into its RGB values.                                            ┃
    ///</summary>.                                                                                ┃
    ///<param name="colorInstruction">The color instruction to split.                     </param>┃
    ///<returns>The RGB values of the color instruction.                                </returns>┃
    ///.     ┖────────────────────────────────────────────────────╮                               ┃
    static string SplitColorInstruction //. ══════════════════════╪═════════════════════════════╗ ┃
      (string colorInstruction)                                //.│ > COLOR_INSTRUCTION         ║ ┃
    { ///.                                                        │                             ║ ┃
      string instruction = " ";                                //.╰────────────────────────╮    ║ ┃
      int redValue = 255,                           // ┏ RGB ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┪    ║ ┃
          greenValue = 255,                         // ┃                                   ┃    ║ ┃
          blueValue = 255;                          // ┃                                   ┃    ║ ┃
      string[] rgbValues;                           // ┃\u001b[38; 2;   < 3(8) = FOREGROUND┃    ║ ┃
      if (colorInstruction.Contains(","))           // ┃  { redValue_foreground };         ┃    ║ ┃
      {                                             // ┃  { greenValue_foreground };       ┃    ║ ┃
                                                    // ┃  { blueValue_foreground } m       ┃    ║ ┃
        rgbValues = colorInstruction.Split(',');    // ┃\u001b[48; 2;   < 4(8) = BACKGROUND┃    ║ ┃
                                                    // ┃  { redValue_background };         ┃    ║ ┃
        int.TryParse(rgbValues[0], out redValue);   // ┃  { greenValue_background };       ┃    ║ ┃
        int.TryParse(rgbValues[1], out greenValue); // ┃  { blueValue_background } m       ┃    ║ ┃
        int.TryParse(rgbValues[2], out blueValue);  // ┃      { textToColor }              ┃    ║ ┃
      }                                             // ┃\u001b[0m       < COLOR RESET      ┃    ║ ┃
                                                    // ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛    ║ ┃
      ///._____________ colorscale: ___________________________________________________________ ║ ┃
      else if (colorInstruction == "red"                       //.│        ┏━ RED ━━━━━━━┓      ║ ┃
            || colorInstruction == "Red"                       //.│        ┃ 255 0 0     ┃      ║ ┃
            || colorInstruction == "RED")                      //.│        ┃             ┃      ║ ┃
      { redValue = 255; greenValue = 0; blueValue = 0; }       //.│        ┗━━━━━━━━━━━━━┛      ║ ┃
      else if (colorInstruction == "darkred"                   //.│        ┏━ RED ━━━━━━━┓      ║ ┃
            || colorInstruction == "DarkRed"                   //.│        ┃ 75 0 0      ┃      ║ ┃
            || colorInstruction == "DARKRED")                  //.│        ┃             ┃      ║ ┃
      { redValue = 75; greenValue = 0; blueValue = 0; }        //.│        ┗━━━━━━━━━━━━━┛      ║ ┃
      else if (colorInstruction == "orange"                    //.│        ┏━ ORANGE ━━━━┓      ║ ┃
            || colorInstruction == "Orange"                    //.│        ┃ 255 155 0   ┃      ║ ┃
            || colorInstruction == "ORANGE")                   //.│        ┃             ┃      ║ ┃
      { redValue = 255; greenValue = 155; blueValue = 0; }     //.│        ┗━━━━━━━━━━━━━┛      ║ ┃
      else if (colorInstruction == "darkorange"                //.│        ┏━ DARKORANGE ┓      ║ ┃
            || colorInstruction == "DarkOrange"                //.│        ┃ 95 45 0     ┃      ║ ┃
            || colorInstruction == "DARKORANGE")               //.│        ┃             ┃      ║ ┃
      { redValue = 95; greenValue = 45; blueValue = 0; }       //.│        ┗━━━━━━━━━━━━━┛      ║ ┃
      else if (colorInstruction == "yellow"                    //.│        ┏━ YELLOW ━━━━┓      ║ ┃
            || colorInstruction == "Yellow"                    //.│        ┃ 255 255 0   ┃      ║ ┃
            || colorInstruction == "YELLOW")                   //.│        ┃             ┃      ║ ┃
      { redValue = 255; greenValue = 255; blueValue = 0; }     //.│        ┗━━━━━━━━━━━━━┛      ║ ┃
      else if (colorInstruction == "darkyellow"                //.│        ┏━ DARKYELLOW ┓      ║ ┃
            || colorInstruction == "DarkYellow"                //.│        ┃ 85 85 0     ┃      ║ ┃
            || colorInstruction == "DARKYELLOW")               //.│        ┃             ┃      ║ ┃
      { redValue = 85; greenValue = 85; blueValue = 0; }       //.│        ┗━━━━━━━━━━━━━┛      ║ ┃
      else if (colorInstruction == "green"                     //.│        ┏━ GREEN ━━━━━┓      ║ ┃
            || colorInstruction == "Green"                     //.│        ┃ 0 255 0     ┃      ║ ┃
            || colorInstruction == "GREEN")                    //.│        ┃             ┃      ║ ┃
      { redValue = 0; greenValue = 255; blueValue = 0; }       //.│        ┗━━━━━━━━━━━━━┛      ║ ┃
      else if (colorInstruction == "darkgreen"                 //.│        ┏━ DARKGREEN ━┓      ║ ┃
            || colorInstruction == "DarkGreen"                 //.│        ┃ 0 95 0      ┃      ║ ┃
            || colorInstruction == "DARKGREEN")                //.│        ┃             ┃      ║ ┃
      { redValue = 0; greenValue = 95; blueValue = 0; }        //.│        ┗━━━━━━━━━━━━━┛      ║ ┃
      else if (colorInstruction == "cyan"                      //.│        ┏━ CYAN ━━━━━━┓      ║ ┃
            || colorInstruction == "Cyan"                      //.│        ┃ 0 255 255   ┃      ║ ┃
            || colorInstruction == "CYAN")                     //.│        ┃             ┃      ║ ┃
      { redValue = 0; greenValue = 255; blueValue = 255; }     //.│        ┗━━━━━━━━━━━━━┛      ║ ┃
      else if (colorInstruction == "blue"                      //.│        ┏━ BLUE ━━━━━━┓      ║ ┃
            || colorInstruction == "Blue"                      //.│        ┃ 0 0 255     ┃      ║ ┃
            || colorInstruction == "BLUE")                     //.│        ┃             ┃      ║ ┃
      { redValue = 0; greenValue = 0; blueValue = 255; }       //.│        ┗━━━━━━━━━━━━━┛      ║ ┃
      else if (colorInstruction == "magenta"                   //.│        ┏━ MAGENTA ━━━┓      ║ ┃
            || colorInstruction == "Magenta"                   //.│        ┃ 255 0 255   ┃      ║ ┃
            || colorInstruction == "MAGENTA")                  //.│        ┃             ┃      ║ ┃
      { redValue = 255; greenValue = 0; blueValue = 255; }     //.│        ┗━━━━━━━━━━━━━┛      ║ ┃
      else if (colorInstruction == "brown"                     //.│        ┏━ BROWN ━━━━━┓      ║ ┃
            || colorInstruction == "Brown"                     //.│        ┃ 170 65 35   ┃      ║ ┃
            || colorInstruction == "BROWN")                    //.│        ┃             ┃      ║ ┃
      { redValue = 170; greenValue = 65; blueValue = 35; }     //.│        ┗━━━━━━━━━━━━━┛      ║ ┃
      ///._____________ greyscale: ____________________________________________________________ ║ ┃
      else if (colorInstruction == "white"                     //.│        ┏━ WHITE ━━━━━┓      ║ ┃
            || colorInstruction == "While"                     //.│        ┃ 255 255 255 ┃      ║ ┃
            || colorInstruction == "WHITE")                    //.│        ┃             ┃      ║ ┃
      { redValue = 255; greenValue = 255; blueValue = 255; }   //.│        ┗━━━━━━━━━━━━━┛      ║ ┃
      else if (colorInstruction == "lightgrey"                 //.│        ┏━ LIGHTGREY ━┓      ║ ┃
            || colorInstruction == "LightGrey"                 //.│        ┃ 100 100 100 ┃      ║ ┃
            || colorInstruction == "LIGHTGREY")                //.│        ┃             ┃      ║ ┃
      { redValue = 100; greenValue = 100; blueValue = 100; }   //.│        ┗━━━━━━━━━━━━━┛      ║ ┃
      else if (colorInstruction == "grey"                      //.│        ┏━ GREY ━━━━━━┓      ║ ┃
            || colorInstruction == "Grey"                      //.│        ┃ 55 55 55    ┃      ║ ┃
            || colorInstruction == "GREY")                     //.│        ┃             ┃      ║ ┃
      { redValue = 55; greenValue = 55; blueValue = 55; }      //.│        ┗━━━━━━━━━━━━━┛      ║ ┃
      else if (colorInstruction == "darkgrey"                  //.│        ┏━ DARKGREY ━━┓      ║ ┃
            || colorInstruction == "DarkGrey"                  //.│        ┃ 20 20 20    ┃      ║ ┃
            || colorInstruction == "DARKGREY")                 //.│        ┃             ┃      ║ ┃
      { redValue = 20; greenValue = 20; blueValue = 20; }      //.│        ┗━━━━━━━━━━━━━┛      ║ ┃
      else if (colorInstruction == "darkestgrey"               //.│        ┏━ DARKESTGREY┓      ║ ┃
            || colorInstruction == "DarkestGrey"               //.│        ┃ 12 12 12    ┃      ║ ┃
            || colorInstruction == "DARKESTGREY")              //.│        ┃             ┃      ║ ┃
      { redValue = 12; greenValue = 12; blueValue = 12; }      //.│        ┗━━━━━━━━━━━━━┛      ║ ┃
      else if (colorInstruction == "black"                     //.│        ┏━ BLACK ━━━━━┓      ║ ┃
            || colorInstruction == "Black"                     //.│        ┃ 0 0 0       ┃      ║ ┃
            || colorInstruction == "BLACK")                    //.│        ┃             ┃      ║ ┃
      { redValue = 0; greenValue = 0; blueValue = 0; }         //.│        ┗━━━━━━━━━━━━━┛      ║ ┃
      ///._____________ other nice colors: ____________________________________________________ ║ ┃
      ///┏━━━━━━━━━━━━━━━━━━━━┯━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓║ ┃
      ///┃ IxIdarkgreen       │ 0,70,33                                                        ┃║ ┃
      ///┗━━━━━━━━━━━━━━━━━━━━┷━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛║ ┃
      else if (colorInstruction == "IxIdarkgreen"              //.│     ┏━ IxIdarkgreen ━┓      ║ ┃
      || colorInstruction == "ixidarkgreen"                    //.│     ┃ 0 70 33        ┃      ║ ┃
      || colorInstruction == "IXIDARKGREEN")                   //.│     ┃                ┃      ║ ┃
      { redValue = 0; greenValue = 70; blueValue = 33; }       //.│     ┗━━━━━━━━━━━━━━━━┛      ║ ┃
                                                               //.│                             ║ ┃
      instruction = $"{redValue};{greenValue};{blueValue}";    //.│ instruction: r;g;b          ║ ┃
      return instruction;                                      //.│ return instruction string   ║ ┃
    }                                                          //.│                             ║ ┃
    ///. ━━━━┓════════════════════════════════════════════════════╧═════════════════════════════╝ ┃
    ///. ━━━━┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛

  }
}