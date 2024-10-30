using Application.Interfaces;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Models.Request;
using Application.Models.DTO;

namespace Application.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public bool CreateEvent(EventsRequest eventRequest) 
        { 
            var newEvent = new Event(eventRequest.Name, eventRequest.Address, eventRequest.City, eventRequest.Date, eventRequest.NumberOfTickets, eventRequest.Category, eventRequest.Price, eventRequest.EventOrganizerId);
            return _eventRepository.Add(newEvent, eventRequest.EventOrganizerId);
        }

        public EventsDto GetEventById(int eventId)
        {
            var eventToGet = _eventRepository.GetById(eventId);
            return EventsDto.Create(eventToGet);
        }

        public List<EventsDto> GetAllEvents() 
        { 
            var events = _eventRepository.GetAll();
            var eventsDto = new List<EventsDto>();
            foreach (var e in events)
            {
                eventsDto.Add(EventsDto.Create(e));
            }
            return eventsDto;
        }

        public List<Event> GetEventsByOrganizerId(int organizerId)
        {
            return _eventRepository.GetEventsByOrganizerId(organizerId).ToList();
        }

        public void UpdateEvent(Event eventToUpdate)
        {
            _eventRepository.Update(eventToUpdate);
        }

        public void DeleteEvent(int eventId)
        {
            _eventRepository.Delete(eventId);
        }
    }
}
