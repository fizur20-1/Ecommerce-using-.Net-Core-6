using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIecommerce.Controllers 
{
   
    [ApiController]
    public class CartController : ControllerBase
    {
        [HttpGet]
        [Route("api/carts")]
        public IActionResult Carts()
        {
            try
            {
                var data = CartService.Get();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/carts/{id}")]
        public IActionResult Carts(int Id) 
        {
            try
            {
                var data1 = CartService.Get(Id);

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
        [Route("api/carts/create")]
        public IActionResult Create(CartDTO data)
        {
            try
            {
                var res = CartService.Create(data);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/carts/update")]
        public IActionResult Update(CartDTO data)
        {

            var exmp = CartService.Get(data.Id);

            if (exmp != null)
            {
                try
                {
                    var res = CartService.Update(data);
                    if (res != null)
                    {

                        return Ok(new { Message = "Updated" });
                    }
                    else
                    {
                        return BadRequest(new { Message = "You Can't Update Others Cart" });
                    }

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
                return BadRequest(new { Message = "Cart not found" });
        }

        [HttpPost]
        [Route("api/carts/delete/{id}")]
        public IActionResult Delete(int Id)
        {
            var exmp = CartService.Get(Id);

            if (exmp != null)
            {
                try
                {
                    var res = CartService.Delete(Id);
                    if (res != null)
                    {

                        return Ok(new { Message = "Deleted" });
                    }
                    else
                    {
                        return BadRequest(new { Message = "You Can't Delete Others Cart" });
                    }

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
                return BadRequest(new { Message = "Cart not found" });
        }
    }
}
