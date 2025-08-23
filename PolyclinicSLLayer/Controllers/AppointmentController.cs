using Microsoft.AspNetCore.Mvc;
using PoluclinicDALLayer;
using PoluclinicDALLayer.Models;

namespace PolyclinicSLLayer.Controllers
{
    [ApiController]
    [Route("")] //Added routing on methods with new name
    public class AppointmentController : Controller
    {
        PolyclinicRepository _polyclinicRepository;
        public AppointmentController(PolyclinicRepository polyclinicRepository)
        {
            _polyclinicRepository = polyclinicRepository;
        }

        [HttpGet("/api/appointments")]
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

        [HttpGet("/api/appointments/{appointmentId}")]
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

        [HttpPost("/api/appointments")]
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

        [HttpPut("/api/appointments/{appointmentId}/date")]
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

        [HttpDelete("/api/appointment/{appointmentId}")]
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
