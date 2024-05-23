





using System.Security.Cryptography;

namespace Example
{
  class Program
  {
    static void Main() => Example();

    static string
       startColor = "255;122;0",
       endColor = "0;255;222",
       text = "Beispielhafter Text", output = "";
    static int interval = 100, countdown = 40;

    static string[] colors;

    static void Example()
    {
      SetScreen();
      bool run = true;
      int frame = 0;
      do
      {
        if (frame == 0)
          SetScreen(1);

        output = ConcatOutput();
        PrintAnimation();
        RotateColorPalette();
        Thread.Sleep(interval);
        frame = (frame + 1) % text.Length;
        countdown--;
        if (countdown == 0)
        {
          Menu(MenuChoices());
          SetColorPalette();
          countdown = countdown + 40;
          Console.Clear();
          PrintHeader();
        }
      } while (run);
    }

    static string ConcatOutput()
    {
      string temp = "";
      for (int i = 0; i < text.Length; i++)
        temp = temp + "\u001b[38;2;" + colors[i] + "m" + text[i];
      return output = temp;
    }

    static void SetScreen(byte reset = 0)
    {
      Console.CursorVisible = false;
      if (reset == 0)
      {
        Console.Clear();
        PrintHeader();
      }
      SetColorPalette();
    }

    static void RotateColorPalette()
    {
      for (int i = 0; i < (colors.Length - 1) / 2; i++)
      {
        colors[colors.Length - 1 - i] = colors[colors.Length - 2 - i];
        colors[i] = colors[i + 1];
      }
    }

    static void SetColorPalette()
    {
      int[] differences
        = ConvertToByteValues(startColor.Split(';'), endColor.Split(';'));
      colors = GetColors(differences);
    }

    static string[] GetColors(int[] differences)
    {
      int steps = text.Length;
      string[] tempColors = new string[steps];
      for (int i = 0; i < steps; i++)
        tempColors[i]
          = $"{Convert.ToInt32(startColor.Split(';')[0]) - differences[0] * i};"
          + $"{Convert.ToInt32(startColor.Split(';')[1]) - differences[1] * i};"
          + $"{Convert.ToInt32(startColor.Split(';')[2]) - differences[2] * i}";
      return tempColors;
    }

    static int[] ConvertToByteValues(string[] firstColor, string[] secondColor)
    {
      int[] differences = new int[3];
      for (int i = 0; i < 3; i++)
      {
        differences[i]
          = (Convert.ToInt32(firstColor[i]) - Convert.ToInt32(secondColor[i])) / text.Length;
      }
      return
        [
          differences[0],
          differences[1],
          differences[2]
        ];
    }

    static void PrintAnimation()
    {
      Console.SetCursorPosition(4, 4);
      Console.Write("\u001b[0m \n Example: \n\t" + output);
    }

    static void PrintHeader()
    {
      string
        title
          = "Animated Strings",
        spacing
          = new string(' ', (Console.WindowWidth - title.Length) / 2),
        underLine
          = new string('=', Console.WindowWidth),
        header
          = spacing + title + "\n" + underLine;
      Console.Write("\n" + header);
    }

    static void Menu(byte choice)
    {
      switch (choice)
      {
        case 0:
          text = ChangeText();
          break;
        case 1:
          PromptUserInput(out interval);
          break;
        case 2:
          startColor = ChangeText(1);
          break;
        case 3:
          endColor = ChangeText(1);
          break;
      }
    }

    static string ChangeText(byte colorChoice = 0)
    {
      Console.Write(colorChoice == 0 ? "\n Neuen Text eingeben: " : "Farbe im Format: \"222;000;111\" eingeben.");
      return Console.ReadLine();
    }

    static byte MenuChoices()
    {
      string[]
        menuLines
          = [
            "  0 - Change Text",
            "  1 - Change Time Interval",
            "  2 - Change Start Color ",
            "  3 - Change End Color",
          ];
      Console.Write("\n\n" + string.Join('\n', menuLines));
      PromptUserInput(out byte choice);
      return choice;
    }

    static void PromptUserInput(out byte input)
    {
      Console.Write("\n Ihre Auswahl: ");
      if (!byte.TryParse(Console.ReadLine(), out input) || input < 0 || input > 3)
        PromptUserInput(out input);
      else return;
    }

    static void PromptUserInput(out int input)
    {
      Console.Write("\n Ganzzahl eingeben: ");
      if (!int.TryParse(Console.ReadLine(), out input))
        PromptUserInput(out input);
      else return;
    }
  }
}