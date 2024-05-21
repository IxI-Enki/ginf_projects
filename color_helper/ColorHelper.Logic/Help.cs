namespace IxIsColorHelper
{
  //*‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗ • HELP  ‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗*//
  public class Help
  {
    public string HelpScreen()
    {
      string helpC =
                    // "rgb(50,200,50)BELIEBIGER TEXTrgb(255,255,255)\" ein." +
                    //  - Farbpalette -
                    "\nrgb(150,0,0) ► rgb(200,200,200)Farbpalette rgb(150,150,150)- führt den Benutzer durch die Eingabe der Parameter, der" +
                    "\n                 zu zeichnenden Farbpalette." +
                    "\nrgb(150,0,0) ► rgb(200,200,200)Farbwerte rgb(150,150,150)  - wandelt eingegebene Farben in andere Schreibweisen um." +
                    "\nrgb(150,0,0) ► rgb(200,200,200)Farbräder rgb(150,150,150)  - führt den Benutzer durch die Eingabe der Parameter, des" +
                    "\n                 zu zeichnenden Farbrades." +
                    "\nrgb(150,0,0) ► rgb(200,200,200)Befehle rgb(150,150,150)    - lässt den Benutzer die Befehle des Programmes manuell eingeben." +
                    "\n                 Die Syntax ist : ..PLACEHOLDER.. " +
                    "\nrgb(150,0,0) ► rgb(200,200,200)Hilfe rgb(150,150,150)      - zeigt diesen Hilfetext." +
                    "\nrgb(150,0,0) ► rgb(200,200,200)Beenden rgb(150,150,150)    - beendet das Programm." +
                    "\n" +
                    "\n rgb(255,100,100)Rotwertrgb(255,255,255) & rgb(100,255,100)Grünwertrgb(255,255,255) & rgb(100,100,255)Blauwertrgb(255,255,255): 0 bis 255" +
                    "\n" +
                    //      "\n rgb(100,100,100)Befehle:" +
                    //      "\n - palette" +
                    //      "\n - convert" +
                    //      "\n - wheel" +
                    //      "\n - clear" +
                    //      "\n - exit" +
                    "";
      return new string(helpC);
    }
  }
}