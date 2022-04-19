using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SINU.Data;
using SINU.Model;

namespace SINU.Repository
{
    public interface ISubjectsRepository
    {
        Subject GetSubjectById(int id);
        List<Subject> GetAll();

        Subject Create(Subject subject);
    }
}

