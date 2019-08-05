using MyCarServicesFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarServicesFinal.ViewModel
{
    public class CustAndCustViewModel
    {
        public ApplicationUser User { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
        public int? CheckInteger { get; set; }
    }
}