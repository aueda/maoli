namespace Maoli
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    internal static class CpfHelper
    {
        private static Dictionary<CpfPunctuation, string> regexValidations;

        static CpfHelper()
        {
            CpfHelper.regexValidations = new Dictionary<CpfPunctuation, string>();

            CpfHelper.regexValidations.Add(
                CpfPunctuation.Loose,
                @"^\d{3}\.?\d{3}\.?\d{3}\-?\d{2}$");

            CpfHelper.regexValidations.Add(
                CpfPunctuation.Strict,
                @"^\d{3}\.\d{3}\.\d{3}\-\d{2}$");
        }

        internal static bool Validate(string value, CpfPunctuation pontuaction)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            if (!Regex.IsMatch(value, CpfHelper.regexValidations[pontuaction]))
            {
                return false;
            }

            value = CpfHelper.Sanitize(value);

            var inputDigit1 = Convert.ToInt32(value.Substring(9, 1));
            var inputDigit2 = Convert.ToInt32(value.Substring(10, 1));

            var calcDigit1 = CpfHelper.CreateChecksum(value.Substring(0, 9));
            var calcDigit2 = CpfHelper.CreateChecksum(value.Substring(0, 10));

            return inputDigit1 == calcDigit1 && inputDigit2 == calcDigit2;
        }

        internal static int CreateChecksum(string text)
        {
            var i = 0;
            var sum = 0;
            var digit = 0;

            for (i = 0; i < text.Length; i++)
            {
                sum += Convert.ToInt32(text[i].ToString()) * (text.Length + 1 - i);
            }

            digit = 11 - (sum % 11);

            if (digit == 10 || digit == 11)
            {
                digit = 0;
            }

            return digit;
        }

        internal static string Sanitize(string value)
        {
            return value
                .Trim()
                .ToLowerInvariant()
                .Replace(".", string.Empty)
                .Replace("-", string.Empty);
        }

        internal static string Format(string value)
        {
            throw new NotImplementedException();
        }

        internal static string Complete(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O cpf é inválido");
            }

            value = CpfHelper.Sanitize(value);

            if (!Regex.IsMatch(value, @"\d{9}"))
            {
                throw new ArgumentException("O cpf é inválido");
            }

            int digit1 = CpfHelper.CreateChecksum(value);
            int digit2 = CpfHelper.CreateChecksum(value + digit1.ToString());

            return value + digit1.ToString() + digit2.ToString();
        }
    }
}
