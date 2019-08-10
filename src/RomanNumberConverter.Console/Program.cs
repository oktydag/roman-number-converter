using System;
using RomanNumberConverter.Console.ApplicationServices;
using RomanNumberConverter.Console.Domain;

namespace RomanConsoleApp
{
    public class RomanNumberConverter
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\n Enter a number");
                    string input = Console.ReadLine();

                    //Domain
                    Numeric numeric = new Numeric(input);

                    //ApplicationService
                    RomanConverter romanConverter = new RomanConverter();

                    // UserInterface
                    Console.WriteLine(input.ToString() + " --> " + romanConverter.ToRoman(numeric.Number) + "\n");

                    SeperateEachResult();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message} ");
                }
            }
        }

        private static void SeperateEachResult()
        {
            Console.WriteLine("\n **************************************");
        }
    }
}