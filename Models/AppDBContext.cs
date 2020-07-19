using Microsoft.EntityFrameworkCore;

namespace SwitchAcc.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<SwModel> SwModels { get; set; }
        public DbSet<VLAN> VLANs { get; set; }
        public DbSet<Switch> Switches { get; set; }

    }
}
