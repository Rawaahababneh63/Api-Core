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

        //هاد حل شات جي بيتي
        //[HttpGet("calculate")]
        //public IActionResult Calculate([FromQuery] string expression)
        //{
        //    // التحقق من نوع العملية (جمع أو طرح)
        //    char operation = expression.Contains('+') ? '+' : expression.Contains('-') ? '-' : '\0';

        //    if (operation == '\0')
        //    {
        //        return BadRequest("يجب أن يحتوي التعبير على علامة + أو -.");
        //    }

        //    // تقسيم النص بناءً على العملية المحددة
        //    var parts = expression.Split(operation);

        //    // التحقق من أن هناك جزءين صحيحين يمكن تحويلهما إلى أرقام صحيحة
        //    if (parts.Length != 2 ||
        //        !int.TryParse(parts[0], out int num1) ||
        //        !int.TryParse(parts[1], out int num2))
        //    {
        //        return BadRequest("تنسيق المدخل غير صحيح. استخدم 'number1+number2' أو 'number1-number2'.");
        //    }

        //    // إجراء العملية الحسابية بناءً على نوع العملية
        //    int result = operation == '+' ? num1 + num2 : num1 - num2;

        //    // إرجاع النتيجة
        //    return Ok(result);
        //}

        [HttpGet("math")]
        public IActionResult Math(string input)
        {
            var x = input.Split(' ');

            var num1 = Convert.ToDouble(x[0]);
            var op = x[1];
            var num2 = Convert.ToDouble(x[2]);

            double result = 0;

            switch (op)
            {
                case ("+"):
                    result = num1 + num2;
                    break;
                case ("-"):
                    result = num1 - num2;
                    break;
                case ("*"):
                    result = num1 * num2;
                    break;
                case ("/"):
                    if (num2 == 0)
                    {
                        return BadRequest("can't devide on zero");
                    }
                    else
                    {
                        result = num1 / num2;
                        break;
                    }
            }
            return Ok(result);
        }
    }
}
