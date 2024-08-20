using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task1.Models;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private  readonly MyDbContext _db;

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
            var catergory = _db.Categories.FirstOrDefault(x => x.CategoryId== id);
           
            return Ok( catergory);
        }











    }

}
