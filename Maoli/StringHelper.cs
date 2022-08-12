// Copyright (c) Adriano Ueda. All rights reserved.

namespace Maoli
{
    /// <summary>
    /// Helper class for string operations.
    /// </summary>
    internal static class StringHelper
    {
        /// <summary>
        /// Indicates whether a specified string is null, empty,
        /// or consists only of white-space characters.
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns>true, if null, empty or white-space characters;
        /// false, otherwise.</returns>
        internal static bool IsNullOrWhiteSpace(string value)
        {
#if NET20 || NET35
            return string.IsNullOrEmpty(value) ||
                (!string.IsNullOrEmpty(value) && value.Trim() == string.Empty);
#else
            return string.IsNullOrWhiteSpace(value);
#endif
        }

        /// <summary>
        /// Returns a string with only digits.
        /// </summary>
        /// <param name="value">
        /// a CNPJ string.
        /// </param>
        /// <param name="size">
        /// the output size.
        /// </param>
        /// <returns>
        /// a trimmed CNPJ string without punctuation.
        /// </returns>
        internal static string Sanitize(
            string value,
            int size)
        {
            var sanitizedValue = new char[size];

            for (int i = 0, index = 0; index < size && i < value.Length; i++)
            {
                var symbol = value[i];

                if (char.IsDigit(symbol))
                {
                    sanitizedValue[index++] = symbol;
                }
            }

            return new string(sanitizedValue);
        }
    }
}