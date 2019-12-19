// Copyright (c) Adriano Ueda. All rights reserved.

namespace Maoli
{
    /// <summary>
    /// Indicates how punctuation must be validated.
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
        Strict = 1,
    }
}