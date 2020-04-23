using System.ComponentModel.DataAnnotations;

namespace ExamMongoDB.Identity.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
