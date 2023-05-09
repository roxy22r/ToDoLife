using System.ComponentModel.DataAnnotations;

namespace ToDoLife_App.Models
{
    public class ToDo
    {
        public int Id { get; set; }

        public Guid createdByUser { get; set; }
        [Display(Name = "ToDo-Titel")]

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Erledigt")]
        public bool IsCompleted { get; set; }

        [Display(Name = "Erledigen bis")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
            
        [Display(Name = "Preise bei Erledigung")]
        [Range(1, 20)]
        public int? Points { get; set; }
    }
}
