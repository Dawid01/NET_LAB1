using System;
using System.Threading;
using System.Threading.Tasks;

namespace LAB4
{
    public class MatrixOperations
    {
        public static int[,] GenerateMatrix(int size, int seed)
        {
            Random rnd = new Random(seed);
            int[,] matrix = new int[size, size];
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    matrix[x, y] = rnd.Next(0, 100);
                }
            }

            return matrix;
        }


        public static int[,] Multiplication(int[,] a, int[,] b)
        {
            int size = (int)Math.Sqrt(a.Length);
            int[,] result = new int[size, size];
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    for (int i = 0; i < size; i++)
                    {
                        result[x, y] += a[i, y] * b[x, i];
                    }
                }
            }

            return result;
        }
        
        public static int[,] Multiplication(int[,] a, int[,] b, int threadCount)
        {
            int size = (int)Math.Sqrt(a.Length);
            int[,] result = new int[size, size];
            Thread[] threads = new Thread[threadCount];
            int partSize = size / threadCount;

            for (int i = 0; i < threadCount; i++)
            {
                int startColumn = i * partSize;
                int endColumn = (i == threadCount - 1) ? size : (i + 1) * partSize;

                threads[i] = new Thread((object obj) =>
                {
                    int[] range = (int[])obj;
                    int start = range[0];
                    int end = range[1];

                    for (int y = 0; y < size; y++)
                    {
                        for (int x = start; x < end; x++)
                        {
                            for (int k = 0; k < size; k++)
                            {
                                result[x, y] += a[k, y] * b[x, k];
                            }
                        }
                    }
                });

                threads[i].Start(new int[] { startColumn, endColumn });
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            return result;
        }

        public static int[,] MultiplicationParallel(int[,] a, int[,] b, int threadCount)
        {
            int size = (int)Math.Sqrt(a.Length);
            int[,] result = new int[size, size];
            int partSize = size / threadCount;

            Parallel.For(0, threadCount, i =>
            {
                int startColumn = i * partSize;
                int endColumn = (i == threadCount - 1) ? size : (i + 1) * partSize;

                for (int y = 0; y < size; y++)
                {
                    for (int x = startColumn; x < endColumn; x++)
                    {
                        for (int k = 0; k < size; k++)
                        {
                            result[x, y] += a[k, y] * b[x, k];
                        }
                    }
                }
            });

            return result;
        }

        public static string MatrixToString(int[,] matrix)
        {
            string result = "";
            int size = (int)Math.Sqrt(matrix.Length);
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (x == 0)
                    {
                        result += "|";
                    }

                    string value = matrix[x, y].ToString();
                    if (x > 0)
                    {
                        result += " ";
                    }
                    result += $"{value}";
                    if (value.Length < 2)
                    {
                        result += " ";
                    }

                    if (x == size - 1)
                    {
                        result += "|";
                    }
                }

                result += "\n";
            }

            return result;
        }
    }
}