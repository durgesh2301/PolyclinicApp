using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoluclinicDALLayer.Models
{
    public class DoctorAppointments
    {
        public string doctorName { get; set; } 
        public string Specialization { get; set; }
        public int patientId { get; set; }
        public string patientName { get; set; }
        [Key]
        public int appointmentId { get; set; }

    }
}
