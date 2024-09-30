TitleDisplay("The Game of Life");



void TitleDisplay(string title)
{
    Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop);

    Console.WriteLine(title);

    Console.SetCursorPosition(0, Console.CursorTop);
}