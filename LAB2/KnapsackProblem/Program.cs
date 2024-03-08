using System;
using System.Collections.Generic;

namespace KnapsackProblem
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Problem problem = new Problem(10, 1);
            Console.WriteLine(problem + "\n \n");
            Console.WriteLine(problem.Solve(20));

        }

    }
}