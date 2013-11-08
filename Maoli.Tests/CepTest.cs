namespace Maoli.Tests
{
    using System;
    using Maoli;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CepTest
    {
        [TestMethod]
        public void ValidateReturnsTrueIfCepIsEmpty()
        {
            var actual = Cep.Validate(string.Empty);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ValidateReturnsTrueIfCepIsLooseAndValid()
        {
            var actual = Cep.Validate("12345678");

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ValidateReturnsFalseIfCepIsLooseAndInvalidAndIncomplete()
        {
            var actual = Cep.Validate("12345");

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ValidateReturnsFalseIfCepIsLooseAndGreaterThanEightCaracters()
        {
            var actual = Cep.Validate("1234567890");

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ValidateReturnsFalseIfCepIsLooseAndInvalid()
        {
            var actual = Cep.Validate("123-5678");

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ValidateReturnsTrueIfCepIsStrictAndValid()
        {
            var actual = Cep.Validate("12345-678", CepPunctuation.Strict);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ValidateReturnsFalseIfCepIsStrictAndInvalid()
        {
            var actual = Cep.Validate("32341-3d3", CepPunctuation.Strict);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ValidateReturnsFalseIfCepContainsInvalidChars()
        {
            var actual = Cep.Validate("013s3-9b1");

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ValidateReturnsFalseIfCepIsValidButNotStrict()
        {
            var actual = Cep.Validate("12345678", CepPunctuation.Strict);

            Assert.IsFalse(actual);
        }
    }
}
