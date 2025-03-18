namespace EfCoreDbContext.Entities;

public class Member
{
    
    public int Id { get; set; }
    public string MName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    
    public int BookId { get; set; }
    public virtual Book Book { get; set; }
    
    public int AuthorId { get; set; }
    public virtual Author Author { get; set; }
}