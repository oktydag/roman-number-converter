using System;
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

                    Numeric numeric = new Numeric(input);
                    Console.WriteLine(input.ToString() + " --> " + numeric.ToRoman() + "\n");

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