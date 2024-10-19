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
        protected string Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        protected string Email { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        protected string Password { get; set; }

        [Column(TypeName = "nvarchar(11)")]
        protected string Phone {  get; set; }

        [Required]
        public string Role {  get; set; }
        protected User(string name, string email, string password, string phone, string role)
        {
            Name = name;
            Email = email;
            Password = password;
            Phone = phone;
            Role = role;
        }
    }
}
