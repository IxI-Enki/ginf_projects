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
![0](https://github.com/IxI-Enki/ginf_projects/assets/138018029/d4e5c5e1-b039-41f2-87d4-73e342541714)  

![1](https://github.com/IxI-Enki/ginf_projects/assets/138018029/e82defea-6e4f-4e16-a617-ef95ac3f5294)  

![image](https://github.com/IxI-Enki/ginf_projects/assets/138018029/2f79959c-8b53-446b-8e98-262c3a5785a6)  



