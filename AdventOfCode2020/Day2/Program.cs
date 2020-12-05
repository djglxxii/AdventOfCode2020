using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day2
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
            var passwords = new List<Password>();

            using (var reader = new StreamReader("input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var password = new Password(line);
                    passwords.Add(password);
                }
            }

            int validCount = passwords.Count(p => p.IsValid());
            
            Console.WriteLine(validCount);
        }
        
        private static void Part2Solution()
        {
            var passwords = new List<PasswordV2>();

            using (var reader = new StreamReader("input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var password = new PasswordV2(line);
                    passwords.Add(password);
                }
            }

            int validCount = passwords.Count(p => p.IsValid());
            
            Console.WriteLine(validCount);
        }
    }
}
