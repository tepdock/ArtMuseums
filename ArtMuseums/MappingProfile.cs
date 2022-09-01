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
            CreateMap<ExhibitionForUpdateDto, Exhibition>();
            
            CreateMap<Artist, ArtistDto>();
            CreateMap<ArtistForCreationDto, Artist>();
            CreateMap<ArtistForUpdateDto, Artist>();
            
            CreateMap<Entities.Models.ArtMuseum, MuseumDto>();
            CreateMap<MuseumForCreationDto, Entities.Models.ArtMuseum>();
            CreateMap<MuseumForUpdateDto, Entities.Models.ArtMuseum>();
            
            CreateMap<Painting, PaintingDto>();
            CreateMap<PaintingForCreationDto, Painting>();
            CreateMap<PaintingForUpdateDto, Painting>();
            
            CreateMap<Ticket, TicketDto>();
            CreateMap<TicketForCreationDto, Ticket>();
            CreateMap<TicketForUpdatingDto, Ticket>();
            
            CreateMap<Tour, TourDto>();
            CreateMap<TourForCreationDto, Tour>();
            CreateMap<TourForUpdatingDto, Tour>();

            CreateMap<User, UserDto>();
        }
    }
}
