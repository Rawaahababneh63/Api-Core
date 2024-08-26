using task2.Models;

namespace task2.DTOs
{
    public class categoryRequestDTO
    {


        public string? CategoryName { get; set; }

        //هون الكوتش انشأت  الصورة وحولت IFormFile?نوعها لل 
        public IFormFile? CategoryImage { get; set; }

    }
}
