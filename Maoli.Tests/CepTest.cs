namespace Maoli.Tests
{
    using System;
    using Maoli;
    using Xunit;

    public class CepTest
    {
        [Fact]
        public void ConstructorSetsPunctuation()
        {
            var cep = new Cep("01234-001", CepPunctuation.Strict);

            var expected = CepPunctuation.Strict;

            var actual = cep.Punctuation;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConstructorCreatesCepIfPunctuationIsStrict()
        {
            var cep = new Cep("01234-001", CepPunctuation.Strict);

            Assert.NotNull(cep);
        }

        [Fact]
        public void ConstructorCreatesCepIfPunctuationIsLoose()
        {
            var cep = new Cep("01234-001");

            Assert.NotNull(cep);
        }

        [Fact]
        public void ConstructorThrowsExceptionIfCepIsNull()
        {
            Cep cep = null;

            Assert.Throws<ArgumentException>(() =>
            {
                cep = new Cep(null);
            });

            Assert.Null(cep);
        }

        [Fact]
        public void ConstructorThrowsExceptionIfCepIsEmpty()
        {
            Cep cep = null;

            Assert.Throws<ArgumentException>(() =>
            {
                cep = new Cep(string.Empty);
            });

            Assert.Null(cep);
        }

        [Fact]
        public void ConstructorThrowsExceptionIfCepIsInvalidAndLoose()
        {
            Cep cep = null;

            Assert.Throws<ArgumentException>(() =>
            {
                cep = new Cep("012e501", CepPunctuation.Loose);
            });

            Assert.Null(cep);
        }

        [Fact]
        public void ConstructorThrowsExceptionIfCepIsInvalidAndStrict()
        {
            Cep cep = null;

            Assert.Throws<ArgumentException>(() =>
            {
                cep = new Cep("01234001", CepPunctuation.Strict);
            });

            Assert.Null(cep);
        }

        [Fact]
        public void ValidateReturnsFalseIfCepIsNull()
        {
            var actual = Cep.Validate(null);

            Assert.False(actual);
        }

        [Fact]
        public void StrictValidateReturnsFalseIfCepIsNull()
        {
            var actual = Cep.Validate(null, CepPunctuation.Strict);

            Assert.False(actual);
        }

        [Fact]
        public void ValidateReturnsTrueIfCepIsEmpty()
        {
            var actual = Cep.Validate(string.Empty);

            Assert.False(actual);
        }

        [Fact]
        public void ValidateReturnsTrueIfCepIsLooseAndValid()
        {
            var actual = Cep.Validate("12345678");

            Assert.True(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCepIsLooseAndInvalidAndIncomplete()
        {
            var actual = Cep.Validate("12345");

            Assert.False(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCepIsLooseAndGreaterThanEightCaracters()
        {
            var actual = Cep.Validate("1234567890");

            Assert.False(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCepIsLooseAndInvalid()
        {
            var actual = Cep.Validate("123-5678");

            Assert.False(actual);
        }

        [Fact]
        public void ValidateReturnsTrueIfCepIsStrictAndValid()
        {
            var actual = Cep.Validate("12345-678", CepPunctuation.Strict);

            Assert.True(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCepIsStrictAndInvalid()
        {
            var actual = Cep.Validate("32341-3d3", CepPunctuation.Strict);

            Assert.False(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCepContainsInvalidChars()
        {
            var actual = Cep.Validate("013s3-9b1");

            Assert.False(actual);
        }

        [Fact]
        public void ValidateReturnsFalseIfCepIsValidButNotStrict()
        {
            var actual = Cep.Validate("12345678", CepPunctuation.Strict);

            Assert.False(actual);
        }
    }
}
