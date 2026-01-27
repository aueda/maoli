// Copyright (c) Adriano Ueda. All rights reserved.

namespace Maoli.Tests;

using System;
using Maoli;
using Xunit;

/// <summary>
/// Implements tests for <see cref="Cep"/>.
/// </summary>
public sealed class CepTest
{
    /// <summary>
    /// Tests if <see cref="Cep"/> sets the
    /// punctuation correctly.
    /// </summary>
    [Fact]
    public void CepConstructorSetsPunctuation()
    {
        var cep = new Cep("01234-001", CepPunctuation.Strict);

        var expected = CepPunctuation.Strict;

        var actual = cep.Punctuation;

        Assert.Equal(expected, actual);
    }

    /// <summary>
    /// Tests if <see cref="Cep"/> creates the
    /// instance correctly.
    /// </summary>
    [Fact]
    public void CepConstructorCreatesCepIfPunctuationIsStrict()
    {
        var cep = new Cep("01234-001", CepPunctuation.Strict);

        Assert.NotNull(cep);
    }

    /// <summary>
    /// Tests if <see cref="Cep"/> creates the
    /// instance correctly.
    /// </summary>
    [Fact]
    public void CepConstructorCreatesCepIfPunctuationIsLoose()
    {
        var cep = new Cep("01234-001");

        Assert.NotNull(cep);
    }

    /// <summary>
    /// Tests if <see cref="Cep"/> throws an exception if the
    /// CEP is null.
    /// </summary>
    [Fact]
    public void CepConstructorThrowsExceptionIfCepIsNull()
    {
        Assert.Throws<ArgumentException>(
            () =>
            {
#nullable disable
                _ = new Cep(value: null);
#nullable restore
            });
    }

    /// <summary>
    /// Tests if <see cref="Cep"/> throws an exception if the
    /// CEP is empty.
    /// </summary>
    [Fact]
    public void CepConstructorThrowsExceptionIfCepIsEmpty()
    {
        Assert.Throws<ArgumentException>(
            () =>
            {
                _ = new Cep(string.Empty);
            });
    }

    /// <summary>
    /// Tests if <see cref="Cep"/> throws an exception if the
    /// CEP is loose and invalid.
    /// </summary>
    [Fact]
    public void CepConstructorThrowsExceptionIfCepIsInvalidAndLoose()
    {
        Assert.Throws<ArgumentException>(
            () =>
            {
                _ = new Cep("012e501", CepPunctuation.Loose);
            });
    }

    /// <summary>
    /// Tests if <see cref="Cep"/> throws an exception if the
    /// CEP is strict and invalid.
    /// </summary>
    [Fact]
    public void CepConstructorThrowsExceptionIfCepIsInvalidAndStrict()
    {
        Assert.Throws<ArgumentException>(
            () =>
            {
                _ = new Cep("01234001", CepPunctuation.Strict);
            });
    }

    /// <summary>
    /// Tests if <see cref="Cep.Validate(string)"/>
    /// validates a valid loose CEP correctly.
    /// </summary>
    [Fact]
    public void CepValidateReturnsTrueIfCepIsLooseAndValid()
    {
        var actual = Cep.Validate("12345678");

        Assert.True(actual);
    }

    /// <summary>
    /// Tests if <see cref="Cep.Validate(string)"/>
    /// validates an invalid loose CEP correctly.
    /// </summary>
    /// <param name="value">
    /// The CEP value.
    /// </param>
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("12345")]
    [InlineData("1234567890")]
    [InlineData("123-5678")]
    [InlineData("013s3-9b1")]
    public void CepValidateReturnsFalseIfCepIsLooseAndInvalid(
        string? value)
    {
#nullable disable
        var actual = Cep.Validate(value: value);
#nullable restore

        Assert.False(actual);
    }

    /// <summary>
    /// Tests if <see cref="Cep.Validate(string)"/>
    /// validates a valid strict CEP correctly.
    /// </summary>
    [Fact]
    public void CepValidateReturnsTrueIfCepIsStrictAndValid()
    {
        var actual = Cep.Validate(
            "12345-678",
            CepPunctuation.Strict);

        Assert.True(actual);
    }

    /// <summary>
    /// Tests if <see cref="Cep.Validate(string)"/>
    /// validates an invalid strict CEP correctly.
    /// </summary>
    /// <param name="value">
    /// The CEP value.
    /// </param>
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("32341-3d3")]
    [InlineData("12345678")]
    public void CepValidateReturnsFalseIfCepIsStrictAndInvalid(
        string? value)
    {
#nullable disable
        var actual = Cep.Validate(
            value: value,
            CepPunctuation.Strict);
#nullable restore

        Assert.False(actual);
    }
}