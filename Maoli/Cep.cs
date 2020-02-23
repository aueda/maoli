// Copyright (c) Adriano Ueda. All rights reserved.

namespace Maoli
{
    using System;

    /// <summary>
    /// Represents a valid CEP number.
    /// </summary>
    public class Cep
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cep"/> class.
        /// </summary>
        /// <param name="value">a valid CEP string.</param>
        public Cep(string value)
            : this(value, CepPunctuation.Loose)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cep"/> class.
        /// </summary>
        /// <param name="value">a valid CEP string.</param>
        /// <param name="punctuation">the punctuation setting to
        /// how validation must be handled.</param>
        public Cep(string value, CepPunctuation punctuation)
        {
            if (StringHelper.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O CEP não pode ser nulo ou branco");
            }

            if (!CepHelper.Validate(value, punctuation))
            {
                throw new ArgumentException("O CEP não é válido");
            }

            this.Punctuation = punctuation;
        }

        /// <summary>
        /// Gets the punctuation setting.
        /// </summary>
        public CepPunctuation Punctuation { get; private set; }

        /// <summary>
        /// Checks if a string value is a valid CEP representation.
        /// </summary>
        /// <param name="value">a CEP string to be checked.</param>
        /// <returns>true if CEP string is valid; false otherwise.</returns>
        public static bool Validate(string value)
        {
            return CepHelper.Validate(value, CepPunctuation.Loose);
        }

        /// <summary>
        /// Checks if a string value is a valid CEP representation.
        /// </summary>
        /// <param name="value">a CEP string to be checked.</param>
        /// <param name="punctuation">the punctuation setting to
        /// how validation must be handled.</param>
        /// <returns>true if CEP string is valid; otherwise, false.</returns>
        public static bool Validate(string value, CepPunctuation punctuation)
        {
            return CepHelper.Validate(value, punctuation);
        }
    }
}