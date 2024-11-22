using System;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class DocumentUser
    {
        [Key]
        public int UserId { get; set; }
        public string? UserType { get; set; }
        public int? DocumentId { get; set; }
        public Document? Document { get; set; }
    }
}
