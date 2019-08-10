using System;
using FluentAssertions;
using NUnit.Framework;
using RomanNumberConverter.Console.Domain;

namespace RomanNumberConverter.Tests
{
    [TestFixture]
    public class NumbericTests
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
            var result = testNumber.ToRoman();

            result.Should().Equals(expected);
        }
        

        [TestCase("aasd", typeof(ArgumentException))]
        [TestCase("12a4", typeof(ArgumentException))]
        [TestCase("0o1s", typeof(ArgumentException))]
        public void When_Given_Number_Is_Not_Numeric_Then_Should_Throw_Exception(string number, Type expected)
        {
            Numeric testNumber = new Numeric(number);
            Action act = () => testNumber.ToRoman();

            act.Should().Throw<ArgumentException>();
        }


        [Test]
        public void When_Given_Number_Less_Then_Zero_Should_Throw_Exception()
        {
            Numeric testNumber = new Numeric("-100");

            Action act = () => testNumber.ToRoman();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }


    }
}