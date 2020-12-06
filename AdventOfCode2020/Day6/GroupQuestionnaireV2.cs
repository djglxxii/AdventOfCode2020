using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Day6
{
    public class GroupQuestionnaireV2
    {
        private readonly Dictionary<char, int> _map = new Dictionary<char, int>();
        private int groupMemberCount = 0;

        public void AddResult(string result)
        {
            foreach (char c in result)
            {
                if (!_map.ContainsKey(c))
                {
                    _map[c] = 1;
                }
                else
                {
                    _map[c]++;
                }
            }

            groupMemberCount++;
        }

        public bool AllAnsweredYes()
        {
            var set = new HashSet<int>();
            _map.Select(kvp => kvp.Value).ToList().ForEach(n => set.Add(n));
            
            return set.Count == groupMemberCount;
        }
    }
}
