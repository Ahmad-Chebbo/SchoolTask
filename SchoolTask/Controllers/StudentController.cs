using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolTask.Context;
using SchoolTask.Models;
using SchoolTask.Paging;

namespace SchoolTask.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext _context;
        
        // Constructor
        public StudentController(StudentContext context)
        {
            _context = context;
        }

        // GET: Students
        public IActionResult Index(int page = 1)
        {
            // I left those comments to show the process of creating pagination before moving them to a separate
            // class and creating a partial view page with dynamic controller name
            
            // var limit = 3;
            // var skip = (page - 1) * limit; 
            // decimal total = _context.Students.Count();
            // var pageCount = Math.Ceiling((total / limit));
            // @ViewBag.pageCount = pageCount;
            // @ViewBag.currentPage =  Convert.ToInt32(page);
            // pageSize => limit
            // page => currentPage
            // skip => (currentPage - 1) * PageSize
            
            Pagination pager = new Pagination(_context.Students.Count(), page, 3);
            ViewBag.pageCount = pager.TotalPages;
            ViewBag.currentPage =  pager.CurrentPage;
            ViewBag.nextPage =  pager.NextPage;
            ViewBag.previewsPage =  pager.PreviewsPage;
            var students = _context.Students.Skip(pager.Skip).Take(pager.PageSize).OrderBy(e => e.FullName).ToList();
            
            return View(students);
        }

        // GET: Student/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            // Go to the AddOrEdit page to create new student or update existing one in case if the id parameter is not 0
            return View(id == 0 ? new Student() : _context.Students.Find(id));
        }

        // POST: Student/AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(Student student)
        {
            try
            {
                // Validated the data
                if (!ModelState.IsValid) return View(student);
                // Check if the student id exist or not (checking if it's create ot edit action)
                if (student.Id == 0)
                    // Create new student with the given parameters  body
                    _context.Add(student);
                else
                    // Update existing students
                    _context.Update(student);
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

        // POST: Student/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            // Find the student in the database
            var student = await _context.Students.FindAsync(id);
            try
            {
                // Use the ER context to remove the student from the database
                _context.Students.Remove(student);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            // Synchronize the changes in the database and the ER context
            await _context.SaveChangesAsync();
            // Return back
            return RedirectToAction("Index");
        }
    }
}