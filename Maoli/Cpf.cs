namespace Maoli.Docs
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
        public Cpf(string value)
            : this(value, CpfPunctuation.Loose)
        {
        }

        public Cpf(string value, CpfPunctuation pontuaction)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O CPF não pode ser nulo ou branco");
            }

            if (!CpfHelper.Validate(value, pontuaction))
            {
                throw new ArgumentException("O CPF não é válido");
            }
        }

        public static Cpf Parse(string value)
        {
            return Cpf.Parse(value, CpfPunctuation.Loose);
        }

        public static Cpf Parse(string value, CpfPunctuation pontuaction)
        {
            return new Cpf(value, pontuaction);
        }

        public static bool TryParse(string value, out Cpf cpf)
        {
            return Cpf.TryParse(value, CpfPunctuation.Loose, out cpf);
        }

        public static bool TryParse(string value, CpfPunctuation pontuaction, out Cpf cpf)
        {
            var parsed = false;

            try
            {
                cpf = new Cpf(value);
                
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

        public static string Complete(string value)
        {
            return CpfHelper.Complete(value);
        }
    }
}
