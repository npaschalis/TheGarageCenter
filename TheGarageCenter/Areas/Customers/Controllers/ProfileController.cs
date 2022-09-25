using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGarageCenter.Models;

namespace TheGarageCenter.Areas.Customers.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProfileController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize(Roles = "Customer")]
        public ActionResult Create()
        {
            var customer = new Customer();
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {

                return View("Create", customer);
            }

            customer.ApplicationUserId = User.Identity.GetUserId();

            _context.Customers.Add(customer);
            _context.SaveChanges();
            TempData["success"] = "Profile created succesfully";

            return RedirectToAction("Index", "Home");
        }



        [Authorize(Roles = "Customer")]
        public ActionResult Edit()
        {
            var customer = new Customer();
          
            var userId = User.Identity.GetUserId();
            var existingCustomer = _context.Customers.FirstOrDefault(d => d.ApplicationUserId == userId);
            if (existingCustomer == null)
                return RedirectToAction("Create", "Profile");

            return View(existingCustomer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApplicationUserId, FirstName, LastName, PhoneNumber")] Customer customer)
        {
            if (!ModelState.IsValid)
                return View("Edit", customer);

            var userId = User.Identity.GetUserId();
            var existingCustomer = _context.Customers.FirstOrDefault(d => d.ApplicationUserId == userId);

            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.PhoneNumber = customer.PhoneNumber;
            _context.Entry(existingCustomer).State = EntityState.Modified;
            _context.SaveChanges();
            TempData["success"] = "Profile edited succesfully";

            return RedirectToAction("Index", "Home");
        }
    }
}