using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{


    internal class EventOrganizer
    {
        public List<Event> MyEvents { get; set; } = new List<Event>();
        public float Rating { get; set; }

        public EventOrganizer(float rating) 
        {
            Rating = rating;
        }
    }
}
