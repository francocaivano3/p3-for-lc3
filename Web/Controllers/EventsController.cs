using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
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

    }
}
