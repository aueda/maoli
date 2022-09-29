// Copyright (c) Adriano Ueda. All rights reserved.

namespace Maoli.Spellers
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
#if !NET5_0_OR_GREATER
    using System.Text;
#endif

    /// <summary>
    /// Defines methods for a number speller.
    /// </summary>
    public sealed class NumberSpeller
        : INumberSpeller<int>, INumberSpeller<long>
    {
#if !NET5_0_OR_GREATER
        private const string Conjunction = " e ";

        private const string SpecialName =
            "cem";
#endif

        private const string Names =
            " e " +
            "zero" +
            "um" +
            "dois" +
            "três" +
            "quatro" +
            "cinco" +
            "seis" +
            "sete" +
            "oito" +
            "nove" +
            "dez" +
            "onze" +
            "doze" +
            "treze" +
            "quatorze" +
            "quinze" +
            "dezesseis" +
            "dezessete" +
            "dezoito" +
            "dezenove" +
            "vinte" +
            "trinta" +
            "quarenta" +
            "cinquenta" +
            "sessenta" +
            "setenta" +
            "oitenta" +
            "noventa" +
            "cem" +
            "cento" +
            "duzentos" +
            "trezentos" +
            "quatrocentos" +
            "quinhentos" +
            "seiscentos" +
            "setecentos" +
            "oitocentos" +
            "novecentos" +
            "mil" +
            "milhão" +
            "bilhão" +
            "trilhão" +
            "quatrilhão" +
            "quintilhão" +
            "mil" +
            "milhões" +
            "bilhões" +
            "trilhões" +
            "quatrilhões" +
            "quintilhões";

#if !NET5_0_OR_GREATER
        private static readonly string[] OneNames =
            new[]
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
            new[]
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

        private static readonly string[] AltTenNames =
            new[]
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

        private static readonly string[] HundredNames =
            new[]
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

        private static readonly string[] ThousandNames =
            new[]
            {
                "mil",
                "milhão",
                "bilhão",
                "trilhão",
                "quatrilhão",
                "quintilhão",
            };

        private static readonly string[] PluralThousandNames =
            new[]
            {
                "mil",
                "milhões",
                "bilhões",
                "trilhões",
                "quatrilhões",
                "quintilhões",
            };
#endif

        private static readonly int[] OneNameStartIndexes =
            new[]
            {
                03, 04, // zero
                07, 02, // um
                09, 04, // dois
                13, 04, // três
                17, 06, // quatro
                23, 05, // cinco
                28, 04, // seis
                32, 04, // sete
                36, 04, // oito
                40, 04, // nove
            };

        private static readonly int[] AltTenNameIndexes =
            new[]
            {
                44, 03, // dez
                47, 04, // onze
                51, 04, // doze
                55, 05, // treze
                60, 08, // quatorze
                68, 06, // quinze
                74, 09, // dezesseis
                83, 09, // dezessete
                92, 07, // dezoito
                99, 08, // dezenove
            };

        private static readonly int[] TenNamesIndexes =
            new[]
            {
                044, 03, // dez
                107, 05, // vinte
                112, 06, // trinta
                118, 08, // quarenta
                126, 09, // cinquenta
                135, 08, // sessenta
                143, 07, // setenta
                150, 07, // oitenta
                157, 07, // noventa
            };

        private static readonly int[] HundredNameIndexes =
            new[]
            {
                167, 05, // cento
                172, 08, // duzentos
                180, 09, // trezentos
                189, 12, // quatrocentos
                201, 10, // quinhentos
                211, 10, // seiscentos
                221, 10, // setecentos
                231, 10, // oitocentos
                241, 10, // novecentos
            };

        private static readonly int[] ThousandNameIndexes =
            new[]
            {
                251, 03, // mil
                254, 06, // milhão
                260, 06, // bilhão
                266, 07, // trilhão
                273, 10, // quatrilhão
                283, 10, // quintilhão
            };

        private static readonly int[] PluralThousandNameIndexes =
            new[]
            {
                293, 03, // mil
                296, 07, // milhões
                303, 07, // bilhões
                310, 08, // trilhões
                318, 11, // quatrilhões
                329, 11, // quintilhões
            };

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="NumberSpeller"/> class.
        /// </summary>
        public NumberSpeller()
            : base()
        {
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
        public string Spell(
#if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            [NotNull] int number)
#else
            int number)
#endif
        {
            return this.Spell((long)number);
        }
#if NET5_0_OR_GREATER

        /// <summary>
        /// Returns the number spelled in Brazilian Portuguese.
        /// </summary>
        /// <param name="number">
        /// The number.
        /// </param>
        /// <returns>
        /// The number spelled.
        /// </returns>
        public string Spell(
#if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            [NotNull] long number)
#else
            long number)
#endif
        {
            if (number == 0L)
            {
                return
                    GetOneName(0).ToString();
            }

            Span<char> span = stackalloc char[256];

            var conj = Names
                .AsSpan()
                .Slice(0, 3);

            var specialName = Names
                .AsSpan()
                .Slice(164, 3);

            var startIndex = span.Length - 1;

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
                        if (numberClass > 1)
                        {
                            Insert(
                                span,
                                GetPluralThousandName(groupCount - 1),
                                ref startIndex);
                        }
                        else
                        {
                            Insert(
                                span,
                                GetThousandName(groupCount - 1),
                                ref startIndex);
                        }

                        Insert(span, conj.Slice(0, 1), ref startIndex);
                    }

                    if (groupCount != 1 || numberClass != 1)
                    {
                        var digit3 = (int)(numberClass % 10);
                        var digit2 = (int)((numberClass / 10) % 10);
                        var digit1 = (int)((numberClass / 100) % 10);

                        // Write ones
                        if (digit3 > 0 && digit2 != 1)
                        {
                            Insert(
                                span,
                                GetOneName(digit3),
                                ref startIndex);
                        }

                        // Write tens
                        if (digit2 == 1)
                        {
                            Insert(
                                span,
                                GetAltTenName(digit3),
                                ref startIndex);
                        }
                        else
                        {
                            if (digit2 > 0)
                            {
                                if (digit3 > 0)
                                {
                                    Insert(
                                        span,
                                        conj,
                                        ref startIndex);
                                }

                                Insert(
                                    span,
                                    GetTenName(digit2 - 1),
                                    ref startIndex);
                            }
                        }

                        // Write hundreds
                        if (digit1 > 0)
                        {
                            if (digit1 == 1 && digit2 + digit3 == 0)
                            {
                                Insert(
                                    span,
                                    specialName,
                                    ref startIndex);
                            }
                            else
                            {
                                if (digit2 + digit3 > 0)
                                {
                                    Insert(
                                        span,
                                        conj,
                                        ref startIndex);
                                }

                                Insert(
                                    span,
                                    GetHundredName(digit1 - 1),
                                    ref startIndex);
                            }
                        }
                    }

                    if (partialNumber > 0)
                    {
                        if (requiresConjunction)
                        {
                            Insert(
                                span,
                                conj,
                                ref startIndex);

                            requiresConjunction = false;
                        }
                        else
                        {
                            Insert(span, conj[0], ref startIndex);
                        }
                    }
                }

                groupCount++;
            }
            while (partialNumber > 0);

            var offset =
                span[startIndex] == conj[0]
                    ? 1
                    : 0;

            return span
                .Slice(
                    startIndex + offset,
                    span.Length - startIndex - 1 - offset)
                .ToString();
        }
#else

        /// <summary>
        /// Returns the number spelled in Brazilian Portuguese.
        /// </summary>
        /// <param name="number">
        /// The number.
        /// </param>
        /// <returns>
        /// The number spelled.
        /// </returns>
        public string Spell(
#if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            [NotNull] long number)
#else
            long number)
#endif
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
#endif
#if NET5_0_OR_GREATER

        /// <summary>
        /// Returns the one name by index.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <returns>
        /// The name as span.
        /// </returns>
        internal static ReadOnlySpan<char> GetOneName(int index)
        {
            var names = Names.AsSpan();

            return names
                .Slice(
                    OneNameStartIndexes[index << 1],
                    OneNameStartIndexes[(index << 1) + 1]);
        }

        /// <summary>
        /// Returns the ten name by index.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <returns>
        /// The name as span.
        /// </returns>
        internal static ReadOnlySpan<char> GetTenName(int index)
        {
            var names = Names.AsSpan();

            return names
                .Slice(
                    TenNamesIndexes[index << 1],
                    TenNamesIndexes[(index << 1) + 1]);
        }

        /// <summary>
        /// Returns the alternate ten name by index.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <returns>
        /// The name as span.
        /// </returns>
        internal static ReadOnlySpan<char> GetAltTenName(int index)
        {
            var names = Names.AsSpan();

            return names
                .Slice(
                    AltTenNameIndexes[index << 1],
                    AltTenNameIndexes[(index << 1) + 1]);
        }

        /// <summary>
        /// Returns the hundred name by index.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <returns>
        /// The name as span.
        /// </returns>
        internal static ReadOnlySpan<char> GetHundredName(int index)
        {
            var names = Names.AsSpan();

            return names
                .Slice(
                    HundredNameIndexes[index << 1],
                    HundredNameIndexes[(index << 1) + 1]);
        }

        /// <summary>
        /// Returns the thousand name by index.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <returns>
        /// The name as span.
        /// </returns>
        internal static ReadOnlySpan<char> GetThousandName(int index)
        {
            var names = Names.AsSpan();

            return names
                .Slice(
                    ThousandNameIndexes[index << 1],
                    ThousandNameIndexes[(index << 1) + 1]);
        }

        /// <summary>
        /// Returns the plural thousand name by index.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <returns>
        /// The name as span.
        /// </returns>
        internal static ReadOnlySpan<char> GetPluralThousandName(int index)
        {
            var names = Names.AsSpan();

            return names
                .Slice(
                    PluralThousandNameIndexes[index << 1],
                    PluralThousandNameIndexes[(index << 1) + 1]);
        }
#endif
#if NET5_0_OR_GREATER

        /// <summary>
        /// Inserts a string into span
        /// using a pointer to the start of the slice.
        /// </summary>
        /// <param name="span">
        /// The span.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="e">
        /// The start of the slice.
        /// </param>
        private static void Insert(
            Span<char> span,
            ReadOnlySpan<char> value,
            ref int e)
        {
            CopyFrom(
                span.Slice(e - value.Length, value.Length),
                value);

            e -= value.Length;
        }

        /// <summary>
        /// Inserts a char into span
        /// using a pointer to the start of the slice.
        /// </summary>
        /// <param name="span">
        /// The span.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="e">
        /// The start of the slice.
        /// </param>
        private static void Insert(
            Span<char> span,
            char value,
            ref int e)
        {
            CopyFrom(
                span.Slice(e - 1, 1),
                value);

            e--;
        }

        /// <summary>
        /// Copies a char to the span.
        /// </summary>
        /// <param name="span">
        /// The span.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        private static void CopyFrom(
            Span<char> span,
            char value)
        {
            if (span.Length > 0)
            {
                span[0] = value;
            }
        }

        /// <summary>
        /// Copies a string value to the span.
        /// </summary>
        /// <param name="span">
        /// The span.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        private static void CopyFrom(
            Span<char> span,
            ReadOnlySpan<char> value)
        {
            for (var i = 0; i < span.Length; i++)
            {
                if (i > value.Length)
                {
                    break;
                }

                span[i] = value[i];
            }
        }
#else

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
#endif
    }
}