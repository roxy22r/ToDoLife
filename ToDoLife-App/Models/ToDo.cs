using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ToDoLife_App.Models
{
    public class ToDo
    {
        public int ID { get; set; }
        [Display(Name = "ToDo-Titel")]

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string TodoTitle { get; set; } = string.Empty;

        [Display(Name = "Erledigen bis")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        [Display(Name = "Preise bei Erledigung")]
        public string? prices { get; set; }
    }
}
