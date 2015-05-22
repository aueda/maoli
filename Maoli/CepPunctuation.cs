//-----------------------------------------------------------------------
// <copyright file="CepPunctuation.cs" company="Adriano Ueda">
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
    /// Indicates how punctuation must be validated
    /// </summary>
    public enum CepPunctuation
    {
        /// <summary>
        /// A valid CEP has or not punctuation
        /// </summary>
        Loose = 0,

        /// <summary>
        /// A valid CEP must have punctuation
        /// </summary>
        Strict = 1
    }
}