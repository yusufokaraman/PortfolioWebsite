using PortfolioWebsite.BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using PortfolioWebsite.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;

namespace CoreDemo.ViewComponents.Blog
{
    public class BlogListDashboard : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IViewComponentResult Invoke()
        {
            var values = bm.GetBlogsListWithCategory();
            return View(values);
        }
    }
}
