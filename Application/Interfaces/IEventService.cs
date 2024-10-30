using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.DTO;
using Application.Models.Request;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IEventService
    {

        bool CreateEvent(EventsRequest eventsRequest);
        EventsDto GetEventById(int eventId);
        List<EventsDto> GetAllEvents();
        List<Event> GetEventsByOrganizerId(int organizerId);
        void UpdateEvent(Event eventToUpdate);
        void DeleteEvent(int eventId);
    }
}
