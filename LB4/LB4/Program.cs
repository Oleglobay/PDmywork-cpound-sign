
using System;
using LibrarySystem.Models;
using LibrarySystem.Services;

namespace LibrarySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            library.AddBook(new Book(1, "Кобзар", "Тарас Шевченко"));
            library.AddBook(new Book(2, "Лісова пісня", "Леся Українка"));
            library.AddBook(new Book(3, "Тигролови", "Іван Багряний"));
            library.AddBook(new Book(4, "Захар Беркут", "Іван Франко"));
            library.AddReader(new Reader(1, "Олег"));
            library.AddReader(new Reader(2, "Андрій"));
            library.AddReader(new Reader(3, "Марія"));
            Console.WriteLine("\n=== ПОЧАТОК РОБОТИ ===");
            library.ShowAvailableBooks();

            Console.WriteLine("\n=== ВИДАЧА КНИГИ ===");
            library.BorrowBook(1, 1);

            Console.WriteLine("\n=== ПОВТОРНА ВИДАЧА ===");
            library.BorrowBook(1, 2);

            library.ShowBorrowedBooks();

            Console.WriteLine("\n=== ПОВЕРНЕННЯ КНИГИ ===");
            library.ReturnBook(1, 1);

            Console.WriteLine("\n=== ПЕРЕВІРКА ДОСТУПНОСТІ ===");
            library.ShowAvailableBooks();

            library.ShowReaders();

            Console.WriteLine("\n=== ЗАВЕРШЕННЯ РОБОТИ ===");

            Console.ReadKey();
        }
    }
}

