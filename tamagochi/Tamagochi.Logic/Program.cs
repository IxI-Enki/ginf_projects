using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using IxIGotchi;
using Gotchi;
using System.Security.Cryptography.X509Certificates;

namespace IxIGotchi
{
  class MainProgram
  {
    static int cWidth = 81;
    static int cHeight = cWidth / 3;

    static void Main()
    {
      //*________________________________________// set_settings
      Settings Set = new Settings(); /*          */ Set.ScreenSettings(cWidth);
      Console.OutputEncoding = Encoding.UTF8;
      //  initiate Menu
      Menu Do = new Menu();
      //  initiate Colorizer
      Colorizer Format = new Colorizer();
      //  initiate Intro Screen
      IntroScreen Show = new IntroScreen();
        Show.PrintIntro(cWidth);                    // UNCOMMENT TO DISPLAY INTRO
      Console.Clear();
      //  initiate Debug Screen 
      DebugScreen Debug = new DebugScreen();
      //    Debug.ScreenDrawer(cWidth);                 // UNCOMMENT TO DISPLAY DEBUG SCREENS
      //  initiate Box Drawer
      Box Call = new Box();
      //  initiate Animations
      Animations Animate = new Animations();
      //  initiate PetState
      Pet Wake = new Pet();

      //  draw OUTER BOXES :
      string colorMod = "ℝ36,56,42₲";
      Call.DrawBox(0, 0, cWidth, cHeight, 1, colorMod);
      colorMod = "ℝ56,76,62₲";
      Call.DrawBox(2, 1, cWidth - 2, cHeight, 2, colorMod);
      //  draw INNER BOXES :
      // CENTER:
      colorMod = "ℝ76,96,82₲";
      Call.DrawBox(26, 17, cWidth - 27, cHeight + 15, 0, colorMod);
      // RIGHT:
      colorMod = "ℝ76,96,82₲";
      Call.DrawBox(54, 17, cWidth - 4, cHeight + 15, 0, colorMod);
      // LEFT:
      colorMod = "ℝ76,96,82₲";
      Call.DrawBox(4, 17, 26, cHeight + 15, 0, colorMod);

      // initiate Stats:
      int actualHP = 8;
      int actualHydration = 4;
      string petState = "sleep";

      // initiate Runtime Settings:
      int choice = 0;
      bool run = true;
      int frame = 0;
      int timeout = 0;

      while (run)
      { // Generate Menu: 
        Console.SetCursorPosition(36, 16);
        // Draw Pet:
        Wake.CallPet(frame, petState);
        
        //  LET PET FALL ASLEEP :
        timeout += (frame % 60 == 0) ? 1 : 0;
        if (timeout == 8) { petState = "sleep"; }
        if (frame % 5 == 0 && petState == "sleep")
        {
          Console.SetCursorPosition(33, 16);
          Console.Write(Format.ColorString(Animations.AnimateCurser("sleepingDark", frame)));
          Console.Write(Format.ColorString(Animations.AnimateCurser("sleepingMedium", frame + 1)));
          Console.Write(Format.ColorString(Animations.AnimateCurser("sleepingLight", frame + 2)));
        }
        else if (petState != "sleep")
        {
          Console.SetCursorPosition(33, 16);
          Console.Write("   ");
        }

        //  Menu choices :
        Do.GenerateMenu(cWidth, choice, frame, petState);

        //  CHECK AWAKE :
        //  Hydration : 
        if (petState == "awake")
        {
          actualHydration = (frame % 60 == 0) ? actualHydration - 1 : actualHydration;
          actualHydration = (actualHydration <= 0) ? 0 : actualHydration;
        }
        //  HP :
        if (actualHydration == 0)
        {
          actualHP = (frame % 60 == 0) ? actualHP - 1 : actualHP;
          actualHP = (actualHP <= 0) ? 0 : actualHP;
        }

        // PRINT STATUS :
        // HP :
        Console.SetCursorPosition(56, 18);
        for (int HPindexCounter = actualHP; HPindexCounter > 0; HPindexCounter--)
        {
          Console.Write(Format.ColorString(Animations.AnimateCurser("hpAnimation", frame + HPindexCounter))); Console.Write(" ");
        }
        for (int emptyHP = 0; emptyHP + actualHP < 10; emptyHP++)
        {
          Console.Write("  ");
        }

        //  HYDRATION :
        Console.SetCursorPosition(56, 19);
        for (int indexCounter = actualHydration; indexCounter > 0; indexCounter--)
        {
          Console.Write(Format.ColorString(Animations.AnimateCurser("hydration", frame + indexCounter))); Console.Write(" ");
        }
        for (int emptyHydration = 0; emptyHydration + actualHydration < 10; emptyHydration++)
        {
          Console.Write("  ");
        }

        //  CHECK FOR DEAD PET :
        petState = (actualHP == 0 && actualHydration == 0) ? "dead" : petState;

        //  ADVANCE FRAMES:
        Thread.Sleep(50);
        frame = (frame + 1) % 60;

        /*-------------------------- check_pressed_key ----------------------------------------*/
        if (Console.KeyAvailable)
        {
          ConsoleKeyInfo keyInfo = Console.ReadKey(true);
          switch (keyInfo.Key)
          {
            /*  -  -  -  -  - ↑↑↑ -  -  -  -  -  */
            case ConsoleKey.UpArrow: /*          */
            case ConsoleKey.W: /*                */
              Console.SetCursorPosition(cWidth - 2, 1);
              Console.SetCursorPosition(cWidth - 2, 1);
              Console.Write(Format.ColorString("ℝ50,255,50₲↑"));
              { choice--; choice = (choice < 0) ? 5 : choice;/* Console.Clear(); */ timeout = 0; }
              break;

            /*  -  -  -  -  - ↓↓↓ -  -  -  -  -  */
            case ConsoleKey.DownArrow: /*        */
            case ConsoleKey.S: /*                */
              Console.SetCursorPosition(cWidth - 2, 1);
              Console.Write(Format.ColorString("ℝ255,255,50₲↓"));
              { choice++; choice = (choice <= 5) ? choice : 0;/* Console.Clear(); */ timeout = 0; }
              break;

            /*  -  -  -  -  - ESC -  -  -  -  -  */
            case ConsoleKey.Escape: /*           */
              Console.Write(Format.ColorString("\nℝ250,160,160₲rgbB[100,0,0]  ESC -ℝ255,30,30₲ Programm beendet."));
              return;

            /*  -  -  -  -  -ENTER-  -  -  -  -  */
            case ConsoleKey.Enter: /*            */
              Console.SetCursorPosition(cWidth - 2, 1);
              Console.Write(Format.ColorString("ℝ0,255,0₲⏎"));
              /* - - - - - - - - - - - check_choice - - - - - - - - - - - - - - - - - - - - - - -*/
              switch (choice)
              { //. . . LOAD SAVEFILE . . .//
                case 0:
                  petState = (petState == "awake") ? "sleep" : "awake";
                  frame = 0;
                  timeout = 0;
                  break;

                case 1:
                  actualHP = (actualHP + 1) % 11;
                  Math.Clamp(actualHP, 0, 10);
                  break;
                case 2:
                  actualHydration = (actualHydration + 1) % 11;
                  Math.Clamp(actualHydration, 0, 10);
                  break;


                case 4:
                  Filemanager Browse = new Filemanager();
                  Browse.Filebroker(actualHP, actualHydration);
                  break;

                //. . . END PROGRAM . . .//
                case 5:
                  Console.Write(Format.ColorString("\nℝ200,0,0₲  Programm ℝ255,30,30₲beendet."));
                  return;
              }
              break;
          }
        }
      }
    }


  }
}