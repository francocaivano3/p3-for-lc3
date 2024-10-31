using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;


namespace Domain.Interfaces
{
    public interface IEventRepository
    {
        Event Add(Event eventToAdd, int eventOrganizerId);
        Event GetById(int eventId);
        IEnumerable<Event> GetAll();
        IEnumerable<Event> GetEventsByOrganizerId(int organizerId);
        void Update(Event eventToUpdate);
        void Delete(int eventId);

    }
}
