using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SkinCareAPI.Data;

namespace SkinCareAPI.controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class SkinCaresController : ControllerBase
    {
        private readonly ISkinCareAPIRepo _repository;

        public SkinCaresController(ISkinCareAPIRepo respository)
        {
            _repository = respository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {"this", "is", "hard", "coded"};
        }
    }
}