using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp
{
    class Program
    {
        /// <summary>
        /// This is the main method of the application.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Encryptor encryptor = new Encryptor();

            if (args.Length == 0)
            {
                throw new ArgumentException();
            }
            if (args.Length == 1)
            {
                Console.WriteLine(encryptor.Word(args[0]));
            }
            if (args.Length >= 2)
            {
                if (args[0].Equals("-n"))
                {
                    Console.WriteLine(encryptor.ToNumbers(args[1]));
                }
                else
                {
                    Console.WriteLine(encryptor.Sentence(String.Join(" ", args)));
                }
            }
        }
    }
}
