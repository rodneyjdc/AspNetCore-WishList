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

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Index", this._context.Items);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            this._context.Items.Add(item);
            this._context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Item itemToBeDeleted = this._context.Find<Item>(id);
            this._context.Remove(itemToBeDeleted);
            this._context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
