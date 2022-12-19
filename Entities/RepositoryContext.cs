using Entities.Configuration;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext() : base() { }
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ArtMuseumConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistConfiguration());
            modelBuilder.ApplyConfiguration(new PaintingConfiguration());
            modelBuilder.ApplyConfiguration(new ExhibitionConfiguration());
            modelBuilder.ApplyConfiguration(new TourConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<ArtMuseum> ArtMuseums { get; set; }
        public DbSet<Exhibition> Exhibitions { get; set; }
        public DbSet<Painting> Paintings { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}
