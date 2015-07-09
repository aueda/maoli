//-----------------------------------------------------------------------
// <copyright file="AssemblyInfo.cs" company="Adriano Ueda">
//     Copyright (C) Adriano Ueda. All rights reserved.
// </copyright>
// <author>Adriano Ueda</author>
//-----------------------------------------------------------------------

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Maoli")]
[assembly: AssemblyDescription("Maoli is C# helper library for common brazilian business rules (CPF and CNPJ).")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Adriano Ueda")]
[assembly: AssemblyProduct("Maoli")]
[assembly: AssemblyCopyright("Copyright © Adriano Ueda 2013")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("e40b6c4b-f18f-43e0-b877-bd3721200a4d")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("0.2.5")]
#if NET35
[assembly: AssemblyInformationalVersion("0.2.5-net35")]
#else
#if NET40
[assembly: AssemblyInformationalVersion("0.2.5-net40")]
#else
#if NET45
[assembly: AssemblyInformationalVersion("0.2.5-net45")]
#else
#if NET451
[assembly: AssemblyInformationalVersion("0.2.5-net451")]
#else
[assembly: AssemblyInformationalVersion("0.2.5-other")]
#endif
#endif
#endif
#endif

[assembly: AssemblyFileVersion("0.2.5")]