using EfCoreDbContext.Contracts.ResponseDto;

namespace EfCoreDbContext.Repository.Interface;

public interface IMemberRepository
{
    Task<MemberResponseDto> GetMemberById(int id, MemberResponseDto output);
    Task<List<MemberResponseDto>> GetMembers(int id);
    
    
}