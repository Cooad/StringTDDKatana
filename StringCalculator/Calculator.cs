using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class Calculator
    {
        public double Sum(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;
            var inputLines = input.Split('\n');

            var delimeter = ",";
            if (inputLines[0].StartsWith("//")) {
                if (inputLines[0].Contains('['))
                {
                    var regex = new Regex(@"(?<=\[).+?(?=\])");
                    delimeter = regex.Match(inputLines[0]).Value;
                }
                else 
                    delimeter = inputLines[0].Substring(2);
            }

            var numbers = inputLines.Where((_, i) => delimeter == "," || i > 0).SelectMany(x => x.Split(delimeter))
                .Select(double.Parse);

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