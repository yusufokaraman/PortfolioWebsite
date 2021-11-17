﻿using PortfolioWebsite.BusinessLayer.Concrete;
using PortfolioWebsite.BusinessLayer.ValidationRules.FluentValidation;
using PortfolioWebsite.DataAccessLayer.EntityFramework;
using PortfolioWebsite.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebsite.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
            
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            ContactValidator cv = new ContactValidator();
            ValidationResult result = cv.Validate(contact);

            if (result.IsValid)
            {
                contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                contact.ContactStatus = true;
                cm.ContactAdd(contact);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
         

        }
    }
}
