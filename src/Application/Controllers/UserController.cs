using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : DefaultController
    {
        public UserController()
        {

        }

        [HttpGet]
        public string Get()
        {
            return "Hello World";
        }
    }
}
