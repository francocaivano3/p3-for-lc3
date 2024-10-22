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
<<<<<<< HEAD
        void CreateEvent(string name, string address, string city, DateTime date, int numberOfTickets, string category, float price, int eventOrganizerId);
=======
        void CreateEvent(string name, string address, string city, DateTime date, string category, float price, EventOrganizer eventOrganizer);
>>>>>>> e05bf1e512497b1cf92af63a84aa7bfc0628d802
        Event GetEventById(int eventId);
        List<Event> GetAllEvents();
        List<Event> GetEventsByOrganizerId(int organizerId);
        void UpdateEvent(Event eventToUpdate);
        void DeleteEvent(int eventId);
    }
}
