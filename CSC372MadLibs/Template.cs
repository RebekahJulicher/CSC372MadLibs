using System;
using System.Collections.Generic;
using static CSC372MadLibs.Program;

namespace CSC372MadLibs.Templates {
    public class Template {
        private string fileStream = string.Empty;
        //private Dictionary<string, List<string>> POSMappings = new Dictionary<string, string>();
        //private string filledTemplate = string.Empty;
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
                if (Char.IsDigit(template[i][0])){
                    found = true;
                    currPart = i;
                    return template[i];
                }
            }
            currPart = template.Length;
            return null;
        }

        // Sets the current part of speech to the response
        public void setCurrPart(string response){
            template[currPart] = response;
            currPart++;
        }
        
        /*
        public Dictionary<string, List<string>> GetPOSMappings() {
            return POSMappings;
        }

        public void EnterPOS(string POS, string entry) {
            POSMappings.
            POSMappings.Add(POS, entry);
        }

        public void fillTemplate() {
            for ()
        }
        */

        public override string ToString() {
            if (currPart >= template.Length) return fileStream;
            return String.Join(" ", template);
        }
    }
}
