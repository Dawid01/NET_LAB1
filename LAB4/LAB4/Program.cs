using System;

namespace LAB4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("TEST");
            int[,] a =  MatrixOperations.GenerateMatrix(5, 1);
            int[,] b =  MatrixOperations.GenerateMatrix(5, 2);
            int[,] result = MatrixOperations.Multiplication(a, b);
            Console.WriteLine(MatrixOperations.MatrixToString(a));
            Console.WriteLine(MatrixOperations.MatrixToString(b));
            Console.WriteLine(MatrixOperations.MatrixToString(result));

        }
    }
}