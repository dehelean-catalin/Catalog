using System.Collections.Generic;
using SINU.Model;

namespace SINU.Repository
{
    public interface IGradesRepository
    {
        public GradeInfo GetGradeById(int id);
        public List<GradeInfo> GetAll();
        public GradeInfo Create(GradeInfo gradeInfo);
        public List<GradeInfo> GetGradesByProfessorId(int id);
        public List<GradeInfo> GetGradesByStudentId(int id);
        public List<GradeInfo> GetGradesPerSubjectByStudentId(int studentId, int subjectId);
        public GradeInfo Update(GradeInfo gradeInfo);
        public string Delete(GradeInfo gradeInfo);

    }
}

