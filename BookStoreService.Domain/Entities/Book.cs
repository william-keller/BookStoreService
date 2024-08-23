namespace BookStoreService.Domain.Entities
{
    public class Book
    {
        public Book()
        {

        }

        public Book(string title, string author, decimal price)
        {
            Id = Guid.NewGuid();
            Title = title;
            Author = author;
            Price = price;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Sales { get; set; }
        public double Rating { get; set; }
        public bool IsFeatured { get; set; }
    }
}
