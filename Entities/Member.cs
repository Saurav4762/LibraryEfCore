namespace EfCoreDbContext.Entities;

public class Member
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    
    public int BookId { get; set; }
    public virtual Book Books { get; set; }
    
    public int MemberId { get; set; }
    public virtual Member Members { get; set; }
    
}