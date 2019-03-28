using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;

namespace Northwind.Controllers
{
    public class ProductController : Controller
    {
        // this controller depends on the NorthwindRepository
        private INorthwindRepository repository;
        public ProductController(INorthwindRepository repo) => repository = repo;

        // pass the Categories table to view, ordered by CategoryName
        public IActionResult Category() => View(repository.Categories.OrderBy(c => c.CategoryName));
        // pass the Products table to view, where CategoryId is equal to the id passed in, and the product is not discounted
        public IActionResult CategoryDetail(int id) => View(repository.Products.Where(p => p.CategoryId == id && p.Discontinued == false).OrderBy(p => p.ProductName));
        // pass the discounts table to view, where the time of the discount is valid
        public IActionResult Discounts() => View(repository.Discounts.Where(d => d.StartTime <= DateTime.Now && d.EndTime > DateTime.Now));
    }
}
