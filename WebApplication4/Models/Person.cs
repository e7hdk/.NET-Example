namespace WebApplication4.Models;

public class Person
{
    public virtual Guid Id { get; set; }
    public virtual string FirstName { get; set; }
    public virtual string LastName { get; set; }
    public virtual string Email { get; set; }
    public virtual bool IsAttending { get; set; }
    
    public virtual Guid EventId { get; set; }
    
    public Event Event { get; set; } = null!;
    
}