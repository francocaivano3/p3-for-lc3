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
        public int? ClientId { get; set; }
        public Client? Client { get; set; }
        public float Amount { get; set; }
        public string? PaymentMethod { get; set; } 
        public bool State {  get; set; }



        public Ticket(int id, float amount, int eventId, bool state, string? paymentMethod)
        {
            Id = id;
            Amount = amount; 
            EventId = eventId;
            State = state;
            PaymentMethod = null;
            ClientId = null;
        }

        
    }
}
