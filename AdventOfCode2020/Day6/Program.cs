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
            Part1Solution();
            Part2Solution();
            
            Console.WriteLine("Done! Press any key to exit.");
            Console.ReadLine();
        }

        private static void Part1Solution()
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

        private static void Part2Solution()
        {
            var questionnaires = new List<GroupQuestionnaireV2>();

            using (var reader = new StreamReader("input.txt"))
            {
                var gq = new GroupQuestionnaireV2();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        questionnaires.Add(gq);
                        gq = new GroupQuestionnaireV2();
                    }

                    gq.AddResult(line);
                }

                questionnaires.Add(gq);
            }

            var count = questionnaires.Count(gq => gq.AllAnsweredYes());
            
            Console.WriteLine(count);
        }
    }
}