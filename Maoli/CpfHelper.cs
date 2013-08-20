namespace Maoli
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Helper class for <see cref="Cpf"/> class
    /// </summary>
    internal static class CpfHelper
    {
        private static Dictionary<CpfPunctuation, string> regexValidations;

        static CpfHelper()
        {
            CpfHelper.regexValidations = new Dictionary<CpfPunctuation, string>();

            CpfHelper.regexValidations.Add(
                CpfPunctuation.Loose,
                @"^(\d{3}\.\d{3}\.\d{3}\-\d{2})|(\d{11})$");

            CpfHelper.regexValidations.Add(
                CpfPunctuation.Strict,
                @"^\d{3}\.\d{3}\.\d{3}\-\d{2}$");
        }

        /// <summary>
        /// Checks if a string value is a valid CPF representation
        /// </summary>
        /// <param name="value">a CPF string to be checked</param>
        /// <param name="punctuation">the punctuation setting configurating 
        /// how validation must be handled</param>
        /// <returns>true if CPF string is valid; false otherwise</returns>
        internal static bool Validate(string value, CpfPunctuation punctuation)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            if (!Regex.IsMatch(value, CpfHelper.regexValidations[punctuation]))
            {
                return false;
            }

            value = CpfHelper.Sanitize(value);

            var inputDigit1 = Convert.ToInt32(value.Substring(9, 1));
            var inputDigit2 = Convert.ToInt32(value.Substring(10, 1));

            var calcDigit1 = CpfHelper.CreateChecksum(value.Substring(0, 9));
            var calcDigit2 = CpfHelper.CreateChecksum(value.Substring(0, 10));

            return inputDigit1 == calcDigit1 && inputDigit2 == calcDigit2;
        }

        /// <summary>
        /// Create a checksum digit
        /// </summary>
        /// <param name="text">the text to create the checksum</param>
        /// <returns>the checksum digit</returns>
        internal static int CreateChecksum(string text)
        {
            var sum = 0;
            var digit = 0;

            for (var i = text.Length - 1; i > -1; i--)
            {
                sum += Convert.ToInt32(text[i].ToString()) * (text.Length + 1 - i);
            }

            digit = 11 - (sum % 11);

            if (digit == 10 || digit == 11)
            {
                digit = 0;
            }

            return digit;
        }

        /// <summary>
        /// Removes punctuation and trim from a CPF string
        /// </summary>
        /// <param name="value">a CPF string</param>
        /// <returns>a trimmed CPF string without punctuation</returns>
        internal static string Sanitize(string value)
        {
            return value
                .Trim()
                .ToLowerInvariant()
                .Replace(".", string.Empty)
                .Replace("-", string.Empty);
        }

        /// <summary>
        /// Formats a CPF string using the punctuation setting
        /// </summary>
        /// <param name="value">a CPF string to format</param>
        /// <returns>A formated CPF string with or without punctuation</returns>
        internal static string Format(string value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Completes a partial CPF string by appending a valid checksum trailing
        /// </summary>
        /// <param name="value">a partial CPF string with or without punctuation</param>
        /// <returns>a CPF string with a valid checksum trailing</returns>
        internal static string Complete(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O CPF é inválido");
            }

            value = CpfHelper.Sanitize(value);

            if (!Regex.IsMatch(value, @"\d{9}"))
            {
                throw new ArgumentException("O CPF é inválido");
            }

            int digit1 = CpfHelper.CreateChecksum(value);
            int digit2 = CpfHelper.CreateChecksum(value + digit1.ToString());

            return value + digit1.ToString() + digit2.ToString();
        }
    }
}
