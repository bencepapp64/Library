using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvescucc
{
    class Rents
    {
        public int Rent_ID { get; set; }
        public int RMember_ID { get; set; }
        public int RBook_ID { get; set; }
        public string Rent_Start { get; set; }
        public string Rent_End { get; set; }

        public Rents(string row)
        {
            try
            {
                string[] split = row.Split(';');
                Rent_ID = int.Parse(split[0]);
                RMember_ID = int.Parse(split[1]);
                RBook_ID = int.Parse(split[2]);
                Rent_Start = split[3];
                Rent_End = split[4];
            }
            catch (Exception)
            {
                return;
            }

        }
    }
}