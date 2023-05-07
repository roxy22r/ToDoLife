using System.ComponentModel.DataAnnotations;

namespace ToDoLife_App.Models
{
    public class UserProgrammConfig
    {
        public int Id { get; set; }

        [Required]
        public Guid User { get; set; }
        public bool FilterTodoListIsCompleted { get; set; }

        public bool FilterTodoListDueToday { get; set; }
    }
}
