using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redky.AspnetCore.Demo.Models
{
    public class Products
    {

        public static IEnumerable<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product() {
                    Id = 0,
                    Name= "Tige Nixon",
                    Created = DateTime.Now,
                },
                new Product() {
                    Id = 1,
                    Name= "Garrett Winters",
                    Created = DateTime.Now
                },
                new Product() {
                    Id = 2,
                    Name= "Ashton Cox",
                    Created = DateTime.Now
                },
                new Product() {
                    Id = 3,
                    Name= "Cedric Kelly",
                    Created = DateTime.Now
                },
            };
        }
    }
}