using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using ExamMongoDB.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Bson.Serialization.Attributes;

namespace ExamMongoDB.ViewModels
{
    public class ExamViewModel
    {
        public IEnumerable<Exam> Exams { get; set; }
        // public IEnumerable<Programme> Programmes { get; set; }
        //public SelectList ProgrammesList { get; set; }

        //public List<Programme> Programmes { get; set; }

        //public SelectList ProgrammesList { get; set; }

        [BsonElement("_id")]
        [DisplayName("Programme Code")]
        public string ProgrammeCode { get; set; }

    }
}
