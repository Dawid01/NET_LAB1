
using System;

internal class FizzBuzz
{
    private int maxNumber = 0;

    public FizzBuzz(int maxNumber)
    {
        this.maxNumber = maxNumber;
    }

    public void CheckFizzBuzz()
    {
        if (maxNumber < 0)
        {
            Console.WriteLine("ERROR: maxNumber musi byc wiekszy od 0");
            return;
        }

        string result = "";
        for (int i = 1; i <= maxNumber; i++)
        {
            if (i % 3 == 0)
            {
                result = result + "Fizz";
            }

            if (i % 5 == 0)
            {
                result = result + "Buzz";
            }

            if (result.Length == 0) result = "" + i;
            Console.WriteLine(result);
            result = "";
        }
    }
}