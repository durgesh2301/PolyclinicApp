using Microsoft.AspNetCore.Mvc;
using PoluclinicDALLayer;
using PoluclinicDALLayer.Models;

namespace PolyclinicSLLayer.Controllers
{
    [ApiController]
    [Route("")] //Added routing on methods with new name
    public class PatientController : Controller
    {
        PolyclinicRepository _polyclinicRepository;
        public PatientController(PolyclinicRepository polyclinicRepository)
        {
            _polyclinicRepository = polyclinicRepository;
        }

        [HttpGet("/api/patients")]
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


        [HttpGet("/api/patients/{patientId}")]
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

        [HttpPost("/api/patients")]
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

        [HttpPut("/api/patients/{patientId}/age")]
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

        [HttpDelete("/api/patients/{patientId}")]
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

    }
}
