using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext applicationDBContext;

        public ItemController(
            ApplicationDbContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }
        
        public IActionResult Index()
        {
            return View(applicationDBContext.Items.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(
            Item item)
        {
            if (ModelState.IsValid &&
                item != null)
            {
                applicationDBContext.Items.Add(item);
                applicationDBContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var itemToDelete = applicationDBContext.Items.FirstOrDefault(i => i.Id == id);

            if (itemToDelete != null)
            {
                applicationDBContext.Items.Remove(itemToDelete);
                applicationDBContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
