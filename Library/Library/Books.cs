using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvescucc
{
    class Books
    {
        public int Book_ID { get; set; }
        public string Book { get; set; }
        public string Author { get; set; }
        public string Release_Date { get; set; }
        public string Publisher { get; set; }
        public bool Rent { get; set; }


        public Books(string row)
        {
            try
            {
                string[] split = row.Split(';');
                Book_ID = int.Parse(split[0]);
                Author = split[1];
                if (Author == "")
                {
                    Author = "";
                }
                Release_Date = (split[3]);
                Book = split[2];
                Publisher = split[4];
                Rent = Convert.ToBoolean(split[5]);
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}