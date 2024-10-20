using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IEventService
    {
        void CreateEvent(string name, string address, string city, DateTime date, int numberOfTickets, string category, float price, EventOrganizer eventOrganizer);
        Event GetEventById(int eventId);
        IEnumerable<Event> GetAllEvents();
        IEnumerable<EventOrganizer> GetEventsByOrganizerId(int organizerId);
        void UpdateEvent(Event eventToUpdate);
        void DeleteEvent(int eventId);
    }
}
