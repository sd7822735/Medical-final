using Medical.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Medical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using Medical.ViewModel;

namespace Medical.Controllers
{
    public class AllPatientRecordController : Controller
    {
        public IActionResult List(CKeyWordViewModel vModel)
        {
            MedicalContext medical = new MedicalContext();
            CMemberAdminViewModel vm = null;
            string logJson = "";
            logJson = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USE);
            vm = JsonSerializer.Deserialize<CMemberAdminViewModel>(logJson);
            var id = vm.Member.MemberId;

            var doctorID = medical.Doctors.Where(m => m.MemberId == id).Select(m => m.DoctorId).FirstOrDefault();
            var clinicDetailID = medical.ClinicDetails.Where(m => m.DoctorId == doctorID).Select(m => m.ClinicDetailId).FirstOrDefault();
            //var reserveID = 18;
            var reserveID = medical.Reserves.Where(m => m.ClinicDetailId == clinicDetailID).Select(m => m.ReserveId).FirstOrDefault();
            if (string.IsNullOrEmpty(vModel.txtKeyword)){
                if (reserveID != 0)
                {
                    IEnumerable<CaseRecordViewModel> list = null;

                    list = medical.CaseRecords.Where(m => m.ReserveId == reserveID).Select(m => new CaseRecordViewModel
                    {
                        caseRecord = m,
                        Member = m.Member,
                        Reserve = m.Reserve,
                        TreatmentDetail = m.TreatmentDetail
                    });
                    return View(list);
                }
            }
            else
            {
                IEnumerable<CaseRecordViewModel> list = null;

                list = medical.CaseRecords.Where(m => m.ReserveId == reserveID && m.Member.MemberName.Contains(vModel.txtKeyword)).Select(m => new CaseRecordViewModel
                {
                    caseRecord = m,
                    Member = m.Member,
                    Reserve = m.Reserve,
                    TreatmentDetail = m.TreatmentDetail
                });
                return View(list);
            }


            return RedirectToAction("Index", "Home");


        }
    }
}
