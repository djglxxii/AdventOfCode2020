using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Day3
{
    class Program
    {
        private static List<char[]> rows = new List<char[]>();

        static void Main(string[] args)
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var lines = new List<string>();

                while (!reader.EndOfStream)
                {
                    lines.Add(reader.ReadLine());
                }

                int repeatMultiplier = 150;

                foreach (var line in lines)
                {
                    var sb = new StringBuilder();

                    for (int i = 0; i <= repeatMultiplier; i++)
                    {
                        sb.Append(line);
                    }

                    rows.Add(sb.ToString().ToCharArray());
                }
            }

            var numsToProd = new List<int>();

            numsToProd.Add(FindTrees(1,1));
            numsToProd.Add(FindTrees(1, 3));
            numsToProd.Add(FindTrees(1, 5));
            numsToProd.Add(FindTrees(1, 7));
            numsToProd.Add(FindTrees(2, 1));

            Int64 prod = 1;

            numsToProd.ForEach(n => prod = prod * n);

            Console.WriteLine(prod);

            Console.ReadLine();
        }

        private static int FindTrees(int rowStep, int colModifier)
        {
            int colPos = 0, treeCount = 0;

            for (int r = rowStep; r < rows.Count; r = r + rowStep)
            {
                colPos = colPos + colModifier;

                if (rows[r][colPos] == '#') treeCount++;
            }

            return treeCount;
        }
    }
}
