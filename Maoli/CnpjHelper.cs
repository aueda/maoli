// Copyright (c) Adriano Ueda. All rights reserved.

namespace Maoli
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Helper class for <see cref="Cnpj"/> class
    /// </summary>
    internal static class CnpjHelper
    {
        /// <summary>
        /// Regex validations
        /// </summary>
        private static Dictionary<CnpjPunctuation, string> regexValidations =
            new Dictionary<CnpjPunctuation, string>()
            {
                {
                    CnpjPunctuation.Loose,
                    @"^(\d{2}\.\d{3}\.\d{3}/\d{4}\-\d{2})|(\d{14})$"
                },
                {
                    CnpjPunctuation.Strict,
                    @"^\d{2}\.\d{3}\.\d{3}/\d{4}\-\d{2}$"
                }
            };

        /// <summary>
        /// Multipliers for the first check digit
        /// </summary>
        private static int[] multiplier1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        /// <summary>
        /// Multipliers for the second check digit
        /// </summary>
        private static int[] multiplier2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        /// <summary>
        /// Checks if a string value is a valid CNPJ representation
        /// </summary>
        /// <param name="value">a CNPJ string to be checked</param>
        /// <param name="punctuation">the punctuation setting to
        /// how validation must be handled</param>
        /// <returns>true if CNPJ string is valid; false otherwise</returns>
        internal static bool Validate(string value, CnpjPunctuation punctuation)
        {
            if (StringHelper.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            if (!Regex.IsMatch(value, CnpjHelper.regexValidations[punctuation]))
            {
                return false;
            }

            value = CnpjHelper.Sanitize(value);

            var inputDigit1 = int.Parse(value.Substring(12, 1));
            var inputDigit2 = int.Parse(value.Substring(13, 1));

            var calcDigit1 = CnpjHelper.CreateChecksum(value.Substring(0, 12), CnpjHelper.multiplier1);
            var calcDigit2 = CnpjHelper.CreateChecksum(value.Substring(0, 13), CnpjHelper.multiplier2);

            return inputDigit1 == calcDigit1 && inputDigit2 == calcDigit2;
        }

        /// <summary>
        /// Create a checksum digit
        /// </summary>
        /// <param name="text">the text to create the checksum</param>
        /// <param name="multiplier">the multipliers to create the checksum</param>
        /// <returns>the checksum digit</returns>
        internal static int CreateChecksum(string text, int[] multiplier)
        {
            var sum = 0;
            var digit = 0;
            var remainder = 0;

            for (var i = text.Length - 1; i > -1; i--)
            {
                sum += int.Parse(text[i].ToString()) * multiplier[i];
            }

            remainder = sum % 11;
            digit = (remainder < 2) ? 0 : 11 - remainder;

            return digit;
        }

        /// <summary>
        /// Removes punctuation and trim from a CNPJ string
        /// </summary>
        /// <param name="value">a CNPJ string</param>
        /// <returns>a trimmed CNPJ string without punctuation</returns>
        internal static string Sanitize(string value)
        {
            return value
                .Trim()
                .ToUpperInvariant()
                .Replace(".", string.Empty)
                .Replace("-", string.Empty)
                .Replace("/", string.Empty);
        }

        /// <summary>
        /// Completes a partial CNPJ string by appending a valid checksum trailing
        /// </summary>
        /// <param name="value">a partial CNPJ string with or without punctuation</param>
        /// <returns>a CNPJ string with a valid checksum trailing</returns>
        internal static string Complete(string value)
        {
            if (StringHelper.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O CNPJ é inválido");
            }

            value = CnpjHelper.Sanitize(value);

            if (!Regex.IsMatch(value, @"\d{9}"))
            {
                throw new ArgumentException("O CNPJ é inválido");
            }

            int digit1 = CnpjHelper.CreateChecksum(value, CnpjHelper.multiplier1);
            int digit2 = CnpjHelper.CreateChecksum(value + digit1.ToString(), CnpjHelper.multiplier2);

            return value + digit1.ToString() + digit2.ToString();
        }
    }
}
