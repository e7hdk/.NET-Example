namespace WebApplication4.Models;

using System;
using System.Collections.Generic;

public class Event
{
    public virtual Guid Id { get; set; }
    public virtual string Title { get; set; }
    public virtual DateTime Date { get; set; }
    public virtual string Location { get; set; }
    public virtual string Details { get; set; }
    public virtual ICollection<Person> People { get; } = new List<Person>();
}