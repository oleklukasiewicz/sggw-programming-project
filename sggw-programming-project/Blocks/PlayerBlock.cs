using sggw_programming_project.Scene;
using System;

internal class PlayerBlock : Block
{
   // public override string Icon { get; set; } = "\ud83d\udc36";
    public override string Id { get; } = "player";

    public override  int Health { get; set; } = 100;
    public PlayerBlock() : base()
    {
        this.SetRandomLocation();
        Console.WriteLine("Wybierz swój avatar:");
        Console.WriteLine("Wpisz 1 aby wybrać " + "\ud83d\udc36");
        Console.WriteLine("Wpisz 2 aby wybrać " + "\ud83d\udc80");
        Console.WriteLine("Wpisz 3 aby wybrać " + "\ud83e\udd8b");
        Console.WriteLine("Wpisz 4 aby wybrać " + "\ud83d\udc2d");
        Console.WriteLine("Wpisz 5 aby wybrać " + "\ud83c\udf1e");

        ConsoleKeyInfo pressedKey;

            pressedKey = Console.ReadKey();
        switch (pressedKey.Key)
        {
            case ConsoleKey.D1:
                Icon = "\ud83d\udc36";
                break;
            case ConsoleKey.D2:
                Icon = "\ud83d\udc80";
                break;
            case ConsoleKey.D3:
                Icon = "\ud83e\udd8b";
                break;
            case ConsoleKey.D4:
                Icon = "\ud83d\udc2d";
                break;
            case ConsoleKey.D5:
                Icon = "\ud83c\udf1e";
                break;
            default:
                break;
        }

    }

}
// kod na diamencik: \ud83d\udc8e