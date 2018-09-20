using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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

            var delimeters = FindDelimeters(inputLines[0]);

            var stringNumbers = inputLines.Where(line => !line.StartsWith("//")).SelectMany(x => x.SplitMany(delimeters));
                var numbers = stringNumbers.Select(double.Parse);

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

        private string[] FindDelimeters(string delimeterLine)
        {
            if (!delimeterLine.StartsWith("//"))
                return new[] {","};

            var delimeters = new List<string>();

            if (delimeterLine.Contains('['))
            {
                var regex = new Regex(@"(?<=\[).+?(?=\])");
                foreach (Match match in regex.Matches(delimeterLine))
                {
                    delimeters.Add(match.Value);
                }

                return delimeters.ToArray();
            }

            return new[] {delimeterLine.Substring(2)};
        }
    }
}