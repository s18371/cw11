using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw11.Models;
using cw11.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cw11.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private IDoctorDbService _context;
        public DoctorsController(IDoctorDbService context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetDoctors()
        {
            var lista = _context.GetDoctors();
            return Ok(lista);
        }
        [HttpPost]
        public IActionResult AddDoctor(Doctor d)
        {
            var operacja = _context.AddDoctor(d);
            if (operacja.Equals("dodano nowego doktora"))
            {
                return Ok(operacja);
            }
            else
            {
                return BadRequest(operacja);
            }
        }
        [HttpPut]
        public IActionResult ModifyDoctor(Doctor d)
        {
            var operacja = _context.ModifyDoctor(d);
            if (operacja.Equals("zmodyfikowano doktora"))
            {
                return Ok(operacja);
            }
            else
            {
                return BadRequest(operacja);
            }
        }
        [HttpDelete]
        public IActionResult DeleteDoctor(Doctor d)
        {
            var operacja = _context.DeleteDoctor(d);
            if (operacja.Equals("usunieto doktora"))
            {
                return Ok(operacja);
            }
            else
            {
                return BadRequest(operacja);
            }
        }
    }
}