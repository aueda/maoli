// Copyright (c) Adriano Ueda. All rights reserved.

namespace Maoli.V2
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Helper class for <see cref="Cpf"/> class.
    /// </summary>
    internal static class CpfHelper
    {
        /// <summary>
        /// Completes a partial CPF string by appending
        /// a valid checksum trailing.
        /// </summary>
        /// <param name="value">a partial CPF strin
        /// with or without punctuation.</param>
        /// <returns>a CPF string with a valid checksum trailing.</returns>
        internal static string Complete(string value)
        {
            if (StringHelper.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O CPF é inválido");
            }

            var isValid = value.Length == 9 || value.Length == 11;

            if (!isValid)
            {
                throw new ArgumentException("O CPF é inválido");
            }

            var index1 = 0;
            var index2 = 0;

            var sum1 = 0;
            var sum2 = 0;

            var result = new char[11];

            var indexResult = 0;

            for (var i = 0; isValid && i < value.Length; i++)
            {
                var symbol = value[i];

                if (symbol == '-' || symbol == '.')
                {
                    continue;
                }

                if (char.IsDigit(symbol))
                {
                    result[indexResult++] = symbol;

                    sum1 += (symbol - 48) * (10 - index1);
                    index1++;

                    sum2 += (symbol - 48) * (11 - index2);
                    index2++;

                    isValid = true;
                }
                else
                {
                    isValid = false;
                }
            }

            if (isValid)
            {
                var checksum1 = 11 - (sum1 % 11);

                checksum1 = checksum1 == 10 || checksum1 == 11
                    ? 0
                    : checksum1;

                sum2 += checksum1 * (11 - index2);

                var checksum2 = 11 - (sum2 % 11);

                checksum2 = checksum2 == 10 || checksum2 == 11
                    ? 0
                    : checksum2;

                result[9] = (char)(checksum1 + 48);
                result[10] = (char)(checksum2 + 48);
            }
            else
            {
                throw new ArgumentException("O CPF é inválido");
            }

            return new string(result);
        }

        /// <summary>
        /// Removes punctuation and trim from a CPF string.
        /// </summary>
        /// <param name="value">a CPF string.</param>
        /// <returns>a trimmed CPF string without punctuation.</returns>
        internal static string Sanitize(string value)
        {
            var sanitizedValue = new char[11];

            var index = 0;

            for (var i = 0; index < 11 && i < value.Length; i++)
            {
                var symbol = value[i];

                if (char.IsDigit(symbol))
                {
                    sanitizedValue[index++] = symbol;
                }
            }

            return new string(sanitizedValue);
        }

        /// <summary>
        /// Checks if a string value is a valid CPF representation.
        /// </summary>
        /// <param name="value">a CPF string to be checked.</param>
        /// <param name="punctuation">the punctuation setting to
        /// how validation must be handled.</param>
        /// <returns>true if CPF string is valid; false otherwise.</returns>
        internal static bool Validate(string value, CpfPunctuation punctuation)
        {
            var isValid = false;

            if (value == null)
            {
                return isValid;
            }

#if NETSTANDARD2_1 || NET5_0_OR_GREATER
            ReadOnlySpan<char> valueSpan =
                value.AsSpan();
#else
            var valueSpan =
                value;
#endif

            if (punctuation == CpfPunctuation.Strict)
            {
                isValid =
                    valueSpan.Length == 14 &&
                    valueSpan[3] == '.' &&
                    valueSpan[7] == '.' &&
                    valueSpan[11] == '-';
            }
            else
            {
                isValid = valueSpan.Length == 11 || valueSpan.Length == 14;
            }

            var index1 = 0;
            var index2 = 0;

            var sum1 = 0;
            var sum2 = 0;

            var sameDigits = true;

            char previousSymbol = ' ';

            for (var i = 0; isValid && i < valueSpan.Length; i++)
            {
                var symbol = valueSpan[i];

                if (symbol == '-' || symbol == '.')
                {
                    continue;
                }

                if (char.IsDigit(symbol))
                {
                    if (previousSymbol != ' ' &&
                        symbol != previousSymbol)
                    {
                        sameDigits = false;
                    }

                    previousSymbol = symbol;

                    if (index1 < 9)
                    {
                        sum1 += (symbol - 48) * (10 - index1);
                        index1++;
                    }

                    if (index2 < 10)
                    {
                        sum2 += (symbol - 48) * (11 - index2);
                        index2++;
                    }

                    isValid = true;
                }
                else
                {
                    isValid = false;
                }
            }

            isValid = isValid && !sameDigits;

            if (isValid)
            {
                var lastDigit1 = valueSpan[valueSpan.Length - 2] - 48;
                var lastDigit2 = valueSpan[valueSpan.Length - 1] - 48;

                var checksum1 = 11 - (sum1 % 11);

                checksum1 = checksum1 == 10 || checksum1 == 11
                    ? 0
                    : checksum1;

                var checksum2 = 11 - (sum2 % 11);

                checksum2 = checksum2 == 10 || checksum2 == 11
                    ? 0
                    : checksum2;

                isValid =
                    checksum1 == lastDigit1 &&
                    checksum2 == lastDigit2;
            }

            return isValid;
        }
    }
}