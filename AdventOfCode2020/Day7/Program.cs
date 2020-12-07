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
            var bagMap = new Dictionary<string, Bag>();

            using (var reader = new StreamReader("exampleInput.txt"))
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

                    if (!bagMap.ContainsKey(outterBagColor))
                    {
                        bagMap[outterBagColor] = new Bag(outterBagColor);
                    }

                    foreach (var bag in innerBags)
                    {
                        if (bag == "no other") continue;

                        string[] tmpArr = bag.Split(' ');
                        string innerBagColor = string.Join(" ", tmpArr, 1, tmpArr.Length - 1);
                        int quantity = int.Parse(tmpArr[0]);

                        if (!bagMap.ContainsKey(innerBagColor))
                        {
                            bagMap[innerBagColor] = new Bag(innerBagColor);
                        }

                        bagMap[outterBagColor].InnerBags.Add(bagMap[innerBagColor], quantity);
                    }
                }
            }

            int count = 0;
            var myBag = bagMap["shiny gold"];
            
            foreach (var bag in bagMap)
            {
                count += bag.Value.GetBagCount(myBag);
            }
            
            Console.WriteLine(count);
           

            // posh blue bags contain 5 plaid chartreuse bags, 3 plaid lime bags.
            //     clear teal bags contain 2 dotted salmon bags, 2 wavy red bags.
            //     faded blue bags contain 1 dotted chartreuse bag, 3 dim bronze bags.
            //     plaid black bags contain 5 muted beige bags, 2 pale gold bags, 3 wavy lavender bags, 5 dull yellow bags.
            //     bright cyan bags contain 2 vibrant teal bags.
            //     clear magenta bags contain 2 dim chartreuse bags.
            //     muted crimson bags contain 1 clear violet bag, 5 dark coral bags, 1 pale salmon bag, 3 light red bags.
            //     dotted green bags contain 3 muted plum bags.
            //     pale crimson bags contain 3 pale maroon bags, 2 mirrored tan bags.
            //     shiny black bags contain 1 wavy tomato bag.

            // int count = 0;
            //
            // foreach (var kvp in _map)
            // {
            //     if (kvp.Key == "shiny gold")
            //     {
            //         count++;
            //     }
            //     else
            //     {
            //         count += GetMyBagCount(kvp.Key, "shiny gold");    
            //     }
            // }
            //
            // Console.WriteLine(count);
        }
    }
}