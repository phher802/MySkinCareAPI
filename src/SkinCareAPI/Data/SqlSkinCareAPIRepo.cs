using System.Collections.Generic;
using SkinCareAPI.Models;
using System.Linq;
using System;

namespace SkinCareAPI.Data
{
    public class SqlSkinCareAPIRepo : ISkinCareAPIRepo
    {
        private readonly SkinCareContext _context;
        public SqlSkinCareAPIRepo(SkinCareContext context)
        {
            _context = context;
        }
        public void CreateSkinCare(SkinCare sc)
        {   
            if(sc == null)
            {
                throw new ArgumentNullException(nameof(sc));
            }

            _context.SkinCareItems.Add(sc);
        
        }

        public void DeleteSkinCare(SkinCare sc)
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
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateSkinCare(SkinCare sc)
        {
            
        }
    }
}