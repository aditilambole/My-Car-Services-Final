using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCarServicesFinal.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name should be of minimum 3 characters maximum 20 characters")]
        [RegularExpression(@"^([A-Za-z]+)", ErrorMessage = "Enter valid first name")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter lastname")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "lastname should be of minimum 3 characters maximum 20 characters")]
        [RegularExpression(@"^([A-Za-z]+)", ErrorMessage = "Enter valid last name")]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter phone-number")]
        //[RegularExpression(@"^[0 - 9]{10}$)|(^\+[0-9]{2}\s+[0-9]{2}[0-9]{8}$)|(^[0-9]{3}-[0-9]{4}-[0-9]{4}$)")]
        public long PhoneNumber { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Email")]
//[RegularExpression(@"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Address")]
        public string Address { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter City")]
        public string City { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Postalcode")]
        public int PostalCode { get; set; }
    }
}