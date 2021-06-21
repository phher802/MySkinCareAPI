using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SkinCareAPI.Data;
using SkinCareAPI.Models;
using SkinCareAPI.Dtos;
using Microsoft.AspNetCore.JsonPatch;


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

        [HttpPut("{id}")]
        public ActionResult UpdateSkinCare(int id, SkinCareUpdateDto skinCareUpdateDto)
        {
            var skinCareModelFromRepo = _repository.GetSkinCareById(id);
            
            if(skinCareModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(skinCareUpdateDto, skinCareModelFromRepo);

            //this following update does nothing at the moment; it is here incase Entity Framework Core implementation need 
            //to be swapped out for another provider that may need a call to the UpdateSkinCare
            _repository.UpdateSkinCare(skinCareModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialSkinCareUpdate(int id, JsonPatchDocument<SkinCareUpdateDto> patchDoc)
        {
            var skinCareModelFromRepo = _repository.GetSkinCareById(id);
            
            if(skinCareModelFromRepo == null)
            {
                return NotFound();
            }

            //need to create SkinCareUpdateDto object based on the skincare object (skinCareModelFromRepo) retrieved
            var skinCareToPatch = _mapper.Map<SkinCareUpdateDto>(skinCareModelFromRepo);
            //apply the Patch Document received in our request body to the newly created SkinCareUpdateDto: skinCareToPatch
            patchDoc.ApplyTo(skinCareToPatch, ModelState);

            if(!TryValidateModel(skinCareToPatch))
            {
                return ValidationProblem(ModelState);
            }

            //SkinCareUpdateDto(SkinCareToPatch) has been successfuly updated and will use automapper to map it back 
            //to the skincare object in DBContext
            _mapper.Map(skinCareToPatch, skinCareModelFromRepo);
            _repository.UpdateSkinCare(skinCareModelFromRepo);
            _repository.SaveChanges();
            return NoContent();

        }
    }
}