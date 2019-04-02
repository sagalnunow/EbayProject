using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SomaliEbayProject.Models;

namespace SomaliEbayProject.Controllers
{
    public class HomeController : Controller
    {
        private SomaliDbContext db;

        public HomeController(SomaliDbContext somaliDb)
        {
            db = somaliDb;
        }
        public IActionResult Index(string search)
        {
            var products = db.Products.ToList();
            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(
                x => x.ProductName.ToLower().Contains(search.ToLower()) ||
                x.ProductDescription.ToLower().Contains(search.ToLower()) ||
                x.Price.ToString().ToLower().Contains(search.ToLower())).ToList();
            }
            return View(products);
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
