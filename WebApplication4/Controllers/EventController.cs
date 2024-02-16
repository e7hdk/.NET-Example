using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using MongoDB.Bson;

namespace WebApplication4.Controllers;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
using Z.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MongoDB.Driver;
public class EventController: Controller
{

    private readonly ApplicationDbContext dbContext;
    
    public EventController(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    [HttpGet]
    public IActionResult AddPerson()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddPerson(AddPersonViewModel viewModel)
    {
        var person = new Person
        {
            FirstName = viewModel.FirstName,
            LastName = viewModel.LastName,
            Email = viewModel.Email,
            IsAttending = viewModel.IsAttending,

        };
        await dbContext.People.AddAsync(person);
        await dbContext.SaveChangesAsync();
        
        dbContext.SaveChanges();
        
        return View();
    }

    [HttpGet]
    public IActionResult AddEvent()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddEvent(AddEventViewModel viewModel)
    {
        var eventToSave = new Event
        {
            Title = viewModel.Title,
            Date = viewModel.Date,
            Details = viewModel.Details,
            Location = viewModel.Location
        };
        
        await dbContext.Events.AddAsync(eventToSave);
        await dbContext.SaveChangesAsync();

        dbContext.SaveChanges();

        return View();
    }

    [HttpGet]
    public IActionResult ShowEvent(Guid id)
    {
        //var eventId = new ObjectId(id);
        var @event = dbContext.Events.FirstOrDefault(e => e.Id == id);
        
        return View(@event);
    }

    [HttpGet]
    public IActionResult GetAllEvents()
    {
        var events = dbContext.Events.ToList();
        return Json(events);
    }

    [HttpGet]
    public IActionResult GetParticipants(Guid eventId)
    {
        Console.WriteLine(eventId);
        var participants = dbContext.People.Where(p => p.EventId == eventId);
        Console.WriteLine(participants.Count());
        return Json(participants);
    }

    [HttpPost]
    public IActionResult AddPersonToEvent(Guid eventId, string firstName, string lastName,
        bool isAttending, string email)
    {
        
        var person = new Person
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            IsAttending = isAttending,

        };
        
        var @event = dbContext.Events.FirstOrDefault(e => e.Id == eventId);
        
        dbContext.People.Add(person);
        @event.People.Add(person);
        dbContext.SaveChanges();
        return Ok();
    }
}