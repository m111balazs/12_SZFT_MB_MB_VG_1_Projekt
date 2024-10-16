﻿using The_game_of_life_Lib;

TextDisplay("The Game of Life");
TextDisplay("--------------------------------------------");
Console.WriteLine();

#region Constants
const int MaxMapCol = 16;
const int MaxMapRow = 20;
const string MapFilePath = "map.txt";
#endregion

#region States
bool onLoading = true;
bool onMap = false;
#endregion

#region ConsoleSettings
Console.CursorVisible = false;
#endregion

#region Classes
Entities nowGeneratedEntities = new(4, 6, 12);
#endregion

#region Lists
List<Entity> rabbitsList = nowGeneratedEntities.Rabbits;
List<Entity> foxesList = nowGeneratedEntities.Foxes;
List<Entity> grassesList = nowGeneratedEntities.Grasses;
string[,] mapMatrix = MapRead(MapFilePath, MaxMapCol, MaxMapRow);
string[,] newMatrix = ChangeMapCharacters(rabbitsList, foxesList, grassesList, mapMatrix);
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
                onLoading = false;
                onMap = true;
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

    while (onMap)
    {
        Console.SetCursorPosition(0,0);
        MapDisplay(newMatrix);
    }
}

#region Methods
static string[,] MapRead(string filePath, int row, int col)
{
    string[] fileLines = File.ReadAllLines(filePath);

    string[,] matrix = new string[col, row];

    for (int i = 0; i < 16; i++)
    {
        string line = fileLines[i];

        for (int j = 0; j < 20; j++)
        {
            matrix[i, j] = ".";
        }
    }

    return matrix;
}

static string[,] ChangeMapCharacters(List<Entity> rabbits, List<Entity> foxes, List<Entity> grasses, string[,] matrix)
{
    List<List<Entity>> entities = new List<List<Entity>>();
    entities.Add(rabbits);
    entities.Add(foxes);
    entities.Add(grasses);

    foreach(var item in entities)
    {
        foreach (var entity in item)
        {
            switch (entity.Type)
            {
                case "f":
                    matrix[entity.PositionY, entity.PositionX] = "f";
                    break;
                case "g":
                    matrix[entity.PositionY, entity.PositionX] = "g";
                    break;
                case "r":
                    matrix[entity.PositionY, entity.PositionX] = "r";
                    break;
            }
        }
    }

    return matrix;
}

static void TextDisplay(string title)
{
    Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop);

    Console.WriteLine(title);

    Console.SetCursorPosition(0, Console.CursorTop);
}

static void MapDisplay(string[,] matrix)
{
    for (int i = 0; i < 16; i++)
    {
        for (int j = 0; j < 20; j++)
        {
            Console.Write('.');
        }
        Console.WriteLine();
    }
}
#endregion