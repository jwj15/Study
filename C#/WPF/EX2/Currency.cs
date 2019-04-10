using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX2
{
    public class Currency
    {
        public string Title { get; set; }
        public decimal Rate;

        public Currency(string title, decimal rate)
        {
            Title = title;
            Rate = rate;
        }
    }
}
