using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    public class ArtMuseumConfiguration : IEntityTypeConfiguration<Models.ArtMuseum>
    {
        public void Configure(EntityTypeBuilder<Models.ArtMuseum> builder)
        {
            builder.HasData
                (
                    new Models.ArtMuseum
                    {
                        Id = new Guid("033c8277-9be5-451b-9936-87f4b07caae7"),
                        Name = "General art museum",
                        Adress = "st qwerty, 34"
                    },
                    new Models.ArtMuseum
                    {
                        Id=new Guid("df77f745-2310-4bba-b157-c4f3434ff749"),
                        Name = "Museum of modern arts",
                        Adress = "street yung, 25"
                    }
                );
        }
    }
}
