// See https://aka.ms/new-console-template for more information

using Spectre.Console;

namespace flashcard;

public static class Flashcard
{
    public static void Main(string[] args)
    {
        AnsiConsole.Markup("[underline red]Hello World![/]");
    }
}