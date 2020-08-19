using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheaterEngine;

namespace TheaterConsole
{
    /// <summary>
    /// The class used to represent the TheaterConsole.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The theater being created.
        /// </summary>
        private static Theater theater;

        /// <summary>
        /// The TheaterConsole main function.
        /// </summary>
        /// <param name="args">Main arguments.</param>
        public static void Main(string[] args)
        {
            // Set the console's title and show a welcome message.
            Console.Title = "2.2 Theater Test.";
            Console.WriteLine("Welcome to the Marcus Theater!");

            // Sets theater variable to the theater created.
            theater = Theater.NewTheater();

            // Create a command variable.
            string command;

            // Creates an exit variable for the console.
            bool exit = false;

            while (exit != true)
            {
                // Puts a bracket at the start of each line as a prompt to the user.
                Console.Write("] ");

                // Console reads the input from the user.
                command = Console.ReadLine();

                // Converts all input to lower case, and gets rid of extra spacing, so that the switch commands work.
                command = command.ToLower().Trim();

                // Creates the commandWords array. 
                string[] commandWords = command.Split();

                switch (commandWords[0])
                {
                    case "exit":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid command entered: " + command);
                        break;

                    case "new":
                        theater = Theater.NewTheater();
                        Console.WriteLine("A new Marcus Theater was created.");
                        break;

                    case "count":
                        try
                        {
                            switch (commandWords[1])
                            {
                                case "movies":
                                    int movieCount = theater.Movies.Count<Movie>();
                                    Console.WriteLine($"Movies: {movieCount}");
                                    break;

                                case "guests":
                                    int guestCount = theater.Guests.Count<Guest>();
                                    Console.WriteLine($"Guests: {guestCount}");
                                    break;

                                default:
                                    Console.WriteLine("Only movies and guests can be written to the console.");
                                    break;
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Add a second command of either 'movies' or 'guests'.");
                        }
                        
                        break;                
                }
            }
        }
    }
}