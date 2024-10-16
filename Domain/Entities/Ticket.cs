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
        public string Payment {  get; set; }

        public Ticket(int id, string payment)
        {
               
        }
    }
}
