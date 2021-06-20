using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SkinCareAPI.Data;
using SkinCareAPI.Models;
using SkinCareAPI.Dtos;

namespace SkinCareAPI.controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class SkinCaresController : ControllerBase
    {
        private readonly ISkinCareAPIRepo _repository;
        private readonly IMapper _mapper;

        public SkinCaresController(ISkinCareAPIRepo respository, IMapper mapper)
        {
            _repository = respository;
            _mapper = mapper;
        }

        // [HttpGet]
        // public ActionResult<IEnumerable<string>> Get()
        // {
        //     return new string[] {"this", "is", "hard", "coded"};
        // }

        [HttpGet]
        public ActionResult<IEnumerable<SkinCareReadDto>> GetAllSkinCares()
        {
            var skinCareItems = _repository.GetAllSkinCares();
            return Ok(_mapper.Map<IEnumerable<SkinCareReadDto>>(skinCareItems));
        }

        [HttpGet("{id}", Name="GetSkinCareById")]
        public ActionResult<SkinCareReadDto> GetSkinCareById(int id)
        {
            var skinCareItem = _repository.GetSkinCareById(id);

            if(skinCareItem == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SkinCareReadDto>(skinCareItem));
        }

        [HttpPost]
        public ActionResult <SkinCareReadDto> CreateSkincare (SkinCareCreateDto skinCareCreateDto)
        {
            var skinCareModel = _mapper.Map<SkinCare>(skinCareCreateDto);
            _repository.CreateSkinCare(skinCareModel);
            _repository.SaveChanges();

            var SkinCareReadDto = _mapper.Map<SkinCareReadDto>(skinCareModel);

            return CreatedAtRoute(nameof(GetSkinCareById), new {Id = SkinCareReadDto.Id}, SkinCareReadDto);
        }
    }
}