using BookStoreAPI.Models;

namespace BookStoreAPI.Services;

public class BookService : IBookService
{
    private readonly List<Book> _books = new();
    private int _nextId = 1;

    public BookService()
    {
        _books.Add(new Book { 
            Id = _nextId++, 
            Title = "Cien años de soledad", 
            Author = "Gabriel García Márquez", 
            ISBN = "978-8437604947", 
            Price = 18.50m, 
            Stock = 15,
            PublishedDate = new DateTime(1967, 5, 30),
            Genre = "Ficción"
        });
        
        _books.Add(new Book { 
            Id = _nextId++, 
            Title = "El principito", 
            Author = "Antoine de Saint-Exupéry", 
            ISBN = "978-0156012195", 
            Price = 12.00m, 
            Stock = 8,
            PublishedDate = new DateTime(1943, 4, 6),
            Genre = "Infantil"
        });
    }

    public List<Book> GetAll() => _books;
    
    public Book? GetById(int id) => _books.FirstOrDefault(b => b.Id == id);
    
    public Book? GetByISBN(string isbn) => _books.FirstOrDefault(b => b.ISBN == isbn);
    
    public List<Book> GetByGenre(string genre) => _books.Where(b => 
        b.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)).ToList();

    public Book Create(Book book)
    {
        book.Id = _nextId++;
        _books.Add(book);
        return book;
    }

    public Book? Update(int id, Book book)
    {
        var existing = GetById(id);
        if (existing == null) return null;

        existing.Title = book.Title;
        existing.Author = book.Author;
        existing.ISBN = book.ISBN;
        existing.Price = book.Price;
        existing.Stock = book.Stock;
        existing.PublishedDate = book.PublishedDate;
        existing.Genre = book.Genre;
        
        return existing;
    }

    public bool Delete(int id)
    {
        var book = GetById(id);
        return book != null && _books.Remove(book);
    }

    public Book? UpdateStock(int id, int newStock)
    {
        var book = GetById(id);
        if (book == null) return null;
        
        book.Stock = newStock;
        return book;
    }
}