using System.ComponentModel.DataAnnotations;

namespace ToDoLife_App.Models
{
    public class Level
    {
        public int Id { get; set; }

        public Guid User { get; set; }
        [Display(Name = "Level-Titel")]
        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string LevelTitle { get; set; } = string.Empty;
        [Required]
        public int LevelNumber { get; set; }
        [Required]
        public string? LevelDescription { get; set; }
        [Display(Name = "Level-Points to reach")]
        public int Points { get; set; }
        //[Required]
        public Price? Price { get;  set; }
    }
}
