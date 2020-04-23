using System.ComponentModel.DataAnnotations;

namespace ExamMongoDB.Identity.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
