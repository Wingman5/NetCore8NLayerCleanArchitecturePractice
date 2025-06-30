using App.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult(ServiceResult serviceResult)
        {
            if (serviceResult.NoContent())
            {
                return NoContent();
            }
         
            return StatusCode((int)serviceResult.Status, serviceResult.Errors ?? [serviceResult.Message ?? "An error occurred"]);
        }

        [NonAction]
        public IActionResult CreateActionResult<T>(ServiceResult<T> serviceResult)
        {
            if (serviceResult.Status == HttpStatusCode.NoContent)
            {
                return NoContent();
            }

            if (serviceResult.Status == HttpStatusCode.Created)
            {
                return Created(serviceResult.UrlAsCreated, serviceResult.Data);
            }

            return StatusCode((int)serviceResult.Status, serviceResult.Errors ?? [serviceResult.Message ?? "An error occurred"]);
        }


        [NonAction]
        public IActionResult HandleServiceResult<T>(ServiceResult<T> serviceResult)
        {
            if (serviceResult.IsSuccess)
            {
                return Ok(serviceResult.Data);
            }

            if (serviceResult.Status == HttpStatusCode.NotFound)
            {
                return NotFound(serviceResult.Message ?? "Not Found");
            }

            return StatusCode((int)serviceResult.Status, serviceResult.Errors ?? [serviceResult.Message ?? "An error occurred"]);
        }

        [NonAction]
        public IActionResult HandleServiceResult(ServiceResult serviceResult)
        {
            if (serviceResult.IsSuccess)
            {
                return Ok();
            }

            if (serviceResult.Status == HttpStatusCode.NotFound)
            {
                return NotFound(serviceResult.Message ?? "Not Found");
            }

            return StatusCode((int)serviceResult.Status, serviceResult.Errors ?? [serviceResult.Message ?? "An error occurred"]);
        }
    }
}
