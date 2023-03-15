using AutoMapper;
using GreenTicket_WebAPI.Entities;
using GreenTicket_WebAPI.Models;

namespace GreenTicket_WebAPI.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<City, CityDto>();

            CreateMap<Event, EventCardDto>()
                .ForMember(e => e.City, opt => opt.MapFrom(src => src.Venue.Address.City.Name))
                .ForMember(e => e.PriceFrom, opt => opt.MapFrom(src => src.Sections.Any() ? (src.Sections.OrderBy(p => p.Price).FirstOrDefault() != null ? src.Sections!.OrderBy(p => p.Price).FirstOrDefault()!.Price : 0) : 0))
                .ForMember(e => e.ImageFileName, opt => opt.MapFrom(src => src.Images.FirstOrDefault(i => i.ImageType == ImageType.Card) == null ? "card-background.jpg" : src.Images.FirstOrDefault(i => i.ImageType == ImageType.Card)!.FileName));

            CreateMap<Event, EventCarouselDto>()
                .ForMember(e => e.City, opt => opt.MapFrom(src => src.Venue.Address.City.Name))
                .ForMember(e => e.ImageFileName, opt => opt.MapFrom( src => src.Images.FirstOrDefault(i => i.ImageType == ImageType.Carousel) == null ? "carousel-background.jpg" : src.Images.FirstOrDefault(i => i.ImageType == ImageType.Carousel)!.FileName));

            CreateMap<Event, EventNavigationSearchResultItemDto>()
                .ForMember(e => e.VenueName, opt => opt.MapFrom(src => src.Venue.Name))
                .ForMember(e => e.City, opt => opt.MapFrom(src => src.Venue.Address.City.Name));

            CreateMap<Event, EventFilterPageDto>()
                .ForMember(e => e.City, opt => opt.MapFrom(src => src.Venue.Address.City.Name))
                .ForMember(e => e.VenueName, opt => opt.MapFrom(src => src.Venue.Name))
                .ForMember(e => e.PriceFrom, opt => opt.MapFrom(src => src.Sections.Any() ? (src.Sections.OrderBy(p => p.Price).FirstOrDefault() != null ? src.Sections!.OrderBy(p => p.Price).FirstOrDefault()!.Price : 0) : 0))
                .ForMember(e => e.EventCardImage, opt => opt.MapFrom(src => src.Images.FirstOrDefault(i => i.ImageType == ImageType.Card) == null ? "card-background.jpg" : src.Images.FirstOrDefault(i => i.ImageType == ImageType.Card)!.FileName));

            CreateMap<Event, EventPageDto>()
                .ForMember(e => e.City, opt => opt.MapFrom(src => src.Venue.Address.City.Name))
                .ForMember(e => e.VenueName, opt => opt.MapFrom(src => src.Venue.Name))
                .ForMember(e => e.PriceFrom, opt => opt.MapFrom(src => src.Sections.Any() ? (src.Sections.OrderBy(p => p.Price).FirstOrDefault() != null ? src.Sections!.OrderBy(p => p.Price).FirstOrDefault()!.Price : 0) : 0))
                .ForMember(e => e.EventCardImage, opt => opt.MapFrom(src => src.Images.FirstOrDefault(i => i.ImageType == ImageType.Card) == null ? "card-background.jpg" : src.Images.FirstOrDefault(i => i.ImageType == ImageType.Card)!.FileName))
                .ForMember(e => e.SeatingPlanImage, opt => opt.MapFrom(src => src.Images.FirstOrDefault(i => i.ImageType == ImageType.SeatingPlan) == null ? "seating-plan-background.jpg" : src.Images.FirstOrDefault(i => i.ImageType == ImageType.SeatingPlan)!.FileName));

            CreateMap<EventCategory, EventCategoryNavDto>();

            CreateMap<EventSubCategory, EventSubCategoryNavDto>()
                .ForMember(e => e.NoOfEventsOnSale, opt => opt.MapFrom(src => src.Events.Where(ev => ev.EndDateTime > DateTime.Now).Count()));

            CreateMap<Row, RowDto>();

            string sessionId = "";
            CreateMap<Seat, SeatDto>()
                .ForMember(e => e.CurrentReservation, opt => opt.MapFrom(src => ((src.ReservationSessionId == sessionId) && src.ReservationDate < DateTime.Now.AddMinutes(20))))
                .ForMember(e => e.Reserved, opt => opt.MapFrom(src => (!(src.ReservationSessionId == null) && src.ReservationDate < DateTime.Now.AddMinutes(20))));

            CreateMap<Section, SectionDto>();
        }
    }
}
