using PoluclinicDALLayer;
using PoluclinicDALLayer.Models;

namespace ConsoleApp
{
    public class Program
    {
        static PolyclinicRepository polyclinicRepository;
        static PolyclinicDbContext polyclinicDbContext;
        static Program()
        {
            polyclinicDbContext = new PolyclinicDbContext();
            polyclinicRepository = new PolyclinicRepository(polyclinicDbContext);
        }
        static void Main(string[] args)
        {

            polyclinicRepository.GetAllDoctors();
            polyclinicRepository.GetDoctorById(1001);
            polyclinicRepository.GetAllPatients();
            polyclinicRepository.GetPatientById(1002);
            polyclinicRepository.GetAllAppointments();
            polyclinicRepository.GetAppointmentById(1005);
            polyclinicRepository.CalculateDoctorFees(1001, DateTime.Now);
            polyclinicRepository.FetchDoctorAppointments(1001, new DateTime(2023,10,07));
            //int appointmentId = 0;
            polyclinicRepository.GetDoctorAppointment(1001,1001,new DateTime(2025,07,12),out int appointmentId);
        }
    }
}
