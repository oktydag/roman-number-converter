using System;
using FluentAssertions;
using NUnit.Framework;
using RomanNumberConverter.Console.ApplicationServices;
using RomanNumberConverter.Console.Domain;

namespace RomanNumberConverter.Tests.ApplicationServices
{
    [TestFixture]
    public class RomanConverterTests
    {
        [TestCase("10", "X")]
        [TestCase("4", "IV")]
        [TestCase("11", "XI")]
        [TestCase("89", "LXXXIX")]
        [TestCase("456", "CDLVI")]
        [TestCase("990", "CMXC")]
        [TestCase("1244", "MCCXLIV")]
        [TestCase("2999", "MMCMXCIX")]
        public void When_Number_Is_Given_Should_Return_Roman_Number(string number, string expected)
        {
            Numeric testNumber = new Numeric(number);
            RomanConverter romanConverter = new RomanConverter();

            var convertedValue = romanConverter.ToRoman(testNumber.Number);

            convertedValue.Should().BeEquivalentTo(expected);
        }
    }
}
