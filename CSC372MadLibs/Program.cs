using System;
using System.Linq;
using System.Collections.Generic;
using CSC372MadLibs.Templates;

/**
Main class for Madlibs. 
Authors: Orlando Rodriguez
        Rebekah Julicher
*/
namespace CSC372MadLibs {
    class Program {
        // Illustrates array usage
        static string[] validInputs = {"y", "yes", "n", "no"}; // valid inputs as a string array
        static int gamesPlayed = 0; 
        static string longestWord = "";
        // Dictionary usage
        static Dictionary<string, int> wordTypes = new Dictionary<string, int>();

        /**
        Main method for the class
        */
        static void Main(string[] args) {
            bool running = true;
            string playing = String.Empty; // String.Empty is considered good style
            bool valid = false;

            // Asks user if they want to play for the first time
            // Illustrates loop usage, console input reading, and boolean operations
            while (!valid) {
                Console.WriteLine("\nWelcome to Mad Libs! Would you like to play? y/n: ");
                playing = Console.ReadLine();
                // These built-in string methods are useful for changing strings
                playing = playing.ToLower();
                if (validInputs.Contains(playing))
                    valid = true;
                else 
                    Console.WriteLine("Invalid input");
            }

            // Sets the running boolean to true or false
            // You can extract a specific character from a string by treating it like an array
            if (playing[0] == 'y') // only checks the first letter so it handles "yes" and "y"
                running = true;
            else
                running = false;

            // Executes as long as the player wants to play
            // Illustrates more loops and using class methods
            while (running) {
                printStats(); // prints the statistics
                gamesPlayed++; // adds to the game counter
                Console.WriteLine("\n");

                // Actually playing the game
                string templateString = extractTemplate("templates.txt"); // finds a random template from the templates list
                var template = new Template(templateString); // creates a Template object
                string curr = template.getNextPart(); // extracts a part-of-speech (POS) from the file

                // Keeps looping until it is done being filled in
                while (!String.Equals(curr, null)){
                    Console.WriteLine("Enter a " + curr + ": ");
                    string input = Console.ReadLine(); // asks for a POS
                    if (input.Length > longestWord.Length) // checks if it's the longest word yet
                        longestWord = input;
                    template.setCurrPart(input); // Inserts the input into the given string
                    // Arithmetic operations
                    if (wordTypes.ContainsKey(curr)) wordTypes[curr] += 1;
                    else wordTypes[curr] = 1;
                    curr = template.getNextPart(); // Asks for the next POS
                }
                Console.WriteLine(template.ToString());

                valid = false;
                // Asks user if they want to play again
                while (!valid) {
                    Console.WriteLine("\nWant to play again?: y/n"); 
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
            printStats(); // final stat print
        }

        // Reads all lines of a template file into a string array, and 
        // returns a random template line
        static string extractTemplate (string fileName) {
            string [] lines = System.IO.File.ReadAllLines(fileName); // C# has easier file reading capabilities than Java I'd say
            Random rand = new Random(); // Random number class
            int templateIndex = rand.Next(lines.Length); // Selects a random line to use
            return lines[templateIndex]; // Each line has a template, so it returns a template
        }

        // Prints stats
        static void printStats() {
            Console.WriteLine("STATS:");
            // Illustrates string concatenation
            Console.WriteLine("Games played: " + gamesPlayed);
            Console.WriteLine("Longest word entered: \"" + longestWord + "\", length: " + longestWord.Length);
            Console.WriteLine("Number of each type of word entered:");
            // Illustrates using dictionary key value pairs
            foreach(KeyValuePair<string, int> pair in wordTypes){
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }
        }
    }
}
