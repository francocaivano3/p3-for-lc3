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
        public void Register() 
        {
            // Lógica para el registro
        }

        public string Login() 
        {
            return "hoa"; // Lógica para el inicio de sesión
        }

        public List<Event> GetAll() 
        { 
            var a = new List<Event>();
            return a; // Devuelve una lista de eventos
        }

        public List<Ticket> Tickets() 
        { 
            return new List<Ticket>(); // Devuelve una lista de tickets
        }
    }
}
