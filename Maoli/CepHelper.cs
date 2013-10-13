namespace Maoli
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    internal static class CepHelper
    {
        private static Dictionary<CepPunctuation, string> regexValidations;

        static CepHelper()
        {
            CepHelper.regexValidations = new Dictionary<CepPunctuation, string>();

            CepHelper.regexValidations.Add(
                CepPunctuation.Loose,
                @"^(\d{5}\-\d{3})|(\d{5})$");

            CepHelper.regexValidations.Add(
                CepPunctuation.Strict,
                @"^(\d{5}\-\d{3})$");
        }

        /// <summary>
        /// Checks if a string value is a valid CNPJ representation
        /// </summary>
        /// <param name="value">a CNPJ string to be checked</param>
        /// <param name="punctuation">the punctuation setting configurating 
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
