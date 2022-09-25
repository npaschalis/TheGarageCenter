using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGarageCenter.Models;
using TheGarageCenter.ViewModels;

namespace TheGarageCenter.Controllers
{
    public class BrandsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BrandsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index(int id)
        {
            var brand = _context.Brands.FirstOrDefault(b => b.Id == id);
            if (brand == null)
            {
                return HttpNotFound();
            }

            var dealers = _context.Dealers.Where(d => d.BrandId == id && d.isSubscribed == true);

            var viewModel = new BrandViewModel()
            {
                Brand = brand,
                Dealers = dealers
            };

            return View(viewModel);
        }
    }
}