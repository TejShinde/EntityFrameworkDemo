using System .ComponentModel .DataAnnotations;
using System .ComponentModel .DataAnnotations .Schema;

namespace EntityFrameworkDemo .Models
    {
    [Table("UserLogins")]
    public class UserLogin
        {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType .Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType .Password)]
        [Compare("Password" , ErrorMessage = "Passwords do not match.")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        }
    }
