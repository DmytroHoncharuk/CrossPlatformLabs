using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class RefStaffJobTitle
    {
        [Key]
        public string JobCode { get; set; }
        public string? JobDescription { get; set; }
        public ICollection<Staff>? Staff { get; set; }
    }
}
