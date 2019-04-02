using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SomaliEbayProject.Models;
using System.IO;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SomaliEbayProject.Controllers
{
    public class ProductsController : Controller
    {
        private SomaliDbContext db;

        public ProductsController(SomaliDbContext somaliDb)
        {
            db = somaliDb;
        }


        public IActionResult Index()
        {
            var products = db.Products.Include(x => x.Orders).ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product, IFormFile productImage)
        {
            if(ModelState.IsValid)
            {
                if(productImage != null)
                {
                    using (var imageBytes = new MemoryStream())
                    {
                        productImage.CopyTo(imageBytes);
                        product.Image = imageBytes.ToArray();
                    }
                }
                db.Products.Add(product);
                    db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var product = db.Products.Find(Id);
            if(product == null)
            {
                return RedirectToAction("Error");
                     
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product, IFormFile productImage)
        {
            if (ModelState.IsValid)
            {
                if (productImage != null)
                {
                    using (var imageBytes = new MemoryStream())
                    {
                        productImage.CopyTo(imageBytes);
                        product.Image = imageBytes.ToArray();
                    }
                }
                db.Products.Update(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            var product = db.Products.Include(x => x.Orders).FirstOrDefault(p => p.Id == Id);
            if (product == null)
            {
                return RedirectToAction("Error");

            }
            return View(product);
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var product = db.Products.Find(Id);
            if (product == null)
            {
                return RedirectToAction("Error");

            }
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
