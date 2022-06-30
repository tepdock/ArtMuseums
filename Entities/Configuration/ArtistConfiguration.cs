using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasData
                (
                    new Artist
                    {
                        Id = new Guid("3afac7d0-c751-4fc6-9f3d-b6c8e22fb05f"),
                        Name = "Van Gogh",
                        Country = "France"
                    },
                    new Artist
                    {
                        Id=new Guid("e528467c-2dfe-48fa-9e1a-739d2d0c0cd2"),
                        Name = "Ivan Aivazovski",
                        Country = "Russia"
                    },
                    new Artist
                    {
                        Id = new Guid("ffb62ca6-0c3e-4a64-9b22-5af9d79c08ab"),
                        Name = "Mark Shagal",
                        Country = "Belarus"
                    }
                );
        }
    }
}
