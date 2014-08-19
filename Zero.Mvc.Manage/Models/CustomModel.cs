using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zero.Domain.Products;
using Zero.Domain.Customs;

namespace Zero.Mvc.Manage.Models
{
    public class CustomModel
    {
        public Custom Custom { get; set; }

        public ProductSearch ProductSearch { get; set; }
    }
}