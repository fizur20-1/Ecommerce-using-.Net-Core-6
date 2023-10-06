using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIecommerce.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("api/products")]
        public IActionResult Products()
        {
            try 
            {
                var data = ProductService.Get();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/products/GetAll")]
        public IActionResult GetAllProducts(string category,string subCategory, int count)
        {
            try
            {
                var data = ProductService.GetAll(category, subCategory, count);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/products/{id}")]
        public IActionResult Products(int Id) //pharmacy id
        {
            try
            {
                var data1 = ProductService.Get(Id);
                
                if (data1 != null)
                {
                    return Ok(data1);
                }
                else { return BadRequest(); }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

      
        [HttpPost]
        [Route("api/products/create")]
        public IActionResult Create(ProductDTO data)
        {
            try
            {
                var res = ProductService.Create(data);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

       
        [HttpPost]
        [Route("api/products/update")]
        public IActionResult Update(ProductDTO data)
        {

            var exmp = ProductService.Get(data.Id);

            if (exmp != null)
            {
                try
                {
                    var res = ProductService.Update(data);
                    if (res != null)
                    {

                        return Ok(new { Message = "Updated" });
                    }
                    else
                    {
                        return BadRequest(new { Message = "You Can't Update Others product" });
                    }

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
                return BadRequest(new { Message = "product not found" });
        }

        [HttpPost]
        [Route("api/products/delete/{id}")]
        public IActionResult Delete(int Id)
        {
            var exmp = ProductService.Get(Id);

            if (exmp != null)
            {
                try
                {
                    var res = ProductService.Delete(Id);
                    if (res != null)
                    {

                        return Ok(new { Message = "Deleted" });
                    }
                    else
                    {
                        return BadRequest(new { Message = "You Can't Delete Others Product" });
                    }

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
                return BadRequest(new { Message = "Product not found" });
        }
    }
}

