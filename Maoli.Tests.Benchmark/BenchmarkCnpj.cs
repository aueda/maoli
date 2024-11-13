// Copyright (c) Adriano Ueda. All rights reserved.

namespace Maoli.Benchmark
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Jobs;
    using Maoli;

    [SimpleJob(RuntimeMoniker.Net90)]
    [SimpleJob(RuntimeMoniker.Net80)]
    [SimpleJob(RuntimeMoniker.Net48)]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    [RankColumn]
    public class BenchmarkCnpj
    {
        [Benchmark]
        public bool StrictValidCnpj() =>
            Cnpj.Validate("63.943.315/0001-92");

        [Benchmark]
        public bool StrictInvalidCnpj() =>
            Cnpj.Validate("32.343.315/0001-34");

        [Benchmark]
        public bool LooseValidCnpj() =>
            Cnpj.Validate("63943315000192");

        [Benchmark]
        public bool LooseInvalidCnpj() =>
            Cnpj.Validate("32343315/000134");
    }
}