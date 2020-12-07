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

        public bool CanContain(string bagColor)
        {
            foreach (var bag in InnerBags)
            {
                if (bag.Key.Color == bagColor) return true;
                if (bag.Key.CanContain(bagColor)) return true;
            }

            return false;
        }
        public override int GetHashCode()
        {
            return Color.GetHashCode();
        }
        
        
    }
}
