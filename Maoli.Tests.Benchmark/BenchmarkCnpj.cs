// Copyright (c) Adriano Ueda. All rights reserved.

namespace Maoli.Tests.Benchmark;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Maoli;

/// <summary>
/// Implements benchmarks for <see cref="Cnpj"/>.
/// </summary>
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net48)]
[MemoryDiagnoser]
[MarkdownExporterAttribute.GitHub]
[RankColumn]
public class BenchmarkCnpj
{
    /// <summary>
    /// Runs a benchmark to validate a strict valid CNPJ.
    /// </summary>
    /// <returns>
    /// The validation result.
    /// </returns>
    [Benchmark]
    public bool StrictValidCnpj() =>
        Cnpj.Validate("63.943.315/0001-92");

    /// <summary>
    /// Runs a benchmark to validate a strict invalid CNPJ.
    /// </summary>
    /// <returns>
    /// The validation result.
    /// </returns>
    [Benchmark]
    public bool StrictInvalidCnpj() =>
        Cnpj.Validate("32.343.315/0001-34");

    /// <summary>
    /// Runs a benchmark to validate a loose valid CNPJ.
    /// </summary>
    /// <returns>
    /// The validation result.
    /// </returns>
    [Benchmark]
    public bool LooseValidCnpj() =>
        Cnpj.Validate("63943315000192");

    /// <summary>
    /// Runs a benchmark to validate a loose invalid CNPJ.
    /// </summary>
    /// <returns>
    /// The validation result.
    /// </returns>
    [Benchmark]
    public bool LooseInvalidCnpj() =>
        Cnpj.Validate("32343315/000134");
}