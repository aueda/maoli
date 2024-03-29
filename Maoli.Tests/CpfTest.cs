﻿// Copyright (c) Adriano Ueda. All rights reserved.

namespace Maoli.Tests
{
    using System;
    using Maoli;
    using Xunit;

    public sealed class CpfTest
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
            Assert.Throws<ArgumentException>(() =>
            {
                _ = Cpf.Parse(CpfTest.looseInvalidCpf);
            });
        }

        [Fact]
        public void ValidateReturnsFalseIfCpfIsNull()
        {
            var actual = Cpf.Validate(null);

            Assert.False(actual);
        }

        [Fact]
        public void StrictValidateReturnsFalseIfCpfIsNull()
        {
            var actual = Cpf.Validate(null, CpfPunctuation.Strict);

            Assert.False(actual);
        }

        [Fact]
        public void LooseParseThrowsArgumentExceptionIfCpfIsEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _ = Cpf.Parse(string.Empty);
            });
        }

        [Fact]
        public void LooseParseThrowsArgumentExceptionIfCpfIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _ = Cpf.Parse(null);
            });
        }

        [Fact]
        public void StrictParseThrowsArgumentExceptionACpfObjectIfCpfIsEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _ = Cpf.Parse(string.Empty, CpfPunctuation.Strict);
            });
        }

        [Fact]
        public void StrictParseThrowsArgumentExceptionACpfObjectIfCpfIsInvalid()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _ = Cpf.Parse(CpfTest.looseValidCpf, CpfPunctuation.Strict);
            });
        }

        [Fact]
        public void StrictParseThrowsArgumentExceptionACpfObjectIfCpfIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _ = Cpf.Parse(null, CpfPunctuation.Strict);
            });
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
            Assert.Throws<ArgumentException>(() =>
            {
                _ = Cpf.Parse(CpfTest.looseValidCpf, CpfPunctuation.Strict);
            });
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

        [Theory]
        [InlineData("000.000.000-00")]
        [InlineData("111.111.111-11")]
        [InlineData("222.222.222-22")]
        [InlineData("333.333.333-33")]
        [InlineData("444.444.444-44")]
        [InlineData("555.555.555-55")]
        [InlineData("666.666.666-66")]
        [InlineData("777.777.777-77")]
        [InlineData("888.888.888-88")]
        [InlineData("999.999.999-99")]
        public void ValidateReturnsFalseIfCpfIsSameDigit(
            string cpf)
        {
            var actual = Cpf.Validate(cpf);

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
        [InlineData("721.703.364-00")]
        [InlineData("750.475.604-06")]
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
        [Fact]
        public void CompleteReturnsAValidCpf()
        {
            var actual = Cpf.Complete("714025658");

            Assert.Equal(CpfTest.looseValidCpf, actual);
        }
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

            Assert.Equal(CpfTest.looseValidCpf, actual);
        }

        [Fact]
        public void CompleteThrowsArgumentExceptionIfCpfTextIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _ = Cpf.Complete(null);
            });
        }

        [Fact]
        public void CompleteThrowsArgumentExceptionIfCpfTextIsEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _ = Cpf.Complete(string.Empty);
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
            Assert.Throws<ArgumentException>(() =>
            {
                _ = Cpf.Complete("714o256s8");
            });
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

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToStringReturnsStringWithNoPunctuationIfCpfPunctuationIsLoose()
        {
            var cpf = new Cpf("71402565860");

            var expected = "71402565860";
            var actual = cpf.ToString();

            Assert.Equal(expected, actual);
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
            Assert.Null(cpf);
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
