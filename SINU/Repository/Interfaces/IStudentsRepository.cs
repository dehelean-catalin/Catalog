using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SINU.Controllers;
using SINU.Model;

namespace SINU.Repository
{
    public interface IStudentsRepository
    {
        Student GetStudentById(int id);
        List<Student> GetAll();
        Student GetStudentByUserIdYearId(int userId, int yearId);
        Student Create(Student student);
        List<Student> GetStudentsByClassId(int id);
    }
}
