# Animated Strings 

- Simple demonstration of animated strings  
- C#  

---
### Code Parts

*Recursive check for valid integer input*
```cs
static void UserInput(out int input)
{
  Console.Write("\n Ganzzahl eingeben: ");
  if (!int.TryParse(Console.ReadLine(), out input))
    UserInput(out input);
  else return;
}
```
---  
### Screenshots  
<!--screenshot-->
