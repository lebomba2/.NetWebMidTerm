using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;

namespace Northwind.Controllers
{
    public class CustomerController : Controller
    {
        private INorthwindRepository repository;
        public CustomerController(INorthwindRepository repo) => repository = repo;

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Register() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Customer model) {
            if (!ModelState.IsValid) return View();
            if (repository.Customers.Any(c => c.CompanyName == model.CompanyName))
            {
                ModelState.AddModelError("", "Name Must Be Unique");

            }
            else {
                repository.AddCustomer(model);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}