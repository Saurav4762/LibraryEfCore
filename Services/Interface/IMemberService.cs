using EfCoreDbContext.Contracts.RequestDto;
using EfCoreDbContext.Entities;

namespace EfCoreDbContext.Services.Interface;

public interface IMemberService
{
    Task<Member> CreateMember(MemberRequestDto dto);
    Task<Member> UpdateMember(int id, MemberRequestDto dto);
    Task DeleteMember(int id);
    
}