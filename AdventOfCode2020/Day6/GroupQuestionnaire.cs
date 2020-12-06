using System.Collections.Generic;

namespace Day6
{
    public class GroupQuestionnaire
    {
        private readonly HashSet<char> _answers = new HashSet<char>();
        
        public void AddResult(string result)
        {
            foreach (char c in result)
            {
                _answers.Add(c);
            }
        }

        public int GetYesCount()
        {
            return _answers.Count;
        }
    }
}