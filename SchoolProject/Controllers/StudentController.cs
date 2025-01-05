using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Models.ViewModels;
using SchoolProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public StudentController(IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        // GET: StudentController
        [HttpGet]
        public ActionResult Index()
        {
            List<Student> studentslist = _studentRepository.GetAllStudents();
            return View(studentslist);
        }

        // GET: StudentController/Create
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (student != null)
            {
                _studentRepository.Create(student);
            }
            List<Student> studentslist = _studentRepository.GetAllStudents();
            return View("Index",studentslist);
        }


        // GET: StudentController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: StudentController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: StudentController/Delete/5
        public ViewResult Delete(int id)
        {
            _studentRepository.Delete(id);
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            StudentCourseVM data = new StudentCourseVM();
            data.Courses = _courseRepository.GetAllCourses();
            data.Students = _studentRepository.GetAllStudents();
            return View(data);
        }

        [HttpPost]
        public ActionResult Register(int studentId, int courseId)
        {
            _studentRepository.Register(studentId, courseId);
            return RedirectToAction("Register");
        }
    }
}
