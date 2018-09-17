using System;
using Xunit;

namespace StringKatana
{
    public class StringCalculatorTest
    {
        private readonly StringCalculator.StringCalculator _stringCalculator;

        public StringCalculatorTest()
        {
            _stringCalculator = new StringCalculator.StringCalculator();
        }

        [Fact]
        public void Test1()
        {
            var input = "";
            var sum = _stringCalculator.Sum(input);
            Assert.Equal(0, sum);
        }
    }
}
