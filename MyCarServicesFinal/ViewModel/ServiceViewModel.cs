using MyCarServicesFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarServicesFinal.ViewModel
{
    public class ServiceViewModel
    {
        public Car Car{ get; set; }
        public IEnumerable<Service> Services { get; set; }
        public Service Service { get; set; }
        public IEnumerable<ServiceType> ServiceType { get; set; }

    }
}