using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day7
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var colorBagMap = new Dictionary<string, Bag>();

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

                    if (!colorBagMap.ContainsKey(outterBagColor))
                    {
                        colorBagMap[outterBagColor] = new Bag(outterBagColor);
                    }

                    var outterBag = colorBagMap[outterBagColor];

                    foreach (var bag in innerBags)
                    {
                        if (bag == "no other") continue;

                        string[] tmpArr = bag.Split(' ');
                        string innerBagColor = string.Join(" ", tmpArr, 1, tmpArr.Length - 1);
                        int quantity = int.Parse(tmpArr[0]);

                        if (!colorBagMap.ContainsKey(innerBagColor))
                        {
                            colorBagMap[innerBagColor] = new Bag(innerBagColor);
                        }

                        var innerBag = colorBagMap[innerBagColor];
                        outterBag.AddBag(innerBag, quantity);
                    }
                }
            }

            var myBag = colorBagMap["shiny gold"];

            int count = 0;

            foreach (var kvp in colorBagMap)
            {
                var bag = kvp.Value;
                
                // don't count myself
                if (bag == myBag) continue;
                
                if (bag.CanContain(myBag))
                {
                    count++;
                }
            }
            
            Console.WriteLine(count);
            Console.WriteLine(myBag.GetBagCount());
            
            Console.WriteLine("Done! Press any key to exit.");
            Console.ReadLine();
        }
    }
}
