``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.2006/21H2/November2021Update)
Intel Core i7-2670QM CPU 2.20GHz (Sandy Bridge), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.100-preview.6.22352.1
  [Host]   : .NET 7.0.0 (7.0.22.32404), X64 RyuJIT AVX
  .NET 7.0 : .NET 7.0.0 (7.0.22.32404), X64 RyuJIT AVX

Job=.NET 7.0  Runtime=.NET 7.0  

```
|            Method |       Mean |     Error |    StdDev |     Median | Rank | Allocated |
|------------------ |-----------:|----------:|----------:|-----------:|-----:|----------:|
|   StrictValidCnpj | 112.704 ns | 2.0206 ns | 4.2178 ns | 112.012 ns |    4 |         - |
| StrictInvalidCnpj | 106.121 ns | 2.1581 ns | 2.8810 ns | 105.372 ns |    3 |         - |
|    LooseValidCnpj | 101.879 ns | 2.0135 ns | 4.9768 ns | 100.296 ns |    2 |         - |
|  LooseInvalidCnpj |   5.806 ns | 0.1702 ns | 0.2843 ns |   5.757 ns |    1 |         - |
