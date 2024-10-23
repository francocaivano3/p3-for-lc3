using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationContext _context;

        public ClientRepository(ApplicationContext context)
        {
            _context = context; 
        }

        public void BuyTicket(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            _context.SaveChanges();
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
