using System;
using System.Collections.Generic;
using System.IO;

namespace Day1
{
    internal class Program
    {
        // https://adventofcode.com/2020/day/1
        public static void Main(string[] args)
        {
            var evenNums = new List<int>();
            var oddNums = new List<int>();

            using (var reader = new StreamReader("input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (int.TryParse(line, out int num))
                    {
                        if (num % 2 == 0)
                        {
                            evenNums.Add(num);
                        }
                        else
                        {
                            oddNums.Add(num);
                        }
                    }
                }
            }

            Part1Solution(evenNums, oddNums);
            Part2Solution(evenNums, oddNums);

            Console.WriteLine("Done! Press any key to exit.");
            Console.ReadLine();
        }

        private static void Part1Solution(List<int> evenNums, List<int> oddNums)
        {
            void PrintSolution(int num1, int num2)
            {
                Console.WriteLine($"{num1} * {num2} = {num1 * num2}");
            }

            // only an even + even can be even, so only check the even numbers.
            for (int i = 0; i < evenNums.Count; i++)
            {
                int num1 = evenNums[i];

                for (int j = i + 1; j < evenNums.Count; j++)
                {
                    int num2 = evenNums[j];

                    if (num1 + num2 == 2020)
                    {
                        PrintSolution(num1, num2);
                        return;
                    }
                }
            }

            // only an odd + odd can be even, so only check the odd numbers.
            for (int i = 0; i < oddNums.Count; i++)
            {
                int num1 = oddNums[i];

                for (int j = i + 1; j < oddNums.Count; j++)
                {
                    int num2 = oddNums[j];

                    if (num1 + num2 == 2020)
                    {
                        PrintSolution(num1, num2);
                        return;
                    }
                }
            }
        }

        private static void Part2Solution(List<int> evenNums, List<int> oddNums)
        {
            void PrintSolution(int num1, int num2, int num3)
            {
                Console.WriteLine($"{num1} * {num2} * {num3} = {num1 * num2 * num3}");
            }

            // only even + even + even can be even, so only check even numbers.
            for (int i = 0; i < evenNums.Count; i++)
            {
                int num1 = evenNums[i];

                for (int j = i + 1; j < evenNums.Count; j++)
                {
                    int num2 = evenNums[j];

                    for (int k = j + 1; k < evenNums.Count; k++)
                    {
                        int num3 = evenNums[k];

                        if (num1 + num2 + num3 == 2020)
                        {
                            PrintSolution(num1, num2, num3);
                            return;
                        }
                    }
                }

            }

            // only odd + odd + even can be even, so check two odds plus an even
            for (int i = 0; i < oddNums.Count; i++)
            {
                int num1 = oddNums[i];

                for (int j = i + 1; j < oddNums.Count; j++)
                {
                    int num2 = oddNums[j];

                    for (int k = 0; k < evenNums.Count; k++)
                    {
                        int num3 = evenNums[k];

                        if (num1 + num2 + num3 == 2020)
                        {
                            PrintSolution(num1, num2, num3);
                            return;
                        }
                    }
                }
            }
        }
    }
}