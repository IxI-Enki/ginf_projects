# Game of Life

- Simple Functional Game of Life
- C#  

---  

```c#
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
```


### Screenshots  
<!--screenshot-->

*Choose living cells by moving the cursor [W-A-S-D] and swapping 0 > 1* 
![image](https://github.com/IxI-Enki/ginf_projects/assets/138018029/dc8e8088-c5b5-430b-a59f-77a3f1b933c0)  

*Watch different cells dying and getting alived periodically*
![image](https://github.com/IxI-Enki/ginf_projects/assets/138018029/9d83c01f-e603-47a8-97e4-bfb0c72f615e)   [](url)
![image](https://github.com/IxI-Enki/ginf_projects/assets/138018029/702b39bf-1e4b-4cef-91b8-b54d679689fe)  

---
### Code Parts

*Setup:*
```c#
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
```

