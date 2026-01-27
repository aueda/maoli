// Copyright (c) Adriano Ueda. All rights reserved.

namespace Maoli.Tests.Benchmark;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Maoli;

/// <summary>
/// Implements benchmarks for <see cref="Cpf"/>.
/// </summary>
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net48)]
[MemoryDiagnoser]
[MarkdownExporterAttribute.GitHub]
[RankColumn]
public class BenchmarkCpf
{
    /// <summary>
    /// Runs a benchmark to validate a strict valid CPF.
    /// </summary>
    /// <returns>
    /// The validation result.
    /// </returns>
    [Benchmark]
    public bool StrictValidCpf() =>
        Cpf.Validate("714.025.658-60");

    /// <summary>
    /// Runs a benchmark to validate a strict invalid CPF.
    /// </summary>
    /// <returns>
    /// The validation result.
    /// </returns>
    [Benchmark]
    public bool StrictInvalidCpf() =>
        Cpf.Validate("825.136.769-32");

    /// <summary>
    /// Runs a benchmark to validate a loose valid CPF.
    /// </summary>
    /// <returns>
    /// The validation result.
    /// </returns>
    [Benchmark]
    public bool LooseValidCpf() =>
        Cpf.Validate("71402565860");

    /// <summary>
    /// Runs a benchmark to validate a loose invalid CPF.
    /// </summary>
    /// <returns>
    /// The validation result.
    /// </returns>
    [Benchmark]
    public bool LooseInvalidCpf() =>
        Cpf.Validate("82513676932");
}