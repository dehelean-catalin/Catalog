using System.Collections.Generic;
using SINU.Data;
using SINU.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SINU.Repository
{
    public class SubjectsProfesorRepository : ISubjectsProfesorRepository
    {
        private readonly AppDbContext _context;

        public SubjectsProfesorRepository(AppDbContext context)
        {
            _context = context;
        }

        public SubjectProfesor GetSubjectProfesorById(int id)
        {
            return _context.SubjectsProfesor.FirstOrDefault(s => s.Id == id);
        }

        public List<SubjectProfesor> GetSubjectsProfesorByTeacherId(int id)
        {
            return _context.SubjectsProfesor.Include(s=>s.Subject).Include(s=>s.StudyYear).Where(s => s.UserId == id).ToList();

        }

        public SubjectProfesor Update(SubjectProfesor subjectProfesor)
        {
            var existingSubjectsProfesor = _context.SubjectsProfesor.FirstOrDefault(s => s.Id == subjectProfesor.Id);
            if (existingSubjectsProfesor == null)
            {
                return null;
            }
            else
            {
                existingSubjectsProfesor.UserId = subjectProfesor.UserId;
                existingSubjectsProfesor.SubjectId = subjectProfesor.SubjectId;
                existingSubjectsProfesor.StudyYearId = subjectProfesor.StudyYearId;
                _context.SubjectsProfesor.Update(existingSubjectsProfesor);
                _context.SaveChanges();
                return existingSubjectsProfesor;
            }

        }

        List<SubjectProfesor> ISubjectsProfesorRepository.GetAll()
        {
            return _context.SubjectsProfesor.ToList();
        }
    }
}
