//-----------------------------------------------------------------------
// <copyright file="Cep.cs" company="Adriano Ueda">
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
