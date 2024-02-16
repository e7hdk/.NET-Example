namespace WebApplication4.Models;

public class User
{
    public int Id { get; set; }
    
    public virtual string Name { get; set; }
    
    public virtual string Email { get; set; }
    
    public virtual string Gender { get; set; }
    
    public virtual string Status { get; set; }
    
    
    
}