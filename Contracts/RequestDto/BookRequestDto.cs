namespace EfCoreDbContext.Contracts.RequestDto;

public class BookRequestDto
{
    
    public string Title { get; set; }
    public DateTime PublishDate { get; set; }
    
    public int  AuthorId { get; set; }
}