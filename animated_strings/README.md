# Animated Strings 

- Simple demonstration of animated strings  
- C#  

---
### Code Parts

*Recursive check for valid integer input*
```cs
static void PromptUserInput(out int input)
{
  Console.Write("\n Ganzzahl eingeben: ");
  if (!int.TryParse(Console.ReadLine(), out input))
    PromptUserInput(out input);
  else return;
}
```
---  
### Screenshots  
<!--screenshot-->
![image](https://github.com/IxI-Enki/ginf_projects/assets/138018029/47da1bfe-f4d6-4fe8-ae42-fb8b59268571)  

![image](https://github.com/IxI-Enki/ginf_projects/assets/138018029/6ee9fb8c-b5a9-43a3-b50c-adc4bbd93fe3)  

