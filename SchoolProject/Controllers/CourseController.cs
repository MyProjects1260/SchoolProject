using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ITeacherRepository _teacherRepository;

        public CourseController(ICourseRepository courseRepository, ITeacherRepository teacherRepository)
        {
            _courseRepository = courseRepository;
            _teacherRepository = teacherRepository;
        }

        // GET: StudentController
        [HttpGet]
        public ActionResult Index()
        {
            List<Course> courses = _courseRepository.GetAllCourses();
            return View(courses);
        }

        // GET: StudentController/Create
        [HttpGet]
        public ViewResult Create()
        {
            List<Teacher> teachers = _teacherRepository.GetAllTeachers();
            return View(teachers);
        }

        [HttpPost]
        public ActionResult Create(Course course)
        {
            if (course != null)
            {
                _courseRepository.Create(course);
            }
            List<Course> courses = _courseRepository.GetAllCourses();
            return View("Index", courses);
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
            _courseRepository.Delete(id);
            List<Course> courses = _courseRepository.GetAllCourses();
            return View("Index", courses);
        }
    }
}
