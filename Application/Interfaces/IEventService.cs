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
        void CreateEvent(string name, string address, string city, DateTime date, string category, float price, EventOrganizer eventOrganizer);
        Event GetEventById(int eventId);
        List<Event> GetAllEvents();
        List<Event> GetEventsByOrganizerId(int organizerId);
        void UpdateEvent(Event eventToUpdate);
        void DeleteEvent(int eventId);
    }
}
