using ASPNET_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace ASPNET_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public List<User> Users;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            Users = Enumerable.Range(1, 1000).Select(user => new User()
            {
                Id = user,
                Name = "张三" + user,
                Age = user + 10
            }).ToList();
        }

        public IActionResult Index(int page = 1)
        {
            var result=Users.ToPagedList(page, 10);
            return View(result);
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
