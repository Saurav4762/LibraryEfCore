using EfCoreDbContext.Contracts.RequestDto;
using EfCoreDbContext.Entities;

namespace EfCoreDbContext.Services.Interface;

public interface IAuthorService
{
    Task<Author> CreateAuthor(AuthorRequestDto dto);
    Task<Author> UpdateAuthor (int id, AuthorRequestDto dto);
    Task DeleteAuthor (int id);
    
}