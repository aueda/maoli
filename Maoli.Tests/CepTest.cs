namespace Maoli.Tests
{
    using System;
    using Maoli;
    using Xunit;

    public class CepTest
    {
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
            Assert.Throws<ArgumentException>(() =>
            {
                var cep = new Cep(null);
            });
        }

        [Fact]
        public void ConstructorThrowsExceptionIfCepIsEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var cep = new Cep(string.Empty);
            });
        }

        [Fact]
        public void ConstructorThrowsExceptionIfCepIsInvalidAndLoose()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var cep = new Cep("012e501", CepPunctuation.Loose);
            });
        }

        [Fact]
        public void ConstructorThrowsExceptionIfCepIsInvalidAndStrict()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var cep = new Cep("01234001", CepPunctuation.Strict);
            });
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
