using Application.Interfaces;
using Domain.Entities;
<<<<<<< HEAD
using Domain.Interfaces;
=======
>>>>>>> e05bf1e512497b1cf92af63a84aa7bfc0628d802
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClientService : IClientService
    {
<<<<<<< HEAD
        private readonly IClientRepository _clientRepository;
        private readonly IEventRepository _eventRepository;
        public ClientService(IClientRepository clientRepository, IEventRepository eventRepository)
        {
            _clientRepository = clientRepository;
            _eventRepository = eventRepository;
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

        public List<Ticket> GetAllMyTickets(int clientId)
        {
            return _clientRepository.GetAllMyTickets(clientId);
        }

        public Client GetClientById(int clientId)
        {
            return _clientRepository.GetClientById(clientId);
        }
=======
        public void Register() { }
        public string Login() { return "hoa"; }
        public List<Event> GetAll() { var a = new List<Event>();
                return a ; }
        public List<Ticket> Tickets() { return new List<Ticket>(); }
>>>>>>> e05bf1e512497b1cf92af63a84aa7bfc0628d802
    }
}
