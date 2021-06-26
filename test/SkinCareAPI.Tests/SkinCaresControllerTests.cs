using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using SkinCareAPI.controllers;
using System.Collections.Generic;
using Moq;
using AutoMapper;
using SkinCareAPI.Models;
using SkinCareAPI.Data;
using SkinCareAPI.Profiles;
using SkinCareAPI.Dtos;


namespace SkinCareAPI.Tests
{
    public class SkinCaresControllerTests : IDisposable
    {
        Mock<ISkinCareAPIRepo> mockRepo;
        SkinCaresProfile realProfile;
        MapperConfiguration configuration;
        IMapper mapper;

        //set up class constructor
        public SkinCaresControllerTests()
        {
            mockRepo = new Mock<ISkinCareAPIRepo>();
            //set up a SkinCaresPRofiles instance and assign it to a MapperConfiguration
            realProfile = new SkinCaresProfile();
            configuration = new MapperConfiguration(cfg => cfg.AddProfile(realProfile));

             //create a concrete instance of IMapper and give it the MapperConfiguration
            mapper = new Mapper(configuration);
        }
        
        public void Dispose()
        {
            mockRepo = null;
            mapper = null;
            configuration = null;
            realProfile = null;
        }

        [Fact]
        public void GetSkinCareItems_ReturnZeroItems_WhenDBIsEmpty()
        {
        //Arrange
          
            //use setup method to establish how it will behave; specify interface method called GetAllSkinCares to mock
            //followed by what we want it to return, GetSkinCares(0)
            mockRepo.Setup(repo => repo.GetAllSkinCares()).Returns(GetSkinCares(0));

            //use the object extension on the mock to pass in a mock object instance of ISkinCareAPIRepo
            //pass the IMapper instance to the SkinCaresController constructor
            var controller = new SkinCaresController(mockRepo.Object, mapper);

        //Act
            //make a call to the GetAllSkinCares action on the controller
            var result = controller.GetAllSkinCares();
            
        //Assert
            //assert that the Result is an OKObjectResult (equals to 200 OK)
            Assert.IsType<OkObjectResult>(result.Result);
        }

        private List<SkinCare> GetSkinCares(int num)
        {
            var skinCares = new List<SkinCare>();
            if(num > 0){
                skinCares.Add(new SkinCare
                {
                    Id = 0,
                    IngredientName = "Coconut Oil",
                    Contain = "Fatty acids from the coconut fruit",
                    ReasonWhyItsBad = "It's comedogenic and cloggs pores.",
                    Source = "https://www.skinterrupt.com/coconut-oil-is-bad-for-your-skin/"
                });
            }
            return skinCares;
        }


    }
}