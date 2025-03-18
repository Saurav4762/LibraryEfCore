using EfCoreDbContext.Contracts.RequestDto;
using EfCoreDbContext.Data;
using EfCoreDbContext.Entities;
using EfCoreDbContext.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace EfCoreDbContext.Services;

public class MemberService : IMemberService
{
    private readonly EfCoreDbcontext _context;

    public MemberService(EfCoreDbcontext context)
    {
        _context = context;
    }


    public async Task<Member> CreateMember(MemberRequestDto dto)
    {
        bool memberExists = await _context.Members.AnyAsync(m => m.MName == dto.Name);
        if (memberExists)
        {
            throw new Exception($"Member with name {dto.Name} already exists");
        }

        var member = new Member()
        {
            MName = dto.Name,
            Email = dto.Email,
            Phone = dto.Phone,
            AuthorId = dto.AuthorId,
            BookId = dto.BookId,
        };

        await _context.Members.AddAsync(member);
        await _context.SaveChangesAsync();

        return member;
    }

    public async Task<Member> UpdateMember(int id, MemberRequestDto dto)
    {

        var member = await _context.Members.FindAsync(id);
        if (member == null)
        {
            throw new Exception($"Member with id {id} not found");
        }

        member.MName = dto.Name;
        member.Email = dto.Email;
        member.Phone = dto.Phone;
        member.AuthorId = dto.AuthorId;
        member.BookId = dto.BookId;

        _context.Members.Update(member);
        await _context.SaveChangesAsync();
        return member;
    }

    public async Task DeleteMember(int id)
    {
        var member = await _context.Members.FindAsync(id);
        if (member == null)
        {
            throw new Exception($"Member with id {id} not found");
        }

        _context.Members.Remove(member);
        await _context.SaveChangesAsync();
    }
}