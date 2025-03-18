using EFCore;
using EfCoreDbContext.Contracts.ResponseDto;
using EfCoreDbContext.Data;
using EfCoreDbContext.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EfCoreDbContext.Repository;

public class BookRepository : IBookRepository
{
    private readonly EfCoreDbcontext _context;

    public BookRepository(EfCoreDbcontext context)
    {
        _context = context;
    }

    public async Task<BookResponseDto> GetBookById(int id)
    {
        var books = await _context.Books
            .Where(b => b.Id == id)
            .Select(b => new BookResponseDto
            {
                Id = b.Id,
                BookId = b.Id,
                Title = b.Title,
                AuthorId = b.AuthorId,
                PublishDate = b.PublishDate,
            }).FirstOrDefaultAsync();

        if (books == null)
        {
            throw new Exception("Book not found");
        }

        return books;


    }

    public async Task<List<BookResponseDto>> GetBooksAsync()
    {
        var book =  await _context.Books
            .Select(b => new BookResponseDto
            {
                Id = b.Id,
                BookId = b.Id,
                Title = b.Title,
                AuthorId = b.AuthorId,
                PublishDate = b.PublishDate,

            }).ToListAsync();
        
        return book;
    }
}
