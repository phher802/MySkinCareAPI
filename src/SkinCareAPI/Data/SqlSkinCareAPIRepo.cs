using System.Collections.Generic;
using SkinCareAPI.Models;
using System.Linq;

namespace SkinCareAPI.Data
{
    public class SqlSkinCareAPIRepo : ISkinCareAPIRepo
    {
        private readonly SkinCareContext _context;
        public SqlSkinCareAPIRepo(SkinCareContext context)
        {
            _context = context;
        }
        public void CreateSkinCare(SkinCare cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteSkinCare(SkinCare cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<SkinCare> GetAllSkinCares()
        {
            return _context.SkinCareItems.ToList();
        }

        public SkinCare GetSkinCareById(int id)
        {
            return _context.SkinCareItems.FirstOrDefault(s => s.Id == id);
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