using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Day6
{
    public class GroupQuestionnaireV2
    {
        // dict to keep track of question (char) and how many times answered (int)
        private readonly Dictionary<char, int> _map = new Dictionary<char, int>();
        // how many members are in this group?
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

        public int NumAnsweredAllYes()
        {
            // count how many questions have answers that equal memberCount
            // (which means everyone answered 'yes' for that particular question)
            var count = _map.Values.Count(v => v == _groupMemberCount);

            return count;
        }
    }
}
