// Copyright (c) Adriano Ueda. All rights reserved.

namespace Maoli.Spellers
{
    using System.Text;

    /// <summary>
    /// Defines methods for a number speller.
    /// </summary>
    public sealed class NumberSpeller
        : INumberSpeller<int>, INumberSpeller<long>
    {
        private const string Conjunction = " e ";

        private const string SpecialName =
            "cem";

        private static readonly string[] OneNames =
            new string[]
            {
                "zero",
                "um",
                "dois",
                "três",
                "quatro",
                "cinco",
                "seis",
                "sete",
                "oito",
                "nove",
            };

        private static readonly string[] TenNames =
            new string[]
            {
                "dez",
                "vinte",
                "trinta",
                "quarenta",
                "cinquenta",
                "sessenta",
                "setenta",
                "oitenta",
                "noventa",
            };

        private static readonly string[] HundredNames =
            new string[]
            {
                "cento",
                "duzentos",
                "trezentos",
                "quatrocentos",
                "quinhentos",
                "seiscentos",
                "setecentos",
                "oitocentos",
                "novecentos",
            };

        private static readonly string[] AltTenNames =
            new string[]
            {
                "dez",
                "onze",
                "doze",
                "treze",
                "quatorze",
                "quinze",
                "dezesseis",
                "dezessete",
                "dezoito",
                "dezenove",
            };

        private static readonly string[] ThousandNames =
            new string[]
            {
                "mil",
                "milhão",
                "bilhão",
                "trilhão",
                "quatrilhão",
                "quintilhão",
            };

        private static readonly string[] PluralThousandNames =
            new string[]
            {
                "mil",
                "milhões",
                "bilhões",
                "trilhões",
                "quatrilhões",
                "quintilhões",
            };

        /// <summary>
        /// Returns the number spelled in Brazilian Portuguese.
        /// </summary>
        /// <param name="number">
        /// The number.
        /// </param>
        /// <returns>
        /// The number spelled.
        /// </returns>
        public string Spell(int number)
        {
            return this.Spell((long)number);
        }

        /// <summary>
        /// Returns the number spelled in Brazilian Portuguese.
        /// </summary>
        /// <param name="number">
        /// The number.
        /// </param>
        /// <returns>
        /// The number spelled.
        /// </returns>
        public string Spell(long number)
        {
            if (number == 0L)
            {
                return OneNames[number];
            }

            var sb = new StringBuilder();

            var partialNumber = number;
            var firstGroup = true;
            var requiresConjunction = false;
            var groupCount = 0;

            do
            {
                var numberClass = (int)(partialNumber % 1000);

                partialNumber /= 1000;

                if (numberClass > 0)
                {
                    if (firstGroup)
                    {
                        firstGroup = false;

                        if (numberClass <= 100 || numberClass % 100 <= 0)
                        {
                            requiresConjunction = true;
                        }
                    }

                    if (groupCount > 0)
                    {
                        var desc = numberClass > 1
                            ? PluralThousandNames[groupCount - 1]
                            : ThousandNames[groupCount - 1];

                        sb.Insert(0, desc);

                        sb.Insert(0, ' ');
                    }

                    if (groupCount != 1 || numberClass != 1)
                    {
                        sb.Insert(0, SpellValue(numberClass));
                    }

                    if (partialNumber > 0)
                    {
                        if (requiresConjunction)
                        {
                            sb.Insert(0, Conjunction);
                            requiresConjunction = false;
                        }
                        else
                        {
                            sb.Insert(0, ' ');
                        }
                    }
                }

                groupCount++;
            }
            while (partialNumber > 0);

            return sb
                .ToString()
                .Trim();
        }

        /// <summary>
        /// Returns the spell of last 3 digits of a number.
        /// </summary>
        /// <param name="value">
        /// The number.</param>
        /// <returns>
        /// The spell of the last 3 digits.
        /// </returns>
        private static string SpellValue(
            long value)
        {
            var sb = new StringBuilder();

            var digit3 = (int)(value % 10);
            var digit2 = (int)((value / 10) % 10);
            var digit1 = (int)((value / 100) % 10);

            WriteHundreds(
                sb,
                digit1,
                digit2,
                digit3);

            WriteTens(
                sb,
                digit2,
                digit3);

            WriteOnes(
                sb,
                digit2,
                digit3);

            return sb.ToString();
        }

        private static void WriteHundreds(
            StringBuilder sb,
            int digit1,
            int digit2,
            int digit3)
        {
            if (digit1 > 0)
            {
                if (digit1 == 1 && digit2 + digit3 == 0)
                {
                    sb.Append(SpecialName);
                }
                else
                {
                    sb.Append(HundredNames[digit1 - 1]);

                    if (digit2 + digit3 > 0)
                    {
                        sb.Append(Conjunction);
                    }
                }
            }
        }

        private static void WriteTens(
            StringBuilder sb,
            int digit2,
            int digit3)
        {
            if (digit2 == 1)
            {
                sb.Append(AltTenNames[digit3]);
            }
            else
            {
                if (digit2 > 0)
                {
                    sb.Append(TenNames[digit2 - 1]);

                    if (digit3 > 0)
                    {
                        sb.Append(Conjunction);
                    }
                }
            }
        }

        private static void WriteOnes(
            StringBuilder sb,
            int digit2,
            int digit3)
        {
            if (digit3 > 0 && digit2 != 1)
            {
                sb.Append(OneNames[digit3]);
            }
        }
    }
}