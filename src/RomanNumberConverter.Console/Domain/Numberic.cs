using System;
using System.Collections.Generic;
using System.Linq;
using EnsureThat;

namespace RomanNumberConverter.Console.Domain
{
    public class Numeric
    {
        public string Number { get; private set; }

        public Numeric(string number)
        {
            ValidateGivenNumber(number);
            Number = number;
        }

        private static void ValidateGivenNumber(string number)
        {
            int convertedNumber = IsNumeric(number) ? Convert.ToInt32(number) : throw new ArgumentException("Given code should be number");

            Ensure.That(convertedNumber).IsGt(0);
            Ensure.That(convertedNumber).IsLt(3000);
        }

        private static bool IsNumeric(string checkedNumber)
        {
            int output;
            return int.TryParse(checkedNumber, out output);
        }
    }
}