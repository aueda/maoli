// Copyright (c) Adriano Ueda. All rights reserved.

namespace Maoli.Spellers
{
    /// <summary>
    /// Defines methods for a number speller.
    /// </summary>
    /// <typeparam name="TNumber">
    /// The type of the number.
    /// </typeparam>
    public interface INumberSpeller<TNumber>
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
        string Spell(TNumber number);
    }
}
