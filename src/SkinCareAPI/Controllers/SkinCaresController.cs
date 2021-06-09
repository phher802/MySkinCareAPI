using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SkinCareAPI.controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class SkinCaresController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {"this", "is", "hard", "coded"};
        }
    }
}