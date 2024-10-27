using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationContext _context;

        public EventRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool Add(Event eventToAdd, int eventOrganizerId)
        {
            var eventOrganizer = _context.EventsOrganizers.Find(eventOrganizerId);

            if(eventToAdd != null && eventOrganizer != null)
            {
                _context.Events.Add(eventToAdd);
                eventOrganizer.MyEvents.Add(eventToAdd);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
        
        public Event GetById(int eventId)
        {
            //return _context.Events.Include(e => e.Tickets).FirstOrDefault(e => e.Id == eventId);
            return _context.Events.FirstOrDefault(e => e.Id == eventId);
        }

        public IEnumerable<Event> GetAll() 
        {
            return _context.Events.ToList();
        }

        public IEnumerable<Event> GetEventsByOrganizerId(int organizerId)
        {
            return _context.Events
                .Where(e => e.EventOrganizerId == organizerId)
                .ToList();
        }

        public void Update(Event eventToUpdate)
        {
            var existingEvent = _context.Events.Find(eventToUpdate.Id);
            if(existingEvent != null)
            {
                existingEvent.Name = eventToUpdate.Name;
                existingEvent.Address = eventToUpdate.Address;
                existingEvent.City = eventToUpdate.City;
                existingEvent.Date = eventToUpdate.Date;
                existingEvent.Category = eventToUpdate.Category;
                existingEvent.Price = eventToUpdate.Price;
                
                _context.Update(existingEvent);
                _context.SaveChanges();
            }
        }

        public void Delete(int eventId)
        {
            var eventToDelete = _context.Events.Find(eventId);

            if(eventToDelete != null)
            {
                _context.Events.Remove(eventToDelete);
                _context.SaveChanges();
            }
        }
    }   
}
