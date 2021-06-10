using System.Collections.Generic;
using SkinCareAPI.Models;

namespace SkinCareAPI.Data
{
    public interface ISkinCareAPIRepo
    {
        bool SaveChanges();
        IEnumerable<SkinCare> GetAllSkinCares();
        SkinCare GetSkinCareById(int id);
        void CreateSkinCare(SkinCare cmd);
        void UpdateSkinCare(SkinCare cmd);
        void DeleteSkinCare(SkinCare cmd);

        
    }

}