using AutoMapper;
using AutoMapper.QueryableExtensions;
using GreenTicket_WebAPI.Entities;
using GreenTicket_WebAPI.Exceptions;
using GreenTicket_WebAPI.Models;
using GreenTicket_WebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics.Eventing.Reader;

namespace GreenTicket_WebAPI.Services
{
    public class EventService : IEventService
    {
        private readonly GreenTicketDbContext _context;
        private readonly IMapper _mapper;

        public EventService(GreenTicketDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EventPageDto> GetEventPageModelAsync(int id)
        {
            var eventModel = await _context
            .Events
            .Where(e => e.Id == id)
            .ProjectTo<EventPageDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

            if (eventModel is null)
                throw new NotFoundException("Event not found.");

            return eventModel;
        }

        public async Task<IEnumerable<EventFilterPageDto>> GetFilteredEventsAsync(QueryParamsFilter queryParams)
        {
            var query = _context
            .Events
            .Where(e => e.StartDateTime > DateTime.Now);

            if (queryParams.SubCategoryId.HasValue)
            {
                query = query.Where(e => e.EventSubCategoryId == queryParams.SubCategoryId.Value);
            }
            else if (queryParams.CategoryId.HasValue)
            {
                query = query.Where(e => e.SubCategory.CategoryId == queryParams.CategoryId.Value);
            }

            if (queryParams.CityId.HasValue)
            {
                query = query.Where(e => e.Venue.Address.CityID == queryParams.CityId.Value);
            }


            query = query.OrderBy(e => e.StartDateTime);

            var events = await query
                .AsNoTracking()
                .ProjectTo<EventFilterPageDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return events;
        }

        public async Task<IEnumerable<EventNavigationSearchResultItemDto>> NavigationSearchAsync(string searchPhrase)
        {
            var events = await _context
                .Events
                .Where(e => e.Name.Contains(searchPhrase) || e.Venue.Address.City.Name.Contains(searchPhrase))
                .ProjectTo<EventNavigationSearchResultItemDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return events;
        }

        public async Task<IEnumerable<EventCarouselDto>> GetCarouselModelsAsync(int qty)
        {
            var events = _context
                .Events
                .Where(e => e.Images.Where(i => i.ImageType == ImageType.Carousel).Any())
                .Take(qty)
                .ProjectTo<EventCarouselDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return await events;
        }

        public async Task<IEnumerable<EventCardDto>> GetCardsAsync(CardCategory category, int qty)
        {

            switch (category)
            {
                case CardCategory.Newest:
                    var newestEvents = _context
                        .Events
                        .OrderByDescending(e => e.CreateDateTime)
                        .Take(qty)
                        .ProjectTo<EventCardDto>(_mapper.ConfigurationProvider)
                        .ToListAsync();

                    return await newestEvents;
                case CardCategory.Sport:
                    var sportEvents = _context
                        .Events
                        .Where(e => e.SubCategory.Category.Category == EventCategories.Sport) 
                        .OrderBy(e => Guid.NewGuid())
                        .Take(qty)
                        .ProjectTo<EventCardDto>(_mapper.ConfigurationProvider)
                        .ToListAsync();

                    return await sportEvents;
                case CardCategory.Culture:
                    var cultureEvents = _context
                        .Events
                        .Where(e => e.SubCategory.Category.Category == EventCategories.Culture)
                        .OrderBy(e => Guid.NewGuid())
                        .Take(qty)
                        .ProjectTo<EventCardDto>(_mapper.ConfigurationProvider)
                        .ToListAsync();

                    return await cultureEvents;
                case CardCategory.Concert:
                    var concertEvents = _context
                        .Events
                        .Where(e => e.SubCategory.Category.Category == EventCategories.Concerts)
                        .OrderBy(e => Guid.NewGuid())
                        .Take(qty)
                        .ProjectTo<EventCardDto>(_mapper.ConfigurationProvider)
                        .ToListAsync();

                    return await concertEvents;
                default:
                    break;
            }

            var events = _context
                .Events
                .OrderByDescending(e => e.CreateDateTime)
                .Take(qty)
                .ProjectTo<EventCardDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return await events;
        }
    }
}
