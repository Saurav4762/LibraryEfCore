using EfCoreDbContext.Contracts.RequestDto;
using EfCoreDbContext.Data;
using EfCoreDbContext.Entities;
using EfCoreDbContext.Repository.Interface;
using EfCoreDbContext.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace EfCoreDbContext.Services;

public class AuthorService : IAuthorService
{
    private readonly EfCoreDbcontext _context;

    public AuthorService(EfCoreDbcontext context)
    {
        _context = context;
    }


    public async Task<Author> CreateAuthor(AuthorRequestDto dto)
    {
        //Check Author Exist or not 
        bool authorExists= await _context.Authors.AnyAsync(c=>c.Name==dto.Name);
        if (authorExists)
        {
            throw new Exception($"Author {dto.Name} does not exist");
        }

        var author = new Author()
        {
            Name = dto.Name,
            Email = dto.Email
        };
        
        //Add Course to Database
        await _context.Authors.AddAsync(author);
        await _context.SaveChangesAsync();
        
        return author;
    }

    public async Task<Author> UpdateAuthor(int id, AuthorRequestDto authorRequestDto)
    {
        var author = await _context.Authors.FindAsync(id);
        if (author == null)
        {
            throw new Exception($"Author {authorRequestDto.Name} does not exist");
        }
        
        author.Name = authorRequestDto.Name;
        author.Email = authorRequestDto.Email;
        
        _context.Authors.Update(author);
        await _context.SaveChangesAsync();
        
        return author;
    }

    public async Task DeleteAuthor(int id)
    {
        var author = await _context.Authors.FindAsync(id);

        if (author == null)
        {
            throw new Exception($"Author {id} does not exist");
        }
        _context.Authors.Remove(author);
        await _context.SaveChangesAsync();
    }
}