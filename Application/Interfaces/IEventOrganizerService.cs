using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEventOrganizerService
    {
        EventOrganizer GetEventOrganizer(int eventOrganizerId);
        int CheckAvailableTickets(int eventOrganizerId, int eventId);
        int CheckSoldTickets(int eventOrganizerId, int eventId);
    }
}
