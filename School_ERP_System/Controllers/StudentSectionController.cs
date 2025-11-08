using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School_ErP.Models;
using School_ErP.Web.Data;


namespace School_ErP.Controllers
{
    public class StudentSectionController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;


        public StudentSectionController(AppDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;

        }
        public IActionResult StList()
        {
            var stdetails = _context.Tbl_StudentRegistration.ToList();
            return View(stdetails);
        }


        public IActionResult AddRegistration()
        {
            ViewBag.Classes = new SelectList(_context.Tbl_MasterClass.ToList(), "Class", "Class");
            ViewBag.Sections = new SelectList(_context.Tbl_MasterSection.ToList(), "Sec", "Sec");
            ViewBag.House = new SelectList(_context.Tbl_MasterHouse.ToList(), "House", "House");
            ViewBag.FeeCat = new SelectList(_context.Tbl_MasterFeeCategory.ToList(), "Location", "Location");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRegistration(Tbl_StRegistration student, IFormFile StudentPhoto, IFormFile FatherPhoto, IFormFile MotherPhoto)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;

                // Uploads folder
                string uploadPath = Path.Combine(wwwRootPath, "uploads");
                if (!Directory.Exists(uploadPath))
                    Directory.CreateDirectory(uploadPath);

                // Student Photo
                if (StudentPhoto != null)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(StudentPhoto.FileName);
                    string path = Path.Combine(uploadPath, fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await StudentPhoto.CopyToAsync(fileStream);
                    }
                    student.StudentPhoto = "/uploads/" + fileName;
                }

                // Father Photo
                if (FatherPhoto != null)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(FatherPhoto.FileName);
                    string path = Path.Combine(uploadPath, fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await FatherPhoto.CopyToAsync(fileStream);
                    }
                    student.FatherPhoto = "/uploads/" + fileName;
                }

                // Mother Photo
                if (MotherPhoto != null)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(MotherPhoto.FileName);
                    string path = Path.Combine(uploadPath, fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await MotherPhoto.CopyToAsync(fileStream);
                    }
                    student.MotherPhoto = "/uploads/" + fileName;
                }

                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(StList));
            }
            ViewBag.Classes = new SelectList(_context.Tbl_MasterClass.ToList(), "Class", "Class");
            ViewBag.Sections = new SelectList(_context.Tbl_MasterSection.ToList(), "Sec", "Sec");
            ViewBag.House = new SelectList(_context.Tbl_MasterHouse.ToList(), "House", "House");
            ViewBag.FeeCat = new SelectList(_context.Tbl_MasterFeeCategory.ToList(), "Location", "Location");
            return View(student);

        }

        public async Task<IActionResult> EditRegistration(int id)
        {
            var student = await _context.Tbl_StudentRegistration.FindAsync(id);
            if (student == null)
                return NotFound();

            BindDropdowns();
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRegistration(int id, Tbl_StRegistration model, IFormFile StudentPhoto, IFormFile FatherPhoto, IFormFile MotherPhoto)
        {
            if (id != model.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    model.StudentPhoto = await SaveImage(StudentPhoto, model.StudentPhoto);
                    model.FatherPhoto = await SaveImage(FatherPhoto, model.FatherPhoto);
                    model.MotherPhoto = await SaveImage(MotherPhoto, model.MotherPhoto);

                    _context.Update(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(StList));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Tbl_StudentRegistration.Any(e => e.Id == model.Id))
                        return NotFound();
                    else
                        throw;
                }
            }

            BindDropdowns();
            return View(model);
        }

        // -------------------- DELETE --------------------
        public async Task<IActionResult> DeleteRegistration(int id)
        {
            var student = await _context.Tbl_StudentRegistration.FindAsync(id);
            if (student == null)
                return NotFound();

            _context.Tbl_StudentRegistration.Remove(student);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(StList));
        }

        // -------------------- IMAGE SAVE METHOD --------------------
        private async Task<string> SaveImage(IFormFile file, string existingFilePath = null)
        {
            if (file == null || file.Length == 0)
                return existingFilePath;

            string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return "/uploads/" + uniqueFileName;
        }

        // -------------------- BIND DROPDOWNS --------------------
        private void BindDropdowns()
        {
            ViewBag.Classes = new SelectList(_context.Tbl_MasterClass.ToList(), "Class", "Class");
            ViewBag.Sections = new SelectList(_context.Tbl_MasterSection.ToList(), "Sec", "Sec");
            ViewBag.House = new SelectList(_context.Tbl_MasterHouse.ToList(), "House", "House");
            ViewBag.FeeCat = new SelectList(_context.Tbl_MasterFeeCategory.ToList(), "Location", "Location");
        }

        public async Task<IActionResult> DetailsClass(int id)
        {
            var student = await _context.Tbl_StudentRegistration
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
                return NotFound();

            return PartialView("_StudentDetailsPartial", student);
        }
    }
}
