using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCarServicesFinal.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter VIN")]
        public int VIN { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Company Name")]
        public string Company { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Model type")]
        public string Model { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Style")]
        public string Style { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Color")]
        public string Color { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}