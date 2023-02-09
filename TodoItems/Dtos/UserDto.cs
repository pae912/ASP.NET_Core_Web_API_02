using System.ComponentModel.DataAnnotations;

namespace TodoItems.Dtos
{
    public class CreateUserDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public String Firstname { get; set; }
        [Required]
        public String Lastname { get; set; }
        [Required]
        public String Email { get; set; }
    }
}
