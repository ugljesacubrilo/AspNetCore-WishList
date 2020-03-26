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
        private readonly ApplicationDbContext _context;

        public ItemController(
            ApplicationDbContext applicationDBContext)
        {
            this._context = applicationDBContext;
        }
        
        public IActionResult Index()
        {
            var model = _context.Items.ToList();
            return View("Index", model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(
            Item item)
        {
            if (ModelState.IsValid &&
                item != null)
            {
                _context.Items.Add(item);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var itemToDelete = _context.Items.FirstOrDefault(i => i.Id == id);

            if (itemToDelete != null)
            {
                _context.Items.Remove(itemToDelete);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
