using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class Seat
    {
        private readonly string _seatCode;

        public Seat(string seatCode)
        {
            _seatCode = seatCode;
        }

        public int GetSeatNo()
        {
            var sb = new StringBuilder(_seatCode);
            sb.Replace("F", "0");
            sb.Replace("B", "1");
            sb.Replace("R", "1");
            sb.Replace("L", "0");

            return Convert.ToInt32(sb.ToString(), 2);
        }
    }
}
