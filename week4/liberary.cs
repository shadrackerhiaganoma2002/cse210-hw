using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsAvailable { get; set; } = true;

        public string GetDetails()
        {
            return $"Title: {Title}, Author: {Author}, ISBN: {ISBN}, Available: {IsAvailable}";
        }

        public void Checkout()
        {
            IsAvailable = false;
        }

        public void Return()
        {
            IsAvailable = true;
        }
    }

    public class Member
    {
        public string MemberId { get; set; }
        public string Name { get; set; }
        public List<Book> BorrowedBooks { get; set; } = new List<Book>();

        public string GetMemberDetails()
        {
            return $"ID: {MemberId}, Name: {Name}";
        }

        public void BorrowBook(Book book)
        {
            if (book.IsAvailable)
            {
                BorrowedBooks.Add(book);
                book.Checkout();
                Console.WriteLine($"{Name} borrowed '{book.Title}'");
            }
            else
            {
                Console.WriteLine($"The book '{book.Title}' is not available.");
            }
        }

        public void ReturnBook(Book book)
        {
            if (BorrowedBooks.Contains(book))
            {
                BorrowedBooks.Remove(book);
                book.Return();
                Console.WriteLine($"{Name} returned '{book.Title}'");
            }
            else
            {
                Console.WriteLine($"{Name} does not have '{book.Title}' borrowed.");
            }
        }
    }

    public class Library
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Member> Members { get; set; } = new List<Member>();

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void RegisterMember(Member member)
        {
            Members.Add(member);
        }

        public Book FindBookByISBN(string isbn)
        {
            return Books.Find(b => b.ISBN == isbn);
        }

        public Member FindMemberById(string memberId)
        {
            return Members.Find(m => m.MemberId == memberId);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            library.AddBook(new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", ISBN = "9780743273565" });
            library.AddBook(new Book { Title = "1984", Author = "George Orwell", ISBN = "9780451524935" });

            Member alice = new Member { MemberId = "M001", Name = "Alice" };
            Member bob = new Member { MemberId = "M002", Name = "Bob" };
            library.RegisterMember(alice);
            library.RegisterMember(bob);

            Console.WriteLine("Books in Library:");
            foreach (var book in library.Books)
            {
                Console.WriteLine(book.GetDetails());
            }

            alice.BorrowBook(library.FindBookByISBN("9780743273565"));
            bob.BorrowBook(library.FindBookByISBN("9780451524935"));
            alice.ReturnBook(library.FindBookByISBN("9780743273565"));

            Console.WriteLine("\nMembers in Library:");
            foreach (var member in library.Members)
            {
                Console.WriteLine(member.GetMemberDetails());
            }
        }
    }
}
