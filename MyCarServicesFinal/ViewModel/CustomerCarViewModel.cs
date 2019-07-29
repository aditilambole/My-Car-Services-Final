using MyCarServicesFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarServicesFinal.ViewModel
{
    public class CustomerCarViewModel
    {
        public Customer Customers { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }
}