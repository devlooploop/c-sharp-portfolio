# C# Portfolio

![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=flat&logo=dotnet&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91?style=flat&logo=visualstudio&logoColor=white)
![GitHub](https://img.shields.io/badge/GitHub-181717?style=flat&logo=github&logoColor=white)
![Status](https://img.shields.io/badge/Status-Active-brightgreen)
![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)

A collection of **C# projects** demonstrating fundamental programming concepts such as **object-oriented programming (OOP)**, **encapsulation**, **error handling**, **chainable operations**, and **console I/O**.

---

## 📁 Repository Structure

```text
c-sharp-portfolio/
├── 01-Calculator-cs/
│   └── Calculator.cs
│
├── README.md
└── LICENSE
```

---

## 🚀 Featured Projects

### 01 – Chainable Calculator

A simple yet powerful **console-based calculator** that maintains a running total, allowing chained arithmetic operations.

**Highlights:**

- Supports **Addition, Subtraction, Multiplication**, and **Division**
- Tracks the last operation and number used for meaningful output
- Graceful handling of division by zero (replaces 0 with 1 to avoid exceptions)
- Clear() method to reset the calculator
- Private fields with full encapsulation
- Demo in Main() shows full usage flow, including error case

**Skills practiced:**  
Object-oriented design, private encapsulation, method chaining logic, basic error handling, interpolated strings, and console output.

---

## 🛠️ How to Run the Code

### Using Visual Studio (Recommended - Windows)

1. Open SourceFile.cs or the folder as a project
2. Build and run (Ctrl + F5)

### Using Visual Studio Code with .NET SDK

1. Install .NET SDK if not already installed
2. Open terminal in the project folder
3. Run:

```bash
dotnet new console -o TempCalc   # (optional: create a project)
# Or just:
dotnet run --project path/to/your/project   # if you have a .csproj
# For single file:
dotnet run Calculator.cs
```

### Using dotnet CLI (single file)

1. Install .NET SDK if not already installed
2. Open terminal in the project folder
3. Run:

```bash
dotnet new console -n CalculatorDemo
copy Calculator.cs Program.cs   # replace the default Program.cs
dotnet run
```

---

## 📜 License

This project is released under the **MIT License**.  
See the `LICENSE` file for more details.

⭐ **Star this repository** if you find it helpful!
