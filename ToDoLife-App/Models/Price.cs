namespace ToDoLife_App.Models
{
    public class Price
    {
        public int Id { get; set; }
        public Guid User { get; set; }
        public Level Level { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPriceObtained { get; set; }
    }
}
