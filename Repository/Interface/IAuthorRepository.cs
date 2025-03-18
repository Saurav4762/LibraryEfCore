using EfCoreDbContext.Contracts.ResponseDto;
using EfCoreDbContext.Entities;

namespace EfCoreDbContext.Repository.Interface;

public interface IAuthorRepository 
{
    Task<AuthorResponseDto> GetAuthorById(int id, AuthorResponseDto output);
    Task<List<AuthorResponseDto>> GetAuthors(int id);
    
    
}