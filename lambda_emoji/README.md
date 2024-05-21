# Lambda Emoji

- Simple demonstration of simple lambda expressions & ansi sequences to color console output
- C#  

---  
### Interesting code parts

*Lambda Function to call Methods*
```cs
static void Main() => RunGame();

static byte Health(ref byte hp) => (byte)(hp-- % 2);
```

*ANSI Esc-Sequences*
```cs
/// The full syntax for coloring a string with ANSI is:
///
/// \u001b[   ... tells the program, that a color-specifier is next:
/// 38;       ... is the number representing the foreground, and tells the program that an RGB-value follows (other examples: 48 does the same for the background)
/// 2;        ... is the default value or "format-mod" (some terminals/consoles support underlined, or even blinking text) 
/// x;x;x     ... R-G-B values from 0 to 255, separated by ';'
/// m         ... indication of the End of this sequence.

// Divide this Syntax into:
  static string
    ESC = "\u001b[",
    ColorForeground = "38" + Mod,
    ColorBackground = "48" + Mod;
  static string Mod => ";2;";
  static string rgb => string.Join(';', r, g, b);
  static byte
    r = 255,
    g = 0,
    b = 0;
// By using the following we can now set colors easy:
  static string
    rgbF = ESC + ColorForeground + rgb + 'm',
    rgbB = ESC + ColorBackground + rgb + 'm';
// And resetting them by using:
  static string Reset = ESC + "0m";
```
> *In use*:
> ```cs
> Console.WriteLine(" " + rgbB + " Lambda " + Reset + "\n" + rgbF + "  anyone? \n " + Reset);
> ```

---  

### Screenshots  
<!--screenshot-->
![image](https://github.com/IxI-Enki/ginf_projects/assets/138018029/6de894d6-127c-4b4a-8b1e-db5ca549f559)  

![image](https://github.com/IxI-Enki/ginf_projects/assets/138018029/aa0b7b10-a9bc-40aa-95d8-78c8ec96a525)  

 
