using System;

namespace LAB4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int size = 1000;
            int[,] a =  MatrixOperations.GenerateMatrix(size, 1);
            int[,] b =  MatrixOperations.GenerateMatrix(size, 2);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            MatrixOperations.Multiplication(a, b);
            watch.Stop();
            long elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"Watek [1]: {elapsedMs} ms");
            for (int i = 2; i <= 16; i++)
            {
                CalculateMatrix(a, b, i);
                //CalculateMatrixParallel(a, b, i);
            }
            
        }

        private static void CalculateMatrix(int[,] a, int[,] b, int threads)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            MatrixOperations.Multiplication(a, b, threads);
            watch.Stop();
            long elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"Watki [{threads}]: {elapsedMs} ms");
        }
        
        private static void CalculateMatrixParallel(int[,] a, int[,] b, int threads)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            MatrixOperations.MultiplicationParallel(a, b, threads);
            watch.Stop();
            long elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"Parallel Watki [{threads}]: {elapsedMs} ms");
        }
    }
}