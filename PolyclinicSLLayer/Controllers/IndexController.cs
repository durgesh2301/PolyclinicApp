using Microsoft.AspNetCore.Mvc;
using PoluclinicDALLayer;
using PoluclinicDALLayer.Models;

namespace PolyclinicSLLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class IndexController : Controller
    {
        PolyclinicRepository _polyclinicRepository;
        public IndexController(PolyclinicRepository polyclinicRepository)
        {
            _polyclinicRepository = polyclinicRepository;
        }

        [HttpGet]
        public JsonResult GetAllDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();
            try
            {
                doctors = _polyclinicRepository.GetAllDoctors();
            }
            catch (Exception ex)
            {
                doctors = null;
            }
            return Json(doctors);
        }

        [HttpGet]
        public JsonResult GetAllPatients()
        {
            List<Patient> patients = new List<Patient>();
            try
            {
                patients = _polyclinicRepository.GetAllPatients();
            }
            catch (Exception ex)
            {
                patients = null;
            }
            return Json(patients);
        }

        [HttpGet]
        public JsonResult GetAllAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            try
            {
                appointments = _polyclinicRepository.GetAllAppointments();
            }
            catch (Exception ex)
            {
                appointments = null;
            }
            return Json(appointments);
        }

        [HttpGet]
        public JsonResult GetDoctorById(int doctorId)
        {
            Doctor doctor = new Doctor();
            try
            {
                doctor = _polyclinicRepository.GetDoctorById(doctorId);
            }
            catch (Exception ex)
            {
                doctor = null;
            }
            return Json(doctor);
        }

        [HttpGet]
        public JsonResult GetPatientById(int patientId)
        {
            Patient patient = new Patient();
            try
            {
                patient = _polyclinicRepository.GetPatientById(patientId);
            }
            catch (Exception ex)
            {
                patient = null;
            }
            return Json(patient);
        }

        [HttpGet]
        public JsonResult GetAppointmentById(int appointmentId)
        {
            Appointment appointment = new Appointment();
            try
            {
                appointment = _polyclinicRepository.GetAppointmentById(appointmentId);
            }
            catch (Exception ex)
            {
                appointment = null;
            }
            return Json(appointment);
        }

        [HttpGet]
        public JsonResult CalculateDoctorFees(int doctorId, DateTime appointmentDate)
        {
            decimal fees = 0;
            try
            {
                fees = _polyclinicRepository.CalculateDoctorFees(doctorId, appointmentDate);
            }
            catch (Exception ex)
            {
                fees = 0;
            }
            return Json(fees);
        }

        [HttpGet]
        public JsonResult FetchDoctorAppointments(int doctorId, DateTime appointmentDate)
        {
            List<DoctorAppointments> doctorAppointments = new List<DoctorAppointments>();
            try
            {
                doctorAppointments = _polyclinicRepository.FetchDoctorAppointments(doctorId, appointmentDate);
            }
            catch (Exception ex)
            {
                doctorAppointments = null;
            }
            return Json(doctorAppointments);
        }

        [HttpPost]
        public JsonResult AddDoctor(Doctor doctor)
        {
            bool result = false;
            try
            {
                result = _polyclinicRepository.AddDoctor(doctor);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return Json(result);
        }

        [HttpPost]
        public JsonResult AddPatient(Patient patient)
        {
            bool result = false;
            try
            {
                result = _polyclinicRepository.AddPatient(patient);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return Json(result);
        }

        [HttpPost]
        public JsonResult AddAppointment(Appointment appointment)
        {
            bool result = false;
            try
            {
                result = _polyclinicRepository.AddAppointment(appointment);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetDoctorAppointment(int doctorId, int patientId, DateTime appointmentDate)
        {
            int appointmentId = 0;
            try
            {
                appointmentId = _polyclinicRepository.GetDoctorAppointment(doctorId, patientId, appointmentDate, out appointmentId);
            }
            catch (Exception ex)
            {
                appointmentId = 0;
            }
            return Json(appointmentId);
        }

        [HttpPut]
        public JsonResult UpdateDoctorFees(int doctorId, decimal fees)
        {
            bool result = false;
            try
            {
                result = _polyclinicRepository.UpdateDoctorFees(doctorId, fees);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return Json(result);
        }

        [HttpPut]
        public JsonResult UpdateAppointmentDate(int appointmentId, DateTime newDate)
        {
            bool result = false;
            try
            {
                result = _polyclinicRepository.UpdateAppointmentDate(appointmentId, newDate);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return Json(result);
        }

        [HttpPut]
        public JsonResult UpdatePatientAge(int patientId, int newAge)
        {
            bool result = false;
            try
            {
                result = _polyclinicRepository.UpdatePatientAge(patientId, newAge);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return Json(result);
        }

        [HttpDelete]
        public JsonResult DeleteDoctor(int doctorId)
        {
            bool result = false;
            try
            {
                result = _polyclinicRepository.DeleteDoctor(doctorId);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return Json(result);
        }

        [HttpDelete]
        public JsonResult DeletePatient(int patientId)
        {
            bool result = false;
            try
            {
                result = _polyclinicRepository.DeletePatient(patientId);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return Json(result);
        }

        [HttpDelete]
        public JsonResult DeleteAppointment(int appointmentId)
        {
            bool result = false;
            try
            {
                result = _polyclinicRepository.DeleteAppointment(appointmentId);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return Json(result);
        }

    }
}
