namespace GraphQLBookstore.Models
{
    public class Book
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public long AuthorId { get; set; }
        public Author Author { get; set; }
    }
}