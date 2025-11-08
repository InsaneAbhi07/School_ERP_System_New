using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_ErP.Models;
using School_ErP.Web.Data;

namespace School_ErP.Controllers
{
    public class FeeController : Controller
    {
        private readonly AppDbContext _context; 
            
        public FeeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult OldBList()
        {
            var OBlance= _context.Tbl_OldBalance.Where(x=>x.DFlag==0).ToList();  
            return View(OBlance);
        }

        [HttpGet]
        public IActionResult TakeOldBalance()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TakeOldBalance(OldBalance ob)
        {
            if (ModelState.IsValid)
            {
                ob.EDate = DateOnly.FromDateTime(DateTime.Now);
                ob.DFlag = 0;
                ob.Session = "2025-2026";
                _context.Tbl_OldBalance.Add(ob);
                _context.SaveChanges();
                TempData["msg"] = "Old Balance Saved Successfully!";
                return RedirectToAction("OldBList");
            }
            return View(ob);
        }

        public IActionResult EditOldB(int id)
        {
            var data = _context.Tbl_OldBalance.Find(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult EditOldB(OldBalance ob)
        {
            if (ModelState.IsValid)
            {
                ob.Session = "2025-2026";
                _context.Tbl_OldBalance.Update(ob);
                _context.SaveChanges();
                TempData["msg"] = "Old Balance Updated Successfully!";
                return RedirectToAction("OldBList");
            }
            return View(ob);
        }

        // GET: Delete
        public IActionResult DeleteOldB(int id)
        {
            var data = _context.Tbl_OldBalance.Find(id);
            if (data != null)
            {
                data.DFlag = 1;
                _context.SaveChanges();
            }
            return RedirectToAction("OldBList");
        }

        [HttpGet]
        public JsonResult GetStudentInfo(string regNo)
            {
              var student = _context.Tbl_StudentRegistration
             .Where(s => s.RegNo == regNo)
             .Select(s => new
             {
                 ClassName = s.CurrentClass,
                 Section = s.Section,
                 FatherName = s.FatherName,
                 ContactNo = s.SMSNo
             })
             .FirstOrDefault();

                    return Json(student);
        }

        public async Task<IActionResult> DetailsOldB(int id)
        {
            var oldB = await _context.Tbl_OldBalance
                .FirstOrDefaultAsync(s => s.Id == id);

            if (oldB == null)
                return NotFound();

            return PartialView("_OlDBalanceDetailsPartial", oldB);
        }

        public IActionResult FeeDepositeList()
        {
            var feedepo= _context.Tbl_FeeDeposite.Where(x=>x.Cancel!="0").ToList(); 
            return View(feedepo);
        }

    }
}
