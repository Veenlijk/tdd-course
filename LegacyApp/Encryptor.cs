using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp
{
    public class Encryptor
    {
        private static int EncryptCharValue(int charValue)
        {
            return charValue + 2;
        }

        private static void ValidateForSpaces(string word)
        {
            if (word.Contains(" "))
            {
                throw new ArgumentException();
            }
        }

        private static string Encrypt(string input, bool toChar)
        {
            char[] inputArray = input.ToCharArray();

            String output = String.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                int charValue = inputArray[i];

                int encryptedChar = EncryptCharValue(charValue);
                if (toChar)
                {
                    output += Convert.ToChar(encryptedChar);
                }
                else
                {
                    output += encryptedChar.ToString();
                }
            }

            return output;
        }

        public String Word(String word)
        {
            ValidateForSpaces(word);

            char[] wordArray = word.ToCharArray();

            String newWord = String.Empty;
            for (int index = 0; index < word.Length; index++)
            {
                int charValue = wordArray[index];
                newWord += Convert.ToChar(EncryptCharValue(charValue));
            }

            return newWord;
        }

        public String Word(String word, String charsToReplace)
        {
            ValidateForSpaces(word);

            char[] wordArray = word.ToCharArray();
            char[] replacement = charsToReplace.ToCharArray();
            char[] result = word.ToCharArray();

            for (int wordIndex = 0; wordIndex < wordArray.Length; wordIndex++)
            {
                for (int replaceIndex = 0; replaceIndex < replacement.Length; replaceIndex++)
                {
                    if (replacement[replaceIndex] == wordArray[wordIndex])
                    {
                        int charValue = wordArray[wordIndex];
                        result[wordIndex] = Convert.ToChar(EncryptCharValue(charValue));
                    }
                }
            }
            return String.Join("", result);
        }

        public String ToNumbers(String word)
        {
            ValidateForSpaces(word);

            string newWord = Encrypt(word, false);

            return newWord;
        }


        public String Sentence(String sentence)
        {
            String newWord = Encrypt(sentence, true);

            return newWord;
        }

        public String[] GetWords(String sentence)
        {
            return sentence.Split(' ');
        }

        public void PrintWords(String sentence)
        {
            String[] words = GetWords(sentence);
            foreach (String word in words)
            {
                Console.Write("<" + word + ">");
            }
        }
    }
}
