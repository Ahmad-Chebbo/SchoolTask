using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolTask.Context;
using SchoolTask.Models;
using SchoolTask.Paging;

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
        public  IActionResult Index(int page = 1)
        {
            Pagination pager = new Pagination(_context.Subjects.Count(), page, 6);
            ViewBag.pageCount = pager.TotalPages;
            ViewBag.currentPage =  pager.CurrentPage;
            ViewBag.nextPage =  pager.NextPage;
            ViewBag.previewsPage =  pager.PreviewsPage;
            var subjects = _context.Subjects.Skip(pager.Skip).Take(pager.PageSize).OrderBy(e => e.Name).ToList();

            return View(subjects); 
            
        }
        
        // GET: Subject/Create
        public IActionResult Create()
        {
            // Go to the Create page to create new subject
            return View();
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
        public IActionResult Detail(int? id)
        {
            Subject subject = _context.Subjects.Find(id);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }
        
        // GET: Subject/Edit/{id}
        public IActionResult Edit(int id)
        {
            if (_context.Subjects.Find(id) != null)
            { 
                return View(_context.Subjects.Find(id));
            }

            return NotFound();
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
            try
            {
                // Find the subject in the database
                var subject = await _context.Subjects.FindAsync(id);
                // Use the ER context to remove the subject from the database
                _context.Subjects.Remove(subject);
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
    }
}