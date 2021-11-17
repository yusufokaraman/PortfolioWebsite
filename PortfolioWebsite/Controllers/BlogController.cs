using PortfolioWebsite.BusinessLayer.Concrete;
using PortfolioWebsite.BusinessLayer.ValidationRules.FluentValidation;
using PortfolioWebsite.DataAccessLayer.EntityFramework;
using PortfolioWebsite.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;

namespace PortfolioWebsite.Controllers
{
   [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            var result = bm.GetBlogsListWithCategory();
            return View(result);
        }

        public void GetCategoryList()
        {
            List<SelectListItem> categoryValues = (from x in cm.TGetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            ViewBag.CommentId = id;
            var result = bm.GetBlogByID(id);
            return View(result);
        }

        public IActionResult GetBlogListByWriter()
        {
            var result =  bm.GetBlogsListWithWriter(20);
            return View(result);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {

            List<SelectListItem> categoryValues = (from x in cm.TGetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;

            return View();
        }

       

        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(blog);
            if (results.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate= DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterId = 20;
                bm.TAdd(blog);
                return RedirectToAction("GetBlogListByWriter", "Blog");    
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            List<SelectListItem> categoryValues = (from x in cm.TGetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View();
        }

      
        public IActionResult BlogDelete(int id)
        {
            var value =  bm.TGetById(id);
            bm.TDelete(value);
            return RedirectToAction("GetBlogListByWriter");
        }

        [HttpGet]
        public IActionResult BlogEdit(int id)
        {
            var value = bm.TGetById(id);
            List<SelectListItem> categoryValues = (from x in cm.TGetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View(value);
        }

        [HttpPost]
        public IActionResult BlogEdit(Blog blog)
        {

            blog.BlogStatus = true;
            blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.WriterId = 20;
            bm.TUpdate(blog);

           
            List<SelectListItem> categoryValues = (from x in cm.TGetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;

            return RedirectToAction("GetBlogListByWriter");
        }

        

    }
}
