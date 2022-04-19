//using System.Collections.Generic;
//using SINU.Data;
//using SINU.Model;
//using System.Linq;
//using Microsoft.EntityFrameworkCore;

//namespace SINU.Repository
//{
//    public class TeachersRepository : ITeacherRepository
//    {
//        private readonly AppDbContext _context;

//        public TeachersRepository(AppDbContext context)
//        {
//            _context = context;
//        }

//        public Teacher GetTeacherByEmail(string email)
//        {
//            User user = _context.Users.FirstOrDefault(s => s.Email == email);
//            if (user != null)
//                return new Teacher()
//                {
//                    Id = user.Id,
//                    FirstName = user.FirstName,
//                    LastName = user.LastName,
//                    Email = user.Email,
//                    Phone = user.Phone,
//                    Role = user.Role
//                };
//            else
//                return null;
//        }

//        public Teacher GetTeacherById(int id)
//        {
//            User user = _context.Users.FirstOrDefault(s => s.Id == id);
//            if (user!=null)
//            return new Teacher()
//            {
//                Id = user.Id,
//                FirstName = user.FirstName,
//                LastName = user.LastName,
//                Email = user.Email,
//                Phone = user.Phone,
//                Role = user.Role
//            };
//            else
//                return null;
//        }

//        public List<SubjectProfesor> GetTeacherSubjectsByTeacherId(int id)
//        {
//            //return _context.SubjectsProfesor.Include(s=>s.Subject).Include(s=>s.StudyYear).Include(s=>s.User).Where(s => s.UserId == id).ToList();
//            return _context.SubjectsProfesor.Where(s => s.UserId == id).ToList();
//        }

//        public Teacher Update(Teacher teacher)
//        {

//            var user = _context.Users.FirstOrDefault(u => u.Id == teacher.Id);
//            user.FirstName = teacher.FirstName;
//            user.LastName = teacher.LastName;
//            user.Email = teacher.Email;
//            user.Phone = teacher.Phone;
//            _context.Users.Add(user);
//            _context.SaveChanges();
//            user = _context.Users.FirstOrDefault(u => u.Id == teacher.Id);
//            return new Teacher()
//            {
//                Id = user.Id,
//                FirstName = user.FirstName,
//                LastName = user.LastName,
//                Email = user.Email,
//                Phone = user.Phone,
//                Role = user.Role
//            };
//        }

//        public List<Teacher> GetAll()
//        {
//            List < User > users = _context.Users.Where(s=>s.Role=="Teacher").ToList();
//            List<Teacher> teachers = new List<Teacher>();
//            foreach (User user in users)
//            {
//                teachers.Add(new Teacher()
//                {
//                    Id = user.Id,
//                    FirstName = user.FirstName,
//                    LastName = user.LastName,
//                    Email = user.Email,
//                    Phone = user.Phone,
//                    Role = user.Role
//                });
//            }
//            return teachers;
//        }
//    }
//}
