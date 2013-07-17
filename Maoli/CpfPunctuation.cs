namespace Maoli
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Indicates how punctuation must be validated
    /// </summary>
    public enum CpfPunctuation
    {
        /// <summary>
        /// A valid CPF has or not punctuation
        /// </summary>
        Loose = 0,

        /// <summary>
        /// A valid CPF must have punctuation
        /// </summary>
        Strict = 1
    }
}