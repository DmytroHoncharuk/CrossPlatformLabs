using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class Product
    {
        [Key]
        public string ProductCode { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string? OtherDetails { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
    }
}
