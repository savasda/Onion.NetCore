using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Role { get; set; }
        public string Password { get; set; }
    }
}
