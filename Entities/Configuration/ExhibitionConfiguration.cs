using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    public class ExhibitionConfiguration : IEntityTypeConfiguration<Models.Exhibition>
    {
        public void Configure(EntityTypeBuilder<Models.Exhibition> builder)
        {
            builder.HasData
                (
                    new Models.Exhibition
                    {
                        Id = new string("e5368172-b396-4960-8e67-ddffceefc98b"),
                        Name = "exhibition of belarusian artists",
                        ArtMuseumId = new string("033c8277-9be5-451b-9936-87f4b07caae7")
                    },
                    new Models.Exhibition 
                    { 
                        Id = new string("e177f248-6517-449c-9200-16b673c5beff"),
                        Name = "arts of world",
                        Description = "exhibition of famous paintings from different times",
                        ArtMuseumId=new string("df77f745-2310-4bba-b157-c4f3434ff749")
                    }
                );
        }
    }
}
