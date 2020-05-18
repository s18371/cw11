using cw11.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Services
{
    public class EfDbService : IDoctorDbService
    {
        public DoctorsDbContext _context { get; set; }
        public EfDbService(DoctorsDbContext context)
        {
            _context = context;
        }
        public string AddDoctor(Doctor d)
        {
            try
            {
                _context.Add(d);
                _context.SaveChanges();
                return "dodano nowego doktora";
            }
            catch (Exception e)
            {
                return e.ToString();
            }

        }

        public string DeleteDoctor(Doctor d)
        {
            try
            {
                _context.Attach(d);
                _context.Remove(d);
                _context.SaveChanges();
                return "usunieto doktora";
            }
            catch (Exception e)
            {
                return e.ToString();
            }

        }

        public List<Doctor> GetDoctors()
        {
            var list = _context.Doctors.ToList();
            return list;
        }

        public string ModifyDoctor(Doctor d)
        {
            try
            {
                _context.Attach(d);
                _context.Entry(d).State = EntityState.Modified;
                _context.SaveChanges();
                return "zmodyfikowano doktora";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
