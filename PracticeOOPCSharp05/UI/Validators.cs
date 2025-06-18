using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOPCSharp05.UI
{
    internal static class Validators
    {
        public static bool IntPositive(string input, out int result)
            => int.TryParse(input, out result) && result > 0;

        public static bool Year(string input, out int result)
            => int.TryParse(input, out result) && result > 1900 && result <= DateTime.Now.Year;

        public static bool DoublePositive(string input, out double result)
            => double.TryParse(input, out result) && result > 0;

        public static bool StringNotEmpty(string input, out string result)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                result = input;
                return true;
            }

            result = string.Empty;
            return false;
        }

        public static bool Enumeration<TEnum>(string input, out TEnum result) where TEnum : struct, Enum
            => Enum.TryParse(input, true, out result) && Enum.IsDefined(typeof(TEnum), result);

        public static bool Bool(string input, out bool result)
            => bool.TryParse(input, out result);

        public delegate bool TryValidateDelegate<T>(string input, out T result);
    }
}
