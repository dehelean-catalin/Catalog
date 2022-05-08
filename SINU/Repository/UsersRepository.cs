using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SINU.Data;
using SINU.Repository;
using SINU.Model;
using SINU.DTO;

namespace SINU.Repository
{

    public class UsersRepository : IUsersRepository
    {
        private readonly AppDbContext _context;

        public UsersRepository(AppDbContext context)
        {

            _context = context;

        }

        public User Register(User user)
        {

            var existingUser = _context.Users.FirstOrDefault(u => u.IDNP == user.IDNP);
            if (existingUser == null)
            {
                return null;
            }
            else
            {
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;
                //existingUser.Username = user.Username;
                _context.Users.Update(existingUser);
                _context.SaveChanges();
                return existingUser;
            }
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetUserByEmail(string Email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == Email);
        }

        public User GetUserByUsername(string Username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == Username);
        }

        public List<User> GetTeachers()
        {
            return _context.Users.Where(u => u.Role == "Teacher").ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public User GetTeacherById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id && u.Role == "Teacher");
        }

        public User Insert(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User UpdateSettings(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }

        public User UpdatePassword(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }

        public User GetUserByIDNP(string idnp)
        {
            return _context.Users.FirstOrDefault(u => u.IDNP == idnp);
        }

        public User GetUserByPhone(string phone)
        {
            return _context.Users.FirstOrDefault(u => u.Phone == phone);
        }

        public bool VerifyUniqueEmail(string email)
        {
            if (GetUserByEmail(email) != null)
                return false;
            else
                return true;
        }

        public bool VerifyUniquePhone(string phone)
        {
            if (GetUserByPhone(phone) != null)
                return false;
            else
                return true;
        }
    }
}
