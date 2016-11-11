using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Rico.NetCore.Web.EFCore.Controllers
{
    public class HomeController : Controller
    {
        private RicoDbContext _context;
        public HomeController(RicoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //_context.Users.Add(new EFCore.User() {  Id=1, UserName="ricolee",Password="abcd"});
            //_context.SaveChanges();
            var user = _context.Users.Where(p => p.Id == int.Parse("1")).FirstOrDefault();
            var result = _context.Users.ToList();

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
