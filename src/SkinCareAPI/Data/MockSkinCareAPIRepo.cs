using System.Collections.Generic;
using SkinCareAPI.Models;

namespace SkinCareAPI.Data
{
    public class MockSkinCareAPIRepo : ISkinCareAPIRepo
    {
        public void CreateSkinCare(SkinCare cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteSkinCare(SkinCare cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<SkinCare> GetAllSkinCares(){
            var skinCare = new List<SkinCare>
            {
                new SkinCare{
                    Id=0, 
                    IngredientName="Coconut oil", 
                    Contain="Wick, meat, and milk of the coconut palm fruit.", 
                    ReasonWhyItsBad="It's comedogenic and clogs pores.", 
                    Source=""}, 
                new SkinCare{
                    Id=1, 
                    IngredientName="Seaweed", 
                    Contain="Algae", 
                    ReasonWhyItsBad="Highly pore clogging; will cause skin cells inside the pore to bind together and form a plug.", 
                    Source="https://www.porespective.com/got-acne-stay-away-from-spirulina-kelp-and-seaweed/"},
                new SkinCare{
                    Id=2, 
                    IngredientName="Jojoba oil",
                    Contain="Erucic acid", 
                    ReasonWhyItsBad="It's mildly comedogenic but can be a problem if formulated with other comedogenic ingredients.  It can cause an allergic reaction in some people.", 
                    Source=""}
            };
            return skinCare;

        }

        public SkinCare GetSkinCareById(int id)
        {
            return new SkinCare{
                    Id=0, 
                    IngredientName="Coconut oil", 
                    Contain="Wick, meat, and milk of the coconut palm fruit.", 
                    ReasonWhyItsBad="It's comedogenic and clogs pores.", 
                    Source=""};   
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateSkinCare(SkinCare cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}