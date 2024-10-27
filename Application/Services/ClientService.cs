using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
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

        public ClientService (IClientRepository clientRepository, IEventRepository eventRepository)
        {
            _clientRepository = clientRepository;
            _eventRepository = eventRepository;
        }

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


            _clientRepository.UpdateClient(client);
            return _clientRepository.BuyTicket(eventId, clientId);
        }

        public List<Event> GetAll() 
        { 
            return _clientRepository.GetAllEvents();
        }

        public Client GetClientById(int clientId) 
        {
            return _clientRepository.GetClientById(clientId);
        }

        public List<Ticket> GetAllMyTickets(int clientId) { return _clientRepository.GetAllMyTickets(clientId); }

        
    }
}
