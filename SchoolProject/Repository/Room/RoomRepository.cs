using SchoolProject.Context;
using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public RoomRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public List<Room> GetAllRooms()
        {
            try
            {
                List<Room> rooms = (from roomObj in _applicationDbContext.Rooms
                                          select roomObj).ToList();
                return rooms;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public void Create(Room room)
        {
            _applicationDbContext.Rooms.Add(room);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Room room = (from roomObj in _applicationDbContext.Rooms
                               where roomObj.RoomId == id
                               select roomObj).FirstOrDefault();

            _applicationDbContext.Rooms.Remove(room);
            _applicationDbContext.SaveChanges();
        }
    }
}
