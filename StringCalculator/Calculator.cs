using System;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public double Sum(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;
            var numbers = input.Split(',').SelectMany(x => x.Split('\n')).Select(double.Parse);
            double sum = 0;
            foreach (var number in numbers)
            {
                if (number < 0)
                    throw new NegativeNumberException(number);
                if (number > 1000)
                    continue;
                sum += number;
            }

            return sum;
        }
    }
}