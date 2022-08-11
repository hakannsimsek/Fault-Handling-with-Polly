using Microsoft.AspNetCore.Mvc;

namespace ResponseService.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ResponseController : ControllerBase
    {
        //GET /api/response/1-100

        [Route("{id:int}")]
        [HttpGet]
        public ActionResult GetAResponse(int id)
        {
            Random random = new Random();
            var randomInteger = random.Next(1, 101);
            if (randomInteger >= id)
            {
                Console.WriteLine("--> Failure - Generate a HTTP 500");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Console.WriteLine("--> Success - Generate a HTTP 200");
            return Ok();
        }
    }
}