using SchoolProject.Context;
using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public TeacherRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public List<Teacher> GetAllTeachers()
        {
            try
            {
                List<Teacher> teachers = (from teachObj in _applicationDbContext.Teachers
                                          select teachObj).ToList();
                return teachers;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public void Create(Teacher teacher)
        {
            _applicationDbContext.Teachers.Add(teacher);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Teacher teacher = (from teachObj in _applicationDbContext.Teachers
                               where teachObj.TeacherId == id
                               select teachObj).FirstOrDefault();

            _applicationDbContext.Teachers.Remove(teacher);
            _applicationDbContext.SaveChanges();
        }
    }
}
