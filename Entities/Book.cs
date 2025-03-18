namespace EfCoreDbContext.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime PublishDate { get; set; }
    
    public int  AuthorId { get; set; }
    public virtual Author Author { get; set; }
}