using System;
using System.Collections.Generic;

namespace PigLatin
{
    class Program
    {
        public static void Main(string[] args)
        {
        //stores user input into string sentence    
        Console.WriteLine("Enter a sentence to convert to PigLatin:");
        string sentence = Console.ReadLine();
        //takes translated sentence from ToPigLatin and then writes it into console
        string pigLatin = ToPigLatin(sentence);
        Console.WriteLine(pigLatin.ToLower());
        }

        //translates sentence
        static string ToPigLatin (string sentence)
        {
            //creates list of words that the translated words are added to                        
            List<string> latin = new List<string>();

            //splits user entered input
            foreach (string word in sentence.Split(' '))
            {
                //checks position each vowel and y
                int firstVowelIndex = word.IndexOfAny(new char[] {'A','E','I','O','U','a','e','i','o','u',});
                int firstYIndex = word.IndexOfAny(new char[] {'Y','y'});
                
                //checks if Y acts as vowel
                if ((firstYIndex > 0) && (firstYIndex < firstVowelIndex) && (word.ToLower().Contains("y")))
                {
                    string firstY = word.Substring(0, firstYIndex);
                    string restY = word.Substring(firstYIndex);                    
                    latin.Add(restY + firstY + "ay");
                }
                //checks if word contains normal vowel
                else if (firstVowelIndex > 0)
                {
                    string first = word.Substring(0, firstVowelIndex);
                    string rest = word.Substring(firstVowelIndex);
                    latin.Add(rest + first + "ay");                    
                }
                //checks if y acts as vowel in word with no other vowels
                else if (firstYIndex > 0)
                {
                    string firstY = word.Substring(0, firstYIndex);
                    string restY = word.Substring(firstYIndex);                    
                    latin.Add(restY + firstY + "ay");
                }
                //checks if word starts with vowel or contains only consonents
                else
                {
                    latin.Add(word + "yay");                        
                }                   
            }
            //joins translated words together        
            return string.Join(" ", latin);        
        }
    }
}