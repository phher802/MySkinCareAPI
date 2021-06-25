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

namespace SkinCareAPI.Tests
{
    public class SkinCareControllerTests
    {
        [Fact]
        public void GetSkinCareItems_ReturnZeroItems_WhenDBIsEmpty()
        {
            //set up a new mock instance of the respository; only need to pass the interface definition
            var mockRepo = new Mock<ISkinCareAPIRepo>();

            //use setup method to establish how it will behave; specify interface method called GetAllSkinCares to mock
            //followed by what we want it to return, GetSkinCares(0)
            mockRepo.Setup(repo => repo.GetAllSkinCares()).Returns(GetSkinCares(0));

            //set up a SkinCaresPRofiles instance and assign it to a MapperConfiguration
            var realProfile = new SkinCaresProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(realProfile));

            //create a concrete instance of IMapper and give it the MapperConfiguration
            IMapper mapper = new Mapper(configuration);

            //use the object extension on the mock to pass in a mock object instance of ISkinCareAPIRepo
            //pass the IMapper instance to the SkinCaresController constructor
            var controller = new SkinCaresController(mockRepo.Object, mapper);
        //When
        
        //Then
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