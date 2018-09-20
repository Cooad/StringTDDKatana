using System;
using StringCalculator;
using Xunit;

namespace StringKatana
{
    public class StringCalculatorTest
    {
        private readonly Calculator _stringCalculator;

        public StringCalculatorTest()
        {
            _stringCalculator = new Calculator();
        }

        [Fact]
        public void Should_return_zero_for_empty_string()
        {
            var input = "";
            var sum = _stringCalculator.Sum(input);
            Assert.Equal(0, sum);
        }

        [Fact]
        public void Single_number_return_value()
        {
            var input = "2";
            var sum = _stringCalculator.Sum(input);
            Assert.Equal(2, sum);
        }

        [Fact]
        public void Two_numbers_comma_return_sum()
        {
            var input = "2,3";
            var sum = _stringCalculator.Sum(input);
            Assert.Equal(5, sum);
        }

        [Fact]
        public void Two_numbers_new_line_return_sum()
        {
            var input = "2\n3";
            var sum = _stringCalculator.Sum(input);
            Assert.Equal(5, sum);
        }

        [Theory]
        [InlineData(6, "1,2,3")]
        [InlineData(6, "1\n2,3")]
        [InlineData(6, "1,2\n3")]
        [InlineData(6, "1\n2\n3")]
        public void Three_numbers_either_return_sum(double expected, string input)
        {
            var sum = _stringCalculator.Sum(input);
            Assert.Equal(expected, sum);
        }

        [Fact]
        public void Negative_numbers_throw_exception()
        {
            var input = "1,-2,3";
            Assert.Throws<NegativeNumberException>(() => _stringCalculator.Sum(input));
        }

        [Theory]
        [InlineData(1004, "1,1000,3")]
        [InlineData(1003, "1,999,3")]
        [InlineData(4, "1,1001,3")]
        public void Numbers_above_thousand_are_ignored(double expected, string input)
        {
            var sum = _stringCalculator.Sum(input);
            Assert.Equal(expected, sum);
        }

        [Theory]
        [InlineData(7, "1#4#2")]
        [InlineData(5, "1\n2#2")]
        public void First_line__single_character_delimiter(double expected, string inputNumbers)
        {
            var delimeter = "//#";
            var input = delimeter + "\n" + inputNumbers;
            var sum = _stringCalculator.Sum(input);
            Assert.Equal(expected,sum);
        }

        [Theory]
        [InlineData(7, "1##4##2")]
        [InlineData(5, "1\n2##2")]
        public void First_line_multiple_character_delimeter(double expected, string inputNumbers)
        {
            var delimeter = "//[##]";
            var input = delimeter + "\n" + inputNumbers;
            var sum = _stringCalculator.Sum(input);
            Assert.Equal(expected, sum);
        }

        [Theory]
        [InlineData(7,"1##4##2")]
        [InlineData(5,"1#1$1%%1*1")]
        public void First_line_multiple_delimeters(double expected, string inputNumbers)
        {
            var delimeter = "//[#],[##],[$],[%%],[*]";
            var input = delimeter + "\n" + inputNumbers;
            var sum = _stringCalculator.Sum(input);
            Assert.Equal(expected, sum);
        }
    }
}