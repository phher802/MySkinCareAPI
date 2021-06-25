using System;
using Xunit;
using SkinCareAPI.Models;

namespace SkinCareAPI.Tests
{
    public class SkinCareTests
    {
        [Fact]
        public void CanChangeIngredientName()
        {
            //arrange
            var testSkinCare = new SkinCare
            {
                IngredientName = "Oil",
                Contain = "Saturated fat from a coconut fruit",
                ReasonWhyItsBad = "Pore clogging for oily or acne prone skin.",
                Source = "https://skinresourcemd.com/blogs/news/no-you-should-not-use-coconut-oil-on-your-face."
            };
        
            //Act
            testSkinCare.IngredientName = "Coconut Oil";
        
            //Asstert
            Assert.Equal("Coconut Oil", testSkinCare.IngredientName);
        }

         [Fact]
        public void CanChangeContain()
        {
            //arrange
            var testSkinCare = new SkinCare
            {
                IngredientName = "Oil",
                Contain = "Saturated fat from a coconut fruit",
                ReasonWhyItsBad = "Pore clogging for oily or acne prone skin.",
                Source = "https://skinresourcemd.com/blogs/news/no-you-should-not-use-coconut-oil-on-your-face."
            };
        
            //Act
            testSkinCare.Contain = "Fatty acids from the coconut fruit.";
        
            //Asstert
            Assert.Equal("Fatty acids from the coconut fruit.", testSkinCare.Contain);
        }
        
         [Fact]
        public void CanChangeReasonWhyItsBad()
        {
            //arrange
            var testSkinCare = new SkinCare
            {
                IngredientName = "Oil",
                Contain = "Saturated fat from a coconut fruit",
                ReasonWhyItsBad = "Pore clogging for oily or acne prone skin.",
                Source = "https://skinresourcemd.com/blogs/news/no-you-should-not-use-coconut-oil-on-your-face."
            };
        
            //Act
            testSkinCare.ReasonWhyItsBad = "It's comedogenic and the oil sits on top of your skin rather than moisteurizes it.";
        
            //Asstert
            Assert.Equal("It's comedogenic and the oil sits on top of your skin rather than moisteurizes it.", testSkinCare.ReasonWhyItsBad);
        }

 
      
    }
}
