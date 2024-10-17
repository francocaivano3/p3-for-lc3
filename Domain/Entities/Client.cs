using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Client : User 
    {
        public int Age {  get; set; }
        public List<Ticket> MyTickets { get; set; } = new List<Ticket>();
        
        public Client(string name, string email, string password, string phone, int age, string role) : base(name, email, password, phone, role)
        {
            Age = age;
        }
    }
    }

