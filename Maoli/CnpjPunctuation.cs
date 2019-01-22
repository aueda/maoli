// Copyright (c) Adriano Ueda. All rights reserved.

namespace Maoli
{
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