using PortfolioWebsite.BusinessLayer.Concrete;
using PortfolioWebsite.DataAccessLayer.EntityFramework;
using PortfolioWebsite.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioWebsite.Controllers
{
    public class NewsLetterController : Controller
    {
        NewsLetterManager nm = new NewsLetterManager(new EfNewsLetterRepository());

        [HttpGet]
        public PartialViewResult Index()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SubscribeMail(NewsLetter newsLetter)
        {
            newsLetter.MailStatus = true;
            nm.AddNewsLetter(newsLetter);
            return RedirectToAction("Index", "Blog");
        }

    }
}
