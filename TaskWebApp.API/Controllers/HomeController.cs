using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        //Bu bir API projesi olduğu için. Bu dönmüş olduğum tiplerin implemente etmiş olduğu bir interface var "IActionResult" bu şu anlama geliyor, Api projesinde dönüş tipi okey, bad request, not found gibi fönme yapmam lazım

        public async Task<IActionResult> GetContentAsync(CancellationToken token)
        {
            try
            {
                _logger.LogInformation("Started request");
                await Task.Delay(5000, token);
                var mytask = new HttpClient().GetStringAsync("https://www.google.com");

                var data = await mytask;
                _logger.LogInformation("Finished request");
                return Ok(data);
            }
            catch (Exception ex)
            {

                _logger.LogInformation("Error has been cancelled:" + ex.Message); 
                return BadRequest();
            }

          
           
        }
    }
}
