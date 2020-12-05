using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1Solution();
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

            Console.WriteLine(highestSeat);
            Console.ReadLine();
        }
    }
}
