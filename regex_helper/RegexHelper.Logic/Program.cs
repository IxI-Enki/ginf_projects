using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;

namespace RegexLogic
{

  class Program
  {
    static string exampleString => File.ReadAllText(Environment.CurrentDirectory + "\\TestText.txt");
    static void Main() => Example();
    public static void Example()
    {
      while (true)
      {
        Console.Clear();
        Console.WriteLine("\n REGULAR EXPRESSIONS\n-----------------------\n" +
                          "\n Geben Sie eine beliebige Zeichenkette ein," +
                          "\n in welcher gesucht werden soll: " +
                          "\n (0 - verwenden Sie einen vordefinierten Beispiel-Text)\n ");
        string input = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.DarkGray;

        Console.WriteLine("\n CodeFragment:" +
                          "\n" +
                          "\n// Regex-Muster definieren:" +
                          "\n pattern = $@\"{pattern}\"; " +
                          "\n Regex regex = new Regex(@\"pattern\");" +
                          "\n" +
                          "\n");
        Console.WriteLine(input == "0" ? "Der Beispiel Text enthält eine Telefonnummer,\n  mit dem pattern: \"4 Dezimalzahlen / 8 Dezimalzahlen\" " +
                                      "\n" + @"-> verwenden Sie zum finden das Regex-Pattern: \d{4}/\d{8} " : "") ;
        Console.ResetColor();

        if (input == "0")
          input = exampleString;

        Console.WriteLine(" Geben Sie das zu suchende pattern ein:\n ");
        string pattern = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\n CodeFragment:" +
                          "\n" +
                          "\n// Muster in Text suchen:" +
                          "\n Match match = regex.Match(input);\n");
        Console.ResetColor();

        // Regex-Muster definieren
        pattern = $@"{pattern}";
        Regex regex = new Regex(pattern);
        // Regex-Muster für jede Art von Klammern
        Regex regexNormal = new Regex(@"\((?<inner>[^\)]+)\)");
        Regex regexCurly = new Regex(@"\{(?<inner>[^\}]+)\}");
        Regex regexSquare = new Regex(@"\[(?<inner>[^\]]+)\]");


        // Muster in Text suchen
        Match match = regex.Match(input);
        if (match.Success)
        {

          // Zählt die Treffer
          int count = 0;
          // Liste zum Speichern der gefundenen Wörter
          List<string> words = new List<string>();
          // Durchläuft alle Treffer
          foreach (Match m in regex.Matches(input))
          {
            // Erhöht den Zähler
            count++;
            // Speichert das gefundene Wort
            words.Add(m.Groups["word"].Value);
          }
          // Ausgabe der Ergebnisse
          Console.ForegroundColor = ConsoleColor.DarkGreen;
          Console.Write($"\n Das pattern ");

          Console.ForegroundColor = ConsoleColor.Magenta;
          Console.Write(pattern);

          Console.ForegroundColor = ConsoleColor.Green;
          Console.Write($" wurde {count} mal gefunden: ");

          Console.WriteLine("\n Wenn Sie code durchsuchen, \n könnte es zum Beispiel helfen Klammern aufzulösen..");
          Console.WriteLine("Klammern auflösen? [j/n]");

          bool showBrackets = Console.ReadKey().KeyChar.ToString().ToUpper() == "J";
          foreach (string word in words)
          {

            if (pattern == @"(?<pair>\((?<inner>[^\)]+)\))")
            {
              Console.ForegroundColor = ConsoleColor.DarkYellow;
              string innerText = match.Groups["inner"].Value;
              Console.Write("\n Gefundene Klammern:\n " + match.Value);
              Console.ForegroundColor = ConsoleColor.Yellow;
              Console.Write("\n Inhalt der Klammer:\n " + innerText + "\n");
            }
            else
            {
              if (showBrackets)
              {
                // Durchläuft alle Treffer für normale Klammern
                foreach (Match mk in regexNormal.Matches(input))
                {
                  // Ausgabe der gefundenen Klammern und des Inhalts
                  string brackets = mk.Value;
                  string innerText = mk.Groups["inner"].Value;

                  Console.ForegroundColor = ConsoleColor.DarkYellow;
                  Console.WriteLine("\n Gefundene Klammern (normal):\n " + brackets);
                  Console.ForegroundColor = ConsoleColor.Yellow;
                  Console.WriteLine("\n Inhalt der Klammer:\n " + innerText + "\n");
                }

                // Durchläuft alle Treffer für geschwungene Klammern
                foreach (Match mk in regexCurly.Matches(input))
                {
                  // Ausgabe der gefundenen Klammern und des Inhalts
                  string brackets = mk.Value;
                  string innerText = mk.Groups["inner"].Value;

                  Console.ForegroundColor = ConsoleColor.DarkMagenta;
                  Console.WriteLine("\n Gefundene Klammern (geschwungen):\n " + brackets);
                  Console.ForegroundColor = ConsoleColor.Magenta;
                  Console.WriteLine("\n Inhalt der Klammer:\n " + innerText + "\n");
                }

                // Durchläuft alle Treffer für eckige Klammern
                foreach (Match mk in regexSquare.Matches(input))
                {
                  // Ausgabe der gefundenen Klammern und des Inhalts
                  string brackets = mk.Value;
                  string innerText = mk.Groups["inner"].Value;

                  Console.ForegroundColor = ConsoleColor.DarkCyan;
                  Console.WriteLine("\n Gefundene Klammern (eckig):\n " + brackets);
                  Console.ForegroundColor = ConsoleColor.Cyan;
                  Console.WriteLine("\n Inhalt der Klammer:\n " + innerText + "\n");
                }
              }
              Console.WriteLine("  \"" + match.Value + "\"");
            }
          }
        }
        else
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("\nNicht gefunden\n");
        }
        Console.ResetColor();
        Console.ReadLine();         // Thread.Sleep(2000);
      }
    }
    // --------------------------------------------------------------------------------------------
  }
}


#region notes
// - place for notes and outdated code

#endregion