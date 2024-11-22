using System;
using System.Collections.Generic;

namespace App.Models
{
    public class Document
    {
        public int DocumentId { get; set; }
        public string? DocumentName { get; set; }
        public string? DocumentDescription { get; set; }
        public string? OtherDetails { get; set; }
        public ICollection<DocumentUser>? DocumentUsers { get; set; }
    }
}
