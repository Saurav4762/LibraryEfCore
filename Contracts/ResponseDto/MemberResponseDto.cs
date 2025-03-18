namespace EfCoreDbContext.Contracts.ResponseDto;

public class MemberResponseDto
{
    public int Id { get; set; }
    
    public string MName { get; set; }
    
    public string Email { get; set; }
    public int BookId { get; set; }
    public string BookName { get; set; }
    
   public int AuthorId { get; set; }
   public string AuthorName { get; set; }
    
}