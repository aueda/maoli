namespace Maoli.Benchmark
{
    using Maoli;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;

    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Test>();
        }
    }

    [ClrJob(baseline: true), CoreJob, CoreRtJob]
    [RPlotExporter, RankColumn]
    public class Test
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
