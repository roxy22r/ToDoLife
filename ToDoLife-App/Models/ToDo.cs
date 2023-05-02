using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ToDoLife_App.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        [Display(Name = "ToDo-Titel")]

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Erledigen bis")]
        [DataType(DataType.Date)]
        public bool IsCompleted { get; set; }

        public DateTime DueDate { get; set; }
        [Display(Name = "Preise bei Erledigung")]
        public int? Points { get; set; }
    }
}
