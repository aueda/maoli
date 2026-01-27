// Copyright (c) Adriano Ueda. All rights reserved.

namespace Maoli;

using System;

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
            throw new ArgumentException("CPF cannot be null or empty.", nameof(value));
        }

        if (value.Length != 9 && value.Length != 11)
        {
            throw new ArgumentException("CPF must have 9 or 11 digits.", nameof(value));
        }

        var digits = new char[11];
        int sumForFirstDigit = 0, sumForSecondDigit = 0, digitCount = 0;

        foreach (var symbol in value)
        {
            if (char.IsDigit(symbol))
            {
                digits[digitCount] = symbol;
                int numericValue = symbol - '0';

                if (digitCount < 9)
                {
                    sumForFirstDigit += numericValue * (10 - digitCount);
                }

                sumForSecondDigit += numericValue * (11 - digitCount);
                digitCount++;
            }
            else
            {
                if (symbol != '.' && symbol != '-')
                {
                    throw new ArgumentException(
                        "CPF contains invalid characters.",
                        nameof(value));
                }
            }
        }

        if (digitCount < 9)
        {
            throw new ArgumentException(
                "CPF must have at least 9 digits.",
                nameof(value));
        }

        digits[9] = CalculateChecksum(sumForFirstDigit);

        sumForSecondDigit += (digits[9] - '0') * 2;

        digits[10] = CalculateChecksum(sumForSecondDigit);

        return new string(digits);
    }

    /// <summary>
    /// Checks if a string value is a valid CPF representation.
    /// </summary>
    /// <param name="valueSpan">
    /// A CPF string to be checked.
    /// </param>
    /// <param name="punctuation">
    /// The punctuation setting to
    /// how validation must be handled.
    /// </param>
    /// <returns>
    /// true if CPF string is valid;
    /// Otherwise, false.
    /// </returns>
    internal static bool Validate(
#if NETSTANDARD2_1 || NET5_0_OR_GREATER
        ReadOnlySpan<char> valueSpan,
#else
        string valueSpan,
#endif
        CpfPunctuation punctuation)
    {
        if (!IsValidLength(valueSpan, punctuation))
        {
            return false;
        }

        int sumForFirstDigit = 0, sumForSecondDigit = 0, digitCount = 0;
        bool allDigitsAreSame = true;
        char? previousDigit = null;

        foreach (var symbol in valueSpan)
        {
            if (char.IsDigit(symbol))
            {
                int numericValue = symbol - '0';

                if (previousDigit.HasValue && numericValue != previousDigit.Value - '0')
                {
                    allDigitsAreSame = false;
                }

                previousDigit = symbol;

                if (digitCount < 9)
                {
                    sumForFirstDigit += numericValue * (10 - digitCount);
                }

                if (digitCount < 10)
                {
                    sumForSecondDigit += numericValue * (11 - digitCount);
                }

                digitCount++;
            }
            else
            {
                if (symbol != '.' && symbol != '-')
                {
                    return false;
                }
            }
        }

        if (allDigitsAreSame || digitCount < 11)
        {
            return false;
        }

        char expectedFirstChecksum =
            CalculateChecksum(sumForFirstDigit);

        char expectedSecondChecksum =
            CalculateChecksum(sumForSecondDigit + ((expectedFirstChecksum - '0') * 2));

#if NETSTANDARD2_1 || NET5_0_OR_GREATER
        return valueSpan[^2] == expectedFirstChecksum && valueSpan[^1] == expectedSecondChecksum;
#else
        return valueSpan[valueSpan.Length - 2] == expectedFirstChecksum && valueSpan[valueSpan.Length - 1] == expectedSecondChecksum;
#endif
    }

    private static bool IsValidLength(
#if NETSTANDARD2_1 || NET5_0_OR_GREATER
        ReadOnlySpan<char> valueSpan,
#else
        string valueSpan,
#endif
        CpfPunctuation punctuation)
    {
        return punctuation == CpfPunctuation.Strict
            ? valueSpan.Length == 14 && valueSpan[3] == '.' && valueSpan[7] == '.' && valueSpan[11] == '-'
            : valueSpan.Length == 11 || valueSpan.Length == 14;
    }

    private static char CalculateChecksum(int sum)
    {
        int remainder = sum % 11;
        return (char)((remainder < 2 ? 0 : 11 - remainder) + '0');
    }
}