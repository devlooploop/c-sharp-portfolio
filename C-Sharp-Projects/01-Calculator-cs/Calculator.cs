/*
                   =================================================
                                Simple Calculator Class 
                   =================================================

Requirements / Features Implemented:

1. Create a Calculator class that maintains an internal running result.

2. Support the four basic arithmetic operations:
   - Addition
   - Subtraction
   - Multiplication
   - Division

3. Each operation should:
   - Accept a float number as input
   - Update the internal result accordingly
   -Remember the last operation name and the last number used (for printing)

4. Handle division by zero gracefully (prevent crash/exception).
   - In this implementation, dividing by zero is ignored (no change to result).

5. Provide a Clear() method to reset the calculator to initial state (result = 0).

6. Provide a method to print the current result along with the last operation performed.
   Format example: "Result After Adding 10 is: 10"

7. The class should be reusable and encapsulate all data privately.

8. Include a main() function demonstrating usage with a sequence of operations,
   including an attempt to divide by zero to show error handling.

Additional Notes:
- Uses float for decimal support
- All data members are private (good encapsulation)
- Simple and clean design suitable for a beginner/intermediate C++ portfolio
- No external libraries required (only <iostream> and <string>)

*/


using System;

public class clsCalculator
{

    private float _LastNumber = 0;
    private float _Result = 0;
    private string _MathOpsName = string.Empty;

    public void Add(float Num)
    {
        _MathOpsName = "Adding";
        _LastNumber = Num;
        _Result += Num;
    }
    public void Multiply(float Num)
    {
        _MathOpsName = "Multiplying";
        _LastNumber = Num;
        _Result *= Num;
    }
    public void Subtruct(float Num)
    {
         _MathOpsName = "Subtructing";
         _LastNumber = Num;
         _Result -= Num;
    }
    public void Divide(float Num)
    {
         _MathOpsName = "Dividing";
         _LastNumber = Num;

         Num = (Num == 0) ? 1 : Num; // to fix "0" exception
         _Result /= Num;
    }

    public void Clear()
    {
        _MathOpsName = "Clear";
        _Result = 0;
        _LastNumber = 0;
    }

    public void PrintResult()
    {
        Console.WriteLine($"Result After {_MathOpsName} {_LastNumber} is : {_Result}");
    }

}


namespace CalculatorMy
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            clsCalculator Calculator1 = new clsCalculator();

            Calculator1.Clear();

            Calculator1.Add(10);
            Calculator1.PrintResult();

            Calculator1.Add(100);
            Calculator1.PrintResult();

            Calculator1.Subtruct(20);
            Calculator1.PrintResult();

            Calculator1.Divide(0);
            Calculator1.PrintResult();
            Calculator1.Divide(2);
            Calculator1.PrintResult();

            Calculator1.Multiply(3);
            Calculator1.PrintResult();

            Calculator1.Clear();
            Calculator1.PrintResult();

        }
    }
}
