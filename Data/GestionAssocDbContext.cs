using gestion_assoc.Models.Domain;
using gestion_assoc.Models;

using Microsoft.EntityFrameworkCore;

namespace gestion_assoc.Data
{
    public class GestionAssocDbContext : DbContext
    {
        public GestionAssocDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Association> Associations { get; set; }
        public DbSet<Activite> Activites { get; set; }

    }
}
