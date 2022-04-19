using System.Collections.Generic;
using SINU.Model;

namespace SINU.Repository
{
    public interface IStudyYearsRepository
    {
        StudyYear GetStudyYearById(int id);
        List<StudyYear> GetAll();
        StudyYear Create(StudyYear studyYear);
        int GetCurrentYearId();
    }
}

