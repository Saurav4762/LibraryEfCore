using EfCoreDbContext.Contracts.ResponseDto;

namespace EfCoreDbContext.Repository.Interface;

public interface IBookRepository
{
    Task<BookResponseDto> GetBookById(int id);
    Task<List<BookResponseDto>> GetBooksAsync();
    
} 