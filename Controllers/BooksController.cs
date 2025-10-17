using Microsoft.AspNetCore.Mvc;
using BookStoreAPI.Models;
using BookStoreAPI.Services;

namespace BookStoreAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_bookService.GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var book = _bookService.GetById(id);
        return book == null ? NotFound() : Ok(book);
    }

    [HttpGet("isbn/{isbn}")]
    public IActionResult GetByISBN(string isbn)
    {
        var book = _bookService.GetByISBN(isbn);
        return book == null ? NotFound() : Ok(book);
    }

    [HttpGet("genre/{genre}")]
    public IActionResult GetByGenre(string genre) => 
        Ok(_bookService.GetByGenre(genre));

    [HttpPost]
    public IActionResult Create([FromBody] Book book)
    {
        if (string.IsNullOrEmpty(book.Title) || string.IsNullOrEmpty(book.Author))
            return BadRequest("Title and Author are required");

        var created = _bookService.Create(book);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Book book)
    {
        var updated = _bookService.Update(id, book);
        return updated == null ? NotFound() : Ok(updated);
    }

    [HttpPatch("{id}/stock")]
    public IActionResult UpdateStock(int id, [FromBody] int stock)
    {
        var updated = _bookService.UpdateStock(id, stock);
        return updated == null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id) => 
        _bookService.Delete(id) ? NoContent() : NotFound();
}