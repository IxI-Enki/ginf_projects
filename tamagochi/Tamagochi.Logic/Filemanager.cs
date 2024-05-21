using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using IxIGotchi;
using Gotchi;
using System.Linq;

namespace Gotchi
{
  class Filemanager
  {
    public void Filebroker(int health, int hydration)
    {
      Colorizer Format = new Colorizer();
      ///
      int safeFileNr = 1;

      string name = "NAMI";
      ///
      int fileResult = FindSavefile();
      switch (fileResult)
      {
        case -1:
          Console.SetCursorPosition(5, 18);
          Console.Write(Format.ColorString("ℝ200,40,70₲ Ordnerstruktur    "));
          Console.SetCursorPosition(5, 19);
          Console.Write(Format.ColorString("ℝ200,40,70₲ nicht gefunden.   "));
          Console.SetCursorPosition(5, 21);
          Console.Write(Format.ColorString("ℝ180,180,70₲ Ordnerstruktur  "));
          Console.SetCursorPosition(5, 22);
          Console.Write(Format.ColorString("ℝ180,180,70₲ erstellt!       "));
          break;

        case 0:
          Console.SetCursorPosition(5, 18);
          Console.Write(Format.ColorString("ℝ200,40,70₲ savefile.txt nicht"));
          Console.SetCursorPosition(5, 19);
          Console.Write(Format.ColorString("ℝ200,40,70₲ gefunden.       "));
          Console.SetCursorPosition(5, 21);
          Console.Write(Format.ColorString("ℝ255,255,255₲ Neuen Speicherstand"));
          Console.SetCursorPosition(5, 22);
          Console.Write(Format.ColorString("ℝ255,255,255₲ erstellen? [ℝ0,255,0₲jℝ255,255,255₲/ℝ255,0,0₲nℝ255,255,255₲] "));

          bool makeSaveFile = (Char.ToUpper(Console.ReadKey().KeyChar) == 'J' ? true : false);
          if (makeSaveFile)
          {
            string saveFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Gotchi", "Savefiles", "savefile.txt");
            File.WriteAllText(saveFilePath, $"Speicherstand:\n{safeFileNr}\nName:\n{name}\nHealth:\n{health}\nHydration:\n{hydration}");
          }
          break;

        case 1:
          Console.SetCursorPosition(5, 18);
          Console.Write(Format.ColorString($"ℝ180,180,70₲ Speicherstand {safeFileNr.ToString().PadRight(3)} "));
          Console.SetCursorPosition(5, 19);
          Console.Write(Format.ColorString($"ℝ180,180,70₲ gefunden!        "));
          Console.SetCursorPosition(5, 20);
          Console.Write("                    ");
          Console.SetCursorPosition(5, 21);
          Console.Write("                    ");
          Console.SetCursorPosition(5, 22);
          Console.Write("                    ");
          Console.SetCursorPosition(5, 23);
          Console.Write("                    ");

          break;
      }
      Thread.Sleep(800);

    }


    public int FindSavefile()
    {
      string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Gotchi", "Savefiles");

      /*_______CHECK: if directory exists________________________________________________________*/
      if (!Directory.Exists(directoryPath))
      { // directory is NOT present:
        Directory.CreateDirectory(directoryPath);
        return -1;
      }

      /*_______CHECK: if savefile.txt exists_____________________________________________________*/
      string filePath = Path.Combine(directoryPath, "savefile.txt");

      if (File.Exists(filePath))
      { // savefile.txt is present:
        return 1;
      }

      // savefile.txt is NOT present:
      return 0;
    }

  }
}
