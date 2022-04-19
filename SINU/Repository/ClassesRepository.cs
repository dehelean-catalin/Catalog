using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SINU.Data;
using SINU.Model;
using SINU.DTO;

namespace SINU.Repository
{
    public class ClassesRepository : IClassesRepository
    {

        private readonly AppDbContext _context;

        public ClassesRepository(AppDbContext context)
        {
            _context = context;
        }
        public Class Create(Class Class)
        {
            _context.Classes.Add(Class);
            _context.SaveChanges();
            return GetClassById(Class.Id);
        }

        public List<Class> GetAll()
        {
            return _context.Classes.Include(s => s.Mentor).Include(s => s.StudyYear).ToList();
        }

        public Class GetClassById(int id)
        {
            return _context.Classes.Include(s=>s.Mentor).Include(s => s.StudyYear).FirstOrDefault(c => c.Id == id);
        }
    }
}
