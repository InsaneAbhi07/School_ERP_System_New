using Microsoft.AspNetCore.Mvc;
using School_ErP.Models;
using School_ErP.Web.Data;

namespace School_ErP.Controllers
{
    public class MasterController : Controller
    {
        private readonly AppDbContext _context;

        public MasterController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult SchoolList()
        {
            var data = _context.Master_SchoolInfo.ToList();
            return View(data);
        }

        // GET: Master/CreateSchool
        // ==================== CREATE SCHOOL (GET) ====================
        [HttpGet]
        public IActionResult CreateSchool()
        {
            return View(new Master_School());
        }

        // ==================== CREATE SCHOOL (POST) ====================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSchool(Master_School model)
        {
            if (ModelState.IsValid)
            {
                _context.Master_SchoolInfo.Add(model);
                _context.SaveChanges();
                TempData["success"] = "School added successfully!";
                return RedirectToAction("SchoolList");
            }
            return View(model);
        }

        // ==================== EDIT SCHOOL (GET) ====================
        [HttpGet]
        public IActionResult EditSchool(int id)
        {
            var school = _context.Master_SchoolInfo.Find(id);
            if (school == null)
                return NotFound();

            return View("CreateSchool", school); // ✅ reuse same view
        }

        // ==================== EDIT SCHOOL (POST) ====================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSchool(Master_School model)
        {
            if (ModelState.IsValid)
            {
                _context.Master_SchoolInfo.Update(model);
                _context.SaveChanges();
                TempData["success"] = "School updated successfully!";
                return RedirectToAction("SchoolList");
            }
            return View("CreateSchool", model);
        }

        // ==================== DETAILS ====================
        public IActionResult DetailsSchool(int id)
        {
            var school = _context.Master_SchoolInfo.FirstOrDefault(x => x.Id == id);
            if (school == null)
                return NotFound();

            return PartialView("_SchoolDetailsPartial", school);
        }


        // ==================== DELETE ====================
        [HttpGet]
        public IActionResult DeleteSchool(int id)
        {
            var school = _context.Master_SchoolInfo.Find(id);
            if (school == null)
                return NotFound();

            _context.Master_SchoolInfo.Remove(school);
            _context.SaveChanges();
            TempData["success"] = "School deleted successfully!";
            return RedirectToAction("SchoolList");
        }




        /////////MASTER CLASS//
        public IActionResult ClassList()
        {
            var data = _context.Tbl_MasterClass.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult CreateClass()
        {
            return View(new Master_Classes());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateClass(Master_Classes model)
        {
            if (ModelState.IsValid)
            {
                _context.Tbl_MasterClass.Add(model);
                _context.SaveChanges();
                TempData["success"] = "School added successfully!";
                return RedirectToAction("ClassList");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditClass(int id)
        {
            var school = _context.Tbl_MasterClass.Find(id);
            if (school == null)
                return NotFound();

            return View("CreateClass", school);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditClass(Master_Classes model)
        {
            if (ModelState.IsValid)
            {
                _context.Tbl_MasterClass.Update(model);
                _context.SaveChanges();
                TempData["success"] = "School updated successfully!";
                return RedirectToAction("ClassList");
            }
            return View("CreateClass", model);
        }

        public IActionResult DetailsClass(int id)
        {
            var school = _context.Tbl_MasterClass.FirstOrDefault(x => x.Id == id);
            if (school == null)
                return NotFound();

            return PartialView("_ClassDetailsPartial", school);
        }


        [HttpGet]
        public IActionResult DeleteClass(int id)
        {
            var school = _context.Tbl_MasterClass.Find(id);
            if (school == null)
                return NotFound();

            _context.Tbl_MasterClass.Remove(school);
            _context.SaveChanges();
            TempData["success"] = "Class deleted successfully!";
            return RedirectToAction("ClassList");
        }

        //////MASTER SECTION
        public IActionResult SectionList()
        {
            var data = _context.Tbl_MasterSection.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult CreateSection()
        {
            return View(new Master_Section());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSection(Master_Section model)
        {
            if (ModelState.IsValid)
            {
                _context.Tbl_MasterSection.Add(model);
                _context.SaveChanges();
                TempData["success"] = "Section added successfully!";
                return RedirectToAction("SectionList");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditSection(int id)
        {
            var school = _context.Tbl_MasterSection.Find(id);
            if (school == null)
                return NotFound();

            return View("CreateSection", school);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSection(Master_Section model)
        {
            if (ModelState.IsValid)
            {
                _context.Tbl_MasterSection.Update(model);
                _context.SaveChanges();
                TempData["success"] = "Section updated successfully!";
                return RedirectToAction("SectionList");
            }
            return View("CreateSection", model);
        }

        public IActionResult DetailsSection(int id)
        {
            var school = _context.Tbl_MasterSection.FirstOrDefault(x => x.Id == id);
            if (school == null)
                return NotFound();

            return PartialView("_SectionDetailsPartial", school);
        }


        [HttpGet]
        public IActionResult DeleteSection(int id)
        {
            var school = _context.Tbl_MasterSection.Find(id);
            if (school == null)
                return NotFound();

            _context.Tbl_MasterSection.Remove(school);
            _context.SaveChanges();
            TempData["success"] = "Section deleted successfully!";
            return RedirectToAction("SectionList");
        }



        //////////MASTER HOUSE/////
        public IActionResult HouseList()
        {
            var data = _context.Tbl_MasterHouse.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult CreateHouse()
        {
            return View(new Master_House());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateHouse(Master_House model)
        {
            if (ModelState.IsValid)
            {
                _context.Tbl_MasterHouse.Add(model);
                _context.SaveChanges();
                TempData["success"] = "House added successfully!";
                return RedirectToAction("HouseList");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditHouse(int id)
        {
            var school = _context.Tbl_MasterHouse.Find(id);
            if (school == null)
                return NotFound();

            return View("CreateHouse", school);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditHouse(Master_House model)
        {
            if (ModelState.IsValid)
            {
                _context.Tbl_MasterHouse.Update(model);
                _context.SaveChanges();
                TempData["success"] = "House updated successfully!";
                return RedirectToAction("HouseList");
            }
            return View("CreateHouse", model);
        }

        public IActionResult DetailsHouse(int id)
        {
            var school = _context.Tbl_MasterHouse.FirstOrDefault(x => x.Id == id);
            if (school == null)
                return NotFound();

            return PartialView("_HouseDetailsPartial", school);
        }


        [HttpGet]
        public IActionResult DeleteHouse(int id)
        {
            var school = _context.Tbl_MasterHouse.Find(id);
            if (school == null)
                return NotFound();

            _context.Tbl_MasterHouse.Remove(school);
            _context.SaveChanges();
            TempData["success"] = "House deleted successfully!";
            return RedirectToAction("HouseList");
        }


        /////MASTER STREAM/////
        public IActionResult StreamList()
        {
            var data = _context.Tbl_MasterStream.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult CreateStream()
        {
            return View(new Master_Streams());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateStream(Master_Streams model)
        {
            if (ModelState.IsValid)
            {
                _context.Tbl_MasterStream.Add(model);
                _context.SaveChanges();
                TempData["success"] = "Stream added successfully!";
                return RedirectToAction("StreamList");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditStream(int id)
        {
            var school = _context.Tbl_MasterStream.Find(id);
            if (school == null)
                return NotFound();

            return View("CreateStream", school);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditStream(Master_Streams model)
        {
            if (ModelState.IsValid)
            {
                _context.Tbl_MasterStream.Update(model);
                _context.SaveChanges();
                TempData["success"] = "Stream updated successfully!";
                return RedirectToAction("StreamList");
            }
            return View("CreateStream", model);
        }

        public IActionResult DetailsStream(int id)
        {
            var school = _context.Tbl_MasterStream.FirstOrDefault(x => x.Id == id);
            if (school == null)
                return NotFound();

            return PartialView("_StreamDetailsPartial", school);
        }


        [HttpGet]
        public IActionResult DeleteStream(int id)
        {
            var school = _context.Tbl_MasterStream.Find(id);
            if (school == null)
                return NotFound();

            _context.Tbl_MasterStream.Remove(school);
            _context.SaveChanges();
            TempData["success"] = "Stream deleted successfully!";
            return RedirectToAction("StreamList");
        }
        /////MASTER FEE CATEGORY
        public IActionResult FeeCatList()
        {
            var data = _context.Tbl_MasterFeeCategory.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult CreateFeeCat()
        {
            return View(new Master_FeeCategory());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateFeeCat(Master_FeeCategory model)
        {
            if (ModelState.IsValid)
            {
                _context.Tbl_MasterFeeCategory.Add(model);
                _context.SaveChanges();
                TempData["success"] = "Fee Category added successfully!";
                return RedirectToAction("FeeCatList");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditFeeCat(int id)
        {
            var school = _context.Tbl_MasterFeeCategory.Find(id);
            if (school == null)
                return NotFound();

            return View("CreateFeeCat", school);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditFeeCat(Master_FeeCategory model)
        {
            if (ModelState.IsValid)
            {
                _context.Tbl_MasterFeeCategory.Update(model);
                _context.SaveChanges();
                TempData["success"] = "Fee Category updated successfully!";
                return RedirectToAction("FeeCatList");
            }
            return View("CreateFeeCat", model);
        }

        public IActionResult DetailsFeeCat(int id)
        {
            var school = _context.Tbl_MasterFeeCategory.FirstOrDefault(x => x.Id == id);
            if (school == null)
                return NotFound();

            return PartialView("_FeeCatDetailsPartial", school);
        }


        [HttpGet]
        public IActionResult DeleteFeeCat(int id)
        {
            var school = _context.Tbl_MasterFeeCategory.Find(id);
            if (school == null)
                return NotFound();

            _context.Tbl_MasterFeeCategory.Remove(school);
            _context.SaveChanges();
            TempData["success"] = "Fee Category deleted successfully!";
            return RedirectToAction("FeeCatList");
        }
    }
}
