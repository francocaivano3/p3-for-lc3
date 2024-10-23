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
    public class EventsController : Controller
    {
        private readonly ApplicationContext _context;

        private readonly IEventService _eventService;

        public EventsController(ApplicationContext context, IEventService eventService)
        {
            _context = context;
            _eventService = eventService;
        }

        [HttpGet("organizer/{organizerId}/events")]
        public IActionResult GetEventsByOrganizer(int organizerId)
        {
            var events = _eventService.GetEventsByOrganizerId(organizerId);
            if (events == null || !events.Any())
            {
                return NotFound();
            }
            return Ok(events);
        }

        [HttpPost("organizer/{organizerId}/events")]

        public IActionResult CreateEvent(int organizerId, [FromQuery]EventsDto createEventDto)

        {
            if (createEventDto == null)
            {
                return BadRequest("a");
            }



            // Buscar el organizador por su ID
            //var eventOrganizer = _context.EventsOrganizers.Find(organizerId);
            //if (eventOrganizer == null)
            //{
            //    return NotFound("Organizer not found.");
           // }


            _eventService.CreateEvent(
                createEventDto.Name,
                createEventDto.Address,
                createEventDto.City,
                createEventDto.Date,
                createEventDto.NumberOfTickets,
                createEventDto.Category,
                createEventDto.Price,
                createEventDto.EventOrganizerId
            );

            return Ok("Event created successfully.");
        }

    }
}
