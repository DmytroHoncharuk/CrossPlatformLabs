using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class RefGender
    {
        [Key]
        public string GenderCode { get; set; }
        public string? GenderDescription { get; set; }
        public ICollection<ClientEntity>? Clients { get; set; }
    }
}
