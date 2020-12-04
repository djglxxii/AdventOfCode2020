using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day4
{
    // https://adventofcode.com/2020/day/4
    internal class Program
    {
        public static void Main(string[] args)
        {
           Part2Solution();
        }

        private static void Part1Solution()
        {
            var passports = new List<Passport>();

            using (var reader = new StreamReader("input.txt"))
            {
                var passport = new Passport();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (string.IsNullOrEmpty(line))
                    {
                        if (passport.Any())
                        {
                            passports.Add(passport);    
                        }
                        
                        passport = new Passport();
                        continue;
                    }

                    var entries = line.Split(' ');

                    foreach (var entry in entries)
                    {
                        var pair = entry.Split(':');
                        var key = pair[0];
                        var val = pair[1];
                        passport.Add(new KeyValuePair<string, string>(key, val));
                    }
                }
                
                passports.Add(passport);
            }
            
            int totalPassports = passports.Count;
            int validCount = 0;
        
            foreach (var passport in passports)
            {
                if (passport.IsValid())
                {
                    validCount++;
                }
            }
            
            Console.WriteLine($"Total passports {totalPassports}, {validCount} are valid.");
        }

        private static void Part2Solution()
        {
            var passports = new List<PassportV2>();

            using (var reader = new StreamReader("input.txt"))
            {
                var passport = new PassportV2();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (string.IsNullOrEmpty(line))
                    {
                        if (passport.Any())
                        {
                            passports.Add(passport);    
                        }
                        
                        passport = new PassportV2();
                        continue;
                    }

                    var entries = line.Split(' ');

                    foreach (var entry in entries)
                    {
                        var pair = entry.Split(':');
                        var key = pair[0];
                        var val = pair[1];
                        passport.Add(new KeyValuePair<string, string>(key, val));
                    }
                }
                
                passports.Add(passport);
            }
            
            int totalPassports = passports.Count;
            int validCount = 0;
        
            foreach (var passport in passports)
            {
                if (passport.IsValid())
                {
                    validCount++;
                }
            }
            
            Console.WriteLine($"Total passports {totalPassports}, {validCount} are valid.");
        }
    }
}