using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class StaffCharge
    {
        [Key]
        public string JobCode { get; set; }
        public string? SalonTreatmentCode { get; set; }
        public decimal? ChargeAmount { get; set; }
        public RefStaffJobTitle? JobTitle { get; set; }
        public RefSalonTreatment? SalonTreatment { get; set; }
    }
}
