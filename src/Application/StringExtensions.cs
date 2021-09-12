using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Products.Application
{
    public static class StringExtensions
    {
        public static readonly int TheLengthOfSgtin96String = 24;

        public static bool IsAlphanumeric(this string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("String value to be checked can't be null");
            }

            return Regex.IsMatch(value, "^[a-zA-Z0-9]*$");
        }

        public static bool IsHex(this string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("String value to be checked can't be null");
            }
            if (value == string.Empty)
            {
                throw new ArgumentException("String value to be checked can't be empty");
            }

            return value.All(c => Uri.IsHexDigit(c));
        }

        public static bool IsValidSgtin96Format(this string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("String value to be checked can't be null");
            }

            return value.Length == TheLengthOfSgtin96String && value.IsHex();
        }
    }
}
