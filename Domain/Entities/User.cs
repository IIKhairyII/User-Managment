using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        [Required, MaxLength(150)]
        public string UserName { get; set; }
        [Required, EmailAddress,MaxLength(150)]
        public string Email { get; set; }
        [Required, MaxLength(150)]
        public string FirstName { get; set; }
        [Required, MaxLength(150)]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        public string? Phone { get; set; }
        public string? ImgPath { get; set; }
    }
}
