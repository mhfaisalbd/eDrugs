using eDrugs.ApplicationCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eDrugs.DbAccess
{
    public class ApplicationDbContext  : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Drug> Drugs { get; set; }
        public DbSet<DrugMfgInfo> DrugMfgInfos { get; set; }
    }
}