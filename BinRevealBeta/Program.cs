using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace BinRevealBeta
{
    class Program
    {
        /// <summary>
        /// Prints out information about how to use the program.
        /// </summary>
        private static void Usage()
        {
            Console.WriteLine(@"Usage: binreveal.exe [flags] [file]");
        }

        /// <summary>
        /// prints out a full width line with a specified forground and background color.
        /// </summary>
        public static void printLn(object obj, ConsoleColor backColor, ConsoleColor fontColor)
        {
            var str = obj.ToString();
            Console.BackgroundColor = backColor;
            Console.ForegroundColor = fontColor;
            Console.Write(str);
            for(int i = 0; i < Console.WindowWidth - str.Length; ++i)
            {
                Console.Write(@" ");
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Prints out text with a red color for indicating an error
        /// </summary>
        /// <param name="obj">Additional information</param>
        /// <param name="ex">If specified, an exception to be printed to the console</param>
        public static void printError(object obj, Exception ex = null)
        {
            if (ex != null)
            {
                Program.printLn(@" Error: " + ex.Message, ConsoleColor.Black, ConsoleColor.Red);
            } else
            {
                Program.printLn(obj, ConsoleColor.Black, ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Prints out a grey line
        /// </summary>
        public static void printRow()
        {
            //print an entire line with a grey background color
            Console.BackgroundColor = ConsoleColor.Gray;
            for(int i = 0; i < Console.WindowWidth; ++i)
            {
                Console.Write(@" ");
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Print the information about the program including it's author, version and license
        /// </summary>
        public static void printHeader()
        {
            printLn(@" BinReveal 1.0", ConsoleColor.White, ConsoleColor.Black);
            printLn(@"", ConsoleColor.Gray, ConsoleColor.Black);
            printLn(@" Created by Sem Voigtländer", ConsoleColor.Gray, ConsoleColor.Black);
            printLn(@" Copytight (c) 2018. Licensed under MIT.", ConsoleColor.Gray, ConsoleColor.Black);
        }

        public static void printFooter()
        {
            if(System.Diagnostics.Debugger.IsAttached) //Only ask for userinput in Visual Studio
            {
                Console.WriteLine(@""); //Print a new line
                Console.Write(@"Press any key to continue...");
                Console.ReadKey(); //Wait for user interaction
            }
        }


        static void Main(string[] args)
        {
            Console.Clear(); //Reset the console output
            //The program needs arguments to work with.
            if (args == null || args.Length <= 0)
            {
                //If we are not in visual studio we should print out usage information
                if (!System.Diagnostics.Debugger.IsAttached)
                {
                    Usage(); //print information about how to use the program
                } else
                {
                    var input = new List<string>();
                    while (!input.Contains(@"<<<EOF"))
                    {
                        Console.Write(@"argv[" + input.Count + "]: ");
                        var value = Console.ReadLine().Replace("\"", "");
                        input.Add(value == "" ? "<<<EOF" : value);
                    }
                    args = input.ToArray();
                    Console.Clear();
                }
            }

            //try to run the program with the specified arguments
            try {
                printHeader(); //Print the info about the program
                printRow(); //Print a new row
                MagicFinder.findMagic(args.First(), args.Contains(@"--hexdump")); //try to find the magic of the specified file and also generate a hexdump if the flag is specified
                printFooter(); //print out the footer if we are in visual studio
            }
            catch (Exception ex) //If something went wrong during execution of the program that we did not handle yet
            {
                Console.WriteLine(@"An unknown error has occured."); //We don't know exactly what went wrong
                Console.WriteLine(@"Reason: " + ex.Message); //We print out the reason of why it went wrong
                if (System.Diagnostics.Debugger.IsAttached) //We ask for userinput if we are in visual studio
                {
                    Console.WriteLine(@"Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}
