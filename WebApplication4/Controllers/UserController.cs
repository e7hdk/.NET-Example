using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication4.Models;
using System.Linq.Expressions;
using System.Text.Json;


namespace WebApplication4.Controllers;

public class UserController: Controller
{
    private readonly ApplicationDbContext dbContext;
    
    public UserController(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    [HttpGet]
    public IActionResult Main()
    {
        return View();
    }

    [HttpGet]
    public IActionResult AddUser()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> AddUser(AddUserViewModel viewModel)
    {
        if (dbContext.Users.Count(u => u.Id == viewModel.Id) == 0)
        {
            var user = new User
            {
                Email = viewModel.Email,
                Id = viewModel.Id,
                Status = viewModel.Status,
                Name = viewModel.Name,
                Gender = viewModel.Gender

            };
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            
        }
        
        
        dbContext.SaveChanges();
        return View();
    }

    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var users = dbContext.Users.ToList();
        return Json(users);
    }

    

    [HttpGet]
    public IActionResult DeleteUser()
    {
        return View();
    }

    [HttpDelete]
    public IActionResult DeleteUser(int userId)
    {
        Console.WriteLine(userId);
        dbContext.Users.Remove(dbContext.Users.Single(e => e.Id == userId));
        dbContext.SaveChanges();
        return Ok();
    }

    [HttpGet]
    public IActionResult UpdateUser()
    {
        return View();
    }
    

    [HttpPut]
    public IActionResult UpdateUser([FromBody] User updatedUser)
    {
        Console.WriteLine(updatedUser.ToString());
        var existingUser = dbContext.Users.FirstOrDefault(u => u.Id == updatedUser.Id);
        if(existingUser == null)
            Console.WriteLine("User Not Found");
        else
        {
            existingUser.Name = updatedUser.Name;
            existingUser.Email = updatedUser.Email;
            existingUser.Status = updatedUser.Status;
            existingUser.Gender = updatedUser.Gender;
            dbContext.Update(existingUser);
            dbContext.SaveChanges();

        }


        return Ok();
    }
    
    [HttpGet]
    public IActionResult GetUserData()
    {
        return View();
    }
}