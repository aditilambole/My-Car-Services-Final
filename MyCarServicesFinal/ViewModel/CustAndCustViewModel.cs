using MyCarServicesFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarServicesFinal.ViewModel
{
    public class CustAndCustViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public int? CheckInteger { get; set; }
    }
}