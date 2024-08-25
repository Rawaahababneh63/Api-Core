using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task2.Models;

namespace task2.Controllers
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
        public IEnumerable<Product> GetAllProducts(MyDbContext dd)

        {
            var c = dd.Products
                .Include(e => e.Category)
                .ToList();

            return c;
        }


        [HttpGet("{id}/{price}")]

        public IActionResult Get(int id, int price)
        {
            var product = _db.Products.Where(c => c.Price > price && c.CategoryId == id).Count();

            return Ok(product);
        }



        [HttpDelete]
        public void Delete(int id)
        {

            var dd = _db.Products.Where(e => e.CategoryId == id).ToList();
            _db.Products.RemoveRange(dd);
            _db.SaveChanges();

        }


        [HttpGet("{name}")]

        public IActionResult Get(string name)
        {
            var product = _db.Products.Where(c => c.ProductName == name);

            return Ok(product);
        }

    }
}
