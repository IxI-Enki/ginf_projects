# Regex Helper

- Simple demonstration of regex expressions  
- C#  

---
### Code Parts

```cs
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
```
---  
### Screenshots  
<!--screenshot-->

![image](https://github.com/IxI-Enki/ginf_projects/assets/138018029/486eed65-1874-4306-91d5-67441b3e0041)  

![image](https://github.com/IxI-Enki/ginf_projects/assets/138018029/cae98d58-e7e6-451d-a626-45510e28cb63)  



