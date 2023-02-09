using System.ComponentModel.DataAnnotations;

namespace TodoItems.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public String Firstname { get; set; }
        [Required]
        public String Lastname { get; set; }
        [Required]
        public String Email { get; set; }
    }

}
