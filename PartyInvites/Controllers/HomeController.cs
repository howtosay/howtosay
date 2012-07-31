using System;
using System.Web.Mvc;
using Ninject;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good morning" : "Good afternoon";
            return View();
        }
        
        [HttpGet]
        public ActionResult RspvForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RspvForm(GuestResponse guestResponse)
        {
            //TO DO: Email guestResponse to the part organizer
            return View("Thank", guestResponse);
        }

    }
}
