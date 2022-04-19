using System.Collections.Generic;
using SINU.Model;

namespace SINU.Repository
{
    public interface ISubjectsProfesorRepository
    {
        public SubjectProfesor GetSubjectProfesorById(int id);
        public List<SubjectProfesor> GetSubjectsProfesorByTeacherId(int id);
        public SubjectProfesor Update(SubjectProfesor subjectProfesor);
        public List<SubjectProfesor> GetAll();
    }
}
