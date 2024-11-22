using System;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class PaymentDetail
    {
        [Key]
        public int PaymentId { get; set; }
        public int? ClientId { get; set; }
        public DateTime? DateOfPayment { get; set; }
        public decimal? AmountDue { get; set; }
        public decimal? AmountPaid { get; set; }
        public decimal? Balance { get; set; }
        public ClientEntity? Client { get; set; }
    }
}
