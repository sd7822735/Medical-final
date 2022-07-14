using Medical.Models;
using Medical.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.Controllers
{
    public class ClinicDetailController : Controller
    {
        
        private readonly MedicalContext _context;
        public ClinicDetailController(MedicalContext medicalContext)
        {
            _context = medicalContext;
        }
        // 寫死日期 要再改
        public IActionResult List()
        {
            var result = _context.ClinicDetails.Where(a => a.ClinicDate == "2022/07/12/12/00/00")
                .Include(a => a.Doctor)
                .Include(a => a.Department)
                .Include(a => a.Reserves)
                .Include(a => a.Room)
                .ToList();


            return View(result);
        }

 
    }
}
