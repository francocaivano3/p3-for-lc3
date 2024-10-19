using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

<<<<<<< HEAD
=======

<<<<<<< HEAD
>>>>>>> c74e19f6d2768f3d3bbb71ee3cc47c49a596bc19
    public class EventOrganizer
=======
    internal class EventOrganizer
>>>>>>> main
    {
        public List<Event> MyEvents { get; set; } = new List<Event>();
        public float Rating { get; set; }

        public EventOrganizer(float rating) 
        {
            Rating = rating;
        }
    }
}
