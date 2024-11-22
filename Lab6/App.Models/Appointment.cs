using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int? ClientId { get; set; }
        public int? StaffId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public TimeSpan? AppointmentTime { get; set; }
        public string? ColourUsed { get; set; }
        public string? HairStyleCode { get; set; }
        public string? ProductCode { get; set; }
        public ClientEntity? Client { get; set; }
        public Staff? Staff { get; set; }
        public RefHairStyle? HairStyle { get; set; }
        public Product? Product { get; set; }
    }
}
