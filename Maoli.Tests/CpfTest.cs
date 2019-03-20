namespace Maoli.Tests
{
    using System;
    using Maoli;
    using Xunit;

    public class CpfTest
    {
        private const string looseValidCpf = "71402565860";

        private const string looseInvalidCpf = "82513676932";

        private const string strictValidCpf = "714.025.658-60";

        private const string strictInvalidCpf = "825.136.769-32";

        [Fact]
        public void PunctuationReturnsStrict()
        {
            var cpf = Cpf.Parse(CpfTest.strictValidCpf, CpfPunctuation.Strict);
            var expected = CpfPunctuation.Strict;
            var actual = cpf.Punctuation;

            Assert.Equal<CpfPunctuation>(expected, actual);
        }

        [Fact]
        public void PunctuationReturnsLoose()
        {
            var cpf = Cpf.Parse(CpfTest.looseValidCpf, CpfPunctuation.Loose);
            var expected = CpfPunctuation.Loose;
            var actual = cpf.Punctuation;

            Assert.Equal<CpfPunctuation>(expected, actual);
        }

        [Fact]
        public void LooseParseReturnsACpfObjectIfCpfIsValid()
        {
            var cpf = Cpf.Parse(CpfTest.looseValidCpf);

            Assert.NotNull(cpf);
        }

        [Fact]
        public void LooseParseReturnsACpfObjectIfFormattedCpfIsValid()
        {
            var cpf = Cpf.Parse(CpfTest.strictValidCpf);

            Assert.NotNull(cpf);
        }

        [Fact]
        public void LooseParseThrowsArgumentExceptionIfCpfIsNotValid()
        {
            var actual = false;

            try
            {
                Cpf.Parse(CpfTest.looseInvalidCpf);
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.True(actual);
        }

        [Fact]
        public void LooseParseThrowsArgumentExceptionIfCpfIsEmpty()
        {
            var actual = false;

            try
            {
                Cpf.Parse(string.Empty);
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.True(actual);
        }

        [Fact]
        public void LooseParseThrowsArgumentExceptionIfCpfIsNull()
        {
            var actual = false;

            try
            {
                Cpf.Parse(null);
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.True(actual);
        }

        [Fact]
        public void StrictParseThrowsArgumentExceptionACpfObjectIfCpfIsEmpty()
        {
            var actual = false;

            try
            {
                Cpf.Parse(string.Empty, CpfPunctuation.Strict);
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.True(actual);
        }

        [Fact]
        public void StrictParseThrowsArgumentExceptionACpfObjectIfCpfIsInvalid()
        {
            var actual = false;

            try
            {
                Cpf.Parse(CpfTest.looseValidCpf, CpfPunctuation.Strict);
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.True(actual);
        }

        [Fact]
        public void StrictParseThrowsArgumentExceptionACpfObjectIfCpfIsNull()
        {
            var actual = false;

            try
            {
                Cpf.Parse(null, CpfPunctuation.Strict);
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.True(actual);
        }

        [Fact]
        public void StrictParseReturnsACpfObjectIfFormattedCpfIsValid()
        {
            var cpf = Cpf.Parse(CpfTest.strictValidCpf, CpfPunctuation.Strict);

            Assert.NotNull(cpf);
        }

        [Fact]
        public void StrictParseThrowsArgumentExceptionIfCpfIsFormatted()
        {
            var actual = false;

            try
            {
                Cpf.Parse(CpfTest.looseValidCpf, CpfPunctuation.Strict);
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.True(actual);
        }

        [Fact]
        public void ValidateReturnsTrueIfCpfIsValid()
        {
            var actual = Cpf.Validate(CpfTest.looseValidCpf);

            Assert.True(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCpfIsInvalid()
        {
            var actual = Cpf.Validate(CpfTest.looseInvalidCpf);

            Assert.False(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCpfIsEmpty()
        {
            var actual = Cpf.Validate(string.Empty);

            Assert.False(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCpfIsSameDigit()
        {
            var actual = Cpf.Validate("111.111.111-11");

            Assert.False(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCpfIsOnlyZero()
        {
            var actual = Cpf.Validate("000.000.000-00");

            Assert.False(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCpfIsOnlyOne()
        {
            var actual = Cpf.Validate("111.111.111-11");

            Assert.False(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCpfIsOnlyTwo()
        {
            var actual = Cpf.Validate("222.222.222-22");

            Assert.False(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCpfIsOnlyThree()
        {
            var actual = Cpf.Validate("333.333.333-33");

            Assert.False(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCpfIsOnlyFour()
        {
            var actual = Cpf.Validate("444.444.444-44");

            Assert.False(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCpfIsOnlyFive()
        {
            var actual = Cpf.Validate("555.555.555-55");

            Assert.False(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCpfIsOnlySix()
        {
            var actual = Cpf.Validate("666.666.666-66");

            Assert.False(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCpfIsOnlySeven()
        {
            var actual = Cpf.Validate("777.777.777-77");

            Assert.False(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCpfIsOnlyEight()
        {
            var actual = Cpf.Validate("888.888.888-88");

            Assert.False(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCpfIsOnlyNine()
        {
            var actual = Cpf.Validate("999.999.999-99");

            Assert.False(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCpfContainsInvalidChars()
        {
            var actual = Cpf.Validate("714o256s860");

            Assert.False(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCpfContainsInvalidCharsAndItIsShorter()
        {
            var actual = Cpf.Validate("714o256s8");

            Assert.False(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCnpjIsLooseAndGreaterThanElevenCaracters()
        {
            var actual = Cpf.Validate("12345678901234567890");

            Assert.False(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCpfIsValidButNotStrict()
        {
            var actual = Cpf.Validate(looseValidCpf, CpfPunctuation.Strict);

            Assert.False(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCpfIsHalfPunctuatedAndValidAndLoose()
        {
            var actual = Cpf.Validate("714.025.65860", CpfPunctuation.Loose);

            Assert.False(actual);
        }

#if NET40 || NET45
        [Fact]
        public void ValidateReturnsTrueIfCpfIsValidAndStrict()
        {
            var actual = Cpf.Validate(CpfTest.strictValidCpf, CpfPunctuation.Strict);

            Assert.True(actual);
        }
#else
        [InlineData("714.025.658-60")]
        [InlineData("066.663.484-00")]
        [Theory]
        public void ValidateReturnsTrueIfCpfIsValidAndStrict(string cnpj)
        {
            var actual = Cpf.Validate(cnpj, CpfPunctuation.Strict);

            Assert.True(actual);
        }
#endif

        [Fact]
        public void ValidateReturnsFalseIfCpfIsInvalidAndStrict()
        {
            var actual = Cpf.Validate(CpfTest.strictInvalidCpf, CpfPunctuation.Strict);

            Assert.False(actual);
        }

#if NET40 || NET45
#pragma warning disable xUnit2006
        [Fact]
        public void CompleteReturnsAValidCpf()
        {
            var actual = Cpf.Complete("714025658");

            Assert.Equal(CpfTest.looseValidCpf, actual);
        }
#pragma warning restore xUnit2006
#else
        [InlineData("066663484", "06666348400")]
        [InlineData("721703364", "72170336400")]
        [InlineData("714025658", "71402565860")]
        [InlineData("750475604", "75047560406")]
        [Theory]
        public void CompleteReturnsAValidCpf(
            string cpfString,
            string expected)
        {
            var actual = Cpf.Complete(cpfString);

            Assert.Equal(expected, actual);
        }
#endif

        [Fact]
        public void CompleteReturnsAValidCpfIfHasPunctuaction()
        {
            var actual = Cpf.Complete("714.025.658");

#if NET40 || NET45
#pragma warning disable xUnit2006
#endif

            Assert.Equal(CpfTest.looseValidCpf, actual);

#if NET40 || NET45
#pragma warning restore xUnit2006
#endif
        }

        [Fact]
        public void CompleteThrowsArgumentExceptionIfCpfTextIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Cpf.Complete(null);
            });
        }

        [Fact]
        public void CompleteThrowsArgumentExceptionIfCpfTextIsEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Cpf.Complete(string.Empty);
            });
        }

        [Fact]
        public void CompleteThrowsArgumentExceptionIfCpfTextIsShorter()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Cpf.Complete("7140256");
            });
        }

        [Fact]
        public void CompleteThrowsArgumentExceptionIfCpfTextIsWrong()
        {
            var actual = false;

            try
            {
                Cpf.Complete("714o256s8");
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.True(actual);
        }

        // see http://msdn.microsoft.com/en-us/library/ms173147(v=vs.80).aspx
        [Fact]
        public void EqualsReturnsTrueIfSameCpfIsEqual()
        {
            var cpf = Cpf.Parse("71402565860");

            var actual = cpf.Equals(cpf);

            Assert.True(actual);
        }

        // see http://msdn.microsoft.com/en-us/library/ms173147(v=vs.80).aspx
        [Fact]
        public void EqualsReturnsTrueIfTwoCpfsAreReciprocal()
        {
            var cpf1 = Cpf.Parse("71402565860");
            var cpf2 = Cpf.Parse("71402565860");

            var actual = cpf1.Equals(cpf2) && cpf2.Equals(cpf1);

            Assert.True(actual);
        }

        // see http://msdn.microsoft.com/en-us/library/ms173147(v=vs.80).aspx
        [Fact]
        public void EqualsReturnsTrueIfThreeCpfsAreReciprocal()
        {
            var cpf1 = Cpf.Parse("71402565860");
            var cpf2 = Cpf.Parse("71402565860");
            var cpf3 = Cpf.Parse("71402565860");

            var actual = cpf1.Equals(cpf2) && cpf2.Equals(cpf3) && cpf1.Equals(cpf3);

            Assert.True(actual);
        }

        // see http://msdn.microsoft.com/en-us/library/ms173147(v=vs.80).aspx
        [Fact]
        public void EqualsReturnsFalseIfCpfIsNull()
        {
            var cpf = Cpf.Parse("71402565860");

            var actual = cpf.Equals(null);

            Assert.False(actual);
        }

        [Fact]
        public void EqualsReturnsTrueIfCpfAreEqual()
        {
            var cpf1 = Cpf.Parse("71402565860");
            var cpf2 = Cpf.Parse("71402565860");

            var actual = cpf1.Equals(cpf2);

            Assert.True(actual);
        }

        [Fact]
        public void EqualsReturnsTrueIfCpfAreEqualButWithDiffPunctuation()
        {
            var cpf1 = Cpf.Parse("71402565860");
            var cpf2 = Cpf.Parse("714.025.658-60", CpfPunctuation.Strict);

            var actual = cpf1.Equals(cpf2);

            Assert.True(actual);
        }

        [Fact]
        public void EqualsReturnsFalseIfCpfAreNotEqual()
        {
            var cpf1 = Cpf.Parse("71402565860");
            var cpf2 = Cpf.Parse("77033192100");

            var actual = cpf1.Equals(cpf2);

            Assert.False(actual);
        }

        [Fact]
        public void EqualsReturnsTrueIfCpfAreEqualAndObject()
        {
            object cpf1 = Cpf.Parse("71402565860");
            var cpf2 = Cpf.Parse("71402565860");

            var actual = cpf2.Equals(cpf1);

            Assert.True(actual);
        }

        [Fact]
        public void EqualsReturnsTrueIfCpfAreNotEqualAndObject()
        {
            object cpf1 = Cpf.Parse("71402565860");
            var cpf2 = Cpf.Parse("77033192100");
        
            var actual = cpf2.Equals(cpf1);

            Assert.False(actual);
        }

        [Fact]
        public void GetHashCodeReturnsTrueIfCpfAreEqual()
        {
            var hash1 = Cpf.Parse("71402565860").GetHashCode();
            var hash2 = Cpf.Parse("71402565860").GetHashCode();

            Assert.Equal<int>(hash1, hash2);
        }

        [Fact]
        public void GetHashCodeReturnsTrueIfCpfAreEqualButWithDiffPunctuation()
        {
            var hash1 = Cpf.Parse("71402565860").GetHashCode();
            var hash2 = Cpf.Parse("714.025.658-60").GetHashCode();

            Assert.Equal<int>(hash1, hash2);
        }

        [Fact]
        public void GetHashCodeReturnsFalseIfCpfAreNotEqual()
        {
            var hash1 = Cpf.Parse("71402565860").GetHashCode();
            var hash2 = Cpf.Parse("77033192100").GetHashCode();

            Assert.NotEqual<int>(hash1, hash2);
        }

        [Fact]
        public void ToStringReturnsStringWithNoPunctuationIfCpfPunctuationIsStrict()
        {
            var cpf = new Cpf("714.025.658-60", CpfPunctuation.Strict);

            var expected = "71402565860";
            var actual = cpf.ToString();

#if NET40 || NET45
#pragma warning disable xUnit2006
#endif

            Assert.Equal(expected, actual);

#if NET40 || NET45
#pragma warning restore xUnit2006
#endif
        }

        [Fact]
        public void ToStringReturnsStringWithNoPunctuationIfCpfPunctuationIsLoose()
        {
            var cpf = new Cpf("71402565860");

            var expected = "71402565860";
            var actual = cpf.ToString();

#if NET40 || NET45
#pragma warning disable xUnit2006
#endif
            Assert.Equal(expected, actual);

#if NET40 || NET45
#pragma warning disable xUnit2006
#endif
        }

        [Fact]
        public void TryParseReturnsFalseIfCpfIsInvalid()
        {
            var actual = Cpf.TryParse("71402565862", out Cpf cpf);

            Assert.False(actual);
            Assert.Null(cpf);
        }

        [Fact]
        public void TryParseReturnsTrueIfCpfIsValid()
        {
            var actual = Cpf.TryParse("71402565860", out Cpf cpf);

            Assert.True(actual);
            Assert.NotNull(cpf);
        }

        [Fact]
        public void StrictTryParseReturnsFalseIfCpfIsInvalid()
        {
            var actual = Cpf.TryParse(
                "71402565860",
                out Cpf cpf,
                CpfPunctuation.Strict);

            Assert.False(actual);
        }

        [Fact]
        public void StrictTryParseReturnsTruefCpfIsValidAndHasPunctuation()
        {
            var actual = Cpf.TryParse(
                "714.025.658-60",
                out Cpf cpf,
                CpfPunctuation.Strict);

            Assert.True(actual);
            Assert.NotNull(cpf);
        }
    }
}