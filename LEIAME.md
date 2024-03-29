# Maoli

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/1a4cff971e9c4380826bb3176a668a4d)](https://app.codacy.com/manual/aueda/maoli?utm_source=github.com&utm_medium=referral&utm_content=aueda/maoli&utm_campaign=Badge_Grade_Dashboard)
[![Coverage Status](https://coveralls.io/repos/github/aueda/maoli/badge.svg)](https://coveralls.io/github/aueda/maoli)
[![NuGet Version](https://img.shields.io/nuget/v/Maoli.svg)](https://www.nuget.org/packages/Maoli/)
[![Maoli on fuget.org](https://www.fuget.org/packages/Maoli/badge.svg)](https://www.fuget.org/packages/Maoli)
[![Junte-se ao bate-papo em https://gitter.im/maoli-net/community](https://badges.gitter.im/maoli-net/community.svg)](https://gitter.im/maoli-net/community?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
[![BuitlWithDot.Net shield](https://builtwithdot.net/project/143/maoli/badge)](https://builtwithdot.net/project/143/maoli)

Versão em inglês: [README.md](https://github.com/aueda/maoli/)

Maoli é uma biblioteca de regras de negócio brasileiras comuns,
compatível com .NET Framework 4.6+, .NET Core 1.0+ e .NET 5+.

Atualmente implementa:

*   Validação de CEP
*   Validação de CPF
*   Validação de CNPJ

Para validação em cliente, consulte [Maoli.js](https://github.com/aueda/maoli.js/).

## Documentação

### Cep

``Cep.Validate(string value)`` - valida se uma string é uma representação válida de CEP. Devolve true se o CEP é válido; caso contrário, false.

```c#
if (Cep.Validate("99999-999"))
{
  Console.WriteLine("CEP é válido");
}
```

### Cpf

``Cpf.Validate(string value)`` - valida se uma string é uma representação válida de CPF. Devolve true se o CPF é válido; caso contrário, false.

```c#
if (Cpf.Validate("999.999.99-99"))
{
  Console.WriteLine("CPF é válido");
}
```

``Cpf.Complete(string value)`` - completa uma string de CPF parcial concatenando um dígito verificador válido. Devolve uma string de CPF com um dígito verificador válido.

```c#
// devolve "99999999999"
var cpf = Cpf.Complete("99999999")); 
```

### Cnpj

``Cnpj.Validate(string value)`` - valida se uma string é uma representação válida de CNPJ. Devolve true se o CNPJ é válido; caso contrário, false.

```c#
if (Cnpj.Validate("99.999.999/9999-99"))
{
  Console.WriteLine("CPNJ é válido");
}
```
``Cnpj.Complete(string value)`` - completa uma string de CNPJ parcial concatenando um dígito verificador válido. Devolve uma string de CNPJ com um dígito verificador válido.

```c#
// devolve "99999999999999"
var cnpj = Cnpj.Complete("999999999999"));
```

### Number Speller

``NumberSpeller.Spell(int value)`` - retorna o número por extenso em português brasileiro.
O valor máximo é `int.MaxValue`.

```c#
var speller = new NumberSpeller();

var number = speller.Spell(2022);

// imprime "dois mil duzentos e vinte e dois"
Console.WriteLine(number);
```

``NumberSpeller.Spell(long value)`` - retorna o número por extenso em português brasileiro.
O valor máximo é `long.MaxValue`.

```c#
var speller = new NumberSpeller();

var number = speller.Spell(2022L);

// imprime "dois mil duzentos e vinte e dois"
Console.WriteLine(number);
```

## Pacote NuGet

Para instalar o Maoli usando o NuGet, execute o seguinte comando na linha de comando do console de Gerenciador de Pacotes:

```powershell
Install-Package Maoli
```

Veja o [website do NuGet](https://www.nuget.org/packages/Maoli/).

## .NET Fiddles

Os seguintes [.NET Fiddles](https://dotnetfiddle.net) estão disponíveis para testar o Maoli: 

*   Validação de CPF: [https://dotnetfiddle.net/7h7X00](https://dotnetfiddle.net/7h7X00)
*   Validação de CNPJ: [https://dotnetfiddle.net/IpEEmC](https://dotnetfiddle.net/IpEEmC)

## Código-fonte

O código-fonte está disponível em [GitHub](https://github.com/aueda/maoli/).

## Licença

Este projeto está sob a [licença MIT](http://opensource.org/licenses/MIT).

## Autor

Adriano Ueda [@adriueda](https://twitter.com/adriueda)
