using System;
using System.Collections.Generic;

namespace PoluclinicDALLayer.Models;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string DoctorName { get; set; } = null!;

    public string Specialization { get; set; } = null!;

    public decimal Fees { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
