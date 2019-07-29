using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarServicesFinal.Models
{
    public class Car
    {
        public int Id { get; set; }
        public int VIN { get; set; }
        public string Company { get; set; }
        public string Model { get; set; }
        public string Style { get; set; }
        public string Color { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}