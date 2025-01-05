using SchoolProject.Context;
using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public StudentRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public List<Student> GetAllStudents()
        {
            try
            {
                List<Student> students = (from stdsObj in _applicationDbContext.Students
                                          select stdsObj).ToList();
                return students;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public void Create(Student student)
        {
            _applicationDbContext.Students.Add(student);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Student student = (from stdObj in _applicationDbContext.Students
                               where stdObj.StudentId == id
                               select stdObj).FirstOrDefault();

            _applicationDbContext.Students.Remove(student);
            _applicationDbContext.SaveChanges();
        }

        public void Register(int studentId, int courseId)
        {
            _applicationDbContext.StudentCourse.Add(new StudentCourse
            {
                CourseId = courseId,
                StudentId = studentId
            });
            _applicationDbContext.SaveChanges();
        }
    }
}
