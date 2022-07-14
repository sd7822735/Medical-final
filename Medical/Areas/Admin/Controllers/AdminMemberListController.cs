using Medical.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.Areas.Admin.Controllers
{[Area(areaName: "Admin")]
    public class AdminMemberListController : Controller
    {
        
        public IActionResult AdminMemberList()   //管理員帳號登入=>會員清單管理
        {
            if (HttpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_USE))  //TODO 還需要寫一個getSession(登出)/未驗證身分
            {
                MedicalContext medicalContext = new MedicalContext();
                //CMemberAdminViewModel vModel = new CMemberAdminViewModel();
                IEnumerable<Member> datas = null;

                datas = from t in medicalContext.Members
                        select t;

                return View(datas);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int? id)
        {
            MedicalContext db = new MedicalContext();
            Member mem = db.Members.FirstOrDefault(c => c.MemberId == id);
            if (mem != null)
            {
                db.Members.Remove(mem);
                db.SaveChanges();
            }
            return RedirectToAction("AdminMemberList", "AdminMemberList");
        }


        public IActionResult Edit(int? id)
        {
            MedicalContext db = new MedicalContext();
            Member mem = db.Members.FirstOrDefault(c => c.MemberId == id);
            if (mem == null)
                return RedirectToAction("Index", "Home");
            return View(mem);
        }
        [HttpPost]
        public IActionResult Edit(Member p)
        {
            MedicalContext db = new MedicalContext();
            Member mem = db.Members.FirstOrDefault(c => c.MemberId == p.MemberId);
            if (mem != null)
            {
                mem.IdentityId = p.IdentityId;
                mem.Password = p.Password;
                mem.MemberName = p.MemberName;
                mem.BirthDay = p.BirthDay;
                mem.GenderId = p.GenderId;
                mem.BloodType = p.BloodType;
                mem.Weight = p.Weight;
                mem.IcCardNo = p.IcCardNo;
                mem.Phone = p.Phone;
                mem.Email = p.Email;
                mem.Role = p.Role;
                mem.CityId = p.CityId;
                mem.Address = p.Address;


                db.SaveChanges();
            }
            return RedirectToAction("AdminMemberList","AdminMemberList");
        }
    }

}
