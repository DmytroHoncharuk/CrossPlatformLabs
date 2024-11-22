using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class RefAgeBand
    {
        [Key]
        public string AgeBandCode { get; set; }
        public string? AgeBandDescription { get; set; }
        public ICollection<ClientEntity>? Clients { get; set; }
    }
}
