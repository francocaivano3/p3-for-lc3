using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class EventOrganizerRepository : IEventOrganizerRepository
    {
        private readonly ApplicationContext _context;
        public EventOrganizerRepository(ApplicationContext context) 
        {
            _context = context;
        }
        public EventOrganizer GetEventOrganizer(int eventOrganizerId) 
        {
            return _context.EventsOrganizers.OfType<EventOrganizer>().FirstOrDefault(e => e.Id == eventOrganizerId);
        }
    }
}
