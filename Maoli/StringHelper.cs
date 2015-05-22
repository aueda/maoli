//-----------------------------------------------------------------------
// <copyright file="StringHelper.cs" company="Adriano Ueda">
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
    /// Helper class for string operations
    /// </summary>
    internal static class StringHelper
    {
        /// <summary>
        /// Indicates whether a specified string is null, empty,
        /// or consists only of white-space characters.
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns>true, if null, empty or white-space characters;
        /// false, otherwise.</returns>
        public static bool IsNullOrWhiteSpace(string value)
        {
#if NET35
            return string.IsNullOrEmpty(value) ||
                (!string.IsNullOrEmpty(value) && value.Trim() == string.Empty);
#else
            return string.IsNullOrWhiteSpace(value);
#endif
        }
    }
}
