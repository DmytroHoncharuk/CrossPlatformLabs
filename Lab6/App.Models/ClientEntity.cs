using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class ClientEntity
    {
        [Key]
        public int ClientId { get; set; }
        public string? AgeBandCode { get; set; }
        public string? GenderCode { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? CellPhone { get; set; }
        public string? HomePhone { get; set; }
        public string? EmailAddress { get; set; }
        public string? Comments { get; set; }
        public string? NaturalHairColor { get; set; }
        public string? OtherDetails { get; set; }

        public RefAgeBand? AgeBand { get; set; }
        public RefGender? Gender { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }
        public ICollection<PaymentDetail>? PaymentDetails { get; set; }
    }
}
