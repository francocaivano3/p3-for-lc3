using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IEventRepository _eventRepository;
        public void Register() 
        {
            // Lógica para el registro
        }

        public string Login() 
        {
            return "hoa"; // Lógica para el inicio de sesión
        }

        public bool BuyTicket(int clientId, int eventId)
        {
            Client client = _clientRepository.GetClientById(clientId);
            if (client == null)
            {
                return false;
            }

            Event eventEntity = _eventRepository.GetById(eventId);
            if (eventEntity == null)
            {
                return false;
            }

            Ticket availableTicket = eventEntity.Tickets.FirstOrDefault(t => t.State == true);
            if (availableTicket == null)
            {
                return false;
            }

            availableTicket.ClientId = clientId;
            availableTicket.State = false;

            client.MyTickets.Add(availableTicket);

            _clientRepository.UpdateClient(client);
            _clientRepository.BuyTicket(availableTicket);

            return true;
        }

        public List<Event> GetAll() 
        { 
            var a = new List<Event>();
            return a; // Devuelve una lista de eventos
        }

        public List<Ticket> GetAllMyTickets(int clientId) { return _clientRepository.GetAllMyTickets(clientId); }

        public List<Ticket> Tickets() 
        { 
            return new List<Ticket>(); // Devuelve una lista de tickets
        }
    }
}
