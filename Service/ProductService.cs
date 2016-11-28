using Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService:AbstractService,IProduct
    {
        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> products = new List<ProductModel>{
                new ProductModel { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
                new ProductModel { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
                new ProductModel { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M } 
            };

            return products;
        }
    }
}
