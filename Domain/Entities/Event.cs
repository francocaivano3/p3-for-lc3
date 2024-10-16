using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Event
    {
        private string _name {  get; set; }
        private string _address { get; set; }
        private string _city { get; set; }
        private DateTime _date { get; set; }
        private List<Ticket> _tickets { get; set; }
        private string _category { get; set; }
        private float _price { get; set; }

        public Event(string name, string address, string city, DateTime date, List<Ticket> tickets, string category, float price)
        {
            _name = name;
            _address = address;
            _city = city;
            _date = date;
            _tickets = tickets;
            _category = category;
            _price = price;
        }
    }
}
