using Gighub.Models;
using Gighub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Gighub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upCommingGigs = _context.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .Where(g => g.DateTime > DateTime.Now && !g.IsCanceled);

            var viewModel = new GigsViewModel
            {
                UpcomingGigs = upCommingGigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcomming Gigs"
            };
            return View("Gigs", viewModel);
        }


        public ActionResult Following()
        {
            var userId = User.Identity.GetUserId();
            var artists = _context.Followings
                .Where(a => a.FollowerId == userId)
                .Select(a => a.Followee).ToList();
            var viewModel = new FollowingViewModel
            {
                Following = artists
            };
            return View(viewModel);
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
           
            return View();
        }
    }

    
}