namespace Maoli.Tests.Spellers
{
    using Maoli.Spellers;
    using Xunit;

    public sealed class NumberSpellerTests
    {
#if !NET40 && !NET45
        [Theory]
        [InlineData(0L, "zero")]
        [InlineData(1L, "um")]
        [InlineData(2L, "dois")]
        [InlineData(3L, "três")]
        [InlineData(4L, "quatro")]
        [InlineData(5L, "cinco")]
        [InlineData(6L, "seis")]
        [InlineData(7L, "sete")]
        [InlineData(8L, "oito")]
        [InlineData(9L, "nove")]
        [InlineData(10L, "dez")]
        [InlineData(11L, "onze")]
        [InlineData(12L, "doze")]
        [InlineData(13L, "treze")]
        [InlineData(14L, "quatorze")]
        [InlineData(15L, "quinze")]
        [InlineData(16L, "dezesseis")]
        [InlineData(17L, "dezessete")]
        [InlineData(18L, "dezoito")]
        [InlineData(19L, "dezenove")]
        [InlineData(20L, "vinte")]
        [InlineData(25L, "vinte e cinco")]
        [InlineData(100L, "cem")]
        [InlineData(205L, "duzentos e cinco")]
        [InlineData(225L, "duzentos e vinte e cinco")]
        [InlineData(1000L, "mil")]
        [InlineData(1001L, "mil e um")]
        [InlineData(1637L, "mil seiscentos e trinta e sete")]
        [InlineData(2200L, "dois mil e duzentos")]
        [InlineData(2226L, "dois mil duzentos e vinte e seis")]
        [InlineData(2400L, "dois mil e quatrocentos")]
        [InlineData(2435L, "dois mil quatrocentos e trinta e cinco")]
        [InlineData(6300L, "seis mil e trezentos")]
        [InlineData(9100L, "nove mil e cem")]
        [InlineData(10000L, "dez mil")]
        [InlineData(61637L, "sessenta e um mil seiscentos e trinta e sete")]
        [InlineData(100000L, "cem mil")]
        [InlineData(961637L, "novecentos e sessenta e um mil seiscentos e trinta e sete")]
        [InlineData(1000000L, "um milhão")]
        [InlineData(5961637L, "cinco milhões novecentos e sessenta e um mil seiscentos e trinta e sete")]
        [InlineData(10000000L, "dez milhões")]
        [InlineData(25961637L, "vinte e cinco milhões novecentos e sessenta e um mil seiscentos e trinta e sete")]
        [InlineData(425961637L, "quatrocentos e vinte e cinco milhões novecentos e sessenta e um mil seiscentos e trinta e sete")]
        [InlineData(1000000000L, "um bilhão")]
        [InlineData(1159000000L, "um bilhão cento e cinquenta e nove milhões")]
        [InlineData(8425961637L, "oito bilhões quatrocentos e vinte e cinco milhões novecentos e sessenta e um mil seiscentos e trinta e sete")]
        [InlineData(10000000000L, "dez bilhões")]
        [InlineData(100000000000L, "cem bilhões")]
        [InlineData(100000000001L, "cem bilhões e um")]
        [InlineData(324312090215L, "trezentos e vinte e quatro bilhões trezentos e doze milhões noventa mil duzentos e quinze")]
        [InlineData(1000000000000L, "um trilhão")]
        [InlineData(1000000000001L, "um trilhão e um")]
        [InlineData(1000000000000000L, "um quatrilhão")]
        [InlineData(1000000000000001L, "um quatrilhão e um")]
        [InlineData(long.MaxValue, "nove quintilhões duzentos e vinte e três quatrilhões trezentos e setenta e dois trilhões trinta e seis bilhões oitocentos e cinquenta e quatro milhões setecentos e setenta e cinco mil oitocentos e sete")]
        public void SpellReturnsCorrectLongNumber(
            long value,
            string expected)
        {
            var speller = new NumberSpeller();

            var actual = speller.Spell(value);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, "zero")]
        [InlineData(1, "um")]
        [InlineData(2, "dois")]
        [InlineData(3, "três")]
        [InlineData(4, "quatro")]
        [InlineData(5, "cinco")]
        [InlineData(6, "seis")]
        [InlineData(7, "sete")]
        [InlineData(8, "oito")]
        [InlineData(9, "nove")]
        [InlineData(10, "dez")]
        [InlineData(11, "onze")]
        [InlineData(12, "doze")]
        [InlineData(13, "treze")]
        [InlineData(14, "quatorze")]
        [InlineData(15, "quinze")]
        [InlineData(16, "dezesseis")]
        [InlineData(17, "dezessete")]
        [InlineData(18, "dezoito")]
        [InlineData(19, "dezenove")]
        [InlineData(20, "vinte")]
        [InlineData(25, "vinte e cinco")]
        [InlineData(100, "cem")]
        [InlineData(205, "duzentos e cinco")]
        [InlineData(225, "duzentos e vinte e cinco")]
        [InlineData(1000, "mil")]
        [InlineData(1001, "mil e um")]
        [InlineData(1637, "mil seiscentos e trinta e sete")]
        [InlineData(2200, "dois mil e duzentos")]
        [InlineData(2226, "dois mil duzentos e vinte e seis")]
        [InlineData(2400, "dois mil e quatrocentos")]
        [InlineData(2435, "dois mil quatrocentos e trinta e cinco")]
        [InlineData(6300, "seis mil e trezentos")]
        [InlineData(9100, "nove mil e cem")]
        [InlineData(10000, "dez mil")]
        [InlineData(61637, "sessenta e um mil seiscentos e trinta e sete")]
        [InlineData(100000, "cem mil")]
        [InlineData(961637, "novecentos e sessenta e um mil seiscentos e trinta e sete")]
        [InlineData(1000000, "um milhão")]
        [InlineData(5961637, "cinco milhões novecentos e sessenta e um mil seiscentos e trinta e sete")]
        [InlineData(10000000, "dez milhões")]
        [InlineData(25961637, "vinte e cinco milhões novecentos e sessenta e um mil seiscentos e trinta e sete")]
        [InlineData(425961637, "quatrocentos e vinte e cinco milhões novecentos e sessenta e um mil seiscentos e trinta e sete")]
        [InlineData(1000000000, "um bilhão")]
        [InlineData(1159000000, "um bilhão cento e cinquenta e nove milhões")]
        [InlineData(int.MaxValue, "dois bilhões cento e quarenta e sete milhões quatrocentos e oitenta e três mil seiscentos e quarenta e sete")]
        public void SpellReturnsCorrectIntegerNumber(
            int value,
            string expected)
        {
            var speller = new NumberSpeller();

            var actual = speller.Spell(value);

            Assert.Equal(expected, actual);
        }
#endif
    }
}
