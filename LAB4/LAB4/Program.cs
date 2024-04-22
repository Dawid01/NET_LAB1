using System;

namespace LAB4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[,] a =  MatrixOperations.GenerateMatrix(1000, 1);
            int[,] b =  MatrixOperations.GenerateMatrix(1000, 2);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int[,] result = MatrixOperations.Multiplication(a, b);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"Zwykle: {elapsedMs} ms");
            watch = System.Diagnostics.Stopwatch.StartNew();
            int[,] resultThread = MatrixOperations.Multiplication(a, b, 10);
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"Watki: {elapsedMs} ms");
            
            /*Console.WriteLine(MatrixOperations.MatrixToString(a));
            Console.WriteLine(MatrixOperations.MatrixToString(b));
            Console.WriteLine(MatrixOperations.MatrixToString(result));
            Console.WriteLine(MatrixOperations.MatrixToString(resultThread));*/

        }
    }
}