using ExamMongoDB.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using ExamMongoDB.ConfigMongoDB;
using Microsoft.AspNetCore.Mvc;

namespace ExamMongoDB.Models.Repositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly IDatabaseSettings _context;

        public ExamRepository(IDatabaseSettings context)
        {
            _context = context;

        }

        public void CreateExam(Exam exam, string idProgramme)
        {
            throw new NotImplementedException();
        }

        public bool DeteleExam(string idExam)
        {
            throw new NotImplementedException();
        }

      
        public IEnumerable<Exam> GetMyExams(string programme) // is not used
        {
            String idMongo = new String(programme);
            FilterDefinition<Exam> filter = Builders<Exam>.Filter.Eq(m => m.ProgrammeCode, idMongo);
            return _context
                          .Exams
                          .Find(_ => true)
                          .ToList();
        }

        public IEnumerable<Exam> GetMyExams()
        {
            return _context
                          .Exams
                          .Find(_ => true)
                          .ToList();
        }

        public Exam GetExamById(string id)
        {
            String idMongo = new String(id);
            FilterDefinition<Exam> filter = Builders<Exam>.Filter.Eq(m => m.ExamId, idMongo);
            return _context
                  .Exams
                  .Find(filter)
                  .FirstOrDefault();
        }


        [HttpGet]
        public void EnrollForExam(Student student, Exam exam)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Exam> GetExamsByProgrammeCode(string id)
        {
            String idMongo = new String(id);

            FilterDefinition<Exam> filter = Builders<Exam>.Filter.Eq(m => m.ProgrammeCode, idMongo);

            return _context
                   .Exams
                   .Find(filter)
                   .ToList();
        }

        public void UpdateExam(string idExam, Exam exam, string idProgramme)
        {
            throw new NotImplementedException();
        }

    }
}
