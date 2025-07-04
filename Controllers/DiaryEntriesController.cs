using Microsoft.AspNetCore.Mvc;
using DiaryApp.Data;
using DiaryApp.Models; // Add this line or replace with the correct namespace for ApplicationDbContext

namespace DiaryApp.Controllers
{
    public class DiaryEntriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DiaryEntriesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<DiaryEntry> entries = _context.DiaryEntries.ToList();
            return View(entries);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DiaryEntry entry)
        {
            if (entry != null && entry.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Title must be at least 3 characters long.");
            }
            if (ModelState.IsValid)
            {
                _context.DiaryEntries.Add(entry);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entry);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DiaryEntry? entry = _context.DiaryEntries.Find(id);
            {
                if (entry == null)
                {
                    return NotFound();
                }
            }
            return View(entry);
        }
        [HttpPost]
        public IActionResult Edit(DiaryEntry entry)
        {
            if (entry != null && entry.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Title must be at least 3 characters long.");
            }
            if (ModelState.IsValid)
            {
                _context.DiaryEntries.Update(entry);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entry);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DiaryEntry? entry = _context.DiaryEntries.Find(id);
            {
                if (entry == null)
                {
                    return NotFound();
                }
            }
            return View(entry);
        }
        [HttpPost]
        public IActionResult Delete(DiaryEntry entry)
        {
            _context.DiaryEntries.Remove(entry);
            _context.SaveChanges();
            return RedirectToAction("Index");
            
        }
    }
}