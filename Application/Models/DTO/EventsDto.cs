using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTO
{
    public class EventsDto
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int NumberOfTickets { get; set; }
        public string Category { get; set; } = string.Empty;
        public float Price { get; set; }
        public int EventOrganizerId { get; set; }
    }
}
