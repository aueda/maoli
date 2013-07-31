namespace Maoli
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a valid Cnpj number
    /// </summary>
    public class Cnpj
    {
        private string rawValue;

        private string parsedValue;

        /// <summary>
        /// Gets the punctuation setting
        /// </summary>
        public CnpjPunctuation Punctuation { get; private set; }

        /// <summary>
        /// Initializes a new instance of Cnpj
        /// </summary>
        /// <param name="value">a valid Cnpj string</param>
        public Cnpj(string value)
            : this(value, CnpjPunctuation.Loose)
        {
        }

        /// <summary>
        /// Initializes a new instance of Cnpj
        /// </summary>
        /// <param name="value">a valid Cnpj string</param>
        /// <param name="punctuation">the punctuation setting configurating 
        /// how validation must be handled</param>
        public Cnpj(string value, CnpjPunctuation punctuation)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O CNPJ não pode ser nulo ou branco");
            }

            if (!CnpjHelper.Validate(value, punctuation))
            {
                throw new ArgumentException("O CNPJ não é válido");
            }

            this.rawValue = value;
            this.parsedValue = CnpjHelper.Sanitize(value);

            this.Punctuation = punctuation;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Cnpj"/> from a Cnpj string
        /// </summary>
        /// <param name="value">a Cnpj string</param>
        /// <returns>the new instance of <see cref="Cnpj"/></returns>
        public static Cnpj Parse(string value)
        {
            return Cnpj.Parse(value, CnpjPunctuation.Loose);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Cnpj"/> from a Cnpj string
        /// </summary>
        /// <param name="value">a Cnpj string</param>
        /// <param name="punctuation">the punctuation setting configurating 
        /// how validation must be handled</param>
        /// <returns>the new instance of <see cref="Cnpj"/></returns>
        public static Cnpj Parse(string value, CnpjPunctuation punctuation)
        {
            return new Cnpj(value, punctuation);
        }

        /// <summary>
        /// Tries to create a new instance of <see cref="Cnpj"/> from a Cnpj string
        /// </summary>
        /// <param name="value">a Cnpj string</param>
        /// <param name="Cnpj">the new instance of <see cref="Cnpj"/></param>
        /// <returns>true if Cnpj string is valid; false, otherwise</returns>
        public static bool TryParse(string value, out Cnpj Cnpj)
        {
            return Cnpj.TryParse(value, out Cnpj, CnpjPunctuation.Loose);
        }

        /// <summary>
        /// Tries to create a new instance of <see cref="Cnpj"/> from a Cnpj string
        /// </summary>
        /// <param name="value">a Cnpj string</param>
        /// <param name="Cnpj">the new instance of <see cref="Cnpj"/></param>
        /// <param name="punctuation">the punctuation setting configurating 
        /// how validation must be handled</param>
        /// <returns>true if Cnpj string is valid; false, otherwise</returns>
        public static bool TryParse(string value, out Cnpj Cnpj, CnpjPunctuation punctuation)
        {
            var parsed = false;

            try
            {
                Cnpj = new Cnpj(value, punctuation);

                parsed = true;
            }
            catch (ArgumentException)
            {
                Cnpj = null;

                parsed = false;
            }

            return parsed;
        }

        /// <summary>
        /// Checks if a string value is a valid Cnpj representation
        /// </summary>
        /// <param name="value">a Cnpj string to be checked</param>
        /// <returns>true if Cnpj string is valid; false otherwise</returns>
        public static bool Validate(string value)
        {
            return CnpjHelper.Validate(value, CnpjPunctuation.Loose);
        }

        /// <summary>
        /// Checks if a string value is a valid Cnpj representation
        /// </summary>
        /// <param name="value">a Cnpj string to be checked</param>
        /// <param name="punctuation">the punctuation setting configurating 
        /// how validation must be handled</param>
        /// <returns>true if Cnpj string is valid; otherwise, false</returns>
        public static bool Validate(string value, CnpjPunctuation punctuation)
        {
            return CnpjHelper.Validate(value, punctuation);
        }

        /// <summary>
        /// Completes a partial Cnpj string by appending a valid checksum trailing
        /// </summary>
        /// <param name="value">a partial Cnpj string with or without punctuation</param>
        /// <returns>a Cnpj string with a valid checksum trailing</returns>
        public static string Complete(string value)
        {
            return CnpjHelper.Complete(value);
        }

        /// <summary>
        /// Determines whether this instance and a specified object, which must also be a <see cref="Cnpj"/> object, have the same value
        /// </summary>
        /// <param name="obj">The Cnpj to compare to this instance</param>
        /// <returns>if the value of the value parameter is the same as this instance; otherwise, false</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Cnpj);
        }

        /// <summary>
        /// Determines whether this instance and another specified <see cref="Cnpj"/> object have the same value
        /// </summary>
        /// <param name="Cnpj">The Cnpj to compare to this instance</param>
        /// <returns>if the value of the value parameter is the same as this instance; otherwise, false</returns>
        public bool Equals(Cnpj Cnpj)
        {
            if (Cnpj == null)
            {
                return false;
            }

            return this.parsedValue == Cnpj.parsedValue;
        }

        /// <summary>
        /// Returns the hash code for this Cnpj
        /// </summary>
        /// <returns>A 32-bit signed integer hash code</returns>
        public override int GetHashCode()
        {
            int hash = 17;

            unchecked
            {
                hash = hash * 31 + (string.IsNullOrWhiteSpace(this.parsedValue) ? 0 : this.parsedValue.GetHashCode());
            }

            return hash;
        }

        /// <summary>
        /// Converts the value of this instance to a <seealso cref="string"/>String.
        /// </summary>
        /// <returns>The Cnpj as string</returns>
        public override string ToString()
        {
            return this.parsedValue;
        }
    }
}
