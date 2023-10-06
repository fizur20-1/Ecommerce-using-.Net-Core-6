using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIecommerce.Controllers
{
    
    [ApiController]
    public class ReviewController : ControllerBase
    {
        [HttpGet]
        [Route("api/reviews")]
        public IActionResult Reviews()
        {
            try
            {
                var data = ReviewService.Get();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/reviews/{id}")]
        public IActionResult Reviews(int Id) //pharmacy id
        {
            try
            {
                var data1 = ReviewService.Get(Id);

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
        [Route("api/reviews/create")]
        public IActionResult Create(ReviewDTO data)
        {
            try
            {
                var res = ReviewService.Create(data);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/reviews/update")]
        public IActionResult Update(ReviewDTO data)
        {

            var exmp = ReviewService.Get(data.Id);

            if (exmp != null)
            {
                try
                {
                    var res = ReviewService.Update(data);
                    if (res != null)
                    {

                        return Ok(new { Message = "Updated" });
                    }
                    else
                    {
                        return BadRequest(new { Message = "You Can't Update Others Review" });
                    }

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
                return BadRequest(new { Message = "Review not found" });
        }

        [HttpPost]
        [Route("api/reviews/delete/{id}")]
        public IActionResult Delete(int Id)
        {
            var exmp = ReviewService.Get(Id);

            if (exmp != null)
            {
                try
                {
                    var res = ReviewService.Delete(Id);
                    if (res != null)
                    {

                        return Ok(new { Message = "Deleted" });
                    }
                    else
                    {
                        return BadRequest(new { Message = "You Can't Delete Others Review" });
                    }

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
                return BadRequest(new { Message = "Review not found" });
        }
    }
}
