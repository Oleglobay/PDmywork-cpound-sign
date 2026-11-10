
using System;
using System.Collections.Generic;
using System.Linq;
using LibrarySystem.Models;

namespace LibrarySystem.Services
{
    public class Library
    {
        private readonly List<Book> books = new List<Book>();
        private readonly List<Reader> readers = new List<Reader>();

        public void AddBook(Book book)
        {
            if (book == null || books.Any(b => b.Id == book.Id))
            {
                Console.WriteLine("Помилка: книга вже існує або некоректна!");
                return;
            }

            books.Add(book);
            Console.WriteLine($"Книгу '{book.Title}' додано.");
        }

        public void AddReader(Reader reader)
        {
            if (reader == null || readers.Any(r => r.Id == reader.Id))
            {
                Console.WriteLine("Помилка: користувач вже існує або некоректний!");
                return;
            }

            readers.Add(reader);
            Console.WriteLine($"Користувача '{reader.Name}' додано.");
        }

        public void BorrowBook(int bookId, int readerId)
        {
            Book book = books.Find(b => b.Id == bookId);
            Reader reader = readers.Find(r => r.Id == readerId);

            if (book == null)
            {
                Console.WriteLine("Помилка: книгу не знайдено!");
                return;
            }

            if (reader == null)
            {
                Console.WriteLine("Помилка: користувача не знайдено!");
                return;
            }

            if (!book.IsAvailable)
            {
                Console.WriteLine("Помилка: книга вже перебуває в оренді!");
                return;
            }

            book.Borrow();
            reader.AddBook(book);

            Console.WriteLine(
                $"Книгу '{book.Title}' видано користувачу {reader.Name}.");
        }

        public void ReturnBook(int bookId, int readerId)
        {
            Reader reader = readers.Find(r => r.Id == readerId);

            if (reader == null)
            {
                Console.WriteLine("Помилка: користувача не знайдено!");
                return;
            }

            Book book = reader.BorrowedBooks.FirstOrDefault(
                b => b.Id == bookId);

            if (book == null)
            {
                Console.WriteLine(
                    "Помилка: користувач не орендував цю книгу!");
                return;
            }

            reader.RemoveBook(book);
            book.Return();

            Console.WriteLine($"Книгу '{book.Title}' повернуто.");
        }

        public void ShowAllBooks()
        {
            Console.WriteLine("\n--- УСІ КНИГИ ---");

            foreach (Book book in books)
            {
                string status = book.IsAvailable ? "Доступна" : "В оренді";

                Console.WriteLine(
                    $"{book.Id}. {book.Title} - {book.Author} | {status}");
            }
        }

        public void ShowAvailableBooks()
        {
            Console.WriteLine("\n--- ДОСТУПНІ КНИГИ ---");

            var availableBooks = books.Where(b => b.IsAvailable);

            if (!availableBooks.Any())
            {
                Console.WriteLine("Доступних книг немає.");
                return;
            }

            foreach (Book book in availableBooks)
            {
                Console.WriteLine(
                    $"{book.Id}. {book.Title} - {book.Author}");
            }
        }

        public void ShowBorrowedBooks()
        {
            Console.WriteLine("\n--- КНИГИ В ОРЕНДІ ---");

            var borrowedBooks = books.Where(b => !b.IsAvailable);

            if (!borrowedBooks.Any())
            {
                Console.WriteLine("Книг в оренді немає.");
                return;
            }

            foreach (Book book in borrowedBooks)
            {
                Console.WriteLine(
                    $"{book.Id}. {book.Title} - {book.Author}");
            }
        }

        public void ShowReaders()
        {
            Console.WriteLine("\n--- КОРИСТУВАЧІ ---");

            foreach (Reader reader in readers)
            {
                Console.WriteLine(
                    $"\nID: {reader.Id}, Ім'я: {reader.Name}");

                if (reader.BorrowedBooks.Count == 0)
                {
                    Console.WriteLine("Орендованих книг немає.");
                }
                else
                {
                    Console.WriteLine("Орендовані книги:");

                    foreach (Book book in reader.BorrowedBooks)
                    {
                        Console.WriteLine($"- {book.Title}");
                    }
                }
            }
        }
    }
}
