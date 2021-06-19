using Microsoft.EntityFrameworkCore;
using SkinCareAPI.Models;

namespace SkinCareAPI.Data
{
    public class SkinCareContext : DbContext
    {
        public SkinCareContext(DbContextOptions<SkinCareContext> options)
            :base(options)
            {

            }

            public DbSet<SkinCare> SkinCareItems {get; set;}
    }
}