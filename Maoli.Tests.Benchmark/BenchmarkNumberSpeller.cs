// Copyright (c) Adriano Ueda. All rights reserved.

namespace Maoli.Benchmark
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Jobs;
    using Maoli.Spellers;

    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net48)]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    [RankColumn]
    public class BenchmarkNumberSpeller
    {
        [Benchmark]
        public void SpellSmallNumber()
        {
            var speller = new NumberSpeller();

            _ = speller.Spell(1L);
        }

        [Benchmark]
        public void SpellMedianNumber()
        {
            var speller = new NumberSpeller();

            _ = speller.Spell(1000000000L);
        }

        [Benchmark]
        public void SpellBigNumber()
        {
            var speller = new NumberSpeller();

            _ = speller.Spell(long.MaxValue);
        }
    }
}