// Copyright (c) Adriano Ueda. All rights reserved.

namespace Maoli.Tests.Benchmark
{
    using BenchmarkDotNet.Running;

    public class Program
    {
        public static void Main(
            string[] args)
        {
            _ = 
                BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}