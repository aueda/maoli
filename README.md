# Maoli

[![Build Status](https://travis-ci.org/aueda/maoli.svg?branch=master)](https://travis-ci.org/aueda/maoli/)
[![Coverage Status](https://coveralls.io/repos/github/aueda/maoli/badge.svg)](https://coveralls.io/github/aueda/maoli)
[![NuGet Version](https://img.shields.io/nuget/v/Maoli.svg)](https://www.nuget.org/packages/Maoli/)
[![Maoli no fuget.org](https://www.fuget.org/packages/Maoli/badge.svg)](https://www.fuget.org/packages/Maoli)
[![Join the chat at https://gitter.im/maoli-net/community](https://badges.gitter.im/maoli-net/community.svg)](https://gitter.im/maoli-net/community?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
[![BuitlWithDot.Net shield](https://builtwithdot.net/project/143/maoli/badge)](https://builtwithdot.net/project/143/maoli)

Versão em português: [LEIAME.md](https://github.com/aueda/maoli/blob/master/LEIAME.md)

Maoli is a C# helper library for common Brazilian business rules (CEP, CPF and CNPJ),
compatible with .NET Framework 4.0 and above.

Currently implements:

*   CEP validation
*   CPF validation
*   CNPJ validation

For client-side validation of CPF and CNPJ, please see [Maoli.js](https://github.com/aueda/maoli.js/).

## Documentation

### Cep

``Cep.Validate(string value)`` - checks if a string value is a valid CEP representation. Returns true if CEP string is valid; false otherwise.

```c#
if (Cep.Validate("99999-999"))
{
  Console.WriteLine("CEP is valid");
}
```

### Cpf

``Cpf.Validate(string value)`` - checks if a string value is a valid CPF representation. Returns true if CPF string is valid; false otherwise.

```c#
if (Cpf.Validate("999.999.99-99"))
{
  Console.WriteLine("CPF is valid");
}
```

``Cpf.Complete(string value)`` - completes a partial CPF string by appending a valid checksum trailing.
Returns a CPF string with a valid checksum trailing.

```c#
// outputs "99999999999"
var cpf = Cpf.Complete("99999999"));
```

### Cnpj

``Cnpj.Validate(string value)`` - checks if a string value is a valid CNPJ representation. Returns true if CNPJ string is valid; false otherwise.

```c#
if (Cnpj.Validate("99.999.999/9999-99"))
{
  Console.WriteLine("CPNJ is valid");
}
```
``Cnpj.Complete(string value)`` - completes a partial CNPJ string by appending a valid checksum trailing.
Returns a CNPJ string with a valid checksum trailing.

```c#
// outputs "99999999999999"
var cnpj = Cnpj.Complete("999999999999"));
```

## NuGet Package

To install Maoli using NuGet, run the following command in the Package Manager Console:

```
Install-Package Maoli
```

See the [NuGet website](https://www.nuget.org/packages/Maoli/).

## .NET Fiddles

The following [.NET Fiddles](https://dotnetfiddle.net) are available to test Maoli: 

* CPF validation: [https://dotnetfiddle.net/7h7X00](https://dotnetfiddle.net/7h7X00)
* CNPJ validation: [https://dotnetfiddle.net/IpEEmC](https://dotnetfiddle.net/IpEEmC)

## Source Code

Source code is available at [GitHub](https://github.com/aueda/maoli/).

## License

This project is licensed under the [MIT License](http://opensource.org/licenses/MIT).

## Author

Adriano Ueda [@adriueda](https://twitter.com/adriueda)
