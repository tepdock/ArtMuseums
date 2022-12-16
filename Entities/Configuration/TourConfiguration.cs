using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    public class TourConfiguration : IEntityTypeConfiguration<Models.Tour>
    {
        public void Configure(EntityTypeBuilder<Models.Tour> builder)
        {
            builder.HasData
                (
                    new Models.Tour
                    {
                        Id = new string("805ed4d2-bcf3-48cf-a722-94db044d43ac"),
                        TourPlaces = 20,
                        ExhibitionId = new string("e5368172-b396-4960-8e67-ddffceefc98b")
                    },
                    new Models.Tour
                    {
                        Id= new string("579acbef-ffbe-42fe-b26d-5f8befa41889"),
                        TourPlaces = 5,
                        ExhibitionId = new string("e5368172-b396-4960-8e67-ddffceefc98b")
                    },
                    new Models.Tour
                    {
                        Id = new string("769a5cb1-9b03-447f-a2d9-c8589a0c901d"),
                        TourPlaces = 20,
                        ExhibitionId = new string("e177f248-6517-449c-9200-16b673c5beff")
                    },
                    new Models.Tour
                    {
                        Id = new string("b177f615-4df7-4aa8-9f98-21f7a9a18f32"),
                        TourPlaces = 5,
                        ExhibitionId = new string("e177f248-6517-449c-9200-16b673c5beff")
                    }
                );
        }
    }
}
