
WriteInTheMiddle("Welcome! To start the simulation press any key");

void WriteInTheMiddle(string outputText)
{
    Console.SetCursorPosition((Console.WindowWidth - outputText.Length) / 2, Console.CursorTop);
    Console.WriteLine(outputText);
}