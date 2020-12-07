using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Day7
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var map = new Dictionary<string, List<KeyValuePair<string,int>>>();
            
            using (var reader = new StreamReader("input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    var outterBagColor = line.Substring(0, line.IndexOf("bags")).Trim();

                    var innerBags = line.Substring(line.IndexOf("contain"), line.Length - line.IndexOf("contain"))
                        .Replace("contain", "")
                        .Replace("bags", "")
                        .Replace("bag", "")
                        .Replace(".", "")
                        .Split(',')
                        .Select(b => b.Trim());

                    map[outterBagColor] = new List<KeyValuePair<string, int>>();
                    
                    foreach (var bag in innerBags)
                    {
                        if (bag == "no other") continue;

                        string[] tmpArr = bag.Split(' ');
                        string innerBagColor = string.Join(" ", tmpArr, 1, tmpArr.Length - 1);
                        int quantity = int.Parse(tmpArr[0]);
                        map[outterBagColor].Add(new KeyValuePair<string, int>(innerBagColor, quantity));
                    }
                }
            }
            
            int count = 0;

            foreach (var kvp in map)
            {
                if (kvp.Key == "shiny gold")
                {
                    count++;
                }
                
                foreach (var innerKvp in kvp.Value)
                {
                    if (innerKvp.Key == "shiny gold")
                    {
                        count = count + innerKvp.Value;
                    }
                }
            }
                
            Console.WriteLine(count);
        }
    }
}