using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public int EventId { get; set; } // id del evento al que está asociado el ticket
        public Event Event { get; set; }
        public int Amount { get; set; }
        public string PaymentMethod { get; set; }

        public Ticket(int id, int amount, string paymentMethod, int eventId)
        {
            Id = id;
            Amount = amount; 
            PaymentMethod = paymentMethod;
            EventId = eventId;
        }
    }
}
