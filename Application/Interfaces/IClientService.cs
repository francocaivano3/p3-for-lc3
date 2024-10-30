﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Request;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IClientService
    {
        //bool CreateClient();
        List<Ticket> GetAllMyTickets(int clientId);
        bool BuyTicket(int clientId, int eventId);
        List<Event> GetAll();
        Client GetClientById(int clientId);

    }
}
