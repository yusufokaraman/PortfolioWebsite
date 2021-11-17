using PortfolioWebsite.BusinessLayer.Concrete;
using PortfolioWebsite.DataAccessLayer.Concrete;
using PortfolioWebsite.DataAccessLayer.EntityFramework;
using PortfolioWebsite.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PortfolioWebsite.Controllers
{
   
    public class LoginController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(Writer writer)
        {
            Context c = new Context();
            var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
            if (datavalue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,writer.WriterMail)
                };
                var useridentity = new ClaimsIdentity(claims, "key");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Writer");
            }
            else
            {
                return View();
            }
        }
    }
}

//Context c = new Context();
//var datavalue = c.Writers.FirstOrDefault(x => x.Mail == writer.Mail && x.Password == writer.Password);
//if (datavalue != null)
//{
//    HttpContext.Session.SetString("username", writer.Mail);
//    return RedirectToAction("Index", "Writer");
//}
//else
//{
//    return View();
//}
