using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolTask.Context;
using SchoolTask.Models;

namespace SchoolTask.Controllers
{
    public class SubjectController : Controller
    {
        private readonly SubjectContext _context;

        public SubjectController(SubjectContext context)
        {
            _context = context;
        }

        // GET: Subject
        public async Task<IActionResult> Index()
        {
            // Display the index page with the students list from the database
            return View(await _context.Subjects.ToListAsync());
        }
        
        // GET: Subject/Create
        public IActionResult Create()
        {
            // Go to the Create page to create new subject
            return View(new Subject());
        }
        
        // POST: Subject/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> Create(Subject subject)
        {
            try
            {
                // Validated the data
                if (!ModelState.IsValid) return View(subject);
                // Create new subject with the given parameters  body
                _context.Add(subject);
                // Synchronize the changes in the database and the ER context
                await _context.SaveChangesAsync();
                // Return back
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }
        
        // GET: Subject/Detail/{id}
        public IActionResult Detail(int id)
        {
            return View(_context.Subjects.Find(id));
        }
        
        // GET: Subject/Edit/{id}
        public IActionResult Edit(int id)
        {
            return View(_context.Subjects.Find(id));
        }
        
        // POST: Subject/Edit{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult>Edit(Subject subject)
        {
            // Validated the data
            if (!ModelState.IsValid) return View(subject);
            // Update existing subject
            _context.Update(subject);
            // Synchronize the changes in the database and the ER context
            await _context.SaveChangesAsync();
            // Return back
            return RedirectToAction("Index");
        }
        
        // POST: Subject/Delete/{id}
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            // Find the subject in the database
            var subject = await _context.Subjects.FindAsync(id);
            try
            {
                // Use the ER context to remove the subject from the database
                _context.Subjects.Remove(subject);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
            // Synchronize the changes in the database and the ER context
            await _context.SaveChangesAsync();
            // Return back
            return RedirectToAction("Index");
        }
    }
}