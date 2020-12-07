using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Day7
{
    internal class Program
    {
        private static Dictionary<Bag, List<Bag>> _bagMap = new Dictionary<Bag, List<Bag>>();

        public static void Main(string[] args)
        {
            using (var reader = new StreamReader("input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    
                    var outterBag = new Bag(line.Substring(0, line.IndexOf("bags")));
                    
                    var innerBags = line.Substring(line.IndexOf("contain"), line.Length - line.IndexOf("contain"))
                        .Replace("contain", "")
                        .Replace("bags", "")
                        .Replace(".", "")
                        .Split(',')
                        .Select(b => b.Trim());

                    _bagMap[outterBag] = new List<Bag>();
                    
                    foreach (var bag in innerBags)
                    {
                        if (bag == "no other") continue;

                        string[] tmpArr = bag.Split(' ');
                        string color = string.Join(" ", tmpArr, 1, tmpArr.Length - 1);
                        int quantity = int.Parse(tmpArr[0]);

                        var innerBag = new Bag(color);
                        innerBag.Quantity = quantity;
                        
                        _bagMap[outterBag].Add(innerBag);
                    }
                }

                int count = 0;
                
                foreach (var bag in _bagMap)
                {
                    if (CanContain("shiny gold", bag.Key))
                    {
                        count++;
                    }
                }
                
                Console.WriteLine(count);
            }
        }

        private static bool CanContain(string innerBagColor, Bag outterBag)
        {
            return _bagMap[outterBag].Any(b => b.Color == innerBagColor);
        }
    }
}


// if (bag == "no other")
// {
//     _bagMap[outterBag] = null;
//     continue;
// }
//

// _bagMap[outterBag] = new Tuple<string, int>(color, quantity);