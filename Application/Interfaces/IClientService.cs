using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IClientService
    {
<<<<<<< HEAD
        List<Ticket> GetAllMyTickets(int clientId);
        bool BuyTicket(int clientId, int eventId);
        Client GetClientById(int clientId);
=======
        List<Event> GetAll();
        List<Ticket> Tickets();
>>>>>>> e05bf1e512497b1cf92af63a84aa7bfc0628d802
    }
}
