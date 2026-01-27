// Copyright (c) Adriano Ueda. All rights reserved.

namespace Maoli.Tests.Benchmark;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Maoli.Spellers;

/// <summary>
/// Implements benchmarks for <see cref="NumberSpeller"/>.
/// </summary>
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net48)]
[MemoryDiagnoser]
[MarkdownExporterAttribute.GitHub]
[RankColumn]
public sealed class BenchmarkNumberSpeller
{
    private NumberSpeller speller;

    /// <summary>
    /// Runs the global setup for the benchmarks.
    /// </summary>
    [GlobalSetup]
    public void Setup() =>
        this.speller = new NumberSpeller();

    /// <summary>
    /// Runs a benchmark to small number.
    /// </summary>
    [Benchmark]
    public void SpellSmallNumber() =>
        _ = this.speller.Spell(1L);

    /// <summary>
    /// Runs a benchmark to median number.
    /// </summary>
    [Benchmark]
    public void SpellMedianNumber() =>
        _ = this.speller.Spell(1000000000L);

    /// <summary>
    /// Runs a benchmark to big number.
    /// </summary>
    [Benchmark]
    public void SpellBigNumber() =>
        _ = this.speller.Spell(long.MaxValue);
}