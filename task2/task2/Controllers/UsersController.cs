using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task2.DTOs;
using task2.Models;

namespace task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MyDbContext _db;
        public UsersController(MyDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var Users = _db.Users.ToList();
            if (Users.Any())
                return Ok(Users);
            return NoContent();
        }
        [HttpGet("GetUserByName/{Name}")]
        public IActionResult GetUserByName(string Name)
        {


            if (string.IsNullOrWhiteSpace(Name))
            {
                return BadRequest("Name parameter is required.");
            }
            var User = _db.Users.Where(c => c.Username == Name).FirstOrDefault();
            if (User == null)
            {
                return NotFound();
            }
            return Ok(User);
        }


        [HttpGet("GetUserById/{id}")]
        public IActionResult GetUserById(int id)
        {



            if (id <= 0)
            {
                return BadRequest("ID parameter is required.");
            }
            var User = _db.Users.Find(id);
            if (User == null)
            {
                return NotFound();
            }
            return Ok(User);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {



            if (id <= 0)
            {
                return BadRequest("ID parameter is required.");
            }

            var User = _db.Users.Find(id);

            if (User == null)
            {
                return NotFound();
            }

            _db.Users.Remove(User);
            _db.SaveChanges();
            return NoContent(); // Return the deleted category or a success message
        }
        [HttpPost]
        public IActionResult addUser([FromForm] UpdateUserRequestcs useradd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = new User
            {
                Username = useradd.Username,
                Email = useradd.Email,
                Password = useradd.Password,
            };

            _db.Users.Add(user);
            _db.SaveChanges();
            return Ok(user);

        }


        [HttpPut ("addUser{id}")]
        public IActionResult addUser(int id,[FromForm] UpdateUserRequestcs useradd)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var updateuser = _db.Users.FirstOrDefault(c => c.UserId == id);
            _db.Users.Update(updateuser);
            _db.SaveChanges();
            return Ok();


        }
    }
}
