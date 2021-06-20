using eDrugs.ApplicationCore;
using Microsoft.EntityFrameworkCore;

namespace eDrugs.DbAccess
{
    public class ApplicationDbContext  : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Drug> Drugs { get; set; }
        public DbSet<DrugMfgInfo> DrugMfgInfos { get; set; }
    }
}