using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zero.Domain.Products;

namespace Zero.Domain.Orders
{
    public class Cart : BaseEntity
    {
        public int CartId { get; set; }

        public int ProductId { get; set; }

        public int SkuId   { get; set; }

        public string Attr { get; set; }

        public int Quantity { get; set; }

        public int UserId { get; set; }

        public string GuestId { get; set; }

        public Product Product { get; set; }

        public Sku Sku { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}
