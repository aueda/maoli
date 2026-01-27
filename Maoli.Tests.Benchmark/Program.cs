// Copyright (c) Adriano Ueda. All rights reserved.

namespace Maoli.Tests.Benchmark;

using BenchmarkDotNet.Running;

/// <summary>
/// Hosts the entry point for the application.
/// </summary>
public static class Program
{
    /// <summary>
    /// Defines the entry point for the application.
    /// </summary>
    /// <param name="args">
    /// The command line parameters.
    /// </param>
    public static void Main(
        string[] args)
    {
        _ = BenchmarkRunner.Run(typeof(Program).Assembly);
    }
}