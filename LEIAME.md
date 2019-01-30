# Maoli

[![Build Status](https://travis-ci.org/aueda/maoli.svg?branch=master)](https://travis-ci.org/aueda/maoli/)
[![NuGet Version](https://img.shields.io/nuget/v/Maoli.svg)](https://www.nuget.org/packages/Maoli/)
[![Maoli on fuget.org](https://www.fuget.org/packages/Maoli/badge.svg)](https://www.fuget.org/packages/Maoli)
[![Junte-se ao bate-papo em https://gitter.im/maoli-net/community](https://badges.gitter.im/maoli-net/community.svg)](https://gitter.im/maoli-net/community?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

Versão em inglês: [README.md](https://github.com/aueda/maoli/)

Maoli é uma biblioteca de regras de negócio brasileiras comuns, compatível com .NET Framework 4.0 e superior.

Atualmente implementa:

* Validação de CEP
* Validação de CPF
* Validação de CNPJ

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

## Pacote NuGet

Para instalar o Maoli usando o NuGet, execute o seguinte comando na linha de comando do console de Gerenciador de Pacotes:

```
Install-Package Maoli
```

Veja o [website do NuGet](https://www.nuget.org/packages/Maoli/).

## Código-fonte

O código-fonte está disponível em [GitHub](https://github.com/aueda/maoli/).

## Licença

Este projeto está sob a [licença MIT](http://opensource.org/licenses/MIT).

## Autor

Adriano Ueda [@adriueda](https://twitter.com/adriueda)