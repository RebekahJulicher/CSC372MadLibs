using System;
using System.Linq;
using System.Collections.Generic;
using CSC372MadLibs.Templates;

namespace CSC372MadLibs {
    class Program {
        static string[] validInputs = {"y", "yes", "n", "no"};

        static void Main(string[] args) {
            bool running = true;

            string playing = "0";
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
            if (playing[0] == 'y') 
                running = true;
            else
                running = false;

            // Executes as long as the player wants to play
            while (running) {
                Console.WriteLine("\n");
                // Actually playing the game
                string templateString = extractTemplate("templates.txt");
                var template = new Template(templateString);
                string curr = template.getNextPart();
                //Console.WriteLine(curr);
                while (!String.Equals(curr, null)){
                    Console.WriteLine("Enter a " + curr + ": ");
                    template.setCurrPart(Console.ReadLine());
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
        }

        // Reads all lines of a template file into a string array, and 
        // returns a random template line
        static string extractTemplate (string fileName) {
            string [] lines = System.IO.File.ReadAllLines(fileName);
            Random rand = new Random();
            int templateIndex = rand.Next(lines.Length);
            return lines[templateIndex];
        }
    }
}
