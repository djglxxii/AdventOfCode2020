using System.Collections.Generic;

namespace Day7
{
    public class Bag
    {
        public string Color { get; }

        public Dictionary<Bag, int> InnerBags = new Dictionary<Bag, int>();
        
        public Bag(string bagColor)
        {
            Color = bagColor;
        }

        public int GetBagCount(Bag innerBag)
        {
            int count = 0;

            if (innerBag == this) count++;

            foreach (var kvp in InnerBags)
            {
                if (kvp.Key == innerBag)
                {
                    count += kvp.Value;
                }
                else
                {
                    count += kvp.Key.GetBagCount(innerBag);
                }
            }
            
            return count;
        }
        
    }
}
