# C#

## Difference between C# and .NET

C# is a programming language. When it is compiled it results in IL Code (Intermediate Language) which is independend of the machine it is running
.NET is a framework for application on Windows, it support other languages besides C#

## What is CLR (Common Language Runtime)?

CRL is an application that translates the IL Code (Intermediate Language) into Machine code through a process called Just-In-Time Compilation (JIT)

## Architecture of .NET Applications

Applications are organized in `classes` and as classes grow we organize related classes in contianers/gropus called `nemaspaces`.

As these namespaces grow need a different way to partition our application and there's where we use `Assemby` which is a file, in the form of a executable (EXE) or a DLL, that contains/groups one ore more namespaces and classes.

An EXE file represents a program that can be executed. A DLL is a file that includes code that can be re-used across different programs. 

When an application is compiled, the compiler build one or more `assemblies` depending on how the code is structured.

## Code

Every C# applications has a `program` class with a `Main` method which is the entry point of the app.