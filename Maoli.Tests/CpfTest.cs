namespace Maoli.Tests
{
    using System;
    using Maoli;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CpfTest
    {
        private const string looseValidCpf = "71402565860";

        private const string invalidCpf = "82513676932";

        private const string strictValidCpf = "714.025.658-60";

        private const string strictInvalidCpf = "825.136.769-32";

        [TestMethod]
        public void PunctuationReturnsStrict()
        {
            var cpf = Cpf.Parse(CpfTest.strictValidCpf, CpfPunctuation.Strict);
            var expected = CpfPunctuation.Strict;
            var actual = cpf.Punctuation;

            Assert.AreEqual<CpfPunctuation>(expected, actual);
        }

        [TestMethod]
        public void PunctuationReturnsLoose()
        {
            var cpf = Cpf.Parse(CpfTest.looseValidCpf, CpfPunctuation.Loose);
            var expected = CpfPunctuation.Loose;
            var actual = cpf.Punctuation;

            Assert.AreEqual<CpfPunctuation>(expected, actual);
        }

        [TestMethod]
        public void LooseParseReturnsACpfObjectIfCpfIsValid()
        {
            var cpf = Cpf.Parse(CpfTest.looseValidCpf);

            Assert.IsNotNull(cpf);
        }

        [TestMethod]
        public void LooseParseReturnsACpfObjectIfFormattedCpfIsValid()
        {
            var cpf = Cpf.Parse(CpfTest.strictValidCpf);

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
                var cpf = Cpf.Parse(CpfTest.looseValidCpf, CpfPunctuation.Strict);
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
            var cpf = Cpf.Parse(CpfTest.strictValidCpf, CpfPunctuation.Strict);

            Assert.IsNotNull(cpf);
        }

        [TestMethod]
        public void StrictParseThrowsArgumentExceptionIfCpfIsFormatted()
        {
            var actual = false;

            try
            {
                var cpf = Cpf.Parse(CpfTest.looseValidCpf, CpfPunctuation.Strict);
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
            var actual = Cpf.IsValid(CpfTest.looseValidCpf);

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
        public void IsValidReturnsFalseIfCpfIsValidButNotStrict()
        {
            var actual = Cpf.IsValid(looseValidCpf, CpfPunctuation.Strict);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsValidReturnsTrueIfCpfIsValidAndStrict()
        {
            var actual = Cpf.IsValid(CpfTest.strictValidCpf, CpfPunctuation.Strict);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void CompleteReturnsAValidCpf()
        {
            var actual = Cpf.Complete("714025658");

            Assert.AreEqual<string>(CpfTest.looseValidCpf, actual);
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

        //[TestMethod]
        //public void EqualsOperatorReturnsTrueIfCpfAreEqual()
        //{
        //    var cpf1 = new Cpf("71402565860");
        //    var cpf2 = new Cpf("71402565860");

        //    var actual = cpf1 == cpf2;

        //    Assert.IsTrue(actual);
        //}

        // see http://msdn.microsoft.com/en-us/library/ms173147(v=vs.80).aspx
        [TestMethod]
        public void EqualsReturnsTrueIfSameCpfIsEqual()
        {
            var cpf = Cpf.Parse("71402565860");

            var actual = cpf.Equals(cpf);

            Assert.IsTrue(actual);
        }

        // see http://msdn.microsoft.com/en-us/library/ms173147(v=vs.80).aspx
        [TestMethod]
        public void EqualsReturnsTrueIfTwoCpfsAreReciprocal()
        {
            var cpf1 = Cpf.Parse("71402565860");
            var cpf2 = Cpf.Parse("71402565860");

            var actual = cpf1.Equals(cpf2) && cpf2.Equals(cpf1);

            Assert.IsTrue(actual);
        }

        // see http://msdn.microsoft.com/en-us/library/ms173147(v=vs.80).aspx
        [TestMethod]
        public void EqualsReturnsTrueIfThreeCpfsAreReciprocal()
        {
            var cpf1 = Cpf.Parse("71402565860");
            var cpf2 = Cpf.Parse("71402565860");
            var cpf3 = Cpf.Parse("71402565860");

            var actual = cpf1.Equals(cpf2) && cpf2.Equals(cpf3) && cpf1.Equals(cpf3);

            Assert.IsTrue(actual);
        }

        // see http://msdn.microsoft.com/en-us/library/ms173147(v=vs.80).aspx
        [TestMethod]
        public void EqualsReturnsFalseIfCpfIsNull()
        {
            var cpf = Cpf.Parse("71402565860");
            
            var actual = cpf.Equals(null);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void EqualsReturnsTrueIfCpfAreEqual()
        {
            var cpf1 = Cpf.Parse("71402565860");
            var cpf2 = Cpf.Parse("71402565860");

            var actual = cpf1.Equals(cpf2);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void EqualsReturnsTrueIfCpfAreEqualButWithDiffPunctuation()
        {
            var cpf1 = Cpf.Parse("71402565860");
            var cpf2 = Cpf.Parse("714.025.658-60", CpfPunctuation.Strict);

            var actual = cpf1.Equals(cpf2);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void EqualsReturnsFalseIfCpfAreNotEqual()
        {
            var cpf1 = Cpf.Parse("71402565860");
            var cpf2 = Cpf.Parse("77033192100");

            var actual = cpf1.Equals(cpf2);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void GetHashCodeReturnsTrueIfCpfAreEqual()
        {
            var hash1 = Cpf.Parse("71402565860").GetHashCode();
            var hash2 = Cpf.Parse("71402565860").GetHashCode();

            Assert.AreEqual<int>(hash1, hash2);
        }

        [TestMethod]
        public void GetHashCodeReturnsTrueIfCpfAreEqualButWithDiffPunctuation()
        {
            var hash1 = Cpf.Parse("71402565860").GetHashCode();
            var hash2 = Cpf.Parse("714.025.658-60").GetHashCode();

            Assert.AreEqual<int>(hash1, hash2);
        }

        [TestMethod]
        public void GetHashCodeReturnsFalseIfCpfAreNotEqual()
        {
            var hash1 = Cpf.Parse("71402565860").GetHashCode();
            var hash2 = Cpf.Parse("77033192100").GetHashCode();

            Assert.AreNotEqual<int>(hash1, hash2);
        }

        [TestMethod]
        public void ToStringReturnsStringWithNoPunctuationIfCpfPunctuationIsStrict()
        {
            var cpf = new Cpf("714.025.658-60", CpfPunctuation.Strict);

            var expected = "71402565860";
            var actual = cpf.ToString();

            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod]
        public void ToStringReturnsStringWithNoPunctuationIfCpfPunctuationIsLoose()
        {
            var cpf = new Cpf("71402565860");

            var expected = "71402565860";
            var actual = cpf.ToString();

            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod]
        public void TryParseReturnsFalseIfCpfIsInvalid()
        {
            Cpf cpf = null;

            var actual = Cpf.TryParse("71402565862", out cpf);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void TryParseReturnsTrueIfCpfIsValid()
        {
            Cpf cpf = null;

            var actual = Cpf.TryParse("71402565860", out cpf);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void StrictTryParseReturnsFalseIfCpfIsInvalid()
        {
            Cpf cpf = null;

            var actual = Cpf.TryParse("71402565860", out cpf, CpfPunctuation.Strict);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void StrictTryParseReturnsFalseIfCpfIsValid()
        {
            Cpf cpf = null;

            var actual = Cpf.TryParse("714.025.658-60", out cpf, CpfPunctuation.Strict);

            Assert.IsTrue(actual);
        }
    }
}
