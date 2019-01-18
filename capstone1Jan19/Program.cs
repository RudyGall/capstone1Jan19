using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace capstone1Jan19
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runP = true;
            string firstName = nameValid();
            Console.Clear();

            while (runP == true)
            {
                Console.WriteLine("{0}, Please enter a word or a sentence", firstName);
                string sentence = Console.ReadLine();
                string pigLatin = toPigLatin(sentence);
                Console.WriteLine(pigLatin);
                runP = Continue();
            }
        }
        private static string toPigLatin(string sentence)
        {
            const string vowels = "AEIOUaeio";
            List<string> pigLWords = new List<string>();
            foreach (string word in sentence.Split(' '))
            {         
                string firstLetter = word.Substring(0, 1);
                string restOfWord = word.Substring(1, word.Length - 1);
                int currentLetter = vowels.IndexOf(firstLetter);
                if (word.Contains("1") || word.Contains("2") || word.Contains("3") || word.Contains("4") || word.Contains("5") || word.Contains("6") 
                    || word.Contains("7") || word.Contains("8") || word.Contains("9") || word.Contains("!") || word.Contains("$") || word.Contains("@") 
                    || word.Contains("#") || word.Contains("%") || word.Contains("^") || word.Contains("&") || word.Contains("*"))
                {
                    pigLWords.Add(word);
                }
                else if (currentLetter == -1)
                {
                    pigLWords.Add(restOfWord + firstLetter + "ay");
                }
                else
                {
                    pigLWords.Add(word + "way");
                }
            }
            return string.Join(" ", pigLWords);
        }
        public static bool Continue()
        {
            Console.WriteLine("\nWould you like to run the application again? (Y or N)");
            string input = Console.ReadLine().ToLower();
            input = input.ToLower();
            bool goOn;
            if (input == "y")
            {
                goOn = true;
            }
            else if (input == "n")
            {
                Console.WriteLine("Thank you, Goodbye!");
                Console.ReadLine();
                goOn = false;
            }
            else
            {
                Console.WriteLine("I don't understand that, let's try again");
                goOn = Continue();
            }
            return goOn;
        }
        public static string nameValid()
        {
            bool responseValid = true;
            string firstName = "";
            while (responseValid)
            {
                Console.WriteLine("Please enter your first name");
                firstName = Console.ReadLine();

                if (!Regex.IsMatch(firstName, @"^[A-Z]+[A-z]{2,30}$"))
                {
                    Console.WriteLine("I'm sorry, this is not a valid name");
                }
                else
                {
                    Console.WriteLine("Name is valid");
                    break;
                }
            }
            return firstName;
        }
    }
}
