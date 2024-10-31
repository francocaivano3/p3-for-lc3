using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTO
{
    public class EventsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int NumberOfTickets { get; set; }
        public string Category { get; set; } = string.Empty;
        public float Price { get; set; }
        public int EventOrganizerId { get; set; }

        public static EventsDto Create(Event eventToCreate)
        {
            EventsDto dto = new EventsDto();
            dto.Id = eventToCreate.Id;
            dto.Name = eventToCreate.Name;
            dto.Address = eventToCreate.Address;
            dto.City = eventToCreate.City;
            dto.Date = eventToCreate.Date;
            dto.NumberOfTickets = eventToCreate.NumberOfTickets;
            dto.Category = eventToCreate.Category;
            dto.Price = eventToCreate.Price;
            dto.EventOrganizerId = eventToCreate.EventOrganizerId;

            return dto;
        }

    }
}
