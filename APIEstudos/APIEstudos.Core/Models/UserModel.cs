using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIEstudos.Core.Models
{
    [Table("UserModel")]
    public class UserModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "The length of the field must be 100 characters long.")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(30, ErrorMessage = "The length of the field must be 100 characters long.")]
        public string Email { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
