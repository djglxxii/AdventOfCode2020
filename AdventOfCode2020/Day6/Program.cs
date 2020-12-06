using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var questionnaires = new List<GroupQuestionnaire>();

            using (var reader = new StreamReader("input.txt"))
            {
                var gq = new GroupQuestionnaire();
                
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        questionnaires.Add(gq);
                        gq = new GroupQuestionnaire();
                    }
                    gq.AddResult(line);
                }
                questionnaires.Add(gq);
            }

            int sum = questionnaires.Sum(s => s.GetYesCount());
            Console.WriteLine(sum);
        }
    }
}