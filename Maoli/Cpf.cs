namespace Maoli
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a valid CPF number
    /// </summary>
    public class Cpf
    {
        private string rawValue;

        private string parsedValue;

        /// <summary>
        /// Gets the puntuaction setting
        /// </summary>
        public CpfPunctuation Punctuation { get; private set; }

        /// <summary>
        /// Initializes a new instance of Cpf
        /// </summary>
        /// <param name="value">a valid CPF string</param>
        public Cpf(string value)
            : this(value, CpfPunctuation.Loose)
        {
        }

        /// <summary>
        /// Initializes a new instance of Cpf
        /// </summary>
        /// <param name="value">a valid CPF string</param>
        /// <param name="puntuaction">the puntuaction setting configurating 
        /// how validation must be handled</param>
        public Cpf(string value, CpfPunctuation puntuaction)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O CPF não pode ser nulo ou branco");
            }

            if (!CpfHelper.Validate(value, puntuaction))
            {
                throw new ArgumentException("O CPF não é válido");
            }

            this.rawValue = value;
            this.parsedValue = CpfHelper.Sanitize(value);

            this.Punctuation = puntuaction;
        }

        public static Cpf Parse(string value)
        {
            return Cpf.Parse(value, CpfPunctuation.Loose);
        }

        public static Cpf Parse(string value, CpfPunctuation puntuaction)
        {
            return new Cpf(value, puntuaction);
        }

        public static bool TryParse(string value, out Cpf cpf)
        {
            return Cpf.TryParse(value, out cpf, CpfPunctuation.Loose);
        }

        public static bool TryParse(string value, out Cpf cpf, CpfPunctuation punctuation)
        {
            var parsed = false;

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

        public static bool IsValid(string value)
        {
            return CpfHelper.Validate(value, CpfPunctuation.Loose);
        }

        public static bool IsValid(string value, CpfPunctuation punctuation)
        {
            return CpfHelper.Validate(value, punctuation);
        }

        public static string Complete(string value)
        {
            return CpfHelper.Complete(value);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Cpf);
        }

        public bool Equals(Cpf cpf)
        {
            if (cpf == null)
            {
                return false;
            }

            return this.parsedValue == cpf.parsedValue;
        }

        public override int GetHashCode()
        {
            int hash = 17;

            unchecked
            {
                hash = hash * 31 + (string.IsNullOrWhiteSpace(this.parsedValue) ? 0 : this.parsedValue.GetHashCode());
            }

            return hash;
        }

        public override string ToString()
        {
            return this.parsedValue;
        }
    }
}
