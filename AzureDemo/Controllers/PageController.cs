using AzureDemo.Models;
using AzureDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace AzureDemo.Controllers
{
    public class PageController : Controller
    {
        private readonly AzureQueueService _queueService;
        public PageController(AzureQueueService queueService)
        {
            _queueService = queueService;
        }
        [HttpPost]
        public async Task<IActionResult> SubmitForm(formData data)
        {
            if (ModelState.IsValid)
            {
                var formData = new
                {
                    Name = data.Name,
                    Email = data.Email,
                    Message = data.Message
                };

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
