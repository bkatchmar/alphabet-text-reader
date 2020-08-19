using System;
using System.Collections.Generic;
using System.Text;

namespace alphabet_text_reader
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lets pretend there is some fancy dependency injector here or some design pattern like a factory class that generates this
            ITextCharacterCounter counter;

            /*
             * Requirement: Receives a string as command line argument
             * I take this as it is meant to only read 1 string. Since `args` is an array, this means control for only 1 argument
             */
            if (args.Length > 0)
            {
                string firstArgument = args[0];
                counter = new AlphabetCharacterCounter();
                OutputResult(firstArgument, counter);
            }
            else
            {
                Console.WriteLine("No Arguments Detected; Aborting Operation");
            }
        }

        /// <summary>
        /// I want to handle the output outside of the class as the class should only be used for processing.
        /// What if instead we output to an MVC app?
        /// </summary>
        static void OutputResult(string strToProcess, ITextCharacterCounter counter)
        {
            // Initial Variables
            IDictionary<char,int> processed = counter.ProcessString(strToProcess);
            var header = new StringBuilder("|");
            var dataRow = new StringBuilder("|");

            // Loop through the result of `processed` and build the output strings
            foreach (KeyValuePair<char,int> pair in processed) 
            {
                // Build the header for this record
                header.Append(pair.Key);
                header.Append("|");

                // Build the row for this record
                dataRow.Append(pair.Value);
                dataRow.Append("|");
            }

            // Output
            Console.WriteLine(header.ToString());
            Console.WriteLine(dataRow.ToString());

            // (Optional) After the tabulate is displayed, display the message
            Console.WriteLine($"The text has been processed. Total letters counted: {counter.TotalNumberOfLettersCounted}");
        }
    }

    /// <summary>Interface class for this exercise</summary>
    /// <remarks>Must be implemented in order to write a custom class solution.</remarks>
    interface ITextCharacterCounter
    {
        char[] CharactersToCount { get; }
        int TotalNumberOfLettersCounted { get; }
        IDictionary<char,int> ProcessString(string str);
    }

    /// <summary>Implementation of ITextCharacterCounter</summary>
    /// <remarks>Counts only alphabetical characters and disregards case.</remarks>
    class AlphabetCharacterCounter : ITextCharacterCounter
    {
        /// <summary>Class implementation definition of what characters to count</summary>
        public char[] CharactersToCount
        {
            get
            {
                return new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            }
        }

        /// <summary>Counter for how many characters have been counted</summary>
        public int TotalNumberOfLettersCounted { get; private set; }

        public AlphabetCharacterCounter()
        {
            this.TotalNumberOfLettersCounted = 0; // Default value
        }

        /// <summary>Returns a data structure for each character counted</summary>
        /// <param name="str">The string to process</param>
        public IDictionary<char, int> ProcessString(string str)
        {
            // This will be built up and eventually returned after the process is complete
            var rtnVal = new Dictionary<char, int>();

            // Initial setup
            foreach (char character in this.CharactersToCount) rtnVal.Add(character, 0);

            // It is not relevant for the counting if the letters are capitalized or not
            str = str.ToUpper();
            char[] lookup = str.ToCharArray();

            // Loop through char array and increment where a counter can be found
            foreach (char current in lookup)
            {
                if (rtnVal.ContainsKey(current))
                {
                    // Increment Dictionary
                    rtnVal[current]++;
                    // Increment Total Counter
                    this.TotalNumberOfLettersCounted++;
                }
            }

            return rtnVal;
        }
    }
}