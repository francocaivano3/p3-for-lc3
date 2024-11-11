﻿using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.Repositories;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Application.Models.Request;
using Application.Services;


namespace Web.Controllers
{
    [Authorize]
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



        [Authorize(Policy = "EventOrganizer")]
        [HttpPost("/create-event")]
        public IActionResult CreateEvent(EventsCreateRequest createEventRequest)
        {
            if (createEventRequest == null)
            {
                return BadRequest("Invalid event data");
            }

            if (createEventRequest.Date < DateTime.Now) 
            {
                return BadRequest("Invalid date");
            }

            var eventOrganizer = _context.EventsOrganizers.Find(createEventRequest.EventOrganizerId);
            if (eventOrganizer == null)
            {
                return NotFound("Organizer not found");
            }

            var createEvent = _eventService.CreateEvent(createEventRequest);

            if (createEvent != null)
            {
                return CreatedAtAction(nameof(GetEventById), new { id = createEvent.Id }, createEvent);
            }
            return BadRequest("Not equals ids");
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



        [Authorize(Policy = "EventOrganizer")]
        [HttpGet("{Id}")]
        public IActionResult GetEventById(int Id)
        {
            var eventToSearch = _eventService.GetEventById(Id);
            if (eventToSearch == null)
            {
                return NotFound("Event not found");
            }
            return Ok(eventToSearch);
        }



        [Authorize(Policy = "EventOrganizer")]
        [HttpGet("organizers/{eventOrganizerId}/events/{eventId}/tickets/available")]
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



        [Authorize(Policy = "EventOrganizer")]
        [HttpGet("organizers/{eventOrganizerId}/events/{eventId}/tickets/sold")]
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



        [Authorize(Policy = "EventOrganizer")]
        [HttpPut("/update-event")]
        public IActionResult Update( EventUpdateRequest eventToUpdate)
        { 
            try
            {
                _eventService.UpdateEvent(eventToUpdate);
                return NoContent();
            } catch
            {
                return BadRequest("error");
            }
        }


        [Authorize(Policy = "EventOrganizer")]
        [HttpDelete("{eventId}")]
        public IActionResult Delete(int eventId)
        {
            try
            {
                _eventService.DeleteEvent(eventId);
                return NoContent();
            } catch
            {
                return BadRequest("Error al borrar");
            }
        }
    }
}
