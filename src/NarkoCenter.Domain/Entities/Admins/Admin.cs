using NarkoCenter.Domain.Enums.Roles;
using System.ComponentModel.DataAnnotations;

namespace NarkoCenter.Domain.Entities.Admins
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Role Role { get; set; }
    }
}