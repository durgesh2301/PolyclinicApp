using Microsoft.AspNetCore.Mvc;
using PoluclinicDALLayer;
using PoluclinicDALLayer.Models;

namespace PolyclinicSLLayer.Controllers
{
    [ApiController]
    [Route("")] //Added routing on methods with new name
    public class DoctorController : Controller
    {
        PolyclinicRepository _polyclinicRepository;
        public DoctorController(PolyclinicRepository polyclinicRepository)
        {
            _polyclinicRepository = polyclinicRepository;
        }

        [HttpGet("/api/doctors")]
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

        [HttpGet("/api/doctors/{doctorId}")]
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

        [HttpGet("/api/doctors/{doctorId}/fees")]
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

        [HttpGet("/api/doctors/{doctorId}/{appointmentDate}/appointments")]
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

        [HttpPost("/api/doctors")]
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

        [HttpPut("/api/doctors/{doctorId}/fees")]
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

        [HttpDelete("/api/doctors/{doctorId}")]
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

    }
}
