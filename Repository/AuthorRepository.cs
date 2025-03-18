using EfCoreDbContext.Contracts.ResponseDto;
using EfCoreDbContext.Data;
using EfCoreDbContext.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EfCoreDbContext.Repository;

public class AuthorRepository : IAuthorRepository
{
    private readonly EfCoreDbcontext _db;

    public AuthorRepository(EfCoreDbcontext db)
    {
        _db = db;
    }

    public async Task<AuthorResponseDto> GetAuthorById(int id, AuthorResponseDto output)
    {
        var authors = await _db.Authors
            .Where(a => a.Id == id)
            .Select(a => new AuthorResponseDto
            {
                AuthorId = a.Id,
                AuthorName = a.Name,
                AuthorEmail = a.Email,

            }).FirstOrDefaultAsync();

        if (authors == null)
        {
            throw new Exception($"Author with id: {id} not found");
        }
        return authors;
    }

    public Task<List<AuthorResponseDto>> GetAuthors(int id)
    {
        var author = _db.Authors
            .Select(a => new AuthorResponseDto
            {
                AuthorName = a.Name,
                AuthorEmail = a.Email,
            }).ToListAsync();
        
        return author;
    }
}