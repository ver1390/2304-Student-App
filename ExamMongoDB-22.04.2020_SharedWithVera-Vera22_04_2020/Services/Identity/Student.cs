using AspNetCore.Identity.Mongo.Model;
using ExamMongoDB.Models;
using ExamMongoDB.ViewModels;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamMongoDB.Identity
{
    public class Student : MongoUser
    {
     
            public Student()
            {
                //ExamEnrollments = new ExamEnrollment(); //// this code create ExamEnrollment  {} includes all attributes from ExamEnrollment class 
                Programmes = new Programme();
            ExamEnrollment = new List<ExamEnrollmentViewModel>();
            //Enrollment = new List<EnrollmentViewModel>();
        }

            //[BsonElement("programme")]
            //[Required]
            public Programme Programmes { get; set; }


            [BsonElement("ExamEnrollment")]
            //[Required]
            // public List<ExamEnrollment> ExamEnrollment { get; set; } = new List<ExamEnrollment>(); // this code create emptry ExamEnrollment []
            public List<ExamEnrollmentViewModel> ExamEnrollment { get; set; } // this code create emptry ExamEnrollment []

        //  public List<EnrollmentViewModel> Enrollment { get; set; } 

        //[BsonElement("fname")]
        [Display(Name = "First Name")]
        public string Fname { get; set; }

        //[BsonElement("lname")]
        [Display(Name = "Last Name")]
        public string Lname { get; set; }

            //public ExamEnrollment ExamEnrollments { get; set; } // this code create ExamEnrollment  {} includes all attributes from ExamEnrollment class 


     
    }
}
