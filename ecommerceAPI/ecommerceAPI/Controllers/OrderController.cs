using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIecommerce.Controllers
{
    
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        [Route("api/orders")]
        public IActionResult Orders()
        {
            try
            {
                var data = OrderService.Get();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/orders/{id}")]
        public IActionResult Orders(int Id) 
        {
            try
            {
                var data1 = OrderService.Get(Id);

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
        [Route("api/orders/create")]
        public IActionResult Create(OrderDTO data)
        {
            try
            {
                var res = OrderService.Create(data);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/orders/update")]
        public IActionResult Update(OrderDTO data)
        {

            var exmp = OrderService.Get(data.Id);

            if (exmp != null)
            {
                try
                {
                    var res = OrderService.Update(data);
                    if (res != null)
                    {

                        return Ok(new { Message = "Updated" });
                    }
                    else
                    {
                        return BadRequest(new { Message = "You Can't Update Others Order" });
                    }

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
                return BadRequest(new { Message = "Order not found" });
        }

        [HttpPost]
        [Route("api/orders/delete/{id}")]
        public IActionResult Delete(int Id)
        {
            var exmp = OrderService.Get(Id);

            if (exmp != null)
            {
                try
                {
                    var res = OrderService.Delete(Id);
                    if (res != null)
                    {

                        return Ok(new { Message = "Deleted" });
                    }
                    else
                    {
                        return BadRequest(new { Message = "You Can't Delete Others Order" });
                    }

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
                return BadRequest(new { Message = "Order not found" });
        }
    }
}
