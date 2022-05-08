using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SINU.Model;
using SINU.DTO;

namespace SINU.Repository
{
    public interface IUsersRepository
    {
        User GetUserById(int id);
        User GetTeacherById(int id);
        User GetUserByIDNP(string idnp);
        User GetUserByEmail(string email);
        User GetUserByUsername(string Username);
        User Register(User user);
        User Insert(User user);
        User UpdateSettings(User user);
        User UpdatePassword(User user);
        bool VerifyUniqueEmail(string email);
        bool VerifyUniquePhone(string phone);
        List<User> GetAll();
        List<User> GetTeachers();
    }
}
