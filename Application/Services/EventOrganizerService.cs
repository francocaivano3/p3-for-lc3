using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Application.Services
{
    public class EventOrganizerService : IEventOrganizerService
    {
        private readonly IEventOrganizerRepository _eventOrganizerRepository;
        public EventOrganizerService(IEventOrganizerRepository eventOrganizerRepository)
        {
            _eventOrganizerRepository = eventOrganizerRepository;
        }

        public EventOrganizer GetEventOrganizer(int eventOrganizerId) 
        {
            return _eventOrganizerRepository.GetEventOrganizer(eventOrganizerId);
        }

        public int CheckAvailableTickets(int eventOrganizerId, int eventId)
        {
            return _eventOrganizerRepository.CheckAvailableTickets(eventOrganizerId, eventId);
        }

        public int CheckSoldTickets(int eventOrganizerId, int eventId)
        {
            return _eventOrganizerRepository.CheckSoldTickets(eventOrganizerId, eventId);
        }
    }
}
