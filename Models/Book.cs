namespace Models
{
    public class Book : AbstractItem
    {
        public Book(string genre) => Genre = genre;
        public string Genre { get; set; }
    }
}
