using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IClientRepository
    {
        void BuyTicket(int eventId, int clientId);
        List<Ticket> GetAllMyTickets(int clientId);
        Client GetClientById(int id);
        void UpdateClient(Client client);
    }
}
