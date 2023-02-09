using System.ComponentModel.DataAnnotations;

namespace TodoItems.Models
{
    public class TodoItem
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public String Title { get; set; }
        [Required]
        public String Description { get; set; }
        public TodoStatus Status { get; set; } = TodoStatus.Todo;
    }

    // 此處定義 status 屬性的列舉值
    public enum TodoStatus
    {
        Done,
        InProgress,
        Todo
    }

}
