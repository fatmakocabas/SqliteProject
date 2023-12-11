using Microsoft.AspNetCore.Mvc;
using SqLiteProject.Models;
using System.Diagnostics;

namespace SqLiteProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<UserModel> users = new List<UserModel>();
            using (var db = new SqLiteContext())
            {
                users = db.Users.ToList();

            }
            ViewBag.users = users;
            return View();
        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult AddUsers()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUsers(UserModel user)
        {
            using(var db=new SqLiteContext())
            {
                db.Add(user);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}