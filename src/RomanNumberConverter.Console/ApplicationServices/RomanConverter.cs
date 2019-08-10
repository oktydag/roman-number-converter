using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumberConverter.Console.ApplicationServices
{
    public class RomanConverter : IRomanConverter
    {
        private readonly string _number;

        public RomanConverter()
        {
           
        }

        public string ToRoman(string number)
        {
            return InternalOfConverterRoman(Convert.ToInt32(number));
        }

        private static string InternalOfConverterRoman(int number)
        {
            Dictionary<string, int> valueOfRomanNumbers = new Dictionary<string, int>()
            {
                {"M", 1000},
                {"CM", 900},
                {"D", 500},
                {"CD", 400},
                {"C", 100},
                {"XC", 90},
                {"L", 50},
                {"XL", 40},
                {"X", 10},
                {"IX", 9},
                {"V", 5},
                {"IV", 4},
                {"I", 1},
            };

            string resultRomanNumber = string.Empty;

            for (int i = 0; number > 0; i++)
            {
                while (valueOfRomanNumbers.ElementAt(i).Value <= number)
                {
                    resultRomanNumber += valueOfRomanNumbers.ElementAt(i).Key;
                    number -= valueOfRomanNumbers.ElementAt(i).Value;
                }
            }
            return resultRomanNumber;
        }
    }
}
