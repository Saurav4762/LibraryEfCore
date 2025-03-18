using EfCoreDbContext.Contracts.RequestDto;
using EfCoreDbContext.Contracts.ResponseDto;
using EfCoreDbContext.Repository.Interface;
using EfCoreDbContext.Services.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreDbContext.Controllers;

[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookRepository _bookRepository;
    private readonly IBookService _bookService;

    public BookController(IBookRepository bookRepository, IBookService bookService)
    {
        _bookRepository = bookRepository;
        _bookService = bookService;
    }

    //GET
    [HttpGet("api/book")]
    public async Task<IActionResult> GetBook()
    {
        try
        {
            var book = await _bookRepository.GetBooksAsync();
            if (book == null)
            {
                return NotFound("Book not found");
            }

            return Ok(book);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    //GET BY ID
    [HttpGet("api/book/{id}")]
    public async Task<IActionResult> GetBookById([FromRoute]int id)
    {
        try
        {
            var book = await _bookRepository.GetBookById(id);
            return Ok(book);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    
    //POST
    [HttpPost("api/book")]
    public async Task<IActionResult> CreateBook([FromBody] BookRequestDto dto)
    {
        try
        {
            var book = await _bookService.CreateBook(dto);

            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    //UPDATE
    [HttpPut("api/book/id")]
    public async Task<IActionResult> UpdateBook(int id, BookRequestDto dto)
    {
        try
        {
            var book = await _bookService.UpdateBook(id, dto);
            return Ok(book);

        }
        catch (Exception e)
        {
           return BadRequest(e.Message);
        }
    }
    
    //DELETE 
    [HttpDelete("api/book/id")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        try
        {
            await _bookService.DeleteBook(id);
            return Ok();

        }
        catch (Exception e)
        {
           return BadRequest(e.Message);
        }
    }

}