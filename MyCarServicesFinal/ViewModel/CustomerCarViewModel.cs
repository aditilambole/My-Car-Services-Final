using MyCarServicesFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarServicesFinal.ViewModel
{
    public class CustomerCarViewModel
    {
        public ApplicationUser User { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }
}