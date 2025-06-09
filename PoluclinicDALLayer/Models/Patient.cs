using System;
using System.Collections.Generic;

namespace PoluclinicDALLayer.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public string PatientName { get; set; } = null!;

    public int Age { get; set; }

    public string Gender { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
