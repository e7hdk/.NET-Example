namespace WebApplication4.Models;

public class AddEventViewModel
{
    public virtual Guid Id { get; set; }
    
    public virtual string Title { get; set; }
    
    public virtual DateTime Date { get; set; }
    
    public virtual string Location { get; set; }
    
    public virtual string Details { get; set; }
    
    public virtual List<Person> People { get; set; }
}