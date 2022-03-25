/*
 * Written by  Adam Ciszewski
*/

using System.Reflection.Metadata;
using Terminal.Gui;

namespace flashcard;

public enum GameModes
{
    Exact,
    Definition,
    LongAnswer
}

public static class Program
{
    public static void Main(string[] args)
    {
        Application.Init ();

        var app = new View()
        {
            Width = Dim.Fill(),
            Height = Dim.Fill()
        };

        var Flashcards = new Window ("Flashcard") {
            LayoutStyle =  LayoutStyle.Computed,
            X = 1,
            Y = 1,
            
            Width = Dim.Percent (60f),
            Height = Dim.Fill (1)
        };
        
        var Score = new Window ("Score") {
            X = Pos.Right(Flashcards),
            Y = 1,
            Width = Dim.Percent (40f),
            Height = Dim.Fill (1),
            
        };

        // Add both menu and win in a single call
        app.Add(Flashcards, Score);
        Application.Top.Add(app);
        Application.Run ();
    }

    /*private static async Task<List<Flashcard>> GetFlashcardsAsync()
    {
        List<Flashcard> flashcards = new List<Flashcard>();
        return flashcards;
    }
}
public class Flashcard
 {
     public string Question;
     public string Answer;
     public GameModes Gamemode;
 
     Flashcard(string question, string answer, GameModes gamemode)
     {
         Question = question;
         Answer = answer;
         Gamemode = gamemode;
     }
 }
public class Quiz
{
    public string Question;
    public string Answer;
    public GameModes Gamemode;

    Quiz(string question, string answer, GameModes gamemode)
    {
        Question = question;
        Answer = answer;
        Gamemode = gamemode;
    }*/
}