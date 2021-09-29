using System;
using System.Collections.Generic;
using static CSC372MadLibs.Program;

/**
Template class that represents the Template Object that we use in our code.
Authors: Orlando Rodriguez
        Rebekah Julicher
*/
namespace CSC372MadLibs.Templates {
    public class Template {
        private string fileStream = string.Empty; // Input template
        private string[] template; // The actual template ready for POS insertion
        private int currPart = 0; // current part of speech (POS) that is being edited

        // Constructor, reads in the filestream for the template and sets
        // each of the parts of speech to new Lists in the POSMapping Dictionary
        public Template(string fileStream) {
            this.fileStream = fileStream;
            template = fileStream.Split(' '); // splits template into words
        }

        // removed GetFileStream for now because it's covered in ToString

        // Gets the next part of speech after the current index
        public string getNextPart(){
            if (currPart > template.Length - 1 ) return null;
            bool found = false;
            // looks through the template for POS's that need input
            for (int i = currPart; i < template.Length && !found; i++){
                if (template[i].Contains('{')){
                    found = true;
                    currPart = i;
                    char last = template[currPart][template[currPart].Length - 1];
                    // checks if punctuation needs to be cut off
                    if (last == ',' || last == '.') return template[currPart].Substring(1, template[currPart].Length-3);
                    return template[currPart].Substring(1, template[currPart].Length-2);
                }
            }
            currPart = template.Length;  
            return null;
        }

        // Sets the current part of speech to the response
        public void setCurrPart(string response){
            // account for punctuation in the template
            if (template[currPart][template[currPart].Length - 1] == ',') template[currPart] = response + ","; // commas
            else if (template[currPart][template[currPart].Length - 1] == '.') template[currPart] = response + "."; // periods
            else template[currPart] = response; // no punctuation
            currPart++;
        }

        /**
            C# enables us to redefine the toString method for class. 
            This allows us to write out the object in human-friendly way
        */
        public override string ToString() {
            // Debugging information
            if (currPart < template.Length) 
                return fileStream;
            return String.Join(" ", template);
        }
    }
}
