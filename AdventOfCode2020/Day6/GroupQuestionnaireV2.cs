using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Day6
{
    public class GroupQuestionnaireV2
    {
        private readonly Dictionary<char, int> _map = new Dictionary<char, int>();
        private int _groupMemberCount = 0;

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

            _groupMemberCount++;
        }

        public int NumAnsweredYes()
        {
            var count = _map.Values.Count(v => v == _groupMemberCount);

            return count;
        }
    }
}
