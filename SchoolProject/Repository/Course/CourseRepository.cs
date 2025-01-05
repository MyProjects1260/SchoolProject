using SchoolProject.Context;
using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CourseRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public List<Course> GetAllCourses()
        {
            try
            {
                List<Course> courses = (from courseObj in _applicationDbContext.Courses
                                          select courseObj).ToList();
                return courses;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public void Create(Course course)
        { 
            _applicationDbContext.Courses.Add(course);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Course course = (from courseObj in _applicationDbContext.Courses
                               where courseObj.CourseId == id
                               select courseObj).FirstOrDefault();

            _applicationDbContext.Courses.Remove(course);
            _applicationDbContext.SaveChanges();
        }
    }
}
