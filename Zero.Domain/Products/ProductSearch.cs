using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Domain;

namespace Zero.Domain.Products
{
    public class ProductSearch :Search
    {
        public int BrandId { get; set; }

        public int CateId { get; set; }

        public int Lid { get; set; }

        public int Rid { get; set; }

        public string Attr { get; set; }

        public string Sort { get; set; }
    }
}
