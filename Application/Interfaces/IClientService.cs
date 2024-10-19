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
        void Register();
        string Login();
        List<Event> GetAll();
        List<Ticket> Tickets();
    }
}
