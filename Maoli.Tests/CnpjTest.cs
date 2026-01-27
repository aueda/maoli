// Copyright (c) Adriano Ueda. All rights reserved.

namespace Maoli.Tests;

using System;
using System.Globalization;
using System.Threading;
using Maoli;
using Xunit;

/// <summary>
/// Implements tests for <see cref="Cnpj"/>.
/// </summary>
public sealed class CnpjTest
{
    private const string LooseValidCnpj = "63943315000192";

    private const string LooseInvalidCnpj = "32343315/000134";

    private const string StrictValidCnpj = "63.943.315/0001-92";

    private const string StrictInvalidCnpj = "32.343.315/0001-34";

    /// <summary>
    /// Tests if <see cref="Cnpj.Parse(string, CnpjPunctuation)"/> sets the
    /// punctuation correctly.
    /// </summary>
    /// <param name="cnpjPunctuation">
    /// The CNPJ punctuation.
    /// </param>
    [Theory]
    [InlineData(CnpjPunctuation.Strict)]
    [InlineData(CnpjPunctuation.Loose)]
    public void CnpjPunctuationReturnsThePunctuationCorrectly(
        CnpjPunctuation cnpjPunctuation)
    {
        var cnpj = Cnpj.Parse(CnpjTest.StrictValidCnpj, cnpjPunctuation);
        var expected = cnpjPunctuation;
        var actual = cnpj.Punctuation;

        Assert.Equal<CnpjPunctuation>(expected, actual);
    }

    [Theory]
    [InlineData(CnpjTest.LooseValidCnpj)]
    [InlineData(CnpjTest.StrictValidCnpj)]
    public void CnpjLooseParseReturnsACnpjObjectIfCnpjIsValid(
        string cnpjAsString)
    {
        var cnpj = Cnpj.Parse(cnpjAsString);

        Assert.NotNull(cnpj);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(CnpjTest.LooseInvalidCnpj)]
    public void CnpjLooseParseThrowsArgumentExceptionIfCnpjIsNotValid(
        string? cnpjAsString)
    {
        Assert.Throws<ArgumentException>(() =>
        {
#nullable disable
            _ = Cnpj.Parse(cnpjAsString);
#nullable restore
        });
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(CnpjTest.LooseValidCnpj)]
    public void CnpjStrictParseThrowsArgumentExceptionACnpjObjectIfCnpjIsInvalidAndStrict(
        string? cnpjAsString)
    {
        Assert.Throws<ArgumentException>(() =>
        {
#nullable disable
            _ = Cnpj.Parse(cnpjAsString, CnpjPunctuation.Strict);
#nullable restore
        });
    }

    [Theory]
    [InlineData(CnpjTest.StrictValidCnpj)]
    public void CnpjStrictParseReturnsACnpjObjectIfFormattedCnpjIsValidAndStrict(
        string cnpjAsString)
    {
        var cnpj = Cnpj.Parse(cnpjAsString, CnpjPunctuation.Strict);

        Assert.NotNull(cnpj);
    }

    [Fact]
    public void CnpjValidateReturnsTrueIfCnpjIsValid()
    {
        var actual = Cnpj.Validate(CnpjTest.LooseValidCnpj);

        Assert.True(actual);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(CnpjTest.LooseInvalidCnpj)]
    [InlineData("6e9433l5000192")]
    public void CnpjValidateReturnsFalseIfCnpjIsInvalid(
        string? cnpjAsString)
    {
#nullable disable
        var actual = Cnpj.Validate(cnpjAsString);
#nullable restore

        Assert.False(actual);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("714o256s8")]
    [InlineData("12345678901234567890")]
    [InlineData("LooseValidCnpj")]
    [InlineData(CnpjTest.StrictInvalidCnpj)]
    public void CnpjStrictValidateReturnsFalseIfCnpjIsInvalidAndStrict(
        string? cnpjAsString)
    {
#nullable disable
        var actual = Cnpj.Validate(cnpjAsString, CnpjPunctuation.Strict);
#nullable restore

        Assert.False(actual);
    }

#if NET40 || NET45
    [Fact]
    public void ValidateReturnsTrueIfCnpjIsValidAndStrict()
#else
    [Theory]
    [InlineData("04.581.245/0001-00")]
    [InlineData("73.693.087/0001-01")]
    [InlineData("22.678.874/0001-35")]
    [InlineData("63.943.315/0001-92")]
    public void CnpjValidateReturnsTrueIfCnpjIsValidAndStrict(
        string strictCnpjString)
#endif
    {
#if NET40 || NET45
        var actual = Cnpj.Validate(CnpjTest.strictValidCnpj, CnpjPunctuation.Strict);
#else
        var actual = Cnpj.Validate(strictCnpjString, CnpjPunctuation.Strict);
#endif

        Assert.True(actual);
    }

    [Fact]
    public void CnpjValidateReturnsFalseIfCnpjIsHalfPunctuatedAndValidAndLoose()
    {
        var actual = Cnpj.Validate("63.9433150001-92", CnpjPunctuation.Loose);

        Assert.False(actual);
    }

#if NET40 || NET45
#pragma warning disable xUnit2006
    [Fact]
    public void CompleteReturnsAValidCnpj()
    {
        var actual = Cnpj.Complete("639433150001");

        Assert.Equal(CnpjTest.looseValidCnpj, actual);
    }
#pragma warning restore xUnit2006
#else
    [Theory]
    [InlineData("045812450001", "04581245000100")]
    [InlineData("736930870001", "73693087000101")]
    [InlineData("639433150001", "63943315000192")]
    public void CnpjCompleteReturnsAValidCnpj(
        string cnpjString,
        string expectedCnpjString)
    {
        var actual = Cnpj.Complete(cnpjString);

        Assert.Equal(expectedCnpjString, actual);
    }
#endif

#if NET40 || NET45
#pragma warning disable xUnit2006
    [Fact]
    public void CompleteReturnsAValidCnpjIfHasPunctuaction()
    {
        var actual = Cnpj.Complete("63.943.315/0001");

        Assert.Equal(CnpjTest.looseValidCnpj, actual);
    }
#pragma warning restore xUnit2006
#else
    [InlineData("04.581.245/0001", "04581245000100")]
    [InlineData("63.943.315/0001", "63943315000192")]
    [Theory]
    public void CnpjCompleteReturnsAValidCnpjIfHasPunctuaction(
        string cnpjString,
        string expectedCnpj)
    {
        var actual = Cnpj.Complete(cnpjString);

        Assert.Equal(expectedCnpj, actual);
    }
#endif

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("714o256s8")]
    [InlineData("6e9433l5o001")]
    public void CnpjCompleteThrowsArgumentExceptionIfCnpjIsInvalid(
        string? partialCnpjAsString)
    {
        Assert.Throws<ArgumentException>(() =>
        {
#nullable disable
            _ = Cnpj.Complete(partialCnpjAsString);
#nullable restore
        });
    }

    // see http://msdn.microsoft.com/en-us/library/ms173147(v=vs.80).aspx
    [Fact]
    public void CnpjEqualsReturnsTrueIfSameCnpjIsEqual()
    {
        var cnpj = Cnpj.Parse(LooseValidCnpj);

        var actual = cnpj.Equals(cnpj);

        Assert.True(actual);
    }

    // see http://msdn.microsoft.com/en-us/library/ms173147(v=vs.80).aspx
    [Fact]
    public void CnpjEqualsReturnsTrueIfTwoCnpjsAreReciprocal()
    {
        var cnpj1 = Cnpj.Parse(LooseValidCnpj);
        var cnpj2 = Cnpj.Parse(LooseValidCnpj);

        var actual = cnpj1.Equals(cnpj2) && cnpj2.Equals(cnpj1);

        Assert.True(actual);
    }

    // see http://msdn.microsoft.com/en-us/library/ms173147(v=vs.80).aspx
    [Fact]
    public void CnpjEqualsReturnsTrueIfThreeCnpjsAreReciprocal()
    {
        var cnpj1 = Cnpj.Parse(LooseValidCnpj);
        var cnpj2 = Cnpj.Parse(LooseValidCnpj);
        var cnpj3 = Cnpj.Parse(LooseValidCnpj);

        var actual = cnpj1.Equals(cnpj2) && cnpj2.Equals(cnpj3) && cnpj1.Equals(cnpj3);

        Assert.True(actual);
    }

    // see http://msdn.microsoft.com/en-us/library/ms173147(v=vs.80).aspx
    [Fact]
    public void CnpjEqualsReturnsFalseIfCnpjIsNull()
    {
        var cnpj = Cnpj.Parse(LooseValidCnpj);

        var actual = cnpj.Equals(null);

        Assert.False(actual);
    }

    [Fact]
    public void CnpjEqualsReturnsTrueIfCnpjAreEqual()
    {
        var cnpj1 = Cnpj.Parse(LooseValidCnpj);
        var cnpj2 = Cnpj.Parse(LooseValidCnpj);

        var actual = cnpj1.Equals(cnpj2);

        Assert.True(actual);
    }

    [Fact]
    public void CnpjEqualsReturnsTrueIfCnpjAreEqualButWithDiffPunctuation()
    {
        var cnpj1 = Cnpj.Parse(LooseValidCnpj);
        var cnpj2 = Cnpj.Parse(StrictValidCnpj, CnpjPunctuation.Strict);

        var actual = cnpj1.Equals(cnpj2);

        Assert.True(actual);
    }

    [Fact]
    public void CnpjEqualsReturnsFalseIfCnpjAreNotEqual()
    {
        var cnpj1 = Cnpj.Parse(LooseValidCnpj);
        var cnpj2 = Cnpj.Parse("71418811000155");

        var actual = cnpj1.Equals(cnpj2);

        Assert.False(actual);
    }

    [Fact]
    public void CnpjEqualsReturnsTrueIfCnpjAreEqualAndObject()
    {
        object cnpj1 = Cnpj.Parse(LooseValidCnpj);
        var cnpj2 = Cnpj.Parse(LooseValidCnpj);

        var actual = cnpj2.Equals(cnpj1);

        Assert.True(actual);
    }

    [Fact]
    public void CnpjEqualsReturnsTrueIfCnpjAreNotEqualAndObject()
    {
        object cnpj1 = Cnpj.Parse(LooseValidCnpj);
        var cnpj2 = Cnpj.Parse("71418811000155");

        var actual = cnpj2.Equals(cnpj1);

        Assert.False(actual);
    }

    [Fact]
    public void CnpjGetHashCodeAreEqualIfTwoCnpjAreEqual()
    {
        var hash1 = Cnpj.Parse(LooseValidCnpj).GetHashCode();
        var hash2 = Cnpj.Parse(LooseValidCnpj).GetHashCode();

        Assert.Equal<int>(hash1, hash2);
    }

    [Fact]
    public void CnpjGetHashCodeReturnsTrueIfCnpjAreEqualButWithDiffPunctuation()
    {
        var hash1 = Cnpj.Parse(LooseValidCnpj).GetHashCode();
        var hash2 = Cnpj.Parse(StrictValidCnpj).GetHashCode();

        Assert.Equal<int>(hash1, hash2);
    }

    [Fact]
    public void CnpjGetHashCodeReturnsFalseIfTwoCnpjAreNotEqual()
    {
        var hash1 = Cnpj.Parse(LooseValidCnpj).GetHashCode();
        var hash2 = Cnpj.Parse("71418811000155").GetHashCode();

        Assert.NotEqual<int>(hash1, hash2);
    }

    [Fact]
    public void CnpjToStringReturnsStringWithNoPunctuationIfCnpjPunctuationIsStrict()
    {
        var cnpj = new Cnpj(StrictValidCnpj, CnpjPunctuation.Strict);

        var expected = LooseValidCnpj;
        var actual = cnpj.ToString();

#if NET40 || NET45
#pragma warning disable xUnit2006
#endif

        Assert.Equal(expected, actual);

#if NET40 || NET45
#pragma warning restore xUnit2006
#endif
    }

    [Fact]
    public void CnpjToStringReturnsStringWithNoPunctuationIfCnpjPunctuationIsLoose()
    {
        var cnpj = new Cnpj(LooseValidCnpj);

        var expected = LooseValidCnpj;
        var actual = cnpj.ToString();

#if NET40 || NET45
#pragma warning disable xUnit2006
#endif

        Assert.Equal(expected, actual);

#if NET40 || NET45
#pragma warning restore xUnit2006
#endif
    }

    [Fact]
    public void CnpjTryParseReturnsFalseIfCnpjIsInvalid()
    {
        var actual = Cnpj.TryParse(LooseInvalidCnpj, out var cnpj);

        Assert.False(actual);
        Assert.Null(cnpj);
    }

    [Fact]
    public void CnpjTryParseReturnsTrueIfCnpjIsValid()
    {
        var actual = Cnpj.TryParse(LooseValidCnpj, out var cnpj);

        Assert.True(actual);
        Assert.NotNull(cnpj);
    }

    [Fact]
    public void CnpjStrictTryParseReturnsFalseIfCnpjIsInvalid()
    {
        var actual = Cnpj.TryParse(
            LooseInvalidCnpj,
            out var cnpj,
            CnpjPunctuation.Strict);

        Assert.False(actual);
        Assert.Null(cnpj);
    }

    [Fact]
    public void CnpjStrictTryParseReturnsTrueIfCnpjIsValidAndHasPunctuation()
    {
        var actual = Cnpj.TryParse(
            StrictValidCnpj,
            out var cnpj,
            CnpjPunctuation.Strict);

        Assert.True(actual);
        Assert.NotNull(cnpj);
    }
}