using System;
using FluentAssertions;
using NUnit.Framework;
using RomanNumberConverter.Console.Domain;

namespace RomanNumberConverter.Tests
{
    [TestFixture]
    public class NumbericTests
    {

        [TestCase("aasd", typeof(ArgumentException))]
        [TestCase("12a4", typeof(ArgumentException))]
        [TestCase("0o1s", typeof(ArgumentException))]
        public void When_Given_Number_Is_Not_Numeric_Then_Should_Throw_Exception(string number, Type expected)
        {
            Action act = () => new Numeric(number);
            act.Should().Throw<ArgumentException>();
        }


        [Test]
        public void When_Given_Number_Less_Then_Zero_Should_Throw_Exception()
        {
            Action act = () => new Numeric("-100");

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void When_Given_Number_Greater_Then_3000_Should_Throw_Exception()
        {
            Action act = () => new Numeric("35001");

            act.Should().Throw<ArgumentOutOfRangeException>();
        }


    }
}