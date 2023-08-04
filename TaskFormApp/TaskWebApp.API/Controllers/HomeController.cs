using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
    //bU BİR apı PROJESİ OLDUĞU İÇİN Bu dönmüş olduğum tiplerin implemente etmiş olduğu bir interface var "IActionResult" bu şu anlama geliyor, Api projesinde dönüş tipi okey, bad request, not found gibi fönme yapmam lazım

        public async Task<IActionResult> GetContentAsync()
        {
            var mytask = new HttpClient().GetStringAsync("https://www.google.com");

            var data = await mytask;
            return Ok(data);
        } 
    
    }
}
