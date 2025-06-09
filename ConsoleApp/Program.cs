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
        }
    }
}
