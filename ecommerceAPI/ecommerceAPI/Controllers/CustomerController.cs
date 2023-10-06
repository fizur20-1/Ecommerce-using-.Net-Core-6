using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIecommerce.Controllers
{
   
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        [Route("api/customers")]
        public IActionResult Customers()
        {
            try
            {
                var data = CustomerService.Get();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/customers/{id}")]
        public IActionResult Customers(int Id) //pharmacy id
        {
            try
            {
                var data1 = CustomerService.Get(Id);

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
        [Route("api/customers/create")]
        public IActionResult Create(CustomerDTO data)
        {
            try
            {
                var res = CustomerService.Create(data);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/customers/update")]
        public IActionResult Update(CustomerDTO data)
        {

            var exmp = CustomerService.Get(data.Id);

            if (exmp != null)
            {
                try
                {
                    var res = CustomerService.Update(data);
                    if (res != null)
                    {

                        return Ok(new { Message = "Updated" });
                    }
                    else
                    {
                        return BadRequest(new { Message = "You Can't Update Others Customer" });
                    }

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
                return BadRequest(new { Message = "Customer not found" });
        }

        [HttpPost]
        [Route("api/customers/delete/{id}")]
        public IActionResult Delete(int Id)
        {
            var exmp = CustomerService.Get(Id);

            if (exmp != null)
            {
                try
                {
                    var res = CustomerService.Delete(Id);
                    if (res != null)
                    {

                        return Ok(new { Message = "Deleted" });
                    }
                    else
                    {
                        return BadRequest(new { Message = "You Can't Delete Others Customer" });
                    }

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
                return BadRequest(new { Message = "Customer not found" });
        }
    }
}
