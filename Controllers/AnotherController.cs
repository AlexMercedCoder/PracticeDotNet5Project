using Microsoft.AspNetCore.Mvc;


namespace firstapi.Controllers
{
    [Route("cheese")]
    [ApiController]
    public class AnotherController
    {
        [HttpGet]
        public string something(){
            return "Look Ma, This works!";
        }
    }
}