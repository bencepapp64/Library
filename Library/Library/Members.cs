using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvescucc
{
    class Members
    {
        public int Member_ID { get; set; }
        public string Name { get; set; }
        public string Birth_Date { get; set; }
        public string Postal_Code { get; set; }
        public string Place { get; set; }
        public string Street { get; set; }

        public Members(string row)
        {
            try
            {
                string[] split = row.Split(';');
                Member_ID = int.Parse(split[0]);
                Name = split[1];
                Birth_Date = split[2];
                Postal_Code = split[3];
                Place = split[4];
                Street = split[5];
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}