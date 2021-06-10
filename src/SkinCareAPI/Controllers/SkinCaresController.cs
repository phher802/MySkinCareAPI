using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SkinCareAPI.Data;
using SkinCareAPI.Models;

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

        // [HttpGet]
        // public ActionResult<IEnumerable<string>> Get()
        // {
        //     return new string[] {"this", "is", "hard", "coded"};
        // }

        [HttpGet]
        public ActionResult<IEnumerable<SkinCare>> GetAllSkinCares()
        {
            var skinCareItems = _repository.GetAllSkinCares();
            return Ok(skinCareItems);
        }

        [HttpGet("{id}")]
        public ActionResult<SkinCare> GetSkinCareById(int id)
        {
            var skinCareItem = _repository.GetSkinCareById(id);

            if(skinCareItem == null)
            {
                return NotFound();
            }

            return Ok(skinCareItem);
        }
    }
}