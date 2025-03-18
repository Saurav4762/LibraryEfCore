using EfCoreDbContext.Contracts.ResponseDto;
using EfCoreDbContext.Data;
using EfCoreDbContext.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EfCoreDbContext.Repository;

public class MemberRepository : IMemberRepository
{
    private readonly EfCoreDbcontext _context;

    public MemberRepository(EfCoreDbcontext context)
    {
        _context = context;
    }

    public async Task<MemberResponseDto> GetMemberById(int id, MemberResponseDto output)
    {

        var member = await _context.Members
            .Where(m => m.Id == id)
            .Select(m => new MemberResponseDto
            {
                Id = m.Id,
                MName = m.MName,
                Email = m.Email,
                BookId = m.BookId,
                BookName = m.Book.Title,
                AuthorId = m.AuthorId,
                AuthorName = m.Author.Name,


            }).FirstOrDefaultAsync();

        if (member == null)
        {
            throw new KeyNotFoundException($"Member with id {id} not found");
        }
        return member;
    }

    public Task<List<MemberResponseDto>> GetMembers(int id )
    {
        var members = _context.Members
            .Select(m=> new MemberResponseDto
            {
                MName = m.MName,
                Email = m.Email,
                BookId = m.BookId,
                BookName = m.Book.Title,
                AuthorId = m.AuthorId,
                AuthorName = m.Author.Name,
            }).ToListAsync();
        
        return members;
    }
}