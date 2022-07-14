using Microsoft.AspNetCore.Mvc;
using Medical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medical.ViewModels;
using Medical.ViewModel;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Medical.Controllers
{
    public class PatientRecordController : Controller
    {

        public IActionResult List(CKeyWordViewModel vModel)
        {
            MedicalContext medical = new MedicalContext();
            CMemberAdminViewModel vm = null;
            string logJson = "";
            logJson = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USE);
            vm = JsonSerializer.Deserialize<CMemberAdminViewModel>(logJson);
            var id = vm.Member.MemberId;
            IEnumerable<CaseRecordViewModel> list = null;
            if (id != 0)
            {
                if (string.IsNullOrEmpty(vModel.txtKeyword))
                {
                    list = medical.CaseRecords.Where(m => m.MemberId == id).Select(m => new CaseRecordViewModel
                    {
                        Reserve = m.Reserve,
                        caseRecord = m,
                        Member = m.Member,
                        TreatmentDetail = m.TreatmentDetail,
                        Doctor = m.Reserve.ClinicDetail.Doctor
                    });
                    return View(list);
                }
                else
                {
                    list = medical.CaseRecords.Where(m => m.Reserve.ClinicDetail.Doctor.DoctorName.Contains(vModel.txtKeyword) && m.MemberId == id).Select(m => new CaseRecordViewModel
                    {
                        caseRecord = m,
                        Member = m.Member,
                        Reserve = m.Reserve,     
                        TreatmentDetail = m.TreatmentDetail,
                        Doctor = m.Reserve.ClinicDetail.Doctor
                    });
                    return View(list);
                }
            }
                return RedirectToAction("Login", "Home");
            }

        public IActionResult Create(int? id)
        {
            MedicalContext medical = new MedicalContext();
            Doctor list = medical.Doctors.FirstOrDefault(m => m.DoctorId == id);
            if(list == null)
                return RedirectToAction("Login", "Home");
            return View(list);
        }  
        [HttpPost]
        public IActionResult Create(RatingDoctor r)
        {
            MedicalContext medical = new MedicalContext();
            
            medical.RatingDoctors.Add(r);
            medical.SaveChanges();

            return RedirectToAction("List");  
        }
    }
}
