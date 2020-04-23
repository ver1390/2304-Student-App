using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamMongoDB.Models
{
    public class Exam 
    {

        [BsonElement("_id")]
        [Display(Name = "Subject Code - ExamId")]
        public string ExamId { get; set; }


        [BsonElement("subjectName")]
        [Display(Name = "Subject Name")]
        public string SubjectName { get; set; }

        [BsonElement("date")]
        [Display(Name = "Exam Date")]
        public Int32 ExamDate { get; set; }


        [BsonElement("programme")]
        public string ProgrammeCode { get; set; } 

      
    }
}
