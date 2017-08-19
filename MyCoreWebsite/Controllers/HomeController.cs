using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyCoreWebsite.Models;
using Microsoft.Extensions.Options;

namespace MyCoreWebsite.Controllers
{
    public class HomeController : Controller
    {
        public SmtpConfig _smtpConfig { get; set; }

        public HomeController(IOptions<SmtpConfig> smtpConfig)
        {
            _smtpConfig = smtpConfig.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            ViewData["Server"] = _smtpConfig.Server;
            ViewData["Port"] = _smtpConfig.Port;
            ViewData["User"] = _smtpConfig.User;
            ViewData["Pass"] = _smtpConfig.Pass;

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
