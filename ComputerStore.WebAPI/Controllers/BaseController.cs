using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
