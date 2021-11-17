using PortfolioWebsite.BusinessLayer.Concrete;
using PortfolioWebsite.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebsite.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutRepository());
        public IActionResult Index()
        {
           var result = aboutManager.TGetAll();
            return View(result);
        }

        public PartialViewResult SocialMediaAbout()
        {
            return PartialView();
        }

    }
}
