using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day4
{
    internal class Program
    {
        public static void Main(string[] args)
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
            }

            var totalPassports = passports.Count;
            var validCount = passports.Count(p => p.IsValid());
            
            Console.WriteLine($"Total passports {totalPassports}, {validCount} are valid.");
        }
    }
}