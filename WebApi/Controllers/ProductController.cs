using Interface;
using Model;
using Model.User;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Chuang.Back.Controllers
{
    public class ProductController : ApiController
    {
        public IEnumerable<UserModel> GetAllProducts()
        {
           // IProduct service = new ProductService();
            //List<ProductModel> products = service.GetAllProducts();

            IBase user = new UserServicee();
            var users = user.GetAll<UserModel>();
            return users;
        }

        public IHttpActionResult GetProduct(int id)
        {
            IProduct service = new ProductService();
            List<ProductModel> products = service.GetAllProducts();
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
