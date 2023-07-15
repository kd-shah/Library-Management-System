using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Book
    {
        public string Title { get; set; }

        public Author Author { get; set; }
        public int PublicationYear { get; set; }
        public bool IsAvailable { get; set; }
    }

    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class Borrower
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class BorrowedBook
    {
        public Book Book { get; set; }
        public Borrower Borrower { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
    }

    public class LibraryManagementSystem
    {
        private List<Book> books;
        private List<Author> authors;
        private List<Borrower> borrowers;
        private List<BorrowedBook> borrowedBooks;

        public LibraryManagementSystem()
        {
            books = new List<Book>();
            authors = new List<Author>();
            borrowers = new List<Borrower>();
            borrowedBooks = new List<BorrowedBook>();
        }

        public void AddBook(string title, Author author, int publicationYear)
        {
            Book newBook = new Book
            {
                Title = title,
                Author = author,
                PublicationYear = publicationYear,
                IsAvailable = true
            };

            books.Add(newBook);
            Console.WriteLine("Book added successfully.");
        }

        public void UpdateBook(string currentTitle, string newTitle, Author newAuthor, int newPublicationYear)
        {
            Book bookToUpdate = books.FirstOrDefault(b => b.Title == currentTitle);
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = newTitle;
                bookToUpdate.Author = newAuthor;
                bookToUpdate.PublicationYear = newPublicationYear;
                Console.WriteLine("Book updated successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        public void DeleteBook(string title)
        {
            Book bookToDelete = books.FirstOrDefault(b => b.Title == title);
            if (bookToDelete != null)
            {
                books.Remove(bookToDelete);
                Console.WriteLine("Book deleted successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        public void AddAuthor(string firstName, string lastName, DateTime dateOfBirth)
        {
            Author newAuthor = new Author
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth
            };

            authors.Add(newAuthor);
            Console.WriteLine("Author added successfully.");
        }

        public void UpdateAuthor(string currentLastName, string newFirstName, string newLastName, DateTime newDateOfBirth)
        {
            Author authorToUpdate = authors.FirstOrDefault(a => a.LastName == currentLastName);
            if (authorToUpdate != null)
            {
                authorToUpdate.FirstName = newFirstName;
                authorToUpdate.LastName = newLastName;
                authorToUpdate.DateOfBirth = newDateOfBirth;
                Console.WriteLine("Author updated successfully.");
            }
            else
            {
                Console.WriteLine("Author not found.");
            }
        }

        public void DeleteAuthor(string lastName)
        {
            Author authorToDelete = authors.FirstOrDefault(a => a.LastName == lastName);
            if (authorToDelete != null)
            {
                authors.Remove(authorToDelete);
                Console.WriteLine("Author deleted successfully.");
            }
            else
            {
                Console.WriteLine("Author not found.");
            }
        }

        public void AddBorrower(string firstName, string lastName, string email, string phoneNumber)
        {
            Borrower newBorrower = new Borrower
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber
            };

            borrowers.Add(newBorrower);
            Console.WriteLine("Borrower added successfully.");
        }

        public void UpdateBorrower(string currentLastName, string newFirstName, string newLastName, string newEmail, string newPhoneNumber)
        {
            Borrower borrowerToUpdate = borrowers.FirstOrDefault(b => b.LastName == currentLastName);
            if (borrowerToUpdate != null)
            {
                borrowerToUpdate.FirstName = newFirstName;
                borrowerToUpdate.LastName = newLastName;
                borrowerToUpdate.Email = newEmail;
                borrowerToUpdate.PhoneNumber = newPhoneNumber;
                Console.WriteLine("Borrower updated successfully.");
            }
            else
            {
                Console.WriteLine("Borrower not found.");
            }
        }

        public void DeleteBorrower(string lastName)
        {
            Borrower borrowerToDelete = borrowers.FirstOrDefault(b => b.LastName == lastName);
            if (borrowerToDelete != null)
            {
                borrowers.Remove(borrowerToDelete);
                Console.WriteLine("Borrower deleted successfully.");
            }
            else
            {
                Console.WriteLine("Borrower not found.");
            }
        }

        public void RegisterBookToBorrower(string bookTitle, string borrowerLastName, DateTime dueDate)
        {
            Book book = books.FirstOrDefault(b => b.Title == bookTitle);
            Borrower borrower = borrowers.FirstOrDefault(b => b.LastName == borrowerLastName);

            if (book != null && borrower != null)
            {
                if (book.IsAvailable)
                {
                    BorrowedBook borrowedBook = new BorrowedBook
                    {
                        Book = book,
                        Borrower = borrower,
                        BorrowDate = DateTime.Now,
                        DueDate = dueDate
                    };

                    borrowedBooks.Add(borrowedBook);
                    book.IsAvailable = false;
                    Console.WriteLine("Book registered to borrower successfully.");
                }
                else
                {
                    Console.WriteLine("Book is already borrowed.");
                }
            }
            else
            {
                Console.WriteLine("Book or borrower not found.");
            }
        }

        public void DisplayAllBooks()
        {
            Console.WriteLine("Books:");
            foreach (Book book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author.FirstName} {book.Author.LastName}, " +
                    $"Publication Year: {book.PublicationYear}, Status: {(book.IsAvailable ? "Available" : "Borrowed")}");
            }
        }

        public void DisplayAllAuthors()
        {
            Console.WriteLine("Authors:");
            foreach (Author author in authors)
            {
                Console.WriteLine($"Author: {author.FirstName} {author.LastName}, Date of Birth: {author.DateOfBirth}");
            }
        }

        public void DisplayAllBorrowers()
        {
            Console.WriteLine("Borrowers:");
            foreach (Borrower borrower in borrowers)
            {
                Console.WriteLine($"Borrower: {borrower.FirstName} {borrower.LastName}, Email: {borrower.Email}, " +
                    $"Phone Number: {borrower.PhoneNumber}");
            }
        }

        public void SearchBooks(string keyword)
        {
            var results = books.Where(b => b.Title.Contains(keyword) || b.Author.FirstName.Contains(keyword) || b.Author.LastName.Contains(keyword)).ToList();
            if (results.Any())
            {
                Console.WriteLine("Search Results:");
                foreach (Book book in results)
                {
                    Console.WriteLine($"Title: {book.Title}, Author: {book.Author.FirstName} {book.Author.LastName}, " +
                        $"Publication Year: {book.PublicationYear}, Status: {(book.IsAvailable ? "Available" : "Borrowed")}");
                }
            }
            else
            {
                Console.WriteLine("No results found.");
            }
        }

        public void FilterBooksByStatus(bool isAvailable)
        {
            var results = books.Where(b => b.IsAvailable == isAvailable).ToList();
            if (results.Any())
            {
                Console.WriteLine("Filtered Books:");
                foreach (Book book in results)
                {
                    Console.WriteLine($"Title: {book.Title}, Author: {book.Author.FirstName} {book.Author.LastName}, " +
                        $"Publication Year: {book.PublicationYear}, Status: {(book.IsAvailable ? "Available" : "Borrowed")}");
                }
            }
            else
            {
                Console.WriteLine("No books found with the specified status.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LibraryManagementSystem librarySystem = new LibraryManagementSystem();

            Console.WriteLine("Welcome to the Library Management System!");

            while (true)
            {
                Console.WriteLine("\nPlease select an option:");
                Console.WriteLine("1. Add a book");
                Console.WriteLine("2. Update a book");
                Console.WriteLine("3. Delete a book");
                Console.WriteLine("4. Add an author");
                Console.WriteLine("5. Update an author");
                Console.WriteLine("6. Delete an author");
                Console.WriteLine("7. Add a borrower");
                Console.WriteLine("8. Update a borrower");
                Console.WriteLine("9. Delete a borrower");
                Console.WriteLine("10. Register a book to a borrower");
                Console.WriteLine("11. Display all books");
                Console.WriteLine("12. Display all authors");
                Console.WriteLine("13. Display all borrowers");
                Console.WriteLine("14. Search for books");
                Console.WriteLine("15. Filter books by status");
                Console.WriteLine("16. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter book title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter author first name: ");
                        string authorFirstName = Console.ReadLine();
                        Console.Write("Enter author last name: ");
                        string authorLastName = Console.ReadLine();
                        Console.Write("Enter publication year: ");
                        int publicationYear = int.Parse(Console.ReadLine());

                        Author author = new Author
                        {
                            FirstName = authorFirstName,
                            LastName = authorLastName
                        };

                        librarySystem.AddBook(title, author, publicationYear);
                        break;

                    case 2:
                        Console.Write("Enter the current book title: ");
                        string currentTitle = Console.ReadLine();
                        Console.Write("Enter the new book title: ");
                        string newTitle = Console.ReadLine();
                        Console.Write("Enter the new author first name: ");
                        string newAuthorFirstName = Console.ReadLine();
                        Console.Write("Enter the new author last name: ");
                        string newAuthorLastName = Console.ReadLine();
                        Console.Write("Enter the new publication year: ");
                        int newPublicationYear = int.Parse(Console.ReadLine());

                        Author newAuthor = new Author
                        {
                            FirstName = newAuthorFirstName,
                            LastName = newAuthorLastName
                        };

                        librarySystem.UpdateBook(currentTitle, newTitle, newAuthor, newPublicationYear);
                        break;

                    case 3:
                        Console.Write("Enter the book title to delete: ");
                        string titleToDelete = Console.ReadLine();
                        librarySystem.DeleteBook(titleToDelete);
                        break;

                    case 4:
                        Console.Write("Enter author first name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Enter author last name: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Enter date of birth (yyyy-mm-dd): ");
                        DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

                        librarySystem.AddAuthor(firstName, lastName, dateOfBirth);
                        break;

                    case 5:
                        Console.Write("Enter the current author last name: ");
                        string currentLastName = Console.ReadLine();
                        Console.Write("Enter the new author first name: ");
                        string newFirstName = Console.ReadLine();
                        Console.Write("Enter the new author last name: ");
                        string newLastName = Console.ReadLine();
                        Console.Write("Enter the new date of birth (yyyy-mm-dd): ");
                        DateTime newDateOfBirth = DateTime.Parse(Console.ReadLine());

                        librarySystem.UpdateAuthor(currentLastName, newFirstName, newLastName, newDateOfBirth);
                        break;

                    case 6:
                        Console.Write("Enter the author last name to delete: ");
                        string lastNameToDelete = Console.ReadLine();
                        librarySystem.DeleteAuthor(lastNameToDelete);
                        break;

                    case 7:
                        Console.Write("Enter borrower first name: ");
                        string borrowerFirstName = Console.ReadLine();
                        Console.Write("Enter borrower last name: ");
                        string borrowerLastName = Console.ReadLine();
                        Console.Write("Enter borrower email: ");
                        string email = Console.ReadLine();
                        Console.Write("Enter borrower phone number: ");
                        string phoneNumber = Console.ReadLine();

                        librarySystem.AddBorrower(borrowerFirstName, borrowerLastName, email, phoneNumber);
                        break;

                    case 8:
                        Console.Write("Enter the current borrower last name: ");
                        string currentBorrowerLastName = Console.ReadLine();
                        Console.Write("Enter the new borrower first name: ");
                        string newBorrowerFirstName = Console.ReadLine();
                        Console.Write("Enter the new borrower last name: ");
                        string newBorrowerLastName = Console.ReadLine();
                        Console.Write("Enter the new borrower email: ");
                        string newEmail = Console.ReadLine();
                        Console.Write("Enter the new borrower phone number: ");
                        string newPhoneNumber = Console.ReadLine();

                        librarySystem.UpdateBorrower(currentBorrowerLastName, newBorrowerFirstName, newBorrowerLastName, newEmail, newPhoneNumber);
                        break;

                    case 9:
                        Console.Write("Enter the borrower last name to delete: ");
                        string borrowerLastNameToDelete = Console.ReadLine();
                        librarySystem.DeleteBorrower(borrowerLastNameToDelete);
                        break;

                    case 10:
                        Console.Write("Enter the book title: ");
                        string bookTitle = Console.ReadLine();
                        Console.Write("Enter the borrower last name: ");
                        string borrowLastName = Console.ReadLine();
                        Console.Write("Enter the due date (yyyy-mm-dd): ");
                        DateTime dueDate = DateTime.Parse(Console.ReadLine());

                        librarySystem.RegisterBookToBorrower(bookTitle, borrowLastName, dueDate);
                        break;

                    case 11:
                        librarySystem.DisplayAllBooks();
                        break;

                    case 12:
                        librarySystem.DisplayAllAuthors();
                        break;

                    case 13:
                        librarySystem.DisplayAllBorrowers();
                        break;

                    case 14:
                        Console.Write("Enter a keyword to search for: ");
                        string keyword = Console.ReadLine();
                        librarySystem.SearchBooks(keyword);
                        break;

                    case 15:
                        Console.Write("Enter the book status to filter (1 - Available, 0 - Borrowed): ");
                        bool isAvailable = Console.ReadLine() == "1";
                        librarySystem.FilterBooksByStatus(isAvailable);
                        break;

                    case 16:
                        Console.WriteLine("Thank you for using the Library Management System. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }

}