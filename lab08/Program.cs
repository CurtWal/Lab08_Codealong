// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Collections;
using LendingLibrary.Classes;

namespace LendingLibrary.Interface
{
    class Program{
        //instantiate a new Library and a new Backpack

        private static readonly Library library = new Library();
        private static readonly BackPack<Book> bookBag = new BackPack<Book>();

        static void Main(string[] args){
            //create our book dictionary
            LoadBooks();
            // runs our program
            UserInterface();
        }
        static void UserInterface(){
            while(true){
                // all options here
                Console.WriteLine("Welcome to the lending Library");
                Console.WriteLine("Pick an option");
                Console.WriteLine("1. View All Books");
                Console.WriteLine("2. Add New Book");
                Console.WriteLine("3. Borrow a Book");
                Console.WriteLine("4. Return a Book");
                Console.WriteLine("5. View Book Bag");
                Console.WriteLine("6. Exit");
                
                string answer = Console.ReadLine();

                //switch case
                switch (answer){
                    case "1":
                    Console.Clear();
                    Console.WriteLine("Library");
                    Console.WriteLine("=============");
                    OutputBooks(library);
                    break;

                    case "2":
                    Console.Clear();
                    AddBook();
                    Console.Clear();
                    break;

                    case "3":
                    Console.Clear();
                    BorrowBook();
                    Console.Clear();
                    break;

                    case "4":
                    Console.Clear();
                    ReturnBook();
                    Console.Clear();
                    break;

                    case "5":
                    Console.Clear();
                    Console.WriteLine("=============");
                    OutputBooks(bookBag);
                    break;

                    case "6":
                    return;

                    default:
                    Console.WriteLine("Invalid Option....");
                    break;
                }
            }
           
            
        } 
        // Create a predefined set of books

        static void LoadBooks(){
                library.Add("Alice In Wonderkand", "Lewis", "Carol", 146);
                library.Add("The Greate Gatsby", "F.Scott", "XXXX", 218);
                library.Add("Alice", "Tim", "Boom", 26);
                library.Add("In Wonderland", "Sam", "Cook", 226);

            }
            static void OutputBooks(IEnumerable<Book> books){
                int counter = 1;
                foreach (Book book in books){
                    Console.WriteLine($"{counter++}. {book.Title}, {book.Author.FirstName}");
                }
                Console.WriteLine();
            }
            //  add a way for the user to add a book to the library
            private static void AddBook(){
                Console.WriteLine("Please input the following details: ");
                Console.WriteLine("Book Title: ");
                // ask for the book title
                string title = Console.ReadLine();

                Console.WriteLine("Author First Name: ");
                // ask for the firstname
                string first = Console.ReadLine();

                Console.WriteLine("Author Last Name: ");
                //ask for the lastname
                string last = Console.ReadLine();

                Console.WriteLine("Number of Pages: ");
                int numberOfPages = Convert.ToInt32(Console.ReadLine());            
                
                library.Add(title, first, last, numberOfPages);
                } 
            private static void BorrowBook(){
                // go through all books available
                foreach (Book book in library){
                    Console.WriteLine(book.Title);
                }
                // ask which book to borrow
                Console.WriteLine();
                Console.WriteLine("Which Book would you like to borrow?");
                // assign the borrowed book to a variable
                string selection = Console.ReadLine();
                Book borrowed = library.Borrow(selection);
                //pack it in our bookbag
                bookBag.Pack(borrowed);
            }
            static void ReturnBook(){
                OutputBooks(bookBag);
                Console.WriteLine("Which book would you like to return?");
                int selection = Convert.ToInt32(Console.ReadLine());
                Book bookToReturn = bookBag.Unpack(selection - 1);
                Console.WriteLine("========");
                Console.WriteLine(bookToReturn);
                Console.WriteLine("Book returned to library");
                library.Return(bookToReturn);
            }
    }
}