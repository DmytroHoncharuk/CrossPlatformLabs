using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class RefSalonTreatment
    {
        [Key]
        public string SalonTreatmentCode { get; set; }
        public string? TreatmentDescription { get; set; }
        public decimal? StandardPrice { get; set; }
        public ICollection<StaffCharge>? StaffCharges { get; set; }
    }
}
