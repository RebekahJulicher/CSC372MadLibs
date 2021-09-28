using System;
using System.Linq;
using System.Collections.Generic;
using CSC372MadLibs.Templates;

/**
Main class for Madlibs. 
*/
namespace CSC372MadLibs {
    class Program {
        static string[] validInputs = {"y", "yes", "n", "no"}; // valid inputs as a string array
        static int gamesPlayed = 0; 
        static string longestWord = "";

        /**
        Main method for the class
        */
        static void Main(string[] args) {
            bool running = true;

            string playing = String.Empty;
            bool valid = false;

            // Asks user if they want to play for the first time
            while (!valid) {
                Console.WriteLine("\nWelcome to Mad Libs! Would you like to play? y/n: ");
                playing = Console.ReadLine();
                playing = playing.ToLower();
                if (validInputs.Contains(playing))
                    valid = true;
                else 
                    Console.WriteLine("Invalid input");
            }

            // Sets the running boolean to true or false
            if (playing[0] == 'y') // only checks the first letter so it handles "yes" and "y"
                running = true;
            else
                running = false;

            // Executes as long as the player wants to play
            while (running) {
                printStats();
                gamesPlayed++;
                Console.WriteLine("\n");
                // Actually playing the game
                string templateString = extractTemplate("templates.txt");
                var template = new Template(templateString);
                string curr = template.getNextPart();
                //Console.WriteLine(curr);
                while (!String.Equals(curr, null)){
                    Console.WriteLine("Enter a " + curr + ": ");
                    string input = Console.ReadLine();
                    if (input.Length > longestWord.Length)
                        longestWord = input;
                    template.setCurrPart(input);
                    curr = template.getNextPart();
                }
                Console.WriteLine(template.ToString());

                valid = false;
                // Asks user if they want to play again
                while (!valid) {
                    Console.WriteLine("\nWant to play again?: y/n"); // Change this to something non-degenerate
                    playing = Console.ReadLine();
                    playing = playing.ToLower();
                    if (validInputs.Contains(playing))
                        valid = true;
                    else 
                        Console.WriteLine("Invalid input");
                }

                // sets the running boolean to true or false
                if (playing[0] == 'y') 
                    running = true;
                else 
                    running = false;
            }
            Console.WriteLine("Ok byeeeee :D");
            printStats();
        }

        // Reads all lines of a template file into a string array, and 
        // returns a random template line
        static string extractTemplate (string fileName) {
            string [] lines = System.IO.File.ReadAllLines(fileName);
            Random rand = new Random();
            int templateIndex = rand.Next(lines.Length);
            return lines[templateIndex];
        }

        static void printStats() {
            Console.WriteLine("STATS:");
            Console.WriteLine("Games played: " + gamesPlayed);
            Console.WriteLine("Longest word entered: \"" + longestWord + "\", length: " + longestWord.Length);
            //Console.WriteLine(":"); Here you want to print out the dictionary stuff
        }
    }
}
