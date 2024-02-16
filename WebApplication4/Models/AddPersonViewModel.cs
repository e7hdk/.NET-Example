namespace WebApplication4.Models;

public class AddPersonViewModel
{
    public virtual string FirstName { get; set; }
    public virtual string LastName { get; set; }
    public virtual string Email { get; set; }
    
    public virtual bool IsAttending { get; set; }

}