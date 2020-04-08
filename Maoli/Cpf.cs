// Copyright (c) Adriano Ueda. All rights reserved.

namespace Maoli
{
    using System;
    using Maoli.V2;

    /// <summary>
    /// Represents a valid CPF number.
    /// </summary>
    public class Cpf
        : IEquatable<Cpf>
    {
        /// <summary>
        /// Stores the CPF number without punctuation.
        /// </summary>
        private readonly string parsedValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cpf"/> class.
        /// </summary>
        /// <param name="value">a valid CPF string.</param>
        public Cpf(string value)
            : this(value, CpfPunctuation.Loose)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cpf"/> class.
        /// </summary>
        /// <param name="value">a valid CPF string.</param>
        /// <param name="punctuation">the punctuation setting to
        /// how validation must be handled.</param>
        public Cpf(string value, CpfPunctuation punctuation)
        {
            if (StringHelper.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(
                    nameof(value),
                    Properties.Resources.CpfRequired);
            }

            if (!CpfHelper.Validate(value, punctuation))
            {
                throw new ArgumentException(
                    Properties.Resources.CpfInvalid,
                    nameof(value));
            }

            this.parsedValue = CpfHelper.Sanitize(value);

            this.Punctuation = punctuation;
        }

        /// <summary>
        /// Gets the punctuation setting.
        /// </summary>
        public CpfPunctuation Punctuation { get; private set; }

        /// <summary>
        /// Creates a new instance of <see cref="Cpf"/> from a CPF string.
        /// </summary>
        /// <param name="value">a CPF string.</param>
        /// <returns>the new instance of <see cref="Cpf"/>.</returns>
        public static Cpf Parse(string value)
        {
            return Cpf.Parse(value, CpfPunctuation.Loose);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Cpf"/> from a CPF string.
        /// </summary>
        /// <param name="value">a CPF string.</param>
        /// <param name="punctuation">the punctuation setting to
        /// how validation must be handled.</param>
        /// <returns>the new instance of <see cref="Cpf"/>.</returns>
        public static Cpf Parse(string value, CpfPunctuation punctuation)
        {
            return new Cpf(value, punctuation);
        }

        /// <summary>
        /// Tries to create a new instance of <see cref="Cpf"/> from a CPF string.
        /// </summary>
        /// <param name="value">a CPF string.</param>
        /// <param name="cpf">the new instance of <see cref="Cpf"/>.</param>
        /// <returns>true if CPF string is valid; false, otherwise.</returns>
        public static bool TryParse(string value, out Cpf cpf)
        {
            return Cpf.TryParse(value, out cpf, CpfPunctuation.Loose);
        }

        /// <summary>
        /// Tries to create a new instance of <see cref="Cpf"/> from a CPF string.
        /// </summary>
        /// <param name="value">a CPF string.</param>
        /// <param name="cpf">the new instance of <see cref="Cpf"/>.</param>
        /// <param name="punctuation">the punctuation setting to
        /// how validation must be handled.</param>
        /// <returns>true if CPF string is valid; false, otherwise.</returns>
        public static bool TryParse(string value, out Cpf cpf, CpfPunctuation punctuation)
        {
            bool parsed;

            try
            {
                cpf = new Cpf(value, punctuation);

                parsed = true;
            }
            catch (ArgumentException)
            {
                cpf = null;

                parsed = false;
            }

            return parsed;
        }

        /// <summary>
        /// Checks if a string value is a valid CPF representation.
        /// </summary>
        /// <param name="value">a CPF string to be checked.</param>
        /// <returns>true if CPF string is valid; false otherwise.</returns>
        public static bool Validate(string value)
        {
            return CpfHelper.Validate(value, CpfPunctuation.Loose);
        }

        /// <summary>
        /// Checks if a string value is a valid CPF representation.
        /// </summary>
        /// <param name="value">a CPF string to be checked.</param>
        /// <param name="punctuation">the punctuation setting to
        /// how validation must be handled.</param>
        /// <returns>true if CPF string is valid; otherwise, false.</returns>
        public static bool Validate(string value, CpfPunctuation punctuation)
        {
            return CpfHelper.Validate(value, punctuation);
        }

        /// <summary>
        /// Completes a partial CPF string by appending a valid checksum trailing.
        /// </summary>
        /// <param name="value">a partial CPF string
        /// with or without punctuation.</param>
        /// <returns>a CPF string with a valid checksum trailing.</returns>
        public static string Complete(string value)
        {
            return CpfHelper.Complete(value);
        }

        /// <summary>
        /// Determines whether this instance and a specified object,
        /// which must also be a <see cref="Cpf"/> object, have the same value.
        /// </summary>
        /// <param name="obj">The CPF to compare to this instance.</param>
        /// <returns>if the value of the value parameter is
        /// the same as this instance; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Cpf);
        }

        /// <summary>
        /// Determines whether this instance and another specified
        /// <see cref="Cpf"/> object have the same value.
        /// </summary>
        /// <param name="other">
        /// The other CPF to compare to this instance.
        /// </param>
        /// <returns>if the value of the value parameter is
        /// the same as this instance; otherwise, false.
        /// </returns>
        public bool Equals(Cpf other)
        {
            if (other == null)
            {
                return false;
            }

            return this.parsedValue == other.parsedValue;
        }

        /// <summary>
        /// Returns the hash code for this CPF.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            int hash = 17;

            unchecked
            {
                hash = (hash * 31) +
#if NETSTANDARD2_1
                    this.parsedValue.GetHashCode(
                        StringComparison.InvariantCultureIgnoreCase);
#else
                    this.parsedValue.GetHashCode();
#endif
            }

            return hash;
        }

        /// <summary>
        /// Converts the value of this instance to a
        /// <seealso cref="string"/>String.
        /// </summary>
        /// <returns>The CPF as string.</returns>
        public override string ToString()
        {
            return this.parsedValue;
        }
    }
}
