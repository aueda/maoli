namespace Maoli.Tests
{
    using System;
    using Maoli;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CnpjTest
    {
        private const string looseValidCnpj = "63943315000192";

        private const string looseInvalidCnpj = "32343315/000134";

        private const string strictValidCnpj = "63.943.315/0001-92";

        private const string strictInvalidCnpj = "32.343.315/0001-34";

        [TestMethod]
        public void PunctuationReturnsStrict()
        {
            var cnpj = Cnpj.Parse(CnpjTest.strictValidCnpj, CnpjPunctuation.Strict);
            var expected = CnpjPunctuation.Strict;
            var actual = cnpj.Punctuation;

            Assert.AreEqual<CnpjPunctuation>(expected, actual);
        }

        [TestMethod]
        public void PunctuationReturnsLoose()
        {
            var cnpj = Cnpj.Parse(CnpjTest.looseValidCnpj, CnpjPunctuation.Loose);
            var expected = CnpjPunctuation.Loose;
            var actual = cnpj.Punctuation;

            Assert.AreEqual<CnpjPunctuation>(expected, actual);
        }

        [TestMethod]
        public void LooseParseReturnsACnpjObjectIfCnpjIsValid()
        {
            var cnpj = Cnpj.Parse(CnpjTest.looseValidCnpj);

            Assert.IsNotNull(cnpj);
        }

        [TestMethod]
        public void LooseParseReturnsACnpjObjectIfFormattedCnpjIsValid()
        {
            var cnpj = Cnpj.Parse(CnpjTest.strictValidCnpj);

            Assert.IsNotNull(cnpj);
        }

        [TestMethod]
        public void LooseParseThrowsArgumentExceptionIfCnpjIsNotValid()
        {
            var actual = false;

            try
            {
                var cnpj = Cnpj.Parse(CnpjTest.looseInvalidCnpj);
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void LooseParseThrowsArgumentExceptionIfCnpjIsEmpty()
        {
            var actual = false;

            try
            {
                var cnpj = Cnpj.Parse(string.Empty);
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void LooseParseThrowsArgumentExceptionIfCnpjIsNull()
        {
            var actual = false;

            try
            {
                var cnpj = Cnpj.Parse(null);
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void StrictParseThrowsArgumentExceptionACnpjObjectIfCnpjIsEmpty()
        {
            var actual = false;

            try
            {
                var cnpj = Cnpj.Parse(string.Empty, CnpjPunctuation.Strict);
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void StrictParseThrowsArgumentExceptionACnpjObjectIfCnpjIsInvalid()
        {
            var actual = false;

            try
            {
                var cnpj = Cnpj.Parse(CnpjTest.looseValidCnpj, CnpjPunctuation.Strict);
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void StrictParseThrowsArgumentExceptionACnpjObjectIfCnpjIsNull()
        {
            var actual = false;

            try
            {
                var cnpj = Cnpj.Parse(null, CnpjPunctuation.Strict);
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void StrictParseReturnsACnpjObjectIfFormattedCnpjIsValid()
        {
            var cnpj = Cnpj.Parse(CnpjTest.strictValidCnpj, CnpjPunctuation.Strict);

            Assert.IsNotNull(cnpj);
        }

        [TestMethod]
        public void StrictParseThrowsArgumentExceptionIfCnpjIsFormatted()
        {
            var actual = false;

            try
            {
                var cnpj = Cnpj.Parse(CnpjTest.looseValidCnpj, CnpjPunctuation.Strict);
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ValidateReturnsTrueIfCnpjIsValid()
        {
            var actual = Cnpj.Validate(CnpjTest.looseValidCnpj);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ValidateReturnsFalseIfCnpjIsInvalid()
        {
            var actual = Cnpj.Validate(CnpjTest.looseInvalidCnpj);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ValidateReturnsFalseIfCnpjContainsInvalidChars()
        {
            var actual = Cnpj.Validate("714o256s8");

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ValidateReturnsFalseIfCnpjIsValidButNotStrict()
        {
            var actual = Cnpj.Validate(looseValidCnpj, CnpjPunctuation.Strict);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ValidateReturnsTrueIfCnpjIsValidAndStrict()
        {
            var actual = Cnpj.Validate(CnpjTest.strictValidCnpj, CnpjPunctuation.Strict);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ValidateReturnsFalseIfCnpjIsHalfPunctuatedAndValidAndLoose()
        {
            var actual = Cnpj.Validate("63.9433150001-92", CnpjPunctuation.Loose);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void CompleteReturnsAValidCnpj()
        {
            var actual = Cnpj.Complete("639433150001");

            Assert.AreEqual<string>(CnpjTest.looseValidCnpj, actual);
        }

        [TestMethod]
        public void CompleteThrowsArgumentExceptionIfCnpjTextIsWrong()
        {
            var actual = false;

            try
            {
                var cnpj = Cnpj.Complete("714o256s8");
            }
            catch (ArgumentException)
            {
                actual = true;
            }

            Assert.IsTrue(actual);
        }

        // see http://msdn.microsoft.com/en-us/library/ms173147(v=vs.80).aspx
        [TestMethod]
        public void EqualsReturnsTrueIfSameCnpjIsEqual()
        {
            var cnpj = Cnpj.Parse(looseValidCnpj);

            var actual = cnpj.Equals(cnpj);

            Assert.IsTrue(actual);
        }

        // see http://msdn.microsoft.com/en-us/library/ms173147(v=vs.80).aspx
        [TestMethod]
        public void EqualsReturnsTrueIfTwoCnpjsAreReciprocal()
        {
            var Cnpj1 = Cnpj.Parse(looseValidCnpj);
            var Cnpj2 = Cnpj.Parse(looseValidCnpj);

            var actual = Cnpj1.Equals(Cnpj2) && Cnpj2.Equals(Cnpj1);

            Assert.IsTrue(actual);
        }

        // see http://msdn.microsoft.com/en-us/library/ms173147(v=vs.80).aspx
        [TestMethod]
        public void EqualsReturnsTrueIfThreeCnpjsAreReciprocal()
        {
            var Cnpj1 = Cnpj.Parse(looseValidCnpj);
            var Cnpj2 = Cnpj.Parse(looseValidCnpj);
            var Cnpj3 = Cnpj.Parse(looseValidCnpj);

            var actual = Cnpj1.Equals(Cnpj2) && Cnpj2.Equals(Cnpj3) && Cnpj1.Equals(Cnpj3);

            Assert.IsTrue(actual);
        }

        // see http://msdn.microsoft.com/en-us/library/ms173147(v=vs.80).aspx
        [TestMethod]
        public void EqualsReturnsFalseIfCnpjIsNull()
        {
            var cnpj = Cnpj.Parse(looseValidCnpj);

            var actual = cnpj.Equals(null);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void EqualsReturnsTrueIfCnpjAreEqual()
        {
            var cnpj1 = Cnpj.Parse(looseValidCnpj);
            var cnpj2 = Cnpj.Parse(looseValidCnpj);

            var actual = cnpj1.Equals(cnpj2);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void EqualsReturnsTrueIfCnpjAreEqualButWithDiffPunctuation()
        {
            var cnpj1 = Cnpj.Parse(looseValidCnpj);
            var cnpj2 = Cnpj.Parse(strictValidCnpj, CnpjPunctuation.Strict);

            var actual = cnpj1.Equals(cnpj2);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void EqualsReturnsFalseIfCnpjAreNotEqual()
        {
            var cnpj1 = Cnpj.Parse(looseValidCnpj);
            var cnpj2 = Cnpj.Parse("71418811000155");

            var actual = cnpj1.Equals(cnpj2);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void GetHashCodeAreEqualIfTwoCnpjAreEqual()
        {
            var hash1 = Cnpj.Parse(looseValidCnpj).GetHashCode();
            var hash2 = Cnpj.Parse(looseValidCnpj).GetHashCode();

            Assert.AreEqual<int>(hash1, hash2);
        }

        [TestMethod]
        public void GetHashCodeReturnsTrueIfCnpjAreEqualButWithDiffPunctuation()
        {
            var hash1 = Cnpj.Parse(looseValidCnpj).GetHashCode();
            var hash2 = Cnpj.Parse(strictValidCnpj).GetHashCode();

            Assert.AreEqual<int>(hash1, hash2);
        }

        [TestMethod]
        public void GetHashCodeReturnsFalseIfTwoCnpjAreNotEqual()
        {
            var hash1 = Cnpj.Parse(looseValidCnpj).GetHashCode();
            var hash2 = Cnpj.Parse("71418811000155").GetHashCode();

            Assert.AreNotEqual<int>(hash1, hash2);
        }

        [TestMethod]
        public void ToStringReturnsStringWithNoPunctuationIfCnpjPunctuationIsStrict()
        {
            var Cnpj = new Cnpj(strictValidCnpj, CnpjPunctuation.Strict);

            var expected = looseValidCnpj;
            var actual = Cnpj.ToString();

            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod]
        public void ToStringReturnsStringWithNoPunctuationIfCnpjPunctuationIsLoose()
        {
            var Cnpj = new Cnpj(looseValidCnpj);

            var expected = looseValidCnpj;
            var actual = Cnpj.ToString();

            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod]
        public void TryParseReturnsFalseIfCnpjIsInvalid()
        {
            Cnpj Cnpj = null;

            var actual = Cnpj.TryParse(looseInvalidCnpj, out Cnpj);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void TryParseReturnsTrueIfCnpjIsValid()
        {
            Cnpj Cnpj = null;

            var actual = Cnpj.TryParse(looseValidCnpj, out Cnpj);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void StrictTryParseReturnsFalseIfCnpjIsInvalid()
        {
            Cnpj Cnpj = null;

            var actual = Cnpj.TryParse(looseInvalidCnpj, out Cnpj, CnpjPunctuation.Strict);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void StrictTryParseReturnsTrueIfCnpjIsValidAndHasPunctuation()
        {
            Cnpj Cnpj = null;

            var actual = Cnpj.TryParse(strictValidCnpj, out Cnpj, CnpjPunctuation.Strict);

            Assert.IsTrue(actual);
        }
    }
}
