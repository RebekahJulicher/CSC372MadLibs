using System;
using System.Collections.Generic;
using static CSC372MadLibs.Program;

/**
Template class that represents the Template Object that we use in our code.
*/
namespace CSC372MadLibs.Templates {
    public class Template {
        private string fileStream = string.Empty;
        private string[] template;
        private int currPart = 0;

        // Constructor, reads in the filestream for the template and sets
        // each of the parts of speech to new Lists in the POSMapping Dictionary
        public Template(string fileStream) {
            this.fileStream = fileStream;
            template = fileStream.Split(' ');
        }

        // removed GetFileStream for now because it's covered in ToString

        // Gets the next part of speech after the current index
        public string getNextPart(){
            if (currPart > template.Length - 1 ) return null;
            bool found = false;
            for (int i = currPart; i < template.Length && !found; i++){
                if (template[i].Contains('{')){
                    found = true;
                    currPart = i;
                    char last = template[currPart][template[currPart].Length - 1];
                    if (last == ',' || last == '.') return template[currPart].Substring(1, template[currPart].Length-3);
                    return template[currPart].Substring(1, template[currPart].Length-2);
                }
            }
            currPart = template.Length;
            return null;
        }

        // Sets the current part of speech to the response
        public void setCurrPart(string response){
            if (template[currPart][template[currPart].Length - 1] == ',') template[currPart] = response + ",";
            else if (template[currPart][template[currPart].Length - 1] == '.') template[currPart] = response + ".";
            else template[currPart] = response;
            currPart++;
        }

        /**
            C# enables us to redefine the toString method for class. 
            This allows us to write out the object in human-friendly way
        */
        public override string ToString() {
            if (currPart < template.Length) {
                return fileStream;
            }
            return String.Join(" ", template);
        }
    }
}
