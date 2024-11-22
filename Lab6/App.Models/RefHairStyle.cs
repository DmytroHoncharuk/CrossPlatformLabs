using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class RefHairStyle
    {
        [Key]
        public string HairStyleCode { get; set; }
        public string? HairStyleDescription { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
    }
}
