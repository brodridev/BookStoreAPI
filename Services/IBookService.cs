using BookStoreAPI.Models;

namespace BookStoreAPI.Services;

public interface IBookService
{
    List<Book> GetAll();
    Book? GetById(int id);
    Book? GetByISBN(string isbn);
    List<Book> GetByGenre(string genre);
    Book Create(Book book);
    Book? Update(int id, Book book);
    bool Delete(int id);
    Book? UpdateStock(int id, int newStock);
}