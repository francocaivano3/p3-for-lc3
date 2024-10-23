using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class User
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]

        public string Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        [Required]
        public string Password { get; set; }

        [Column(TypeName = "nvarchar(11)")]
        public string Phone {  get; set; }

        [Required]
        public string Role {  get; set; }
        
        public User() { }
        public User(string name, string email, string password, string phone, string role)
        {
            Name = name;
            Email = email;
            Password = password;
            Phone = phone;
            Role = role;
        }
    }
}
