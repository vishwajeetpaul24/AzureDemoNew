using AzureDemo.Data;
using AzureDemo.Models;
using AzureDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzureDemo.Controllers
{
    public class formDataController : Controller
    {
        private readonly AzureQueueService _queueService;
        private readonly AzureDemoDbContext _dbcontext;
        public formDataController(AzureQueueService queueService,AzureDemoDbContext dbContext)
        {
            _queueService = queueService;
            _dbcontext = dbContext;
        }
        [HttpPost]
        public async Task<IActionResult> SubmitForm(formData data)
        {
            if (ModelState.IsValid)
            {


                data.AzId = Guid.NewGuid();
                   
                
                _dbcontext.formData.Add(data);
                await _dbcontext.SaveChangesAsync();
                await _queueService.SendMessageAsync(data);

                return RedirectToAction("Success");
            }
            return View("Azure_Queue");
        }
        public IActionResult Azure_Queue()
        {
            return View();
        }
        public IActionResult Success()
        {
            return Content("Registration data has been successfully submitted to Azure Queue Storage!");
        }

    }
}
