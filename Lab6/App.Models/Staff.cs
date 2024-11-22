using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }
        public string? JobCode { get; set; }
        public string? StaffName { get; set; }
        public string? StaffDetails { get; set; }
        public DateTime? DateJoined { get; set; }
        public DateTime? DateLeft { get; set; }
        public RefStaffJobTitle? JobTitle { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
    }
}
    