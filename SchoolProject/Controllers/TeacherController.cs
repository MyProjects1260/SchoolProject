using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        // GET: StudentController
        [HttpGet]
        public ActionResult Index()
        {
            List<Teacher> teachers = _teacherRepository.GetAllTeachers();
            return View(teachers);
        }

        // GET: StudentController/Create
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Teacher teacher)
        {
            if (teacher != null)
            {
                _teacherRepository.Create(teacher);
            }
            List<Teacher> teachers = _teacherRepository.GetAllTeachers();
            return View("Index",teachers);
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
            _teacherRepository.Delete(id);
            List<Teacher> teachers = _teacherRepository.GetAllTeachers();
            return View("Index", teachers);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
    }
}
