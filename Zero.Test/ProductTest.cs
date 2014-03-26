using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Zero.Data;
using Zero.Domain.Products;
using Zero.Service.Products;

namespace Zero.Test
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var db = new EfDbContext())
            {
                //var product = new Product();

                //db.Products.Add(product);
                //db.SaveChanges();
            } 
        }
    }
}
