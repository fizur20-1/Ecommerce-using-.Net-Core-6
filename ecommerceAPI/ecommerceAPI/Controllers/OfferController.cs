using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIecommerce.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        [HttpGet]
        [Route("api/offers")]
        public IActionResult Offers()
        {
            try
            {
                var data = OfferService.Get();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/offers/{id}")]
        public IActionResult Offers(int Id)
        {
            try
            {
                var data1 = OfferService.Get(Id);

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
        [Route("api/offers/create")]
        public IActionResult Create(OfferDTO data)
        {
            try
            {
                var res = OfferService.Create(data);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/offers/update")]
        public IActionResult Update(OfferDTO data)
        {

            var exmp = OfferService.Get(data.Id);

            if (exmp != null)
            {
                try
                {
                    var res = OfferService.Update(data);
                    if (res != null)
                    {

                        return Ok(new { Message = "Updated" });
                    }
                    else
                    {
                        return BadRequest(new { Message = "You Can't Update Others Offer" });
                    }

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
                return BadRequest(new { Message = "Offer not found" });
        }

        [HttpPost]
        [Route("api/offers/delete/{id}")]
        public IActionResult Delete(int Id)
        {
            var exmp = OfferService.Get(Id);

            if (exmp != null)
            {
                try
                {
                    var res = OfferService.Delete(Id);
                    if (res != null)
                    {

                        return Ok(new { Message = "Deleted" });
                    }
                    else
                    {
                        return BadRequest(new { Message = "You Can't Delete Others Offer" });
                    }

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
                return BadRequest(new { Message = "Offer not found" });
        }
    }
}
