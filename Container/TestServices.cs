using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperSample.Container
{
    internal interface ITestFactorial
    {
        int Factorial(int n);
    }
    
    internal class TestFactorial : ITestFactorial
    {
        public int Factorial(int n)
        {
            Int64 constant = int.MaxValue;
            if (n <= 0) throw new ArgumentOutOfRangeException($"{n} must be greater than 0");
            Int64 factorial = n;
            for (int i = n - 1; i > 1; i--)
            {
                factorial = factorial * i;
                if (factorial > constant)
                    throw new ArgumentException($"{n}! results in a value too big for an integer");
            }
            return (int)factorial;
        }
    }
}
