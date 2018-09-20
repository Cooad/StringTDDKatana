using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculator
{
    public static class Extensions
    {
        public static IEnumerable<string> SplitMany(this string input, IEnumerable<string> delimeters)
        {
            return new[] {input}.SplitMany(delimeters);
        }

        public static IEnumerable<string> SplitMany(this IEnumerable<string> input, IEnumerable<string> delimeters)
        {
            IEnumerable<string> result = new List<string>(input);
            foreach (var delimeter in delimeters)
            {
                result = result.SelectMany(x => x.Split(delimeter));
            }

            return result.Where(x => !string.IsNullOrWhiteSpace(x));
        }
    }
}