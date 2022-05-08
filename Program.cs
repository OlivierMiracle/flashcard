/*
 * Written by  Adam Ciszewski
*/

using System.IO;
using System;
namespace flashcard;

public enum GameModes
{
    Nondefined = 1,
    Exact = 1,
    Definition = 2,
    LongAnswer = 3
}

public enum Commands
{
    h, Help = 0,
    c, Create = 1,
    r, Run = 2,
    e, Edit = 3,
    s, SetDir = 4,
    l, List = 5
}

public enum CommandsCreate
{
    n, name = 0,
    a, add = 1,
    r, remove = 2,
    e, edit = 3,
    l, list = 4,
    x, exit = 5,
    s, save = 6
}

public static class Program
{
    public static void Main(string[] args)
    {
        ArgumentsCheck(args);
    }

    private static void ArgumentsCheck(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine(
                @"Lack of arguments. Type ""flashcard h"" or ""flashcard help"" for list of available commands.");
        }

        int command;
        try
        {
            command = (int) Enum.Parse(typeof(Commands), args[0], true);
        }
        catch (ArgumentException)
        {
            Console.WriteLine(
                @"Entered argument is unknown. Type ""flashcard h"" or ""flashcard help"" for list of available commands.");
            return;
        }

        switch (command)
        {
            case 0:
                Help();
                break;
            case 1:
                CreateFl(args[1]);
                break;
            case 2:
                RunFl(args[1]);
                break;
            case 3:
                EditFl(args[1]);
                break;
            case 4:
                SetDir(args[1]);
                break;
            case 5:
                ListFl();
                break;
        }
    }

    private static void Help()
    {
        Console.WriteLine("Flashcards by Adam Ciszewski\n" +
                          "All rights reserved\n\n" +
                          "List of all available commands:\n\n" +
                          "h, help: Get help information, completely useless information if you're reading this right now.\n" +
                          "c, create: Create a new set of flashcards and choose a saving directory if not defined.\n" +
                          "r, run: Run already existing set of flashcards.\n" +
                          "e, edit: Edit already existing set of flashcards.\n" +
                          "s, setdir: Set working directory for flashcards. It is a directory where every flashcard will be saved and looked for.\n" +
                          "l, list: List out every flashcards set from directory.\n\n" +
                          "If this doesn't help you either way, maybe it's time to take a break or go to sleep, but what do I know…");
    }
    #region CreateFl
    private static void CreateFl(string path)
    {
        Console.WriteLine("\nWelcome to Flashcards Creator!\n" +
                          "Here you can set and change back and forth settings for new Flashcards\n" +
                          "List of all available commands:\n\n" +
                          "n, name [name]: set a name of a whole set.\n" +
                          "a, add [obverse of flashcard]: Add a new flashcard for a set. You will be asked for an obverse of flashcard, it is a first side of the flashcard that you look at.\n" +
                          "                               Then you will be asked for reverse of a flashcard and that is an answer.\n" +
                          "r, remove [obverse of flashcard or numerical position in a set]: Remove flashcard from set" +
                          "e, edit [obverse of flashcard]: Edit a obverse and reverse of particular flashcard.\n" +
                          "l, list: displays list of all existing Flashcards in a set.\n" +
                          "x, exit: Exit a process of creating a flashcard. Every data will be lost.\n" +
                          "s, save: Save a set and end a process.\n");
        FlashcardsSet flashcardsSet = null;
        int stage = 0;
        do
        {
            string[] args = Console.ReadLine().Split(' ');
            int command = 0;
            try
            {
                command = (int) Enum.Parse(typeof(Commands), args[0], true);
            }
            catch (ArgumentException)
            {
                Console.WriteLine(
                    @"Entered argument is unknown. Type ""flashcard h"" or ""flashcard help"" for list of available commands.");
                return;
            }
            
            switch (command)
            {
                case 0:
                    flashcardsSet = new FlashcardsSet(args[1]);
                    stage++;
                    break;
                case 1:
                    AddFl(flashcardsSet, args[1]);
                    break;
                case 2:
                    
                    break;
                case 3:
                    
                    break;
                case 4:
                    
                    break;
                case 5:
                    
                    break;
            }
            
        } while (stage == 3);
    }

    public static int AddFl(FlashcardsSet flset, string obverse)
    {
        if (flset == null)
        {
            Console.WriteLine("Name the set first!\n");
            return 0;
        }

        if (obverse == null)
        {
            Console.WriteLine("You have to give a flashcard some question.\n");
            return 0;
        }
        string reverse;
        GameModes gamemode = 0;
        
        Console.WriteLine("Great!\n" +
                          "Lets's now set a reverse site of flashcard.\n");
        do
        {
            reverse = Console.ReadLine();
            if (reverse == null) Console.WriteLine("Reverse cannot be empty! Try again...");
            else break;
        } while (true);
        
        Console.WriteLine("Great!\n" +
                          "Now you have to set a gamemode of flashcard. \n");
        GameModes gm = GameModes.Exact | GameModes.Definition | GameModes.LongAnswer;
        Console.WriteLine(gm + "\n");

        do
        {
            try
            {
                gamemode = (GameModes) Enum.Parse(typeof(Commands),Console.ReadLine(), true);
            }
            catch (ArgumentException)
            {
                Console.WriteLine(
                    @"Entered gamemode is unknown. Try again...");
            }
        } while (gamemode != 0);
        
        flset.AddFlashcard(obverse, reverse, gamemode);

        return 1;
    }
    
    #endregion
    private static void RunFl(string path)
    {
        
    }
    private static void EditFl(string path)
    {
        
    }
    private static void SetDir(string path)
    {
        
    }
    private static void ListFl()
    {
        
    }
}
/*public class Quiz
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