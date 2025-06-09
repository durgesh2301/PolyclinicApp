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
            catch(Exception ex)
            {
                doctors = null;
            }
            return Json(doctors);
        }
    }
}
