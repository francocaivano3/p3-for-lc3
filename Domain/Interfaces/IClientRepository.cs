using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities
namespace Domain.Interfaces
{
    internal interface IClientRepository
    {
        Task<List<Ticket>> GetClientTickets(int clientId);
        Task<Event> GetById();
    }
}
