using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Domain.Enums;

namespace Infrastructure.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationContext _context;

        public ClientRepository(ApplicationContext context)
        {
            _context = context; 
        }

        public void BuyTicket(int eventId, int clientId)
        {
            var client = _context.Users.OfType<Client>().FirstOrDefault(c => c.Id == clientId);
            var ticket = _context.Events.FirstOrDefault(e => e.Id == eventId).Tickets.FirstOrDefault(t => t.State == TicketState.Available);

            if (client != null && ticket != null)
            {
                ticket.ClientId = clientId;
                ticket.State = TicketState.Sold; 
                _context.Tickets.Update(ticket);
                client.MyTickets.Add(ticket);
                _context.SaveChanges();
            }
        }
        public List<Ticket> GetAllMyTickets(int clientId)
        {
            return _context.Tickets
            .Where(ticket => ticket.ClientId == clientId)
            .ToList(); 
        }
        public Client GetClientById(int id)
        {
            return _context.Users.OfType<Client>().FirstOrDefault(c => c.Id == id);
        }

        public void UpdateClient(Client client)
        {
            _context.Users.Update(client);
            _context.SaveChanges();
        }



    }
}
