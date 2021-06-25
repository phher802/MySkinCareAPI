using System;
using Xunit;
using SkinCareAPI.Models;

namespace SkinCareAPI.Tests
{
    public class SkinCareTests : IDisposable
    {
        //create a global instance of the SkinCare class
        SkinCare testSkinCare;

        //constructor
        public SkinCareTests()
        {
            testSkinCare = new SkinCare
            {
                IngredientName = "Something",
                Contain = "Some stuff",
                ReasonWhyItsBad = "Some reasons.",
                Source = "A Source"
            };
        }

        //implement a Dispose method to clean up code
        public void Dispose()
        {
            testSkinCare = null;
        }

        [Fact]
        public void CanChangeIngredientName()
        {
            //arrange -- emply because the class constructor will be called for every test

            //Act
            testSkinCare.IngredientName = "Coconut Oil";
        
            //Asstert
            Assert.Equal("Coconut Oil", testSkinCare.IngredientName);
        }

         [Fact]
        public void CanChangeContain()
        {
            //arrange
          
            //Act
            testSkinCare.Contain = "Fatty acids from the coconut fruit.";
        
            //Asstert
            Assert.Equal("Fatty acids from the coconut fruit.", testSkinCare.Contain);
        }
        
         [Fact]
        public void CanChangeReasonWhyItsBad()
        {
            //arrange

            //Act
            testSkinCare.ReasonWhyItsBad = "It's comedogenic and the oil sits on top of your skin rather than moisteurizes it.";
        
            //Assert
            Assert.Equal("It's comedogenic and the oil sits on top of your skin rather than moisteurizes it.", testSkinCare.ReasonWhyItsBad);
        }
         [Fact]
         public void CanChangeSource()
         {
         //Arrange
         
         //Act
         testSkinCare.Source = "https://www.skinterrupt.com/coconut-oil-is-bad-for-your-skin/";
         //Assert
         Assert.Equal("https://www.skinterrupt.com/coconut-oil-is-bad-for-your-skin/", testSkinCare.Source);
         }

       
    }
}
