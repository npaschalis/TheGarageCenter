using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using TheGarageCenter.Areas.Dealers.ViewModels;
using TheGarageCenter.Models;

namespace TheGarageCenter.Areas.Dealers.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfileController()
        {
            _context = new ApplicationDbContext();
        }


        [Authorize(Roles = "Dealer")]
        public ActionResult Create()
        {
            var viewModel = new DealerProfileViewModel()
            {
                Brands = _context.Brands.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DealerProfileViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Brands = _context.Brands.ToList();
                return View("Create", viewModel);
            }
                

            var dealer = new Dealer()
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Address = viewModel.Address,
                BrandId = viewModel.Brand,
                ApplicationUserId = User.Identity.GetUserId()
            };

            _context.Dealers.Add(dealer);
            _context.SaveChanges();
            TempData["success"] = "Profile created succesfully";

            return RedirectToAction("Edit", "Schedule");
        }


        [Authorize(Roles = "Dealer")]
        public ActionResult Edit()
        {
            var viewModel = new DealerProfileViewModel() 
            {
                Brands = _context.Brands.ToList()
            };

            var userId = User.Identity.GetUserId();
            var existingDealer = _context.Dealers.FirstOrDefault(d => d.ApplicationUserId == userId);
            if (existingDealer == null)
                return RedirectToAction("Create", "Profile");

            viewModel.Name = existingDealer.Name;
            viewModel.Description = existingDealer.Description;
            viewModel.Address = existingDealer.Address;
            viewModel.Brand = existingDealer.BrandId;

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApplicationUserId, Name, Description, Address")] DealerProfileViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();
            var existingDealer = _context.Dealers.FirstOrDefault(d => d.ApplicationUserId == userId);
            if (!ModelState.IsValid)
            {
                viewModel.Brands = _context.Brands.ToList();
                viewModel.Brand = existingDealer.BrandId;
                return View("Edit", viewModel);
            }
            
            var dealer = new Dealer()
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Address = viewModel.Address,
                BrandId = viewModel.Brand,
                ApplicationUserId = User.Identity.GetUserId()
            };

            
            
            existingDealer.Name = viewModel.Name;
            existingDealer.Description = viewModel.Description;
            existingDealer.Address = viewModel.Address;
            _context.Entry(existingDealer).State = EntityState.Modified;
            _context.SaveChanges();
            TempData["success"] = "Profile edited succesfully";

            return RedirectToAction("Index","Home");
        }
    }
}