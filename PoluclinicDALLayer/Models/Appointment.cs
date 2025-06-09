using System;
using System.Collections.Generic;

namespace PoluclinicDALLayer.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int DoctorId { get; set; }

    public int PatientId { get; set; }

    public DateTime AppointmentDate { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
