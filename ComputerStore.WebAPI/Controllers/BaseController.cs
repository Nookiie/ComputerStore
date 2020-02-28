using Microsoft.AspNetCore.Mvc;

namespace ComputerStore.WebAPI.Controllers
{
    [ApiController]
    public class BaseController 
    {
        [HttpGet("api/[action]")]
        public string Credits()
        {
            return "Made by Viktor";
        }

    }
}
