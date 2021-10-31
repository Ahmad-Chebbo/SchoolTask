using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolTask.Context;
using SchoolTask.Models;

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

        // GET: Student
        public async Task<IActionResult> Index()
        {
            // Display the index page with the students list from the database
            return View(await _context.Students.ToListAsync());
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
                if (ModelState.IsValid)
                {
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
                return View(student);
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