using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task2.DTOs;
using task2.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {



        private readonly MyDbContext _db;

        public CategoriesController(MyDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var c = _db.Categories.ToList();
            return Ok(c);
        }


        [HttpGet("id")]

        public IActionResult Get(int id)
        {
            var catergory = _db.Categories.FirstOrDefault(x => x.CategoryId == id);

            return Ok(catergory);
        }



        //[HttpPost]
        //public IActionResult PostCATEGORY([FromForm] Categorypost category)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var c = new Category
        //    {
        //       CategoryName =category.CategoryName,
        //        CategoryImage = category.CategoryImage,
        //    };
        //    _db.Categories.Add(c);
        //    _db.SaveChanges();
        //    return Ok(c);
        //}

        [HttpPost]
        public IActionResult addCategory([FromForm] categoryRequestDTO category)
        {
            var data = new Category
            {
                CategoryName = category.CategoryName,
                //هون الكوتش راحت جابت  اسم الفولدر يلي أنشأته 

                CategoryImage = category.CategoryImage.FileName
            };

            var ImagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (!Directory.Exists(ImagesFolder))
            {
                Directory.CreateDirectory(ImagesFolder);
            }
            var imageFile = Path.Combine(ImagesFolder, category.CategoryImage.FileName);
            using (var stream = new FileStream(imageFile, FileMode.Create))
            {
                category.CategoryImage.CopyToAsync(stream);
            }



            _db.Categories.Add(data);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPut("UpdateCategorybyCategoryid{id}")]
        public IActionResult UPDATE([FromForm]  categoryRequestDTO categDto, int id)
        {
            var c = _db.Categories.FirstOrDefault(l => l.CategoryId == id);
            c.CategoryName = categDto.CategoryName;
            c.CategoryImage = categDto.CategoryImage.FileName;
            var ImagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (!Directory.Exists(ImagesFolder))
            {
                Directory.CreateDirectory(ImagesFolder);
            }
            var imageFile = Path.Combine(ImagesFolder, categDto.CategoryImage.FileName);
            using (var stream = new FileStream(imageFile, FileMode.Create))
            {
                categDto.CategoryImage.CopyToAsync(stream);
            }

            _db.Categories.Update(c);
            _db.SaveChanges();
            return Ok();

         
        }
    }
}