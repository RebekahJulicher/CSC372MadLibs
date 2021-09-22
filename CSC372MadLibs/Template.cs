﻿using System;
using System.Collections.Generic;

namespace CSC372MadLibs {
    public class Template {
        private string fileStream = string.Empty;
        private Dictionary<string, string> POSMappings = new Dictionary<string, string>();
        private string filledTemplate = string.Empty;

        public Template(string fileStream, string [] partsOfSpeech) {
            this.fileStream = fileStream;
            foreach (string part in partsOfSpeech)
                POSMappings.Add(part, "");
        }

        public string GetFileStream() {
            return fileStream;
        }
        
        public Dictionary<string, string> GetPOSMappings() {
            return POSMappings;
        }

        public void EnterPOS(string POS, string entry) {
            POSMappings.Add(POS, entry);
        }

        public override string ToString() {
            return fileStream;
        }
    }
}