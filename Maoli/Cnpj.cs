// Copyright (c) Adriano Ueda. All rights reserved.

namespace Maoli
{
    using System;
    using Maoli.V2;

    /// <summary>
    /// Represents a valid CNPJ number.
    /// </summary>
    public class Cnpj
        : IEquatable<Cnpj>
    {
        /// <summary>
        /// Stores the CNPJ number without punctuation.
        /// </summary>
        private readonly string parsedValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cnpj"/> class.
        /// </summary>
        /// <param name="value">a valid CNPJ string.</param>
        public Cnpj(string value)
            : this(value, CnpjPunctuation.Loose)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cnpj"/> class.
        /// </summary>
        /// <param name="value">a valid CNPJ string.</param>
        /// <param name="punctuation">the punctuation setting to
        /// how validation must be handled.</param>
        public Cnpj(string value, CnpjPunctuation punctuation)
        {
            if (StringHelper.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O CNPJ não pode ser nulo ou branco");
            }

            if (!CnpjHelper.Validate(value, punctuation))
            {
                throw new ArgumentException("O CNPJ não é válido");
            }

            this.parsedValue = CnpjHelper.Sanitize(value);

            this.Punctuation = punctuation;
        }

        /// <summary>
        /// Gets the punctuation setting.
        /// </summary>
        public CnpjPunctuation Punctuation { get; private set; }

        /// <summary>
        /// Creates a new instance of <see cref="Cnpj"/> from a CNPJ string.
        /// </summary>
        /// <param name="value">a CNPJ string.</param>
        /// <returns>the new instance of <see cref="Cnpj"/>.</returns>
        public static Cnpj Parse(string value)
        {
            return Cnpj.Parse(value, CnpjPunctuation.Loose);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Cnpj"/> from a CNPJ string.
        /// </summary>
        /// <param name="value">a CNPJ string.</param>
        /// <param name="punctuation">the punctuation setting to
        /// how validation must be handled.</param>
        /// <returns>the new instance of <see cref="Cnpj"/>.</returns>
        public static Cnpj Parse(string value, CnpjPunctuation punctuation)
        {
            return new Cnpj(value, punctuation);
        }

        /// <summary>
        /// Tries to create a new instance of <see cref="Cnpj"/> from a CNPJ string.
        /// </summary>
        /// <param name="value">a CNPJ string.</param>
        /// <param name="cnpj">the new instance of <see cref="Cnpj"/>.</param>
        /// <returns>true if CNPJ string is valid; false, otherwise.</returns>
        public static bool TryParse(string value, out Cnpj cnpj)
        {
            return Cnpj.TryParse(value, out cnpj, CnpjPunctuation.Loose);
        }

        /// <summary>
        /// Tries to create a new instance of <see cref="Cnpj"/> from a CNPJ string.
        /// </summary>
        /// <param name="value">a CNPJ string.</param>
        /// <param name="cnpj">the new instance of <see cref="Cnpj"/>.</param>
        /// <param name="punctuation">the punctuation setting to
        /// how validation must be handled.</param>
        /// <returns>true if CNPJ string is valid; false, otherwise.</returns>
        public static bool TryParse(
            string value,
            out Cnpj cnpj,
            CnpjPunctuation punctuation)
        {
            bool parsed;

            try
            {
                cnpj = new Cnpj(value, punctuation);

                parsed = true;
            }
            catch (ArgumentException)
            {
                cnpj = null;

                parsed = false;
            }

            return parsed;
        }

        /// <summary>
        /// Checks if a string value is a valid CNPJ representation.
        /// </summary>
        /// <param name="value">a CNPJ string to be checked.</param>
        /// <returns>true if CNPJ string is valid; false otherwise.</returns>
        public static bool Validate(string value)
        {
            return CnpjHelper.Validate(value, CnpjPunctuation.Loose);
        }

        /// <summary>
        /// Checks if a string value is a valid CNPJ representation.
        /// </summary>
        /// <param name="value">a CNPJ string to be checked.</param>
        /// <param name="punctuation">the punctuation setting to
        /// how validation must be handled.</param>
        /// <returns>true if CNPJ string is valid; otherwise, false.</returns>
        public static bool Validate(string value, CnpjPunctuation punctuation)
        {
            return CnpjHelper.Validate(value, punctuation);
        }

        /// <summary>
        /// Completes a partial CNPJ string by appending a valid checksum trailing.
        /// </summary>
        /// <param name="value">a partial CNPJ string with or without punctuation.</param>
        /// <returns>a CNPJ string with a valid checksum trailing.</returns>
        public static string Complete(string value)
        {
            return CnpjHelper.Complete(value);
        }

        /// <summary>
        /// Determines whether this instance and a specified object,
        /// which must also be a <see cref="Cnpj"/> object, have the same value.
        /// </summary>
        /// <param name="obj">The CNPJ to compare to this instance.</param>
        /// <returns>if the value of the value parameter is
        /// the same as this instance; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Cnpj);
        }

        /// <summary>
        /// Determines whether this instance and another
        /// specified <see cref="Cnpj"/> object have the same value.
        /// </summary>
        /// <param name="other">
        /// The other CNPJ to compare to this instance.
        /// </param>
        /// <returns>if the value of the value parameter is
        /// the same as this instance; otherwise, false.</returns>
        public bool Equals(Cnpj other)
        {
            if (other == null)
            {
                return false;
            }

            return this.parsedValue == other.parsedValue;
        }

        /// <summary>
        /// Returns the hash code for this CNPJ.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            int hash = 17;

            unchecked
            {
                hash = (hash * 31) +
#if NETSTANDARD2_1 || NET5_0
                    this.parsedValue.GetHashCode(
                        StringComparison.InvariantCultureIgnoreCase);
#else
                    this.parsedValue.GetHashCode();
#endif
            }

            return hash;
        }

        /// <summary>
        /// Converts the value of this instance to a <seealso cref="string"/>String.
        /// </summary>
        /// <returns>The CNPJ as string.</returns>
        public override string ToString()
        {
            return this.parsedValue;
        }
    }
}
