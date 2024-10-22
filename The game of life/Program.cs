using The_game_of_life_Lib;

Mezo mezo = new();

mezo.SzovegKiiro("The Game of Life");
mezo.SzovegKiiro("--------------------------------------------");
Console.WriteLine();

mezo.SzovegKiiro("Main Menu");
Console.WriteLine("Select 1 to start the game, 2 to see the tutorial, or 3 to exit");
Console.WriteLine();
Console.WriteLine("\t1 Start");
Console.WriteLine("\t2 Tutorial");
Console.WriteLine("\t3 Exit");

ConsoleKeyInfo key = Console.ReadKey();
bool start = true;

while (true)
{
    if (!start)
    {
        mezo.SzovegKiiro("The Game of Life");
        mezo.SzovegKiiro("--------------------------------------------");
        Console.WriteLine();

        mezo.SzovegKiiro("Main Menu");
        Console.WriteLine("Select 1 to start the game, 2 to see the tutorial, or 3 to exit");
        Console.WriteLine();
        Console.WriteLine("\t1 Start");
        Console.WriteLine("\t2 Tutorial");
        Console.WriteLine("\t3 Exit");
        key = Console.ReadKey();
    }
    
    
    switch (key.Key)
    {
        case ConsoleKey.D1:
            start = false;
            Console.Clear();
            while (true)
            {
                Console.Clear();
                mezo.Kiiras();
                mezo.KoviMezo();
                Thread.Sleep(2000);
            }
        case ConsoleKey.D2:
            start = false;
            Console.Clear();
            mezo.SzovegKiiro("TUTORIAL:");
            Console.WriteLine("1. In game the Grass has 3 condition (initiative, tender, grown up)\n2. We have two animals in the game: rabbits and foxes");// alapveto "hasznalati utasitas" a felhasznalo szamara
            Console.WriteLine("Press ESC to exit to the main menu");
            Console.ReadKey(true);
            Console.Clear();
            break;
        case ConsoleKey.D3:
            start = false;
            Console.Clear();
            mezo.SzovegKiiro("The End.");
            Environment.Exit(0);
            break;
    }
}