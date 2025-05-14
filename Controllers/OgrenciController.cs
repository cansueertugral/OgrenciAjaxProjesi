using Microsoft.AspNetCore.Mvc;
using OgrenciAjaxProjesi.Models;
using System.Linq;

namespace OgrenciAjaxProjesi.Controllers
{
    public class OgrenciController : Controller
    {
        private readonly OkulDbContext _context;

        public OgrenciController(OkulDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult OgrenciList()
        {
            var ogrenciler = _context.Ogrenciler.ToList();
            return Json(ogrenciler);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ogrenci ogrenci)
        {
            _context.Ogrenciler.Add(ogrenci);
            _context.SaveChanges();
            return Json(new { success = true, message = "Öğrenci başarıyla eklendi!" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                _context.Ogrenciler.Update(ogrenci);
                _context.SaveChanges();
                return Json(new { success = true, message = "Öğrenci başarıyla güncellendi!" });
            }
            return Json(new { success = false, message = "Veriler geçersiz!" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var ogrenci = _context.Ogrenciler.Find(id);
            if (ogrenci != null)
            {
                _context.Ogrenciler.Remove(ogrenci);
                _context.SaveChanges();
                return Json(new { success = true, message = "Öğrenci başarıyla silindi!" });
            }
            return Json(new { success = false, message = "Öğrenci bulunamadı!" });
        }
    }
}
