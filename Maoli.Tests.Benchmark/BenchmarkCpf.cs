// Copyright (c) Adriano Ueda. All rights reserved.

namespace Maoli.Benchmark
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Jobs;
    using Maoli;

    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [SimpleJob(RuntimeMoniker.Net60)]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    [RankColumn]
    public class BenchmarkCpf
    {
        [Benchmark]
        public bool StrictValidCpf() =>
            Cpf.Validate("714.025.658-60");

        [Benchmark]
        public bool StrictInvalidCpf() =>
            Cpf.Validate("825.136.769-32");

        [Benchmark]
        public bool LooseValidCpf() =>
            Cpf.Validate("71402565860");

        [Benchmark]
        public bool LooseInvalidCpf() =>
            Cpf.Validate("82513676932");
    }
}