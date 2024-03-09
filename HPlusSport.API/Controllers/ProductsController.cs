using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HPlusSport.API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HPlusSport.API
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly ShopContext shopContext;

        public ProductsController(ShopContext context)
        {
            shopContext = context;
            shopContext.Database.EnsureCreated();
        }

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return shopContext.Products.ToArray();
        }
    }
}

