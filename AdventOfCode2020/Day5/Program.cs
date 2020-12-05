using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1Solution();
            Part2Solution();
            
            Console.WriteLine("Done! Press any key to exit.");
            Console.ReadLine();
        }

        private static void Part1Solution()
        {
            var seats = new List<Seat>();

            using (var reader = new StreamReader("input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Seat seat = new Seat(line);
                    seats.Add(seat);
                }
            }

            var highestSeat = seats.Max(s => s.GetSeatNo());

            Console.WriteLine($"Highest seat ID: {highestSeat}");
        }

        private static void Part2Solution()
        {
            var seats = new List<Seat>();

            using (var reader = new StreamReader("input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Seat seat = new Seat(line);
                    seats.Add(seat);
                }
            }

            int min = seats.Min(s => s.GetSeatNo());
            int max = seats.Max(s => s.GetSeatNo());
            var range = Enumerable.Range(min, max-min);
            var seatNos = seats.Select(s => s.GetSeatNo()).ToArray();

            var missing = range.Except(seatNos).First();
            
            Console.WriteLine($"My seat ID: {missing}");
        }
    }
}
