// Copyright (c) Adriano Ueda. All rights reserved.

namespace Maoli.Benchmark
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Jobs;
    using Maoli;

    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [SimpleJob(RuntimeMoniker.Net80)]
    [SimpleJob(RuntimeMoniker.Net70)]
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net50)]
    [SimpleJob(RuntimeMoniker.Net48)]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    [RankColumn]
    public class BenchmarkCep
    {
        [Benchmark]
        public bool StrictValidCep() =>
            Cep.Validate("01234-001");

        [Benchmark]
        public bool StrictInvalidCep() =>
            Cep.Validate("12e45-678");

        [Benchmark]
        public bool LooseValidCep() =>
            Cep.Validate("012e6501");

        [Benchmark]
        public bool LooseInvalidCep() =>
            Cep.Validate("012e501");
    }
}