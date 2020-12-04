using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day3
{
    // https://adventofcode.com/2020/day/3
    class Program
    {
        static void Main(string[] args)
        {
            var slopes = new List<char[]>();

            using (var reader = new StreamReader("input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (!string.IsNullOrEmpty(line))
                    {
                        slopes.Add(line.ToCharArray());
                    }
                }
            }

            Part1Solution(slopes);
            Part2Solution(slopes);

            Console.WriteLine("Done! Press any key to exit.");
            Console.ReadLine();
        }

        private static void Part1Solution(List<char[]> slopes)
        {
            int treeCount = FindTrees(slopes, 1, 3);
            Console.WriteLine(treeCount);
        }

        private static void Part2Solution(List<char[]> slopes)
        {
            long product = 1;

            product *= FindTrees(slopes, 1, 1);
            product *= FindTrees(slopes, 1, 3);
            product *= FindTrees(slopes, 1, 5);
            product *= FindTrees(slopes, 1, 7);
            product *= FindTrees(slopes, 2, 1);

            Console.WriteLine(product);
        }

        private static int FindTrees(List<char[]> slopes, int slopeStep, int colStep)
        {
            int colPos = 0, treeCount = 0;
            int rowWidth = slopes.First().Length;

            for (int r = slopeStep; r < slopes.Count; r = r + slopeStep)
            {
                colPos = (colPos + colStep) % rowWidth;

                if (slopes[r][colPos] == '#') treeCount++;
            }

            return treeCount;
        }
    }
}
