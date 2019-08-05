using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCarServicesFinal.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Miles Travelled")]
        public int Miles { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Price")]
        public int Price { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Details")]
        public string Details { get; set; }
        public DateTime DateAdded { get; set; }
        public ServiceType ServiceType { get; set; }
        public int ServiceTypeId { get; set; }
        public Car Car { get; set; }
        public int CarId { get; set; }
    }
}