// Copyright (c) Adriano Ueda. All rights reserved.

namespace Maoli.Spellers
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Defines methods for a number speller.
    /// </summary>
    /// <typeparam name="TNumber">
    /// The type of the number.
    /// </typeparam>
    internal interface INumberSpeller<in TNumber>
    {
        /// <summary>
        /// Returns the number spelled.
        /// </summary>
        /// <param name="number">
        /// The number.
        /// </param>
        /// <returns>
        /// The number spelled.
        /// </returns>
        string Spell(
#if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            [NotNull] TNumber number);
#else
            TNumber number);
#endif
    }
}
