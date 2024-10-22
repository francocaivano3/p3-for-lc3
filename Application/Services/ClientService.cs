using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClientService : IClientService
    {
        public void Register() { }
        public string Login() { return "hoa"; }
        public List<Event> GetAll() { var a = new List<Event>();
                return a ; }
        public List<Ticket> Tickets() { return new List<Ticket>(); }
    }
}
