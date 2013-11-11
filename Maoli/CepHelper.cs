//-----------------------------------------------------------------------
// <copyright file="CepHelper.cs" company="Adriano Ueda">
//     Copyright (C) Adriano Ueda. All rights reserved.
// </copyright>
// <author>Adriano Ueda</author>
//-----------------------------------------------------------------------

namespace Maoli
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Helper class for <see cref="Cep"/> class
    /// </summary>
    internal static class CepHelper
    {
        /// <summary>
        /// Regex validations
        /// </summary>
        private static Dictionary<CepPunctuation, string> regexValidations;

        /// <summary>
        /// Initializes static members of the <see cref="CepHelper"/> class.
        /// </summary>
        static CepHelper()
        {
            CepHelper.regexValidations = new Dictionary<CepPunctuation, string>();

            CepHelper.regexValidations.Add(
                CepPunctuation.Loose,
                @"^(\d{5}\-\d{3}|\d{8})$");

            CepHelper.regexValidations.Add(
                CepPunctuation.Strict,
                @"^(\d{5}\-\d{3})$");
        }

        /// <summary>
        /// Checks if a string value is a valid CNPJ representation
        /// </summary>
        /// <param name="value">a CNPJ string to be checked</param>
        /// <param name="punctuation">the punctuation setting to 
        /// how validation must be handled</param>
        /// <returns>true if CNPJ string is valid; false otherwise</returns>
        internal static bool Validate(string value, CepPunctuation punctuation)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            if (!Regex.IsMatch(value, CepHelper.regexValidations[punctuation]))
            {
                return false;
            }

            return true;
        }
    }
}
