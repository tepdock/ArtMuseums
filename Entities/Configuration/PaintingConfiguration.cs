using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class PaintingConfiguration : IEntityTypeConfiguration<Models.Painting>
    {
        public void Configure(EntityTypeBuilder<Models.Painting> builder)
        {
            builder.HasData
                (
                    new Models.Painting
                    {
                        Id = new string("07ba5109-8aec-48ee-b7d9-21e2ce4f3312"),
                        Name = "a walk",
                        Picture = "https://res.cloudinary.com/dkt2qwk4f/image/upload/v1670924106/progulka-shagal_d0mxfj.jpg",
                        Description = "Прогулка - Марк Захарович Шагал. 1917-1918. Холст, масло 169,6x163,4 см",
                        Year = "1918",
                        Category = "Abstract",
                        ArtistId = "ffb62ca6-0c3e-4a64-9b22-5af9d79c08ab",
                        ExhibitionId = new string("e5368172-b396-4960-8e67-ddffceefc98b")
                    },
                    new Models.Painting
                    {
                        Id= new string("9d944131-b6ee-4b76-825b-fa6163a27787"),
                        Name = "Three Candles",
                        Picture = "https://res.cloudinary.com/dkt2qwk4f/image/upload/v1670924115/triCvechiShagal_bvnhcf.jpg",
                        Description = "Прогулка - Марк Захарович Шагал. 1917-1918. Холст, масло 169,6x163,4 см",
                        Year = "1940",
                        Category = "Modern",
                        ArtistId = "ffb62ca6-0c3e-4a64-9b22-5af9d79c08ab",
                        ExhibitionId = new string("e177f248-6517-449c-9200-16b673c5beff")
                    },
                    new Models.Painting
                    {
                        Id = new string("58bde6fc-74f6-41ba-8d60-39424211cfc6"),
                        Name = "Starry Night",
                        Picture = "https://res.cloudinary.com/dkt2qwk4f/image/upload/v1670873513/VanGogh-starry_night_ballance1_dj6w1i.jpg",
                        Description = "The Starry Night (Dutch: De sterrennacht) is an oil-on-canvas painting by the Dutch Post-Impressionist painter Vincent van Gogh. Painted in June 1889, " +
                        "it depicts the view from the east-facing window of his asylum room at Saint-Rémy-de-Provence, just before sunrise, with the addition of an imaginary village.",
                        Year = "1889",
                        Category = "Expresionism",
                        ArtistId = "3afac7d0-c751-4fc6-9f3d-b6c8e22fb05f",
                        ExhibitionId = new string("e5368172-b396-4960-8e67-ddffceefc98b")
                    }
                );
        }
    }
}
