using Entities.Configuration;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext():base() { }
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArtMuseumConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistConfiguration());
            modelBuilder.ApplyConfiguration(new PaintingConfiguration());
            modelBuilder.ApplyConfiguration(new ExhibitionConfiguration());
            modelBuilder.ApplyConfiguration(new TourConfiguration());
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<ArtMuseum> ArtMuseums { get; set; }
        public DbSet<Exhibition> Exhibitions { get; set; }
        public DbSet<Painting> Paintings { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Busket> Buskets { get; set; }
    }
}
