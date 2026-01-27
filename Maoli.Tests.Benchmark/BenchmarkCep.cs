// Copyright (c) Adriano Ueda. All rights reserved.

namespace Maoli.Tests.Benchmark;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Maoli;

/// <summary>
/// Implements benchmarks for <see cref="Cep"/>.
/// </summary>
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net48)]
[MemoryDiagnoser]
[MarkdownExporterAttribute.GitHub]
[RankColumn]
public class BenchmarkCep
{
    /// <summary>
    /// Runs a benchmark to validate a strict valid CEP.
    /// </summary>
    /// <returns>
    /// The validation result.
    /// </returns>
    [Benchmark]
    public bool StrictValidCep() =>
        Cep.Validate("01234-001");

    /// <summary>
    /// Runs a benchmark to validate a strict invalid CEP.
    /// </summary>
    /// <returns>
    /// The validation result.
    /// </returns>
    [Benchmark]
    public bool StrictInvalidCep() =>
        Cep.Validate("12e45-678");

    /// <summary>
    /// Runs a benchmark to validate a loose valid CEP.
    /// </summary>
    /// <returns>
    /// The validation result.
    /// </returns>
    [Benchmark]
    public bool LooseValidCep() =>
        Cep.Validate("012e6501");

    /// <summary>
    /// Runs a benchmark to validate a loose invalid CEP.
    /// </summary>
    /// <returns>
    /// The validation result.
    /// </returns>
    [Benchmark]
    public bool LooseInvalidCep() =>
        Cep.Validate("012e501");
}