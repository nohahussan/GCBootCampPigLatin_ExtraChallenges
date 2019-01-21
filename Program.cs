using System;

namespace PIG_LATIN_ExChallenges
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Pig Latin Translator!\n");
            Boolean repeat = true;
            do
            {
                Console.WriteLine("Enter a line to be translated:");
                string userInput = Console.ReadLine();//keep the case of the word
                string pigLatin = ConverterToPigLatin(userInput);
                Console.WriteLine(pigLatin);
                repeat = Continue(repeat);//cheek if the user would like to continue
            } while (repeat);

        }
            public static string ConverterToPigLatin(string sentence)
            {
                string finalSentence = "";
                //if the sentence begins with white space trim it
                sentence = sentence.TrimStart(' ');
                string[] words = sentence.Split(' ');//store word by word in an array
                for (int i = 0; i < words.Length; i++)
                {
                    string firstLetter = words[i].Substring(0, 1);//first letter in each word
                                                                  //if a word starts with vowel add way to the end
                    if (firstLetter == "a" || firstLetter == "A" || firstLetter == "e" || firstLetter == "E" || firstLetter == "i" || firstLetter == "I" || firstLetter == "o" || firstLetter == "O" || firstLetter == "u" || firstLetter == "U")
                    {
                        words[i] += "way";
                    }
                    //if the word starts with consonant,move all of consonants that appear before the firstvowel to the end of the word,
                    //then add ay to the end
                    else
                    {
                        //Don't transelate words that has numbers 
                        int number;
                        Boolean Numbers = int.TryParse(words[i], out number);
                        if (Numbers == true) //store words that have numbers without translating it
                        {
                            words[i] = words[i];
                        }
                        else
                        {
                            //if a string contain symbols like @, . remain the same without translating it
                            if (words[i].Contains("@") || words[i].Contains("."))
                            {
                                words[i] = words[i];
                            }
                            else
                            {
                                char[] chars = { 'a', 'e', 'i', 'o', 'u' };
                                int indexOfFirstVowel = words[i].IndexOfAny(chars, 0);
                                string consonants = words[i].Substring(0, indexOfFirstVowel);//store first letters before first vowel appear
                                int lenAfterFirstVoewl = words[i].Length - consonants.Length;
                                words[i] = words[i].Substring(indexOfFirstVowel, lenAfterFirstVoewl) + consonants + "ay";
                            }
                        }
                    }
                }
                    for (int i = 0; i < words.Length; i++) //Pig Latin sentence
                {
                    finalSentence += words[i] + " ";
                }
                return finalSentence;
            }

            public static Boolean Continue(Boolean repeat)
            {
                Console.WriteLine("Translate another line?(y/n)");
                string userChoice = Console.ReadLine().ToLower();
                repeat = (userChoice == "y") ? true : false;
                return repeat;
            }

        
    }
}
