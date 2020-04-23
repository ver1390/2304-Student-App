using ExamMongoDB.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamMongoDB.Models.Repositories
{
    public interface IExamRepository
    {
        IEnumerable<Exam> GetMyExams();
        IEnumerable<Exam> GetMyExams(string programme);       
        Exam GetExamById(string id);
        void EnrollForExam(Student student, Exam exam);

        IEnumerable<Exam> GetExamsByProgrammeCode(string id);

        void CreateExam(Exam exam, string idProgramme);

        void UpdateExam(string idExam, Exam exam, string idProgramme);


        bool DeteleExam(string idExam);

    }
}
