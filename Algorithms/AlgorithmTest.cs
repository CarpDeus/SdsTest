using System;
using Xunit;

namespace DeveloperSample.Algorithms
{
    public class AlgorithmTest
    {
        /// <summary>
        /// Validate that the factorial of 4 is 24
        /// </summary>
        [Fact]
        public void CanGetFactorial()
        {
            Assert.Equal(24, Algorithms.GetFactorial(4));
        }

        /// <summary>
        /// Validate Factorial Arguments won't accept 0
        /// </summary>
        [Fact]
        public void CannotGetFactorial0()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Algorithms.GetFactorial(0));
        }

        /// <summary>
        /// Validate Factorial Arguments won't accept negative numbers
        /// </summary>
        [Fact]
        public void CannotGetFactorialNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Algorithms.GetFactorial(-1));
        }

        /// <summary>
        /// Validate Factorial errors when generating a number too large for an int
        /// </summary>
        [Fact]
        public void CannotGetFactorialOverflow()
        {
            Assert.Throws<ArgumentException>(() => Algorithms.GetFactorial(300));
        }


        /// <summary>
        /// Validate formatting a list of items
        /// </summary>
        [Fact]
        public void CanFormatSeparators()
        {
            Assert.Equal("a, b and c", Algorithms.FormatSeparators("a", "b", "c"));
        }

        /// <summary>
        /// Validate formatting a list of two items
        /// </summary>
        [Fact]
        public void CanFormatTwoSeparators()
        {
            Assert.Equal("a and b", Algorithms.FormatSeparators("a", "b"));
        }

        /// <summary>
        /// Validate formatting a single item
        /// </summary>
        [Fact]
        public void CanFormatSingleSeparator()
        {
            Assert.Equal("a", Algorithms.FormatSeparators("a"));
        }

        /// <summary>
        /// Validate formatting no items
        /// </summary>
        [Fact]
        public void CannotFormatNoValues()
        {
            Assert.Equal("", Algorithms.FormatSeparators());
        }
    }
}