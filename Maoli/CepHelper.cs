// Copyright (c) Adriano Ueda. All rights reserved.

namespace Maoli
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Helper class for <see cref="Cep"/> class.
    /// </summary>
    internal static class CepHelper
    {
        /// <summary>
        /// Regex validations.
        /// </summary>
        private static readonly Dictionary<CepPunctuation, string> RegexValidations =
            new ()
            {
                {
                    CepPunctuation.Loose,
                    @"^(\d{5}\-\d{3}|\d{8})$"
                },
                {
                    CepPunctuation.Strict,
                    @"^(\d{5}\-\d{3})$"
                },
            };

        /// <summary>
        /// Checks if a string value is a valid CNPJ representation.
        /// </summary>
        /// <param name="value">a CNPJ string to be checked.</param>
        /// <param name="punctuation">the punctuation setting to
        /// how validation must be handled.</param>
        /// <returns>true if CNPJ string is valid; false otherwise.</returns>
        internal static bool Validate(
            string value,
            CepPunctuation punctuation)
        {
            if (StringHelper.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            if (!Regex.IsMatch(
                value,
                CepHelper.RegexValidations[punctuation],
                RegexOptions.None,
                TimeSpan.FromSeconds(1)))
            {
                return false;
            }

            return true;
        }
    }
}