namespace EfCoreDbContext.Contracts.ResponseDto;

public class BookResponseDto
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public string Title { get; set; }
    public DateTime PublishDate { get; set; }
    public int AuthorId { get; set; }
    
    public string AuthorName { get; set; }
}