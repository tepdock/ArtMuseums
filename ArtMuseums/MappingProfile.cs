using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace ArtMuseums
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Exhibition, ExhibitionDto>();
            CreateMap<ExhibitionForCreationDto, Exhibition>();
            CreateMap<Artist, ArtistDto>();
            CreateMap<ArtistForCreationDto, Artist>();
            CreateMap<Entities.Models.ArtMuseum, MuseumDto>();
            CreateMap<MuseumForCreationDto, Entities.Models.ArtMuseum>();
            CreateMap<Painting, PaintingDto>();
            CreateMap<PaintingForCreationDto, Painting>();
            CreateMap<Ticket, TicketDto>();
            CreateMap<TicketForCreationDto, Ticket>();
            CreateMap<Tour, TourDto>();
            CreateMap<User, UserDto>();
        }
    }
}
