using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public IActionResult GetAllProducts()

        {
            var c = _db.Products.ToList();


            return Ok(c);
        }

        

        [HttpGet ("GETProductby5LAST")]
        public IActionResult GetAllProductsoORDERE()

        {
            
         //  var c = _db.Products.OrderBy(i=>i.ProductName).Reverse().Take(5).Reverse();

            var soso = _db.Products.OrderBy(i => i.ProductName).ToList().TakeLast(5);


            return Ok(soso);
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



        [HttpPost]

        public IActionResult PostPRODUCT([FromForm] ProductRequestDTO product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var x = new Product
            {
                Price = product.Price,
                ProductName = product.ProductName,
                ProductImage = product.ProductImage.FileName,
                Description = product.Description,
                CategoryId = product.CategoryId,


            };
            var ImagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (!Directory.Exists(ImagesFolder))
            {
                Directory.CreateDirectory(ImagesFolder);
            }
            var imageFile = Path.Combine(ImagesFolder, product.ProductImage.FileName);
            using (var stream = new FileStream(imageFile, FileMode.Create))
            {
                product.ProductImage.CopyToAsync(stream);
            }
            _db.Products.Add(x);
            _db.SaveChanges();

            return Ok(x);
        }





        [HttpPut("UpdateProductbyProductid{id}")]
        public IActionResult UPDATE([FromForm] ProductRequestDTO proDto, int id)
        {
            var c = _db.Products.FirstOrDefault(l => l.ProductId == id);
            c.ProductName = proDto.ProductName;
            c.ProductImage = proDto.ProductImage.FileName;
            c.Description = proDto.Description;
            c.Price = proDto.Price;
            c.CategoryId = proDto.CategoryId;
            var ImagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (!Directory.Exists(ImagesFolder))
            {
                Directory.CreateDirectory(ImagesFolder);
            }
            var imageFile = Path.Combine(ImagesFolder, proDto.ProductImage.FileName);
            using (var stream = new FileStream(imageFile, FileMode.Create))
            {
                proDto.ProductImage.CopyToAsync(stream);
            }

            _db.Products.Update(c);
            _db.SaveChanges();
            return Ok(c);


        }
        //[HttpGet ("Calculate")]
        //public IActionResult process(int n, int x)
        //{

        //    if ((n + x) == 30 || n == 30 || x == 30)
        //    {
        //        return Ok(true);
        //    }
        //    return Ok(false);
        //}


        //[HttpGet("Compararing")]
        //public IActionResult process(int n) {

        //    if (n > 0)
        //    {
        //        if (n % 3 == 0 || n % 7 == 0)
        //        {
        //            return Ok(true);
        //        }
        //    }
        //    return Ok(false);


        //} 

        }

    }
