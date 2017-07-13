using Spielwiese.Functions.Counter;
using Spielwiese.Functions.Games;
using Spielwiese.Functions.Miscellaneous;
using Spielwiese.Util.Exceptions;
using Spielwiese.Util.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spielwiese
{
    class Program
    {
        static void Main(string[] args)
        {
            new GameLauncher().LaunchNewGame();
        }

        //    static void Main(string[] args)
        //    {
        //        object[] functions = new object[]
        //        {
        //            new CharacterCounter(),
        //            new WordCounter(),
        //            new AddonDownloader(),
        //            new GameLauncher()
        //        };

        //        CommandParser cmdParser = null;
        //        object currentFunction = null;

        //        Console.WriteLine("Please choose a Function to call");
        //        for (int i = 0; i < functions.Length; i++)
        //        {
        //            Console.WriteLine($"{i}: {functions[i].GetType().Name}");
        //        }

        //        bool validFunction = false;
        //        while (!validFunction)
        //        {
        //            try
        //            {
        //                Console.Write("\n==> ");
        //                currentFunction = functions[Convert.ToInt32(Console.ReadLine())];
        //                cmdParser = new CommandParser(currentFunction);
        //                validFunction = true;
        //            } catch(Exception) { }
        //        }

        //        Console.Clear();
        //        bool validInput = false;
        //        while (!validInput)
        //        {
        //            try
        //            {
        //                Console.WriteLine($"Enter your Command for function '{currentFunction.GetType().Name}'");
        //                Console.Write("==> ");
        //                string command = Console.ReadLine();
        //                cmdParser.CallMethod(command);
        //                validInput = true;
        //            }
        //            catch (CommandException ce)
        //            {
        //                Console.Clear();
        //                Console.WriteLine(ce.Message);
        //            }
        //            catch(Exception e)
        //            {
        //                Console.WriteLine($"Something went wrong :( ==> {e.Message}");
        //                Console.WriteLine(e.StackTrace);
        //                break;
        //            }
        //        }

        //        Console.Write("\n\nPress any key to end programm.");
        //        Console.ReadKey();
        //    }
    }
}
