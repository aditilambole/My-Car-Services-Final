using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarServicesFinal.Models
{
    public class Service
    {
        public int Id { get; set; }
        public int Miles { get; set; }
        public int Price { get; set; }
        public string Details { get; set; }
        public DateTime DateAdded { get; set; }
        public ServiceType ServiceType { get; set; }
        public int ServiceTypeId { get; set; }
        public Car Car { get; set; }
        public int CarId { get; set; }
    }
}