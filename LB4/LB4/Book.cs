namespace LibrarySystem.Models
{
    public class Book
    {
        public int Id { get; }
        public string Title { get; }
        public string Author { get; }

        public bool IsAvailable { get; private set; }

        public Book(int id, string title, string author)
        {
            Id = id;
            Title = title;
            Author = author;
            IsAvailable = true;
        }

        internal void Borrow()
        {
            IsAvailable = false;
        }

        internal void Return()
        {
            IsAvailable = true;
        }
    }
}
