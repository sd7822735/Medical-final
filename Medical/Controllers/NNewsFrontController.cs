using Medical.Models;
using Medical.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.Controllers
{
    public class NNewsFrontController : Controller
    {
        private readonly MedicalContext _medicalContext;
        public NNewsFrontController(MedicalContext medicalContext)
        {
            _medicalContext = medicalContext;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            List<NNewsViewModel> list = new List<NNewsViewModel>();
            list.
            return View();
        }
    }
}
