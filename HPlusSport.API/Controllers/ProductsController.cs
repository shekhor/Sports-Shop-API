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
    public class ProductsController : ControllerBase
    {
        private readonly ShopContext shopContext;

        public ProductsController(ShopContext context)
        {
            shopContext = context;
            shopContext.Database.EnsureCreated();
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(shopContext.Products.ToArray());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetProduct(int id)
        {
            var product = shopContext.Products.Find(id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            shopContext.Products.Add(product);
            await shopContext.SaveChangesAsync();

            return CreatedAtAction(
                "GetProduct",
                new { id = product.Id },
                product);
        }
    }
}

