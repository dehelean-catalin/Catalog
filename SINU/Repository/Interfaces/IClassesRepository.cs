using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SINU.Data;
using SINU.Model;

namespace SINU.Repository
{
    public interface IClassesRepository
    {
        Class GetClassById(int id);
        List<Class> GetAll();

        Class Create(Class Class);
    }
}
