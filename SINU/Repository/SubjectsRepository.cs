using System.Collections.Generic;
using System.Linq;
using SINU.Data;
using SINU.Model;

namespace SINU.Repository
{
    public class SubjectsRepository : ISubjectsRepository
    {

        private readonly AppDbContext _context;

        public SubjectsRepository(AppDbContext context)
        {
            _context = context;
        }
        public Subject Create(Subject subject)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();
            return GetSubjectById(subject.Id);
        }

        public List<Subject> GetAll()
        {
            return _context.Subjects.ToList();
        }

        public Subject GetSubjectById(int id)
        {
            return _context.Subjects.FirstOrDefault(s => s.Id == id);
        }
    }
}
