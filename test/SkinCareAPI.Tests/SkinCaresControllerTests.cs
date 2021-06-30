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
          
            //use setup method to establish how it will behave; specify interface method called GetAllSkinCares to mock repo
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

        [Fact]
        public void GetAllSkinCares_ReturnsOneItem_WhenDBHasOneResource()
        {
        //Arrange
            //arrange mockRepo to return a single command resource
            mockRepo.Setup( repo => repo.GetAllSkinCares()).Returns(GetSkinCares(1));
            //use the object extension on the mock to pass in a mock object instance of ISkinCareAPIRepo
            //pass the IMapper instance to the SkinCaresController constructor
            var controller = new SkinCaresController(mockRepo.Object, mapper);
        //Act
            var result = controller.GetAllSkinCares();
        //Assert
            //convert orginal result to an OkObjectResult in order to navigate object hierarchy
            var OkResult = result.Result as OkObjectResult;
            //obtain a list of SkinCaresReadDtos
            var skinCares = OkResult.Value as List<SkinCareReadDto>;
            //assert that we have a single result set on our SkinCares List
            Assert.Single(skinCares);
        }

        [Fact]
        public void GetAllSkinCares_Returns200K_WhenDBHasOneResource()
        {
        //Arrange
            mockRepo.Setup(repo => repo.GetAllSkinCares()).Returns(GetSkinCares(1));
            var controller = new SkinCaresController (mockRepo.Object, mapper);
        //Act
            var result = controller.GetAllSkinCares();
        //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetAllSkinCares_ReturnsCorrectType_WhenDBHasOneResource()
        {
        //Arrange
            mockRepo.Setup(repo => repo.GetAllSkinCares()).Returns(GetSkinCares(1));
            var controller = new SkinCaresController (mockRepo.Object, mapper);
        //Act
            var result = controller.GetAllSkinCares();
        //Assert
            Assert.IsType<ActionResult<IEnumerable<SkinCareReadDto>>>(result);
        }

        [Fact]
        public void GetSkinCareByID_REturns404NotFound_WhenNonExistentIDProvided()
        {
        //arragng
            //setup the GetSkinCareById method on my mock repo to return nulll when an Id of "0" is passed in
            mockRepo.Setup(repo => repo.GetSkinCareById(0)).Returns(() => null);
            var controller = new SkinCaresController(mockRepo.Object, mapper);
        
        //act
            var result = controller.GetSkinCareById(1);
        
        //assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void GetSkinCareById_Returns200OK_WhenValidIDProvided()
        {
        //arrange
            //setup GetSkinCareById method on my repository to return a valid object when passing in id of "1"
            mockRepo.Setup(repo => repo.GetSkinCareById(1)).Returns(new SkinCare 
            {Id = 1,
                IngredientName = "mock",
                Contain = "mock",
                ReasonWhyItsBad = "mock",
                Source = "mock" });
            
            var controller = new SkinCaresController(mockRepo.Object, mapper);
        
        //Act
            var result = controller.GetSkinCareById(1);
        
        //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetSkinCareById_Returns200Ok_WhenValidIDProvided()
        {
        //Arrange
            mockRepo.Setup(repo => repo.GetSkinCareById(1)).Returns(new SkinCare {
                Id = 1,
                IngredientName = "mock",
                Contain = "mock",
                ReasonWhyItsBad = "mock",
                Source = "mock"
            });
            //use the object extension on the mock to pass in a mock object instance of ISkinCareAPIRepo
            //pass the IMapper instance to the SkinCaresController constructor
            var controller = new SkinCaresController (mockRepo.Object, mapper);

        //Act
            var result = controller.GetSkinCareById(1);
        //Assert
            //checks to see if a SkinCareReadDto is returned; checks the validity of the externally facing contract;
            //if the controller code is changed to return a different type, the test would fail, highlighting 
            //a potential problem with the contract
            Assert.IsType<ActionResult<SkinCareReadDto>>(result);
        }

        [Fact]
        public void CreateSkinCare_ReturnsCorrectResourceType_WhenValidObjectSubmitted()
        {
        //Arrange
            mockRepo.Setup(repo => repo.GetSkinCareById(1)).Returns(new SkinCare {
                Id = 1,
                IngredientName= "mock",
                Contain = "mock",
                ReasonWhyItsBad = "mock",
                Source = "mock"});

                var controller = new SkinCaresController(mockRepo.Object, mapper);
        
        //Act
            var result = controller.CreateSkincare(new SkinCareCreateDto{});
        
        //Assert
            Assert.IsType<ActionResult<SkinCareReadDto>>(result);
        }

        [Fact]
        public void CreateSkinCare_Returns201Created_WhenValidObjectSubmitted()
        {
        //Arrange
            mockRepo.Setup(repo => repo.GetSkinCareById(1)).Returns(new SkinCare{
                Id = 1,
                IngredientName = "mock",
                Contain = "mock",
                ReasonWhyItsBad = "mock",
                Source = "mock"});

                var controller = new SkinCaresController(mockRepo.Object, mapper);
        
        //Act
            var result = controller.CreateSkincare(new SkinCareCreateDto{});
        
        //Assert
            Assert.IsType<CreatedAtRouteResult>(result.Result);
        }

        [Fact]
        public void UpdateSkinCare_Returns204NoContent_WhenValidObjectSubmitted()
        {
        //Arrange
            //ensure that the GetSkinCareById method will return a valid source when attempting to update
            mockRepo.Setup(repo => repo.GetSkinCareById(1)).Returns(new SkinCare {
                Id = 1,
                IngredientName = "mock",
                Contain = "mock",
                ReasonWhyItsBad = "mock",
                Source = "mock" });

            var controller = new SkinCaresController(mockRepo.Object, mapper);
        //Act
            var result = controller.UpdateSkinCare(1, new SkinCareUpdateDto {});

        //Assert
            //check to see if 204 No content response is successful
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void UpdateSkinCare_Returns404NotFound_WhenNonExistentResourceIdSubmitted()
        {
        //Arrange
            //setup mock repository to return back null, which should trigger the 404 not found behavior
            mockRepo.Setup(repo => repo.GetSkinCareById(0)).Returns(() => null);
            var controller = new SkinCaresController(mockRepo.Object, mapper);
        
        //Act
            var result = controller.UpdateSkinCare(0, new SkinCareUpdateDto{});
        
        //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void PartialSkinCareUpdate_Returns404NotFound_WhenNonExistentResourceIDSubmitted()
        {
        //Arrange
            mockRepo.Setup(repo => repo.GetSkinCareById(0)).Returns(() => null);
            var controller = new SkinCaresController(mockRepo.Object, mapper);
        //Act
            var result = controller.PartialSkinCareUpdate(0, 
            new Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<SkinCareUpdateDto>{});
        
        //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteSkinCare_Returns204NoContent_WhenValidResourceIDSubmitted()
        {
        //Arrange
            mockRepo.Setup(repo => repo.GetSkinCareById(1)).Returns(new SkinCare{
                Id = 1, 
                IngredientName = "mock",
                Contain = "mock",
                ReasonWhyItsBad = "mock",
                Source = "mock"
            });
            var controller = new SkinCaresController(mockRepo.Object, mapper);
        
        //Act
            var result = controller.DeleteSkinCare(1);
        
        //Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}