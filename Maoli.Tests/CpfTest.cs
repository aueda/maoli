namespace Maoli.Docs.Tests
{
    using System;
    using Maoli.Docs;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CpfTest
    {
        private const string validCpf = "71402565860";

        private const string invalidCpf = "82513676932";

        private const string formValidCpf = "714.025.658-60";

        private const string formInvalidCpf = "825.136.769-32";

        [TestMethod]
        public void LooseParseReturnsACpfObjectIfCpfIsValid()
        {
            var cpf = Cpf.Parse(CpfTest.validCpf);

            Assert.IsNotNull(cpf);
        }

        [TestMethod]
        public void LooseParseReturnsACpfObjectIfFormattedCpfIsValid()
        {
            var cpf = Cpf.Parse(CpfTest.formValidCpf);

            Assert.IsNotNull(cpf);
        }

        [TestMethod]
        public void LooseParseThrowsArgumentExceptionIfCpfIsNotValid()
        {
            var actual = false;

            try
            {
                var cpf = Cpf.Parse(CpfTest.invalidCpf);
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void LooseParseThrowsArgumentExceptionIfCpfIsEmpty()
        {
            var actual = false;

            try
            {
                var cpf = Cpf.Parse(string.Empty);
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void LooseParseThrowsArgumentExceptionIfCpfIsNull()
        {
            var actual = false;

            try
            {
                var cpf = Cpf.Parse(null);
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void StrictParseThrowsArgumentExceptionACpfObjectIfCpfIsEmpty()
        {
            var actual = false;

            try
            {
                var cpf = Cpf.Parse(string.Empty, CpfPunctuation.Strict);
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void StrictParseThrowsArgumentExceptionACpfObjectIfCpfIsInvalid()
        {
            var actual = false;

            try
            {
                var cpf = Cpf.Parse(CpfTest.validCpf, CpfPunctuation.Strict);
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void StrictParseThrowsArgumentExceptionACpfObjectIfCpfIsNull()
        {
            var actual = false;

            try
            {
                var cpf = Cpf.Parse(null, CpfPunctuation.Strict);
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void StrictParseReturnsACpfObjectIfFormattedCpfIsValid()
        {
            var cpf = Cpf.Parse(CpfTest.formValidCpf, CpfPunctuation.Strict);

            Assert.IsNotNull(cpf);
        }

        [TestMethod]
        public void StrictParseThrowsArgumentExceptionIfCpfIsFormatted()
        {
            var actual = false;

            try
            {
                var cpf = Cpf.Parse(CpfTest.validCpf, CpfPunctuation.Strict);
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsValidReturnsTrueIfCpfIsValid()
        {
            var actual = Cpf.IsValid(CpfTest.validCpf);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsValidReturnsFalseIfCpfIsInvalid()
        {
            var actual = Cpf.IsValid(CpfTest.invalidCpf);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsValidReturnsFalseIfCpfContainsInvalidChars()
        {
            var actual = Cpf.IsValid("714o256s8");

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void CompleteReturnsAValidCpf()
        {
            var actual = Cpf.Complete("714025658");

            Assert.AreEqual<string>(CpfTest.validCpf, actual);
        }

        [TestMethod]
        public void CompleteThrowsArgumentExceptionIfCpfTextIsWrong()
        {
            var actual = false;

            try
            {
                var cpf = Cpf.Complete("714o256s8");
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.IsTrue(actual);
        }
    }
}
