﻿// Copyright (c) Adriano Ueda. All rights reserved.

namespace Maoli.Benchmark
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Jobs;
    using Maoli.Spellers;

    [SimpleJob(RuntimeMoniker.Net90)]
    [SimpleJob(RuntimeMoniker.Net80)]
    [SimpleJob(RuntimeMoniker.Net48)]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    [RankColumn]
    public class BenchmarkNumberSpeller
    {
        public NumberSpeller speller;

        [GlobalSetup]
        public void Setup() =>
            speller = new NumberSpeller();

        [Benchmark]
        public void SpellSmallNumber() =>
            _ = speller.Spell(1L);

        [Benchmark]
        public void SpellMedianNumber() =>
            _ = speller.Spell(1000000000L);
 
        [Benchmark]
        public void SpellBigNumber() =>
            _ = speller.Spell(long.MaxValue);
    }
}