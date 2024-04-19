using System;
using System.Threading;

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
            for (int t = 0; t < threadCount; t++)
            {
                
            }
            
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