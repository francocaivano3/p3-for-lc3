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
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public DateTime Date { get; set; }
        public string? Category { get; set; }
        public float Price { get; set; }
        //public EventOrganizer? EventOrganizer { get; set; }
    }
}
