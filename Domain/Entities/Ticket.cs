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
        public int Amount { get; set; }
        public string PaymentMethod { get; set; }

        public Ticket(int id, int amount, string paymentMethod)
        {
            Id = id;
            Amount = amount; 
            PaymentMethod = paymentMethod;
            
        }
    }
}
