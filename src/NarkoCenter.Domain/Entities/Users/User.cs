using System.ComponentModel.DataAnnotations;

namespace NarkoCenter.Domain.Entities.Users
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}