using MyCarServicesFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarServicesFinal.ViewModel
{
    public class SingleCustomerCarViewModel
    {
        public Car GetCar { get; set; }
        public ApplicationUser User { get; set; }
    }
}