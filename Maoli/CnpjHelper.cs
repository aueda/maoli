// Copyright (c) Adriano Ueda. All rights reserved.

namespace Maoli;

using System;
using System.Text;

/// <summary>
/// Helper class for <see cref="Cnpj"/> class.
/// </summary>
internal static class CnpjHelper
{
    /// <summary>
    /// Checks if a string value is a valid CNPJ representation.
    /// </summary>
    /// <param name="value">
    /// A CNPJ string to be checked.
    /// </param>
    /// <param name="punctuation">
    /// The punctuation setting to
    /// how validation must be handled.
    /// </param>
    /// <returns>
    /// true if CNPJ string is valid; Otherwise, false.
    /// </returns>
    internal static bool Validate(
#if NETSTANDARD2_1 || NET5_0_OR_GREATER
        ReadOnlySpan<char> value,
#else
        string value,
#endif
        CnpjPunctuation punctuation)
    {
        var isValid =
            punctuation == CnpjPunctuation.Strict
                ? value.Length == 18 &&
                    value[2] == '.' &&
                    value[6] == '.' &&
                    value[10] == '/' &&
                    value[15] == '-'
                : value.Length == 14 || value.Length == 18;

        if (!isValid)
        {
            return false;
        }

        var index1 = 0;
        var index2 = 0;

        var sum1 = 0;
        var sum2 = 0;

        for (var i = 0; i < value.Length; i++)
        {
            var symbol = value[i];

            if (symbol == '-' || symbol == '.' || symbol == '/')
            {
                continue;
            }

            if (!char.IsDigit(symbol))
            {
                return false;
            }

            if (index1 < 12)
            {
                sum1 += (symbol - 48) * ((index1 < 4 ? 5 : 13) - index1);
                index1++;
            }

            if (index2 < 13)
            {
                sum2 += (symbol - 48) * ((index2 < 5 ? 6 : 14) - index2);
                index2++;
            }
        }

        var lastDigit1 = value[value.Length - 2] - 48;
        var lastDigit2 = value[value.Length - 1] - 48;

        var checksum1 = sum1 % 11;

        checksum1 =
            checksum1 < 2
                ? 0
                : 11 - checksum1;

        var checksum2 = sum2 % 11;

        checksum2 =
            checksum2 < 2
                ? 0
                : 11 - checksum2;

        return
            checksum1 == lastDigit1 &&
            checksum2 == lastDigit2;
    }

    /// <summary>
    /// Completes a partial CNPJ string by appending
    /// a valid checksum trailing.
    /// </summary>
    /// <param name="value">a partial CNPJ string
    /// with or without punctuation.</param>
    /// <returns>
    /// a CNPJ string with a valid checksum trailing.
    /// </returns>
    internal static string Complete(
        string value)
    {
        if (StringHelper.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(
                "O CNPJ é inválido",
                nameof(value));
        }

        var isValid = value.Length == 12 || value.Length == 15;

        if (!isValid)
        {
            throw new ArgumentException(
                "O CNPJ é inválido",
                nameof(value));
        }

        var index1 = 0;
        var index2 = 0;

        var sum1 = 0;
        var sum2 = 0;

        var result = new char[14];

        var indexResult = 0;

        for (var i = 0; isValid && i < value.Length; i++)
        {
            var symbol = value[i];

            if (symbol == '-' || symbol == '.' || symbol == '/')
            {
                continue;
            }

            if (char.IsDigit(symbol))
            {
                result[indexResult++] = symbol;

                sum1 += (symbol - 48) * ((index1 < 4 ? 5 : 13) - index1);
                index1++;

                sum2 += (symbol - 48) * ((index2 < 5 ? 6 : 14) - index2);
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
            var checksum1 = sum1 % 11;
            checksum1 = checksum1 < 2 ? 0 : 11 - checksum1;

            sum2 += checksum1 * (14 - index2);

            var checksum2 = sum2 % 11;
            checksum2 = checksum2 < 2 ? 0 : 11 - checksum2;

            result[12] = (char)(checksum1 + 48);
            result[13] = (char)(checksum2 + 48);
        }
        else
        {
            throw new ArgumentException(
                "O CNPJ é inválido",
                nameof(value));
        }

        return new string(result);
    }
}