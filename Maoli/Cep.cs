// Copyright (c) Adriano Ueda. All rights reserved.

namespace Maoli
{
    /// <summary>
    /// Represents a valid CEP number
    /// </summary>
    public class Cep
    {
        /// <summary>
        /// Checks if a string value is a valid CEP representation
        /// </summary>
        /// <param name="value">a CEP string to be checked</param>
        /// <returns>true if CEP string is valid; false otherwise</returns>
        public static bool Validate(string value)
        {
            return CepHelper.Validate(value, CepPunctuation.Loose);
        }

        /// <summary>
        /// Checks if a string value is a valid CEP representation
        /// </summary>
        /// <param name="value">a CEP string to be checked</param>
        /// <param name="punctuation">the punctuation setting to
        /// how validation must be handled</param>
        /// <returns>true if CEP string is valid; otherwise, false</returns>
        public static bool Validate(string value, CepPunctuation punctuation)
        {
            return CepHelper.Validate(value, punctuation);
        }
    }
}
