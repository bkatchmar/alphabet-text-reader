# Introduction

IntegriDATA Exercise. The requirements of this are outlined in a PDF file. The PDF itself will be attached to this project.

# About this project

This project was created in Visual Studio Code with .NET Core as a C# Console Application. The first thing done to create this project was the command line:

```
dotnet new console
```

The basis of this project means that distribution depends on copying and pasting into an email. Therefore for simplicity only one `Program.cs` file will be developed for this.

The first thing to be noted as this program is designed to accept a string as a command line argument. Therefore, this program is run by commands such as:

```
dotnet run "pizza"
dotnet run "chicken" "salad"
```

In some cases, if more than one argument is provided, its ignored as the requirement to "accept a string" implies only one.

# Structure

While the delivery was communicated as "copy and paste the solution" and I rather have only one file for simplicity, that can be easily copied and pasted, that doesn't mean that I don't get to use other classes or interfaces. With that said, I settled on a simple structure of one interface and a class that implements it.

## interface ITextCharacterCounter

This interface defines what an implementation of this solution will contain. The concept here is what if instead of a solution that requires only alphabetical characters that disregard case, what if instead I want to include case, numbers, or other special characters? So when the console application consumes this solution, depending on the instance of the class, the solution can be independent of the output.

## class AlphabetCharacterCounter

The class used for this particular solution. Only counts alphabetical characters and disregards case. So "A" and "a" will be counted in the same category.

# Running and debugging

Examples that were tested with this are as follows:

```
dotnet run "pizza" "pepperoni"
```

I expect "pepperoni" to be ignored and only "Pizza" to be processed.

```
dotnet run "Cbb acCA"
dotnet run "numbers 8 and 9"
```
