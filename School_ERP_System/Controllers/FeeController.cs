using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_ErP.Models;
using School_ErP.Web.Data;
using School_ERP_System.Models;

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

        public IActionResult FeeDeposite()
        {
            var model = new FeeDeposite();
            model.ReceiptNo = GenerateNextReceiptNo();
            //model.Regno = GetStudentByRegNo(string Regno);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FeeDeposite(FeeDeposite model, string SelectedMonthsData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();

                // Step 4: Parse JSON & Save Month-wise details
                if (!string.IsNullOrEmpty(SelectedMonthsData))
                {
                    var months = System.Text.Json.JsonSerializer.Deserialize<List<MonthFeeVM>>(SelectedMonthsData);
                    model.Session = "2025-26";
                    model.Sid = 0;

                    foreach (var m in months)
                    {
                        var detail = new FeeDepositeDetail
                        {

                            FeeDepositeId = model.Id,
                            Month = m.Month,
                            Installment = m.Installment,
                            Amount = m.Amount
                        };
                        _context.Add(detail);
                    }
                    await _context.SaveChangesAsync();
                }

                TempData["msg"] = "Record added successfully!";
                return RedirectToAction(nameof(FeeDepositeList));
            }

             return View(model);
        }


        // GET: Edit
        public async Task<IActionResult> EditFeeDeposite(int? id)
        {
            if (id == null) return NotFound();
            var data = await _context.Tbl_FeeDeposite.FindAsync(id);
            if (data == null) return NotFound();
            return View(data);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditFeeDeposite(int id, FeeDeposite model)
        {
            if (id != model.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
                TempData["msg"] = "Record updated successfully!";
                return RedirectToAction(nameof(FeeDepositeList));
            }
            return View(model);
        }

        // GET: Delete
        public async Task<IActionResult> DeleteFeeD(int? id)
        {
            if (id == null) return NotFound();
            var data = await _context.Tbl_FeeDeposite.FindAsync(id);
            if (data == null) return NotFound();
            return View(data);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var data = await _context.Tbl_FeeDeposite.FindAsync(id);
            _context.Tbl_FeeDeposite.Remove(data);
            await _context.SaveChangesAsync();
            TempData["msg"] = "Record deleted successfully!";
            return RedirectToAction(nameof(FeeDepositeList));
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentByRegNo(string regNo)
            {
            if (string.IsNullOrEmpty(regNo))
                return Json(new { success = false, message = "Invalid Reg No" });

                var student = await _context.Tbl_StudentRegistration
                .Where(x => x.FormNo == regNo)
                .Select(s => new
                {
                    StudentName = s.StudentName,
                    FatherName = s.FatherName,
                    CurrentClass = s.CurrentClass,
                    Section = s.Section,
                    smsno = s.SMSNo,
                    FeeCategory = s.FeeCategory
                })
                .FirstOrDefaultAsync();

            if (student == null)
                return Json(new { success = false, message = "No student found!" });

            return Json(new { success = true, data = student });
        }

        public string GenerateNextReceiptNo()
        {
            var last = _context.Tbl_FeeDeposite.OrderByDescending(x => x.Id).Select(x => x.ReceiptNo).FirstOrDefault();

            int nextNo = 1;

            if (!string.IsNullOrEmpty(last))
            {
                string numericPart = new string(last.Where(char.IsDigit).ToArray());

                if (int.TryParse(numericPart, out int num))
                {
                    nextNo = num + 1;
                }
            }
            string newReceipt = $"RC{nextNo:D4}";
            return newReceipt;
        }

        [HttpGet]
        public JsonResult GetMonthFeeByClass(string className)
        {
            try
            {
                    var data = _context.Tbl_MasterMonthFee.Where(x => x.CurClass == className && x.Mode=="NEW").ToList().
                        OrderBy(x => x.Mon).Select((x, index) => new
                                 {
                                     SrNo = index + 1, MonthName = x.Month, Installment = x.fee, Amount = x.Amount
                                 }).ToList();
                    return Json(new { success = true, data });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

    }
}
