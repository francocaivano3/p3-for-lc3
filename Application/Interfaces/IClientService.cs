﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IClientService
    {
        List<Ticket> GetAllMyTickets(int clientId);
        bool BuyTicket(int clientId, int eventId);
        Client GetClientById(int clientId);
    }
}
