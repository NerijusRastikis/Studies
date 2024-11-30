namespace P001.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Pavadinimas { get; set; }
        public List<Author> Autorius { get; set; } = new List<Author>();
        public int LeidybosMetai { get; set; }
    }
}
