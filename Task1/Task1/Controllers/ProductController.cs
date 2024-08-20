using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task1.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {


        private readonly MyDbContext _db;

        public ProductController(MyDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        public  IEnumerable<Product> GetAllProducts(MyDbContext dd)

        {
            var c = dd.Products
                .Include(e => e.Category)
                .ToList();

            return c;
        }
     

        [HttpGet("id")]

        public IActionResult Get(int id)
        {
            var product = _db.Products.FirstOrDefault(x => x.ProductId == id);

            return Ok(product);
        }

    }
}
