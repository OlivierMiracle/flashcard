/*
 * Written by  Adam Ciszewski
*/

using System.IO;
using System;
using System.Reflection.Metadata.Ecma335;
using CommandLine;

namespace flashcard;
[Verb("create", HelpText = "Create a new set of flashcards and choose a save to given directory. Max of 20 characters.")]
class CreateOptions
{
    [Option("name",Max = 20)]
    public IEnumerable<string> NameSet { get; set; }
}

[Verb("run", HelpText = "Run already existing set of flashcards from given directory.")]
class RunOptions
{
    
}
public static class Program
{
    public static void Main(string[] args)
    {
        var result = Parser.Default.ParseArguments<CreateOptions, RunOptions>(args);
    }
    /*public static void Main(string[] args)
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
        #region Help Message
        Console.WriteLine("Flashcards by Adam Ciszewski\n" +
                          "All rights reserved\n\n" +
                          "List of all available commands:\n\n" +
                          "h, help: Get help information, completely useless information if you're reading this right now.\n" +
                          "c, create [name of set]: Create a new set of flashcards and choose a saving directory if not defined.\n" +
                          "r, run: Run already existing set of flashcards.\n" +
                          "e, edit: Edit already existing set of flashcards.\n" +
                          "s, setdir: Set working directory for flashcards. It is a directory where every flashcard will be saved and looked for.\n" +
                          "l, list: List out every flashcards set from directory.\n\n" +
                          "If this doesn't help you either way, maybe it's time to take a break or go to sleep, but what do I know…");
        #endregion
    }
    #region CreateFl
    private static void CreateFl(string name)
    {
        #region Creator Message
        Console.WriteLine("\nWelcome to Flashcards Creator!\n" +
                          "Here you can set and change back and forth settings for new Flashcards\n" +
                          "List of all available commands:\n\n" +
                          "n, name [name]: Rename a whole set.\n" +
                          "a, add: Add a new flashcard for a set. You will be asked for an obverse of flashcard, it is a first side of the flashcard that you look at.\n" +
                          "                               Then you will be asked for reverse of a flashcard and that is an answer.\n" +
                          "r, remove [obverse of flashcard or numerical position in a set]: Remove flashcard from set" +
                          "e, edit [obverse of flashcard]: Edit a obverse and reverse of particular flashcard.\n" +
                          "l, list: displays list of all existing Flashcards in a set.\n" +
                          "x, exit: Exit a process of creating a flashcard. Every data will be lost.\n" +
                          "s, save: Save a set and end a process.\n");
        #endregion
        FlashcardsSet flashcardsSet = new FlashcardsSet(name);
        bool exit = false;
        do
        {
            string[] args = Console.ReadLine().Split(' ');
            int command = 0;
            try
            {
                command = (int) Enum.Parse(typeof(CommandsCreate), args[0], true);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Entered argument is unknown.\n");
            }
            
            switch (command)
            {
                case 0:
                    if (args[1] == null)
                    {
                        Console.WriteLine("Name can't be changed to nothing! PLease type a name");
                        break;
                    }
                    flashcardsSet.RenameSet(args[1]);
                    break;
                case 1:
                    AddFl(flashcardsSet);
                    break;
                case 2:
                    
                    break;
                case 3:
                    
                    break;
                case 4:
                    
                    break;
                case 5:
                    exit = true;
                    break;
            }
            
        } while (!exit);
    }

    public static void AddFl(FlashcardsSet flset)
    {
        if (flset == null)
        {
            Console.WriteLine("Name the set first!\n");
            return;
        }

        string obverse;
        Console.WriteLine("Please write down a obverse (question) of flashcard!\n");
        do
        {
            obverse = Console.ReadLine();
            if (obverse == null) Console.WriteLine("Obverse cannot be empty! Try again...");
            else break;
        } while (true);
        
        string reverse;
        Console.WriteLine("Great!\n" +
                          "Lets's now set a reverse site of flashcard.\n");
        do
        {
            reverse = Console.ReadLine();
            if (reverse == null) Console.WriteLine("Reverse cannot be empty! Try again...");
            else break;
        } while (true);
        
        GameModes gamemode = 0;
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
                Console.WriteLine("Entered gamemode is unknown. Try again...\n");
            }
        } while (gamemode != 0);
        
        flset.AddFlashcard(obverse, reverse, gamemode);
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
        
    }*/
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