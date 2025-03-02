namespace EfCoreDbContext.Contracts.ResponseDto;

public class MemberResponseDto
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public string BookName { get; set; }
    public int MemberId { get; set; }
    public string MemberName { get; set; }
    
}