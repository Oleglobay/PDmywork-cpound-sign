using System.Collections.Generic;

namespace LibrarySystem.Models
{
    public class Reader
    {
        public int Id { get; }
        public string Name { get; }

        private List<Book> borrowedBooks = new List<Book>();

        public IReadOnlyList<Book> BorrowedBooks => borrowedBooks;

        public Reader(int id, string name)
        {
            Id = id;
            Name = name;
        }

        // Додавання книги до списку користувача
        internal void AddBook(Book book)
        {
            borrowedBooks.Add(book);
        }

        // Видалення книги зі списку користувача
        internal void RemoveBook(Book book)
        {
            borrowedBooks.Remove(book);
        }
    }
}
