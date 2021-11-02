using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolTask.Context;
using SchoolTask.Models;

namespace SchoolTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StudentContext _studentContext;
        private readonly SubjectContext _subjectContext;

        public HomeController(ILogger<HomeController> logger, StudentContext studentContext, SubjectContext subjectContext)
        {
            _logger = logger;
            _studentContext = studentContext;
            _subjectContext = subjectContext;
        }

        public IActionResult Index()
        {
            var studentsCount = _studentContext.Students.Count();
            var subjectsCount = _subjectContext.Subjects.Count();
            ViewBag.studentsCount = studentsCount;
            ViewBag.subjectsCount = subjectsCount;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}