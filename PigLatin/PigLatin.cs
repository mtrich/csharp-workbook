using System;
using System.Collections.Generic;

namespace PigLatin
{
    class Program
    {
        public static void Main(string[] args)
        {    
        Console.WriteLine("Enter a sentence to convert to PigLatin:");
        string sentence = Console.ReadLine();
        string pigLatin = ToPigLatin(sentence);
        Console.WriteLine(pigLatin.ToLower());
        }

        static string ToPigLatin (string sentence)
        {                        
            List<string> latin = new List<string>();

            //splits user entered input
            foreach (string word in sentence.Split(' '))
            {
                int firstVowelIndex = word.IndexOfAny(new char[] {'A','E','I','O','U','a','e','i','o','u',});
                int firstYIndex = word.IndexOfAny(new char[] {'Y','y'});
                string first = word.Substring(0, firstVowelIndex);
                string rest = word.Substring(firstVowelIndex);

                if ((firstYIndex > 0) && (firstYIndex < firstVowelIndex) && (word.ToLower().Contains("y")))
                {
                    string firstY = word.Substring(0, firstYIndex);
                    string restY = word.Substring(firstYIndex);                    
                    latin.Add(restY + firstY + "ay");
                }
                else if (firstVowelIndex > 0)
                {
                    latin.Add(rest + first + "ay");
                }
                else
                {
                    latin.Add(word + "yay");                        
                }                   
            }        
            return string.Join(" ", latin);        
        }
    }
}