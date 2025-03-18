using EfCoreDbContext.Contracts.RequestDto;
using EfCoreDbContext.Contracts.ResponseDto;
using EfCoreDbContext.Entities;

namespace EfCoreDbContext.Services.Interface;

public interface IBookService
{
    Task<Book> CreateBook (BookRequestDto dto);
    Task<Book> UpdateBook(int id, BookRequestDto dto);
    
    Task DeleteBook(int id);
}