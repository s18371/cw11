using cw11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Services
{
    public interface IDoctorDbService
    {
        public List<Doctor> GetDoctors();
        public string AddDoctor(Doctor d);
        public string ModifyDoctor(Doctor d);
        public string DeleteDoctor(Doctor d);
    }
}
