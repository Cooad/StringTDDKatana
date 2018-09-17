using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator
{
    public class NegativeNumberException : Exception
    {
        public NegativeNumberException(double number) : base($"A negative number found in the sequence: {number}") { }
    }
}
