using AzureDemo.Data;
using AzureDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzureDemo.Controllers
{
    public class UserController : Controller
    {
        private readonly AzureDemoDbContext _dbcontext;

        public UserController(AzureDemoDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Users user)
        {
            if (ModelState.IsValid)
            {
               
                user.Id = new Guid();
                _dbcontext.Users.Add(user);
                await _dbcontext.SaveChangesAsync();
                TempData["SuccessMessage"] = "Data saved successfully!";
                return RedirectToAction("Register");
            }
            return View(user);
        }
        public IActionResult Success()
        {
            return View();
        }


    }
}
