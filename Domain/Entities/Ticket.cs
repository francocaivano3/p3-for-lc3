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
<<<<<<< HEAD
        public int EventId { get; set; } // id del evento al que está asociado el ticket
        public Event Event { get; set; }
        public float Amount { get; set; }
        public string? PaymentMethod { get; set; } 
        public bool State {  get; set; }

<<<<<<< HEAD


        public Ticket(int id, float amount, int eventId, bool state, string? paymentMethod = null)
=======
        public Ticket(int id, int amount, string paymentMethod, int eventId)
=======
        public int Amount { get; set; }
        public string PaymentMethod { get; set; }

        public Ticket(int id, int amount, string paymentMethod)
>>>>>>> main
>>>>>>> c74e19f6d2768f3d3bbb71ee3cc47c49a596bc19
        {
            Id = id;
            Amount = amount; 
            PaymentMethod = paymentMethod;
<<<<<<< HEAD
            EventId = eventId;
<<<<<<< HEAD
            State = state;
=======
=======
            
>>>>>>> main
>>>>>>> c74e19f6d2768f3d3bbb71ee3cc47c49a596bc19
        }
    }
}
