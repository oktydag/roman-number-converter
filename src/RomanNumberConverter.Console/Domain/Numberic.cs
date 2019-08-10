using System;
using System.Collections.Generic;
using System.Linq;
using EnsureThat;

namespace RomanNumberConverter.Console.Domain
{
    public class Numeric
    {
        private string _value;

        public Numeric(string number)
        {
            this._value = number;

        }

        public string ToRoman()
        {
            return InternalOfConverterRoman(_value);
        }

        private static string InternalOfConverterRoman(string number)
        {
           int convertedNumber =  ValidateGivenNumber(number);

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

            for (int i = 0; convertedNumber > 0; i++)
            {
                while (valueOfRomanNumbers.ElementAt(i).Value <= convertedNumber)
                {
                    resultRomanNumber += valueOfRomanNumbers.ElementAt(i).Key;
                    convertedNumber -= valueOfRomanNumbers.ElementAt(i).Value;
                }
            }
            return resultRomanNumber;
        }

        private static int ValidateGivenNumber(string number)
        {
            int convertedNumber = IsNumeric(number) ? Convert.ToInt32(number) : throw new ArgumentException("Given code should be number");

            Ensure.That(convertedNumber).IsGt(0);
            Ensure.That(convertedNumber).IsLt(3000);

            return convertedNumber;
        }

        private static bool IsNumeric(string checkedNumber)
        {
            int output;
            return int.TryParse(checkedNumber, out output);
        }
    }
}