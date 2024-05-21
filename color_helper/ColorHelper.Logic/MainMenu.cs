namespace IxIsColorHelper
{
  //*‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗ • MENU  ‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗‗*//
  public class MainMenu
  {
    public string Menu(int cWidth, int choice)
    {
      string[] menuePunkte = new string[10];
      menuePunkte[0] = "rgb(255,255,255)\tFarbpalette rgb(200,200,200)erstellen rgb(100,100,100)!        ";
      menuePunkte[1] = "rgb(255,255,255)\tFarbwerte rgb(200,200,200)umrechnen rgb(100,100,100)[hex]-[rgb]";
      menuePunkte[2] = "rgb(255,255,255)\tFarbräder rgb(200,200,200)zeichnen             ";
      menuePunkte[3] = "rgb(255,255,255)\tBefehle rgb(200,200,200)manuell rgb(100,100,100)eingeben       ";
      menuePunkte[4] = "rgb(255,255,255)\tHilfergb(200,200,200)-Text rgb(100,100,100)zeigen              ";
      menuePunkte[5] = "rgb(255,255,255)\tProgramm rgb(200,200,200)beenden                ";
      int tab = 20;
      string spacing;
      string menue = "";

      for (int c = 0; c < menuePunkte.Length; c++)
      {
        spacing = "";
        for (int w = 0; w < ((cWidth / 2) - tab); w++)
        {
          spacing += " ";
        }

        if (c == choice)
        {// pointer choices:  →←  ►◄
          menue = menue + spacing + "rgb(150,0,0)► " + menuePunkte[c] + "rgb(150,0,0) ◄";
        }
        else
        {
          menue = menue + spacing + menuePunkte[c];
        }
        menue = menue + "\n";
      }
      return new string(menue);
    }
  }
}