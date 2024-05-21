using System.Text;
using System.Threading;
 
using IxIsColorHelper;
using ColorHelper;

// C:\Users\}x{\Desktop\colorPet\pet.txt

namespace IxIsColorHelper
{
  public class ColorPet
  {
    public void Pet(int cWidth)
    {
      string petName = "pet.";
      Console.Clear();
      //*______________________________________// print_header
      PetHeader Print = new PetHeader(); /*          */ Print.PetHeaderMain(cWidth, petName);

      string filePath = "C:\\Users\\}x{\\Desktop\\colorPet\\pet.txt";  //  
      DateTime currentTime = DateTime.Now;                             //  

      /* - - - PET - - - - - - - - - - - - - - - - - - - - */
      string pet = "-pet_here-";


      // bool run = true;
      // int frame = 0, maxFrames = 10, currentFrames = 0;
      // ⍵ ⌃ ⌄ ␣ ⊔ ∪ ∐ ⅄ ₒ ₀ ⁰ ‸ ᵕ ᵒ ᴼ ᴗ ᴑ ᓑ ᑌ ᐡ ᐤ ໐ ߋ ߛ ߀ ٥ օ Օ Ѡ ѡ О ω ο ʊ _ - ¯ ­ ‿  ⁔ ‾ ⁀ ⌨ ☚ ☜ ☛ ☞ ☝ ☟ Ꙍ ꙍ
      /* - - - hands:  - - - - - - - - - - - - - - - - - - */
      //    string[] leftHands = ["╭", "╰"];    // ╰ ◟
      //    string[] rightHands = ["╮", "╯"];    // ╯◞ ノ
      /* - - - eyes: - - - - - - - - - - - - - - - - - - - */
      //    string[] leftEyes = ["0", "-"];
      //    string[] rightEyes = ["0", "-"];
      /* - - - mouths: - - - - - - - - - - - - - - - - - - */
      //    string[] mouths = ["‿", "ᴗ"];
      /*
      while (currentFrames <= maxFrames)
      {
        pet = leftHands[frame] + "(" + leftEyes[frame] + "◞" + mouths[frame] + "◟" + rightEyes[frame] + ")" + rightHands[frame];

        if (frame == 0)
        { frame = 1; }
        else if (frame == 1)
        { frame = 0; }

        currentFrames++;
        Console.Write("\n\t\t\t" + pet);
        Thread.Sleep(500);
        Console.Clear();
      }
      //   pet = leftHands[frame] + "(" + leftEyes + "~◞⊍◟~" + rightEyes + ")" + rightHands[frame];
      pet = leftHands[frame] + "(" + leftEyes[frame] + "◞" + mouths[frame] + "◟" + rightEyes[frame] + ")" + rightHands[frame];
      */
      if (petName == "pet.")
      {
        bool nameOK;
        do
        {
          Console.Write("\n\t Gib dem Haustier einen Namen: ");
          petName = Console.ReadLine();
          Console.Write($"\n\t ist der Name {petName} richtig? (j/n) ");
          nameOK = (Char.ToLower(Console.ReadKey().KeyChar) == 'j') ? true : false;

        } while (nameOK == false);
        WriteToFile(filePath, petName, currentTime);
        Console.Write("\n Name gespeichert.");
      }

      Console.Write("\n lese..:\n");
      ReadFromFile(filePath);

      Thread.Sleep(500);
      Console.Write("\n 0 zum beenden");
    }

    static void ReadFromFile(string filePath)
    {
      using (StreamReader reader = new StreamReader(filePath))
      {
        while (!reader.EndOfStream)
        {
          string petstate = reader.ReadLine();
          string[] saveDat = new string[3];
          saveDat = petstate.Split('\n', 3);

          string petName = saveDat[0];
    //      string saveTime = saveDat[1];
      

          Console.Write($"\n {saveDat[0]}");
        }
      }
    }

    static void WriteToFile(string filePath, string petName, DateTime currentTime)
    {
      using (StreamWriter writer = new StreamWriter(filePath))
      {
        writer.Write($"{petName} " +
                      "\n-----------------------" +
                     $"\n{currentTime.ToString("HH:mm:ss")}");
      }

    }
  }
}

/*
╔═╗ ╔╗  ╔═╗ ╔╦╗ ╔═╗ ╔═╗ ╔═╗ ╦ ╦ ╦  ╦ ╦╔═ ╦   ╔╦╗ ╔╗╔ ╔═╗ ╔═╗ ╔═╗  ╦═╗ ╔═╗ ╔╦╗ ╦ ╦ ╦  ╦ ╦ ╦ ═╗ ╦ ╦ ╦ ╔═╗
╠═╣ ╠╩╗ ║    ║║ ║╣  ╠╣  ║ ╦ ╠═╣ ║  ║ ╠╩╗ ║   ║║║ ║║║ ║ ║ ╠═╝ ║═╬╗ ╠╦╝ ╚═╗  ║  ║ ║ ╚╗╔╝ ║║║ ╔╩╦╝ ╚╦╝ ╔═╝
╩ ╩ ╚═╝ ╚═╝ ═╩╝ ╚═╝ ╚   ╚═╝ ╩ ╩ ╩ ╚╝ ╩ ╩ ╩═╝ ╩ ╩ ╝╚╝ ╚═╝ ╩   ╚═╝╚ ╩╚═ ╚═╝  ╩  ╚═╝  ╚╝  ╚╩╝ ╩ ╚═  ╩  ╚═╝
┌─┐ ┌┐  ┌─┐ ┌┬┐ ┌─┐ ┌─┐ ┌─┐ ┬ ┬ ┬  ┬ ┬┌─ ┬   ┌┬┐ ┌┐┌ ┌─┐ ┌─┐ ┌─┐  ┬─┐ ┌─┐ ┌┬┐ ┬ ┬ ┬  ┬ ┬ ┬ ─┐ ┬ ┬ ┬ ┌─┐
├─┤ ├┴┐ │    ││ ├┤  ├┤  │ ┬ ├─┤ │  │ ├┴┐ │   │││ │││ │ │ ├─┘ │─┼┐ ├┬┘ └─┐  │  │ │ └┐┌┘ │││ ┌┴┬┘ └┬┘ ┌─┘
┴ ┴ └─┘ └─┘ ─┴┘ └─┘ └   └─┘ ┴ ┴ ┴ └┘ ┴ ┴ ┴─┘ ┴ ┴ ┘└┘ └─┘ ┴   └─┘└ ┴└─ └─┘  ┴  └─┘  └┘  └┴┘ ┴ └─  ┴  └─┘
*/