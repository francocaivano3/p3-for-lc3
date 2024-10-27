using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.Repositories;
using Infrastructure;


namespace Web.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        private readonly ApplicationContext _context;

        private readonly IEventService _eventService;

        private readonly IEventOrganizerService _eventOrganizerService;
        public EventsController(ApplicationContext context, IEventService eventService, IEventOrganizerService eventOrganizerService)
        {
            _context = context;
            _eventService = eventService;
            _eventOrganizerService = eventOrganizerService;
        }

        [HttpGet("organizer/{organizerId}/getEventOrganizer")]
        public IActionResult GetEventOrganizer(int organizerId)
        {
            var organizer = _eventOrganizerService.GetEventOrganizer(organizerId);
            if (organizer == null)
            {
                return NotFound("Organizer not found");
            }
            return Ok(organizer);
        }

        [HttpGet("organizer/{organizerId}/events")]
        public IActionResult GetEventsByOrganizer(int organizerId)
        {
            var events = _eventService.GetEventsByOrganizerId(organizerId);

            if (events == null || !events.Any())
            {
                return NotFound("No events for this organizer or this is not an organizer"); 
            }
            return Ok(events);
        }

        [HttpPost("organizer/{organizerId}/create-events")]

        public IActionResult CreateEvent(int organizerId, [FromQuery]EventsDto createEventDto)

        {
            if (createEventDto == null)
            {
                return BadRequest("Invalid event data");
            }

            var eventOrganizer = _context.EventsOrganizers.Find(organizerId);
            if (eventOrganizer == null)
            {
                return NotFound("Organizer not found");
            }

            var createEvent = _eventService.CreateEvent(
                createEventDto.Name,
                createEventDto.Address,
                createEventDto.City,
                createEventDto.Date,
                createEventDto.NumberOfTickets,
                createEventDto.Category,
                createEventDto.Price,
                createEventDto.EventOrganizerId
            );

            if (createEvent)
            {
                return Ok("Event created successfully");
                
            }
            return BadRequest("Not equals ids");
        }

        [HttpGet("/event-organizer/{eventOrganizerId}/check-available-tickets/{eventId}")]
        public IActionResult CheckAvailableTickets(int eventOrganizerId, int eventId)
        {
            int result = _eventOrganizerService.CheckAvailableTickets(eventOrganizerId, eventId);
            if(result == -1)
            {
                return NotFound("Event not found");
            } 
            else if (result == -2)
            {
                return NotFound("Organizer not found");
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet("/event-organizer/{eventOrganizerId}/check-sold-tickets/{eventId}")]
        public IActionResult CheckSoldTickets(int eventOrganizerId, int eventId)
        {
            int result = _eventOrganizerService.CheckSoldTickets(eventOrganizerId, eventId);
            if (result == -1)
            {
                return NotFound("Event not found");
            }
            else if (result == -2)
            {
                return NotFound("Organizer not found");
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
