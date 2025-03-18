using EfCoreDbContext.Contracts.RequestDto;
using EfCoreDbContext.Data;
using EfCoreDbContext.Entities;
using EfCoreDbContext.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfCoreDbContext.Services;

[Route("api/[controller]")]
[ApiController]
public class BookService : IBookService
{
    private readonly EfCoreDbcontext _context;

    public BookService(EfCoreDbcontext context)
    {
        _context = context;
    }

    public async Task<Book> CreateBook(BookRequestDto dto)
    {
        bool bookExists = await _context.Books.AnyAsync(b=> b.Title == dto.Title);
        if (bookExists)
        {
            throw new Exception($"Book {dto.Title} already exists");
        }

        var book = new Book()
        {
            Title = dto.Title,
            AuthorId = dto.AuthorId,
            PublishDate = dto.PublishDate
        };
        
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
        
        return book;
    }

    public async Task<Book> UpdateBook(int id, BookRequestDto dto)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            throw new Exception($"Book {dto.Title} does not exist");
        }
        
        book.Title = dto.Title;
        book.PublishDate = dto.PublishDate;
        
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
        
        return book;
    }

    public async Task DeleteBook(int id)
    {
       var book = await  _context.Books.FindAsync(id);
        if (book == null)
        {
            throw new Exception($"Book {id} does not exist");
        }
        
        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
            
    }
}