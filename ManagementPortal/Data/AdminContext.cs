using CumbreAllegro2.Models;
using Microsoft.EntityFrameworkCore;

namespace CumbreAllegro2.Data
{
    public class AdminContext : DbContext
    {
        public AdminContext(DbContextOptions<AdminContext> options)
            : base(options)
        {
        }

        public DbSet<Colonia> Colonia { get; set; }
        public DbSet<Calle> Calles { get; set; }
        public DbSet<Casa> Casas { get; set; }
    }
}
