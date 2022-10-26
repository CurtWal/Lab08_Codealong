using System.Collections;

namespace LendingLibrary.Classes{
    public interface ILibrary : IReadOnlyCollection<Book>
 {
     /// <summary>
     /// Add a Book to the library.
     /// </summary>
     void Add(string title, string firstName, string lastName, int numberOfPages);

     /// <summary>
     /// Remove a Book from the library with the given title.
     /// </summary>
     /// <returns>The Book, or null if not found.</returns>
     Book Borrow(string title);

     /// <summary>
     /// Return a Book to the library.
     /// </summary>
     void Return(Book book);
 }
 public class Library : ILibrary{
    private readonly Dictionary<string, Book> books = new Dictionary<string, Book>();

    public int Count  => books.Count; // this property is used to count the number of books in our library

    public void Add(string title, string firstName, string lastName, int numberOfPages){
        // book object is created
        Book book = new Book{
            Title = title,
            Author = new Author{
                FirstName = firstName,
                LastName = lastName,
            },
            NumOfPages = numberOfPages,

        };
        // book added to dictionary
        books.Add(title, book); // adding whatever book we create to our dictionary
        
    }

    //borrow a book
    public Book Borrow(string title){
        if(!books.ContainsKey(title)){
            return null; 
        }
        Book book = books[title]; //finding the book that matches title
        books.Remove(title); //remove the book from Library
        return book; //book that was borrowed
    }
    // return the book to Library
    public void Return(Book book){
        //read book to the library shelf
        books.Add(book.Title, book);
    }
    public IEnumerator<Book> GetEnumerator(){
    foreach( Book book in books.Values)
    yield return book;
 } 
    IEnumerator IEnumerable.GetEnumerator(){
        return GetEnumerator();
    }
 }
 
}