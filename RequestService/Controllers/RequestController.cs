using Microsoft.AspNetCore.Mvc;
using RequestService.Policies;

namespace RequestService.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class RequestController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public RequestController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        //Get api/request
        [HttpGet]
        public async Task<ActionResult> MakeRequest()
        {
            var client = _clientFactory.CreateClient("Test");

            var response = await client.GetAsync("https://localhost:7138/api/response/30");

            // var response = await _clientPolicy.ImmediateHttpRetry.ExecuteAsync(
            //     () => client.GetAsync("https://localhost:7138/api/response/25")
            // );

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> ResponseService returned Success");
                return Ok();
            }
            Console.WriteLine("--> ResponseService returned Failure");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}