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
            MatrixOperations.Multiplication(a, b);
            watch.Stop();
            long elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"Watek [1]: {elapsedMs} ms");
            for (int i = 2; i <= 16; i++)
            {
                CalculateMatrix(a, b, i);
            }

            /*Console.WriteLine(MatrixOperations.MatrixToString(a));
            Console.WriteLine(MatrixOperations.MatrixToString(b));
            Console.WriteLine(MatrixOperations.MatrixToString(result));
            Console.WriteLine(MatrixOperations.MatrixToString(resultThread));*/

        }

        private static void CalculateMatrix(int[,] a, int[,] b, int threads)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            MatrixOperations.Multiplication(a, b, threads);
            watch.Stop();
            long elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"Watki [{threads}]: {elapsedMs} ms");
        }
    }
}