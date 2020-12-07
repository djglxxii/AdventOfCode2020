using System.Collections.Generic;

namespace Day7
{
    public class Bag
    {
        public string Color { get; }
        public int? Quantity { get; set; }
        
        public Bag(string bagColor)
        {
            Color = bagColor;
        }

        public override int GetHashCode()
        {
            return Color.GetHashCode();
        }
    }
}
