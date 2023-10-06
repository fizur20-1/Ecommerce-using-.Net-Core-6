using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIecommerce.Controllers
{
    //[Route("api/[controller]/[action]")]

    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("api/categories")]
        public IActionResult Categories()
        {
            try
            {
                var data = CategoryService.Get();
                return Ok(data); // Return 200 OK with the data
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/categories/{id}")]
        public IActionResult Categories(int Id)
        {
            try
            {
                var data1 = CategoryService.Get(Id);
                
                 return Ok(data1);
     
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/categories/create")]
        public IActionResult Create(CategoryDTO data)
        {
            try
            {
                var res = CategoryService.Create(data);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/catagories/update")]
        public IActionResult Update(CategoryDTO data)
        {

            var exmp = CategoryService.Get(data.Id);

            if (exmp != null)
            {
                try
                {
                    var res = CategoryService.Update(data);
                    if (res != null)
                    {

                        return Ok(new { Message = "Updated" });
                    }
                    else
                    {
                        return BadRequest(new { Message = "You Can't Update Others CATEGORY" });
                    }

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
                return BadRequest(new { Message = "CATEGORY not found" });
        }


        [HttpPost]
        [Route("api/catagories/delete/{id}")]
        public IActionResult Delete(int Id)
        {
            var exmp = CategoryService.Get(Id);

            if (exmp != null)
            {
                try
                {
                    var res = CategoryService.Delete(Id);
                    if (res != null)
                    {

                        return Ok(new { Message = "Deleted" });
                    }
                    else
                    {
                        return BadRequest(new { Message = "You Can't Delete Others category" });
                    }

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
                return BadRequest(new { Message = "category not found" });
        }
    }
} 
