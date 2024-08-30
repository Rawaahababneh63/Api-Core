using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task2.DTOs;
using task2.Models;

namespace task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
private MyDbContext _db;
    public CartItemController (MyDbContext db)
        {
        _db=db;
              }

        [HttpGet("GetAllCartItems")]
        public IActionResult GetAllCartItems()
        {

            var Data = _db.CartItems.Select(x =>
            new CartTtemRequest
            {
                CartId = x.CartId,
                CartItemId = x.CartItemId,
                Quantity = x.Quantity,
                Product = new ProductDto
                {

                    ProductId = x.Product.ProductId,
                    Price = x.Product.Price,
                    ProductName = x.Product.ProductName,
                    Description = x.Product.Description,
                }
            }



            ).ToList();

            return Ok(Data);

        }


        [HttpGet]
        public IActionResult GetByidCartItems(int id)
        {

            var Data = _db.CartItems.Where(c => c.CartId == id).Select(x =>
            new CartTtemRequest
            {
                CartId = x.CartId,
                CartItemId = x.CartItemId,
                Quantity = x.Quantity,
                Product = new ProductDto
                {

                    ProductId = x.Product.ProductId,
                    Price = x.Product.Price,
                    ProductName = x.Product.ProductName,
                    Description = x.Product.Description,
                }
            }



            ).ToList();

            return Ok(Data);

        }

        [HttpPost]
         public  IActionResult AddCart([FromBody] AddCartRequest request)
        
        
        {
            var data = new CartItem
            {
                CartId = request.CartId,
                Quantity = request.Quantity,
                ProductId = request.ProductId,

            };
            _db.CartItems.Add(data);
           _db.SaveChanges();


            return Ok(); 
        
                }






        [HttpPut("UpdateCartbyCartid{id}")]
        public IActionResult UPDATECART([FromBody] CartUPdateREquest cartDto, int id)
        {
            var c = _db.CartItems.Find(id);
            c.Quantity = cartDto.Quantity;
      
            _db.CartItems.Update(c);
            _db.SaveChanges();
            return Ok();
        }



        [Route("DeleteItem/{id}")]
        [HttpDelete]
        public IActionResult DeleteFromCart(int id)
        {
            if (id <= 0) { return BadRequest(); }

            var y = _db.CartItems.Find(id);
            if (y == null)
            {
                return NotFound();
            }
            _db.CartItems.Remove(y);
            _db.SaveChanges();
            return NoContent();

        }





    }
}

