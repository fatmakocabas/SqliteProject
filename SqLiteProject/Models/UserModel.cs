using System.ComponentModel.DataAnnotations;

namespace SqLiteProject.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
