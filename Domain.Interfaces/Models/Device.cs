using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Availibility { get; set; }
    }
}
