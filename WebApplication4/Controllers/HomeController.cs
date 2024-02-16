using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
namespace WebApplication4.Controllers;
using WebApplication4.Models;
using WebApplication4.Controllers;
using Dapper;
using MongoDB.Driver;

using Microsoft.EntityFrameworkCore;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext dbContext;
    
    public HomeController(ApplicationDbContext dbContext, ILogger<HomeController> logger)
    {
        this.dbContext = dbContext;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var events = dbContext.Events.ToList();
        
        return View(events);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    

    
}