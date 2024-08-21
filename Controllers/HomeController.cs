using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Vividly.Models;

namespace Vividly.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IEmailSender _emailSender;
           
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IEmailSender emailSender)
        {
            _logger = logger;
            _configuration = configuration;
            _emailSender = emailSender;
        }

        public async Task<IActionResult> Index()
        {
            var receiver = "cilarok201@quamox.com";
            var subject = "Test";
            var message = "Hello World";

            await _emailSender.SendEmailAsync(receiver, subject, message);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}