using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ExamMongoDB.Identity.ManageViewModels
{
    public class IndexViewModel
    {
        public string Username { get; set; }

    //    [BsonElement("fname")]
        public string Fname { get; set; }

      //  [BsonElement("lname")]
        public string Lname { get; set; }


        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
    }
}
