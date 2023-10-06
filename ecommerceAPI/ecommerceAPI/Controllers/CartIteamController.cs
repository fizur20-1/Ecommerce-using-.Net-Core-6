using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIecommerce.Controllers
{
  //  [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        [HttpGet]
        [Route("api/cartItems")]
        public IActionResult CartItems()
        {
            try
            {
                var data = CartItemService.Get();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/cartItems/{id}")]
        public IActionResult CartItems(int Id)
        {
            try
            {
                var data1 = CartItemService.Get(Id);

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
        [Route("api/cartItems/create")]
        public IActionResult Create(CartItemDTO data)
        {
            try
            {
                var res = CartItemService.Create(data);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/cartItems/update")]
        public IActionResult Update(CartItemDTO data)
        {

            var exmp = CartItemService.Get(data.Id);

            if (exmp != null)
            {
                try
                {
                    var res = CartItemService.Update(data);
                    if (res != null)
                    {

                        return Ok(new { Message = "Updated" });
                    }
                    else
                    {
                        return BadRequest(new { Message = "You Can't Update Others CartItem" });
                    }

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
                return BadRequest(new { Message = "CartItem not found" });
        }

        [HttpPost]
        [Route("api/cartItems/delete/{id}")]
        public IActionResult Delete(int Id)
        {
            var exmp = CartItemService.Get(Id);

            if (exmp != null)
            {
                try
                {
                    var res = CartItemService.Delete(Id);
                    if (res != null)
                    {

                        return Ok(new { Message = "Deleted" });
                    }
                    else
                    {
                        return BadRequest(new { Message = "You Can't Delete Others CartItem" });
                    }

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
                return BadRequest(new { Message = "CartItem not found" });
        }
    }
}
