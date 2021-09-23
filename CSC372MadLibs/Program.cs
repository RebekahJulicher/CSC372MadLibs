using System;
using System.Linq;
using System.Collections.Generic;
using CSC372MadLibs.Template;

namespace CSC372MadLibs {
    class Program {
        static string [] partsOfSpeech = new string {"noun", "plnoun", "verb", "adjective", "integer"};

        static void Main(string[] args) {
            string templateString = extractTemplate("templates.txt");
            var template = new Template(templateString, extractPOS(templateString));
            Console.WriteLine("Hello World!");
        }

        static string extractTemplate (string fileName) {
            string [] lines = System.IO.File.ReadAllLines(fileName);
            Random rand = new Random();
            int templateIndex = rand.Next(lines.Length);
            return lines[templateIndex];
        }

        static string [] extractPOS(string template) {
            string partString = string.Empty;
            int [] parts = template.Where(Char.IsDigit).ToArray());
            foreach (int part in parts) 
                partString += partsOfSpeech[part - 1] + " ";
            return partString.Split(' ');
        }

        static void askForPOS(Template template) {
            Dictionary<string, string> POS = template.getPOSMappings();
            var keys = POS.Keys.ToList();
            foreach (var key in keys) {
                Console.WriteLine("Enter a {0}: ", key);
                string input = Console.ReadLine();
                POS.Add(key, input);
            }
                

        }
    }
}
