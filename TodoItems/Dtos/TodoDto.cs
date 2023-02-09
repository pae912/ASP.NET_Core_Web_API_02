using System.ComponentModel.DataAnnotations;
using TodoItems.Models;

namespace TodoItems.Dtos
{
    public class CreateTodoDTO
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public String Title { get; set; }
        [Required]
        public String Description { get; set; }
    }
    public class UpdateTodoDTO
    {
        [Required]
        public String Title { get; set; }
        [Required]
        public String Description { get; set; }
        public TodoStatus Status { get; set; }
    }

}
