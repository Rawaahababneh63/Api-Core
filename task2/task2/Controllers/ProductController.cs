using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task2.DTOs;
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
        public IActionResult GetAllProducts()

        {
            var c = _db.Products.ToList();


            return Ok(c);
        }

        [HttpGet("product/{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _db.Products.Where(p => p.ProductId == id).Select(p => new
            {
                p.ProductId,
                p.ProductName,
                p.Description,
                p.Price,
                p.ProductImage,
                Category = new
                {
                    p.Category.CategoryId,
                    p.Category.CategoryName,
                    p.Category.CategoryImage,
                }
            }).FirstOrDefault();

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }




        [HttpGet("GetAllProductDecending")]

        public IActionResult GetAllProductDecending()
        {
            var product = _db.Products.OrderByDescending(c => c.Price).ToList();

            return Ok(product);
        }

        [HttpGet("ProductbyGetCategoryId/{Categoryid}")]

        public IActionResult Get(int Categoryid)
        {
            var product = _db.Products.Where(c => c.CategoryId == Categoryid).ToList();

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



    //    [HttpPost]

    //    public IActionResult PostPRODUCT([FromForm] Productgetform product)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest();
    //        }


    //        var x = new Product
    //        {
    //            Price = product.Price,
    //            ProductName = product.ProductName,
    //            ProductImage = product.ProductImage,
    //            Description = product.Description,
    //            CategoryId = product.CategoryId,


    //        };
    //        _db.Products.Add(x);
    //        _db.SaveChanges();

            


    //        return Ok(product);
    //    }
    }
}