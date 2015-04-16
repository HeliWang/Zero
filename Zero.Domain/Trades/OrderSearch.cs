using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Domain.Trades
{
    public class OrderSearch
    {
        public string Keyword { get; set; }

        public string Seller { get; set; }

        public DateTime StartOrderTime { get; set; }

        public DateTime EndOrderTime { get; set; }

        public int Status { get; set; }

    }
}
