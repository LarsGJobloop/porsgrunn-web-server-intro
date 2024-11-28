class Library
{
  // Data
  List<Book> registeredBooks;
  Dictionary<Book, int> bookInventory;
  Dictionary<Book, int> borrowedBooks;

  // Constructor
  public Library()
  {
    registeredBooks = new List<Book>();
    bookInventory = new Dictionary<Book, int>();
    borrowedBooks = new Dictionary<Book, int>();

    Book book1 = new Book("Foundation");
    registeredBooks.Add(book1); // Legg til i bøker vi vet om
    bookInventory.Add(book1, 10); // Legg til i beholdning vår
    borrowedBooks.Add(book1, 0); // Registre bok for utlån

    Book book2 = new Book("Martian");
    registeredBooks.Add(book2);
    bookInventory.Add(book2, 20);
    borrowedBooks.Add(book2, 0);
  }

  // Metoder
  public List<Book> ListAvailableBooks()
  {
    return registeredBooks;
  }

  public Book? BorrowBook(string title)
  {
    // Finne ut om vi har boken registrert
    Book? book = registeredBooks.Find((book) => { return book.Title == title; });
    // Hvis vi ikke har boken stopp og return null
    if (book == null)
    {
      return null;
    }

    // Finne ut om vi har flere eksemplare tilgjengelig
    bookInventory.TryGetValue(book, out int totalBooks);
    borrowedBooks.TryGetValue(book, out int borrowedCount);

    if (totalBooks > borrowedCount)
    {
      // Vi har eksemplarer tilgjengelig
      borrowedBooks[book] += 1; // Legg til en utlånt bok
      return book;
    }
    else
    {
      // Vi har ingen eksemplarer inne
      return null;
    }
  }
}