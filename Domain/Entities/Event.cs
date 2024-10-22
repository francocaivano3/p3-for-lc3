using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Name {  get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public DateTime Date { get; set; }
        public string? Category { get; set; }
        public float Price { get; set; }


        public List<Ticket> Tickets { get; set; }
        
        public int EventOrganizerId { get; set; }
        public EventOrganizer? EventOrganizer { get; set; }

        public Event(string name, string address, string city, DateTime date, string category, float price, EventOrganizer eventOrganizer)
        {
            Name = name;
            Address = address;
            City = city;
            Date = date;
            Tickets = new List<Ticket>();
            Category = category;
            Price = price;
            EventOrganizer = eventOrganizer;

            for (int i = 1; i <= 10; i++)
            {
                Tickets.Add(new Ticket (i, Price, this.Id, true, null));
            }
        }

        public Event() // constructor vacio que necesita ef
        {
            Tickets = new List<Ticket>();
        }

    }
}
