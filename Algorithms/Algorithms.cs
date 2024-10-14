using System;
using System.Linq;
using System.Text;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
       
        /// <summary>
        /// Get factorial of a number. Only supports integers.
        /// </summary>
        /// <param name="n">Number to find Factorial of (n!)</param>
        /// <returns>Factorial value</returns>
        /// <exception cref="ArgumentOutOfRangeException">Must be a value > 0</exception>
        /// <exception cref="ArgumentException">Factorial is too large</exception>
        public static int GetFactorial(int n)
        {
            // TODO: This only supports 1-13. To support a larger value you would need to return Int64
            Int64 constant = int.MaxValue;
            if (n <= 0) throw new ArgumentOutOfRangeException($"{n} must be greater than 0");
            Int64 factorial = n;
            for (int i = n - 1; i > 1; i--)
            {
                // TODO: If rewritten to support Int64, thie line below should be modified so it throws an error
                // checked { factorial *= i; }
                factorial *= i;
            
                if (factorial > constant)
                    throw new ArgumentException($"{n}! results in a value too big for an integer ");
            }
            return (int)factorial;
        }

        /// <summary>
        /// Get a grammatically correct English list of items, not using the Oxford comma.
        /// See https://www.grammar-monster.com/lessons/commas_in_lists.htm for the general rules used
        /// </summary>
        /// <param name="items">Array of strings to be turned into a grammatically correct English list.</param>
        /// <returns>string of values correctly separated</returns>
        public static string FormatSeparators(params string[] items)
         {
            // TODO: This is a simple implementation. Possible improvements would include
            // 1. Determining if there are duplicates in the list and modifying the output so that sending in apple, bannana, cherry, apple would result in indicating 2 apples.
            //    This could be overly difficult if it required making sure that multiples are gramatically correct (i.e. 3 people when person is in the list mulitple times). 
            //    It might be better to throw an error if there were duplciates provided.
            // 2. Optional parameter to sort the results.
                if (items.Length == 0) return string.Empty;
                if (items.Length == 1) return items[0];
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < items.Length - 1; i++)
                {
                    sb.Append(items[i]);
                    if(i < items.Length - 2) sb.Append(", ");
                }
                sb.Append($" and {items[items.Length - 1]}");
                return sb.ToString();
            }
    }
}