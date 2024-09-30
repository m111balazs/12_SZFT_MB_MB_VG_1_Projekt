TextDisplay("The Game of Life");
Console.WriteLine();

#region states
bool onLoading = true;
bool onMap = false;
#endregion

while (true)
{
    while (onLoading)
    {
        TextDisplay("Main Menu");
        Console.WriteLine("Select 1 to start the game, 2 to see the tutorial, or 3 to exit");
        Console.WriteLine();
        Console.WriteLine("\t1 Start");
        Console.WriteLine("\t2 Tutorial");
        Console.WriteLine("\t3 Exit");

        ConsoleKeyInfo key = Console.ReadKey();

        switch (key.Key)
        {
            case ConsoleKey.D1:
                Console.Clear();
                //map matrix betoltese
                break;
            case ConsoleKey.D2:
                Console.Clear();
                TextDisplay("TUTORIAL:");
                Console.WriteLine("1. In game the Grass has 3 condition (initiative, tender, grown up)\n2. We have two animals in the game: rabbits and foxes");// alapveto "hasznalati utasitas" a felhasznalo szamara
                Console.WriteLine("Press ESC to exit to the main menu");
                Console.ReadKey(true);
                Console.Clear();
                onLoading = true;
                break;
            case ConsoleKey.D3:
                Console.Clear();
                TextDisplay("The End.");
                Environment.Exit(0);
                break;
        }
    }
}

void TextDisplay(string title)
{
    Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop);

    Console.WriteLine(title);

    Console.SetCursorPosition(0, Console.CursorTop);
}