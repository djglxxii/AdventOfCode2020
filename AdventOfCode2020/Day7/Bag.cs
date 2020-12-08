using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    public class Bag
    {
        private readonly Dictionary<Bag, int> _map = new Dictionary<Bag, int>();

        public string Color { get; }

        public Bag(string color)
        {
            Color = color;
        }

        public void AddBag(Bag bag, int quantity)
        {
            _map[bag] = quantity;
        }

        public bool CanContain(Bag bag)
        {
            // it's me!
            if (bag == this) return true;

            return _map.Any(kvp => kvp.Key.CanContain(bag));
        }

        public int GetTotalBagCount()
        {
            int count = 0;

            foreach (var kvp in _map)
            {
                var bag = kvp.Key;
                var quantity = kvp.Value;

                count += quantity;
                count += bag.GetTotalBagCount() * quantity;
            }

            return count;
        }
        
        public override int GetHashCode()
        {
            return Color.GetHashCode() * 17;
        }
    }
}
