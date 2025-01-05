using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        // GET: StudentController
        [HttpGet]
        public ActionResult Index()
        {
            List<Room> rooms = _roomRepository.GetAllRooms();
            return View(rooms);
        }

        // GET: StudentController/Create
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Room room)
        {
            if (room != null)
            {
                _roomRepository.Create(room);
            }
            List<Room> rooms = _roomRepository.GetAllRooms();
            return View("Index",rooms);
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
            _roomRepository.Delete(id);
            List<Room> rooms = _roomRepository.GetAllRooms();
            return View("Index", rooms);
        }
    }
}
