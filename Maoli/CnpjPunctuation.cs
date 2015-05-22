//-----------------------------------------------------------------------
// <copyright file="CnpjPunctuation.cs" company="Adriano Ueda">
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
    public enum CnpjPunctuation
    {
        /// <summary>
        /// A valid CNPJ has or not punctuation
        /// </summary>
        Loose = 0,

        /// <summary>
        /// A valid CNPJ must have punctuation
        /// </summary>
        Strict = 1
    }
}