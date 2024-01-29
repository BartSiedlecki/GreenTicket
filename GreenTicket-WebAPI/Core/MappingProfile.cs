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

            CreateMap<Country, CountryDto>();

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

            CreateMap<Order, PaymentOrderDto>()
                .ForMember(x => x.UserFirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(x => x.UserLastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(x => x.AlreadyPaid, opt => opt.MapFrom(src => src.Statuses.Any(s => s.Type == OrderStatusType.Paid)));

            CreateMap<Order, OrderDetailsDto>();

            CreateMap<Order, OrderListItemDto>()
                .ForMember(dto => dto.Events, opt => opt.MapFrom(src => src.Tickets.Select(t => t.StandingPlace != null ? t.StandingPlace.Section.Event : t.Seat.Row.Section.Event).Distinct()))
                .ForMember(dto => dto.AlreadyPaid, opt => opt.MapFrom(src => src.Statuses.Where(s => s.Type == OrderStatusType.Paid).Any()));

            CreateMap<Row, RowDto>();

            CreateMap<Role, RoleDto>();

            string sessionId = "";
            CreateMap<Seat, SeatDto>()
                .ForMember(e => e.CurrentReservation, opt => opt.MapFrom(src => ((src.ReservationSessionId == sessionId) && src.ReservationDate < DateTime.Now.AddMinutes(20))))
                .ForMember(e => e.Reserved, opt => opt.MapFrom(src => (!(src.ReservationSessionId == null) && src.ReservationDate < DateTime.Now.AddMinutes(20))));

            CreateMap<Section, SectionDto>()
                .ForMember(e => e.IsStanding, opt => opt.MapFrom(src => src.SectionType == SectionTypes.Standing ? true : false));

            CreateMap<Ticket, TicketDto>()
                .ForMember(e => e.EventId, opt => opt.MapFrom(src => src.StandingPlace != null ? src.StandingPlace.Section.EventId : src.Seat.Row.Section.EventId))
                .ForMember(e => e.EventName, opt => opt.MapFrom(src => src.StandingPlace != null ? src.StandingPlace.Section.Event.Name : src.Seat.Row.Section.Event.Name))
                .ForMember(e => e.EventStartDate, opt => opt.MapFrom(src => src.StandingPlace != null ? src.StandingPlace.Section.Event.StartDateTime : src.Seat.Row.Section.Event.StartDateTime))
                .ForMember(e => e.EventEndDate, opt => opt.MapFrom(src => src.StandingPlace != null ? src.StandingPlace.Section.Event.EndDateTime : src.Seat.Row.Section.Event.EndDateTime))
                .ForMember(e => e.IsStanding, opt => opt.MapFrom(src => src.StandingPlace != null ? true : false))
                .ForMember(e => e.SectionName, opt => opt.MapFrom(src => src.StandingPlace != null ? src.StandingPlace.Section.Name : src.Seat.Row.Section.Name))
                .ForMember(e => e.Price, opt => opt.MapFrom(src => src.StandingPlace != null ? src.StandingPlace.Section.Price : src.Seat.Row.Section.Price))
                .ForMember(e => e.SeatNo, opt => opt.MapFrom(src => src.StandingPlace == null ? src.Seat.Number : 0))
                .ForMember(e => e.Venue, opt => opt.MapFrom(src => src.StandingPlace == null ? src.Seat.Row.Section.Event.Venue : src.StandingPlace.Section.Event.Venue))
                .ForMember(e => e.RowName, opt => opt.MapFrom(src => src.StandingPlace == null ? src.Seat.Row.Name : ""))
                .ForMember(e => e.EventImage, opt => opt.MapFrom(src => src.StandingPlace != null ?
                                                                        src.StandingPlace.Section.Event.Images.FirstOrDefault(i => i.ImageType == ImageType.Card) == null ? "card-background.jpg" : src.StandingPlace.Section.Event.Images.FirstOrDefault(i => i.ImageType == ImageType.Card)!.FileName :
                                                                        src.Seat.Row.Section.Event.Images.FirstOrDefault(i => i.ImageType == ImageType.Card) == null ? "card-background.jpg" : src.Seat.Row.Section.Event.Images.FirstOrDefault(i => i.ImageType == ImageType.Card)!.FileName));


            CreateMap<User, LoggedUserDto>();

            CreateMap<User, BasketUserDetailsDto>()
                .ForMember(e => e.Street, opt => opt.MapFrom(src => src.Address.Street))
                .ForMember(e => e.StreetNo, opt => opt.MapFrom(src => src.Address.StreetNo))
                .ForMember(e => e.PostalCode, opt => opt.MapFrom(src => src.Address.PostalCode))
                .ForMember(e => e.City, opt => opt.MapFrom(src => src.Address.City.Name))
                .ForMember(e => e.Country, opt => opt.MapFrom(src => src.Address.Country.Name));

            CreateMap<Venue, VenueDto>()
                .ForMember(e => e.City, opt => opt.MapFrom(src => src.Address.City.Name))
                .ForMember(e => e.PostalCode, opt => opt.MapFrom(src => src.Address.PostalCode))
                .ForMember(e => e.Street, opt => opt.MapFrom(src => src.Address.Street))
                .ForMember(e => e.StreetNo, opt => opt.MapFrom(src => src.Address.StreetNo));
        }
    }
}
